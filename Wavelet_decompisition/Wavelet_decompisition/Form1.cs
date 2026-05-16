using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Wavelet_decompisition
{
    public partial class Form1 : Form
    {
        OpenFileClass file = new OpenFileClass();
        string originalFilePath;
        int width, height;
        byte[] first1078Bytes;
        double[,] originalImageD;

        WaveletCoder waveletCoder;
        double[,] currentImageD;
        bool doneH1 = false;
        bool doneV1 = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void loadOriginalButton_Click(object sender, EventArgs e)
        {
            file.OpenFile();
            originalFilePath = file.getFilePath();
            if (originalFilePath != null)
            {
                if (file.CheckBMPExtension(originalFilePath))
                {

                    MessageBox.Show("Image loaded");
                    originalImageBox.Image = Image.FromFile(originalFilePath);
                    first1078Bytes = GetFirst1078Bytes(originalFilePath);
                    Console.WriteLine(first1078Bytes.Length);

                    Bitmap originalImage = new Bitmap(originalFilePath);
                    width = originalImage.Width;
                    height = originalImage.Height;
                    originalImageD = new double[width, height];
                    ConvertImageToDouble(originalImage);
                    waveletCoder = new WaveletCoder(originalImageD, width, height);
                }
                else
                {
                    originalFilePath = null;
                    MessageBox.Show("You must choose a file with the .bmp extension");
                }
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

        private void ConvertImageToDouble(Bitmap originalImage)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    originalImageD[x, y] = (int)originalImage.GetPixel(x, y).R;
                }
            }
        }

        private void saveEncodedButton_Click(object sender, EventArgs e)
        {

        }

        private void loadEncodedButton_Click(object sender, EventArgs e)
        {

        }

        private void refreshWaveletButton_Click(object sender, EventArgs e)
        {
            if(currentImageD != null)
            {
                if (doneV1)
                {
                    Bitmap waveletImage = CreateBitmapForWaveletHV(currentImageD, width, height, (double)scaleValue.Value);
                    waveletPictureBox.Image = waveletImage;
                }
                else
                {
                    Bitmap waveletImage = CreateBitmapForWaveletH1(currentImageD, width, height, (double)scaleValue.Value);
                    waveletPictureBox.Image = waveletImage;
                }
            }
            else
            {
                MessageBox.Show("Please analyse a picture first");
            }
        }

        private void analysisH1Button_Click(object sender, EventArgs e)
        {
            if (waveletCoder != null)
            {
                if (!doneH1)
                {
                    waveletCoder.AnalysisH1();
                    currentImageD = waveletCoder.GetCurrentImageD();
                    Bitmap waveletImage = CreateBitmapForWaveletH1(currentImageD, width, height, (double)scaleValue.Value);
                    waveletPictureBox.Image = waveletImage;
                    doneH1 = true;
                }
                else
                {
                    MessageBox.Show("You already did the horizontal analysis");
                }
            }
            else
            {
                MessageBox.Show("Please load an image first");
            }
        }

        private void analysisV1Button_Click(object sender, EventArgs e)
        {
            if (currentImageD != null)
            {
                if (!doneV1)
                {
                    waveletCoder.AnalysisV1();
                    currentImageD = waveletCoder.GetCurrentImageD();
                    Bitmap waveletImage = CreateBitmapForWaveletHV(currentImageD, width, height, (double)scaleValue.Value);
                    waveletPictureBox.Image = waveletImage;
                    doneV1 = true;
                }
                else
                {
                    MessageBox.Show("You already did the vertical analysis");
                }
            }
            else
            {
                MessageBox.Show("Please use the horizontal analysis first");
            }
        }

        private void synthesisH1Button_Click(object sender, EventArgs e)
        {

        }

        private void synthesisV1Button_Click(object sender, EventArgs e)
        {

        }

        private void analysisButton_Click(object sender, EventArgs e)
        {

        }

        private void synthesisButton_Click(object sender, EventArgs e)
        {

        }

        public Bitmap CreateBitmapForWaveletH1(double[,] currentImage, int width, int height, double scaleV)
        {
            Bitmap bitmap = new Bitmap(width, height);

            double scale = scaleV;
            double offset = 128.0;

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    double value = currentImage[i, j];
                    int valuePixel;

                    if (i < width / 2)
                    {
                        valuePixel = (int)Math.Round(value);
                    }
                    else
                    {
                        valuePixel = (int)(Math.Round(value) * scale + offset);
                    }

                    if (valuePixel > 255) 
                        valuePixel = 255;
                    if (valuePixel < 0) 
                        valuePixel = 0;

                    Color pixelColor = Color.FromArgb(valuePixel, valuePixel, valuePixel);
                    bitmap.SetPixel(i, j, pixelColor);
                }
            }

            return bitmap;
        }

        public Bitmap CreateBitmapForWaveletHV(double[,] currentImage, int width, int height, double scaleV)
        {
            Bitmap bitmap = new Bitmap(width, height);

            double scale = scaleV;
            double offset = 128.0;

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    double value = currentImage[i, j];
                    int valuePixel;

                    if (i < width / 2 && j < height / 2)
                    {
                        valuePixel = (int)Math.Round(value);
                    }
                    else
                    {
                        valuePixel = (int)(Math.Round(value) * scale + offset);
                    }

                    if (valuePixel > 255)
                        valuePixel = 255;
                    if (valuePixel < 0)
                        valuePixel = 0;

                    Color pixelColor = Color.FromArgb(valuePixel, valuePixel, valuePixel);
                    bitmap.SetPixel(i, j, pixelColor);
                }
            }

            return bitmap;
        }
    }
}
