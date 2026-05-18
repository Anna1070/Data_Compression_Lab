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
using System.Security.Policy;
using System.Reflection.Emit;

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
        bool doneH2  = false;
        bool doneV2 = false;
        bool levelsAnalysis = false;

        string waveletFilePath;

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

        private void refreshWaveletButton_Click(object sender, EventArgs e)
        {
            if(currentImageD != null)
            {
                if (!levelsAnalysis)
                {
                    Bitmap waveletImage = CreateBitmapForWavelet(currentImageD, width, height, (double)scaleValue.Value);
                    waveletPictureBox.Image = waveletImage;
                }
                else
                {
                    Bitmap waveletImage = CreateBitmapForWaveletLevels(currentImageD, width, height, (double)scaleValue.Value, (int)levelValue.Value);
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
                if (!doneH1 && !levelsAnalysis)
                {
                    waveletCoder.AnalysisH1();
                    currentImageD = waveletCoder.GetCurrentImageD();
                    doneH1 = true;
                    xValue.Value = width / 2;
                    yValue.Value = height;

                    Bitmap waveletImage = CreateBitmapForWavelet(currentImageD, width, height, (double)scaleValue.Value);
                    waveletPictureBox.Image = waveletImage;
                }
                else
                {
                    MessageBox.Show("You already did the H1 analysis");
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
                if (!doneV1 && !levelsAnalysis)
                {
                    waveletCoder.AnalysisV1();
                    currentImageD = waveletCoder.GetCurrentImageD();
                    doneV1 = true;
                    xValue.Value = width / 2;
                    yValue.Value = height / 2;

                    Bitmap waveletImage = CreateBitmapForWavelet(currentImageD, width, height, (double)scaleValue.Value);
                    waveletPictureBox.Image = waveletImage;
                }
                else
                {
                    MessageBox.Show("You already did the V1 analysis");
                }
            }
            else
            {
                MessageBox.Show("Please use the H1 analysis first");
            }
        }

        private void analysisH2Button_Click(object sender, EventArgs e)
        {
            if (currentImageD != null)
            {
                if (!doneH2 && !levelsAnalysis)
                {
                    waveletCoder.AnalysisH2();
                    currentImageD = waveletCoder.GetCurrentImageD();
                    doneH2 = true;
                    xValue.Value = width / 4;
                    yValue.Value = height / 2;

                    Bitmap waveletImage = CreateBitmapForWavelet(currentImageD, width, height, (double)scaleValue.Value);
                    waveletPictureBox.Image = waveletImage;
                }
                else
                {
                    MessageBox.Show("You already did the H2 analysis");
                }
                
            }
            else
            {
                MessageBox.Show("Please execute the H1 and V1 analysis first");
            }
        }

        private void analysisV2Button_Click(object sender, EventArgs e)
        {
            if (currentImageD != null && doneH2)
            {
                if (!doneV2 && !levelsAnalysis)
                {
                    waveletCoder.AnalysisV2();
                    currentImageD = waveletCoder.GetCurrentImageD();
                    doneV2 = true;
                    xValue.Value = width / 4;
                    yValue.Value = height / 4;

                    Bitmap waveletImage = CreateBitmapForWavelet(currentImageD, width, height, (double)scaleValue.Value);
                    waveletPictureBox.Image = waveletImage;
                }
                else
                {
                    MessageBox.Show("You already did the V2 analysis");
                }
            }
            else
            {
                MessageBox.Show("Please use the H2 analysis first");
            }
        }

        private void analysisButton_Click(object sender, EventArgs e)
        {
            if(originalImageD != null)
            {
                if(levelValue.Value != 0)
                {
                    waveletCoder = new WaveletCoder(originalImageD, width, height);
                    waveletCoder.AnalyzeToALevel((int)levelValue.Value);
                    levelsAnalysis = true;
                    xValue.Value = width / (int)Math.Pow(2, (int)levelValue.Value);
                    yValue.Value = height / (int)Math.Pow(2, (int)levelValue.Value);

                    currentImageD = waveletCoder.GetCurrentImageD();
                    Bitmap waveletImage = CreateBitmapForWaveletLevels(currentImageD, width, height, (double)scaleValue.Value, (int)levelValue.Value);
                    waveletPictureBox.Image = waveletImage;
                }
                else
                {
                    MessageBox.Show("Please choose a level between 0 and 5");
                }
            }
            else
            {
                MessageBox.Show("Please load an image first");
            }
        }

        private void synthesisH1Button_Click(object sender, EventArgs e)
        {

        }

        private void synthesisV1Button_Click(object sender, EventArgs e)
        {

        }

        private void synthesisH2Button_Click(object sender, EventArgs e)
        {

        }

        private void synthesisV2Button_Click(object sender, EventArgs e)
        {

        }

        private void synthesisButton_Click(object sender, EventArgs e)
        {

        }

        private void saveEncodedButton_Click(object sender, EventArgs e)
        {
            if (originalFilePath != null)
            {
                if (currentImageD == null)
                {
                    MessageBox.Show("Please analyze an image first");
                }
                else
                {
                    string encodedFilePath = Path.GetFullPath(originalFilePath).ToLower() + ".wvt";
                    StoreWavelet storeWavelet = new StoreWavelet(currentImageD, encodedFilePath, width, height, (int)levelValue.Value);
                    storeWavelet.StartStoring();
                }
            }
            else
            {
                MessageBox.Show("Please load an original image first");
            }
        }

        private void loadEncodedButton_Click(object sender, EventArgs e)
        {
            file.OpenFile();
            waveletFilePath = file.getFilePath();
            if (waveletFilePath != null)
            {
                if (file.CheckEncodedExtension(waveletFilePath))
                {
                    LoadWavelet loadWavelet = new LoadWavelet(waveletFilePath);
                    loadWavelet.StartReading();
                    currentImageD = loadWavelet.GetReadWavelet();
                    width = loadWavelet.GetWidth();
                    height = loadWavelet.GetHeight();
                    int level = loadWavelet.GetLevel();
                    levelValue.Value = level;
                    xValue.Value = width / (int)Math.Pow(2, level);
                    yValue.Value = height / (int)Math.Pow(2, level);
                    levelsAnalysis = true;

                    waveletCoder = new WaveletCoder(currentImageD, width, height);
                    waveletPictureBox.Image = CreateBitmapForWaveletLevels(currentImageD, width, height, (double)scaleValue.Value, level);
                }
                else
                {
                    waveletFilePath = null;
                    MessageBox.Show("Please choose a file with the .wvl extension");
                }
            }
        }

        public Bitmap CreateBitmapForWavelet(double[,] currentImage, int width, int height, double scaleV)
        {
            Bitmap bitmap = new Bitmap(width, height);

            double scale = scaleV;
            double offset = 128.0;

            int halfW = width / 2;
            int halfH = height / 2;

            int quarterW = width / 4;
            int quarterH = height / 4;

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    double value = currentImage[i, j];
                    int valuePixel = 0;

                    if ( doneH1 && !doneV1)
                    {
                        if (i < halfW)
                        {
                            valuePixel = (int)Math.Round(value);
                        }
                        else
                        {
                            valuePixel = (int)(Math.Round(value) * scale + offset);
                        }
                    }
                    else if (doneH2 && !doneV2)
                    {
                        if (i < quarterW && j < halfH)
                        {
                            valuePixel = (int)Math.Round(value);
                        }
                        else
                        {
                            valuePixel = (int)Math.Round((value * scale) + offset);
                        }
                    }
                    else if (doneH2 && doneV2)
                    {
                        if (i < quarterW && j < quarterH)
                        {
                            valuePixel = (int)Math.Round(value);
                        }
                        else
                        {
                            valuePixel = (int)Math.Round((value * scale) + offset);
                        }
                    }
                    else if (doneH1 && doneV1)
                    {
                        if (i < halfW && j < halfH)
                        {
                            valuePixel = (int)Math.Round(value);
                        }
                        else
                        {
                            valuePixel = (int)Math.Round((value * scale) + offset);
                        }
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

        public Bitmap CreateBitmapForWaveletLevels(double[,] currentImage, int width, int height, double scale, int level)
        {
            Bitmap bitmap = new Bitmap(width, height);
            double offset = 128.0;

            int finalW = width / (int)Math.Pow(2, level);
            int finalH = height / (int)Math.Pow(2, level);

            for (int j=0; j<height; j++)
            {
                for (int i=0; i<width; i++)
                {
                    double value = currentImage[i, j];
                    int valuePixel = 0;

                    if (i < finalW && j < finalH)
                    {
                        valuePixel = (int)Math.Round(value);
                    }
                    else
                    {
                        valuePixel = (int)Math.Round((value * scale) + offset);
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
