using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Fractal_image_coder
{
    public partial class Form1: Form
    {

        OpenFileClass file = new OpenFileClass();
        string originalFilePath;
        int width, height;
        int[,] originalImageInt;
        byte[] first1078Bytes;

        List<RangeParameters> rangeParameters = new List<RangeParameters>();

        int selectedRangeX = -1, selectedRangeY = -1;
        int selectedDomainX = -1, selectedDomainY = -1;

        string initialFilePath;
        string encodedFilePath;
        byte[] first1078BytesEncoded;
        int[,] currentDecoderStep;
        int[,] originalInt;

        public Form1()
        {
            InitializeComponent();
        }

        private void loadOrigImgButton_Click(object sender, EventArgs e)
        {
            file.OpenFile();
            originalFilePath = file.getFilePath();
            if (originalFilePath != null)
            {
                if (file.CheckBMPExtension(originalFilePath))
                {

                    MessageBox.Show("Image loaded");
                    originalImageBox.Image = Image.FromFile(originalFilePath);
                }
                else
                {
                    originalFilePath = null;
                    MessageBox.Show("You must choose a file with the .bmp extension");
                }
            }
        }

        private async void processButton_Click(object sender, EventArgs e)
        {
            if (originalFilePath != null)
            { 
                Bitmap originalImage = new Bitmap(originalFilePath);
                width = originalImage.Width;
                height = originalImage.Height;

                first1078Bytes = GetFirst1078Bytes(originalFilePath);
                Console.WriteLine(first1078Bytes.Length);

                progressBar.Value = 0;
                var progress = new Progress<int>(v =>
                {
                    progressBar.Value = v;
                });

                FractalCoder fractalCoder = new FractalCoder(originalImage, width, height);
                processButton.Enabled = false;
                await fractalCoder.StartCoding(progress);
                rangeParameters = fractalCoder.GetRangeParameters();
                originalImageInt = fractalCoder.GetConvertedImage();

                processButton.Enabled = true;
            }
        }
        public byte[] GetFirst1078Bytes(string filePath)
        {
            byte[] first1078Bytes = new byte[1078];
            byte[] allBytes = File.ReadAllBytes(filePath);
            for (int i = 0; i < 1078; i++)
            {
                first1078Bytes[i] = allBytes[i];
            }
            return first1078Bytes;
        }

        private void saveProcessedButton_Click(object sender, EventArgs e)
        {
            if(originalFilePath != null)
            {
                if (rangeParameters == null || rangeParameters.Count == 0)
                {
                    MessageBox.Show("Please process an image first");
                }
                else
                {
                    string encodedFilePath = Path.GetFullPath(originalFilePath).ToLower() + ".fc";
                    StoreEncoded storeEncoded = new StoreEncoded(encodedFilePath, first1078Bytes, rangeParameters);
                    storeEncoded.StartStoring();
                }
            }
        }

        private void originalImageBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (rangeParameters == null || rangeParameters.Count == 0)
            {
                MessageBox.Show("Please process an image first");
            }
            else
            {
                int realX = e.X * width / originalImageBox.Width;
                int realY = e.Y * height / originalImageBox.Height;

                int rangeX = (realX / 8) * 8;
                int rangeY = (realY / 8) * 8;
                RangeParameters rP = null;

                foreach (var range in rangeParameters)
                {
                    if (range.rx == rangeX && range.ry == rangeY)
                    {
                        rP = range;
                        break;
                    }
                }

                if (rP != null)
                {
                    selectedRangeX = rP.rx;
                    selectedRangeY = rP.ry;
                    selectedDomainX = rP.dx;
                    selectedDomainY = rP.dy;

                    ShowDetails(rP);

                    originalImageBox.Invalidate();
                }
            }
        }

        private void originalImageBox_Paint(object sender, PaintEventArgs e)
        {
            if (selectedRangeX == -1) return;

            using (Pen penRange = new Pen(Color.Aquamarine, 2))
            {
                e.Graphics.DrawRectangle(penRange, selectedRangeX,
                                                    selectedRangeY,
                                                    8,
                                                    8);
            }
            using (Pen penDomain = new Pen(Color.DeepSkyBlue, 2))
            {
                e.Graphics.DrawRectangle(penDomain, selectedDomainX,
                                                   selectedDomainY,
                                                   16,
                                                   16);
            }
        }  

        private void ShowDetails(RangeParameters rP)
        {
            Bitmap bmpRange = new Bitmap(8,8);
            for (int j=0; j<8; j++)
            {
                for (int i=0; i<8; i++)
                {
                    int val = originalImageInt[rP.rx + i, rP.ry + j];
                    bmpRange.SetPixel(i, j, Color.FromArgb(val, val, val));
                }
            }

            rangePictureBox.Image = RescaleImage(bmpRange,10);

            Bitmap bmpDomain = new Bitmap(16, 16);
            for (int j = 0; j < 16; j++)
            {
                for (int i = 0; i < 16; i++)
                {
                    int val = originalImageInt[rP.dx + i, rP.dy + j];
                    bmpDomain.SetPixel(i, j, Color.FromArgb(val,val,val));
                }
            }

            domainPictureBox.Image = RescaleImage(bmpDomain, 10);

            parametersRangeTextBox.Text = $"Range: ({rP.rx}, {rP.ry})\r\n" +
                                          $"Domain: ({rP.dx}, {rP.dy})\r\n" +
                                          $"Izometry: {rP.izo}\r\n" +
                                          $"sQ: {rP.sQ}\r\n" +
                                          $"oQ: {rP.oQ}";
        }

        private Bitmap RescaleImage(Bitmap source, int scale)
        {
            Bitmap rescaled = new Bitmap(source.Width * scale, source.Height * scale);
            using (Graphics g = Graphics.FromImage(rescaled))
            {
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                g.DrawImage(source, 0, 0, rescaled.Width, rescaled.Height);
            }
            return rescaled;
        }

        private void loadInitialImgButton_Click(object sender, EventArgs e)
        {
            file.OpenFile();
            initialFilePath = file.getFilePath();
            if (initialFilePath != null)
            {
                if (file.CheckBMPExtension(initialFilePath))
                {

                    MessageBox.Show("Initial image loaded");
                    decodedImgBox.Image = Image.FromFile(initialFilePath);
                }
                else
                {
                    initialFilePath = null;
                    MessageBox.Show("You must choose a file with the .bmp extension");
                }
            }
        }

        private void loadProcessedImgButton_Click(object sender, EventArgs e)
        {
            file.OpenFile();
            encodedFilePath = file.getFilePath();
            if (encodedFilePath != null)
            {
                if (file.CheckEncodedExtension(encodedFilePath))
                {

                    MessageBox.Show("Encoded file loaded");
                }
                else
                {
                    encodedFilePath = null;
                    MessageBox.Show("Please choose a file with the .fc extension");
                }
            }
        }

        private void decodeButton_Click(object sender, EventArgs e)
        {
            if (encodedFilePath == null)
            {
                MessageBox.Show("Please load an encoded file first");
            }
            else if(numberStepsDecode.Value != 0)
            {
                Bitmap initialImage = new Bitmap(initialFilePath);
                int widthInitial = initialImage.Width;
                int heightInitial = initialImage.Height;

                first1078BytesEncoded = GetFirst1078Bytes(encodedFilePath);
                Console.WriteLine(first1078BytesEncoded.Length);
                FractalDecoder decoder = new FractalDecoder(initialImage, widthInitial, heightInitial, encodedFilePath, (int)numberStepsDecode.Value);
                decoder.StartDecoding();
                currentDecoderStep = decoder.GetCurrentStep();
                decodedImgBox.Image = CreateBitmapForDecodedMatrix(currentDecoderStep, widthInitial, heightInitial);

                if (originalFilePath != null)
                {
                    double psnr = CalculatePSNR(currentDecoderStep, widthInitial, heightInitial);
                    psnrValueTextBox.Text = $"PSNR = {psnr}";
                }
                else
                {
                    MessageBox.Show("Please load an original image first");
                }
            }
            else
            {
                MessageBox.Show("Please input a number of steps");
            }
        }

        public Bitmap CreateBitmapForDecodedMatrix(int[,] decodedMatrix, int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    int val = decodedMatrix[i, j];
                    Color pixelColor = Color.FromArgb(val, val, val);
                    bitmap.SetPixel(i, j, pixelColor);
                }
            }

            return bitmap;
        }

        public double CalculatePSNR(int[,] decoded, int width, int height)
        {
            double sumSquareOD = 0;
            int maxOrig = int.MinValue;
            Bitmap originalImg = new Bitmap(originalFilePath);
            int[,] originalInt = new int[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    originalInt[x, y] = (int)originalImg.GetPixel(x, y).R;
                }
            }

            for (int j = 0; j < height; j++)
            {
                for (int i = 0;i < width; i++)
                {
                    double diff = originalInt[i, j] - decoded[i, j];
                    sumSquareOD = sumSquareOD + diff * diff;

                    if(originalInt[i, j] > maxOrig)
                    {
                        maxOrig = originalInt[i, j];
                    }
                }
            }

            double meanOD = sumSquareOD / (width * height);
            double psnr = 10 * Math.Log10((maxOrig * maxOrig) / meanOD);
            return psnr;
        }

        private void saveDecodedButton_Click(object sender, EventArgs e)
        {
            if (currentDecoderStep != null)
            {
                width = 256; height = 256;
                string decodedFilePath = Path.GetFullPath(encodedFilePath) + ".bmp";
                StoreDecoded storeDecoded = new StoreDecoded(first1078BytesEncoded, decodedFilePath, currentDecoderStep, width, height);
                storeDecoded.StartStoring();
            }
            else
            {
                MessageBox.Show("Please load an encoded file first and decode it");
            }
        }
    }
}
