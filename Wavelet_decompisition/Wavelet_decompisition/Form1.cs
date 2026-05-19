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
using static System.Windows.Forms.AxHost;
using System.Data.SqlClient;

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
        WaveletSynthesis waveletSynthesis;
        bool doneSH1 = false;
        bool doneSV1 = false;
        bool doneSH2 = false;
        bool doneSV2 = false;
        bool levelsSynthesis = false;

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
                    currentImageD = new double[width, height];
                    Array.Copy(originalImageD, currentImageD, currentImageD.Length);
                    waveletCoder = new WaveletCoder(currentImageD, width, height);
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
            if (currentImageD != null)
            {
                waveletCoder = new WaveletCoder(currentImageD, width, height);
                if (!doneH1 && !levelsAnalysis)
                {
                    waveletCoder.AnalysisH1();
                    currentImageD = waveletCoder.GetCurrentImageD();
                    doneH1 = true;
                    xValue.Value = width / 2;
                    yValue.Value = height;
                    doneSH1 = false;

                    Bitmap waveletImage = CreateBitmapForWavelet(currentImageD, width, height, (double)scaleValue.Value);
                    waveletPictureBox.Image = waveletImage;
                }
            }
        }

        private void analysisV1Button_Click(object sender, EventArgs e)
        {
            if (currentImageD != null)
            {
                if (doneH1 && !levelsAnalysis && !doneV1)
                {
                    waveletCoder.AnalysisV1();
                    currentImageD = waveletCoder.GetCurrentImageD();
                    doneV1 = true;
                    xValue.Value = width / 2;
                    yValue.Value = height / 2;
                    doneSV1 = false;

                    Bitmap waveletImage = CreateBitmapForWavelet(currentImageD, width, height, (double)scaleValue.Value);
                    waveletPictureBox.Image = waveletImage;
                }
            }
        }

        private void analysisH2Button_Click(object sender, EventArgs e)
        {
            if (currentImageD != null)
            {
                if (doneV1 && !levelsAnalysis && !doneH2)
                {
                    waveletCoder.AnalysisH2();
                    currentImageD = waveletCoder.GetCurrentImageD();
                    doneH2 = true;
                    xValue.Value = width / 4;
                    yValue.Value = height / 2;
                    doneSH2 = false;

                    Bitmap waveletImage = CreateBitmapForWavelet(currentImageD, width, height, (double)scaleValue.Value);
                    waveletPictureBox.Image = waveletImage;
                }
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
                    doneSV2 = false;

                    Bitmap waveletImage = CreateBitmapForWavelet(currentImageD, width, height, (double)scaleValue.Value);
                    waveletPictureBox.Image = waveletImage;
                }
            }
        }

        private void analysisButton_Click(object sender, EventArgs e)
        {
            if(currentImageD != null)
            {
                if(levelValue.Value != 0)
                {
                    waveletCoder = new WaveletCoder(currentImageD, width, height);
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
            if(currentImageD != null && doneH1 && !doneV1 && !doneH2 && !doneV2 && !doneSH1)
            {
                waveletSynthesis = new WaveletSynthesis(currentImageD, width, height);
                waveletSynthesis.SynthesisH1();
                currentImageD = waveletSynthesis.GetCurrentImageD();
                doneH1 = false;
                levelsAnalysis = false;
                xValue.Value = width;
                yValue.Value = height;
                doneSH1 = true;

                waveletPictureBox.Image = CreateBitmapForReconstructed(currentImageD, width, height, (double)scaleValue.Value);

            }
        }

        private void synthesisV1Button_Click(object sender, EventArgs e)
        {
            if(currentImageD != null && doneV1 && !doneSV1)
            {
                waveletSynthesis = new WaveletSynthesis(currentImageD, width, height);
                waveletSynthesis.SynthesisV1();
                currentImageD = waveletSynthesis.GetCurrentImageD();

                doneV1 = false;
                xValue.Value = width / 2;
                yValue.Value = height;
                doneSV1 = true;

                waveletPictureBox.Image = CreateBitmapForWavelet(currentImageD, width, height, (double)scaleValue.Value);
            }
        }

        private void synthesisH2Button_Click(object sender, EventArgs e)
        {
            if (currentImageD != null && !doneSH2 && doneH2)
            {
                waveletSynthesis = new WaveletSynthesis(currentImageD, width, height);
                waveletSynthesis.SynthesisH2();
                currentImageD = waveletSynthesis.GetCurrentImageD();

                doneH2 = false;
                xValue.Value = width / 2;
                yValue.Value = height / 2;
                doneSH2 = true;

                waveletPictureBox.Image = CreateBitmapForWavelet(currentImageD, width, height, (double)scaleValue.Value);
            }
        }

        private void synthesisV2Button_Click(object sender, EventArgs e)
        {
            if (currentImageD != null && doneV2 && !doneSV2)
            {
                waveletSynthesis = new WaveletSynthesis(currentImageD, width, height);
                waveletSynthesis.SynthesisV2();
                currentImageD = waveletSynthesis.GetCurrentImageD();

                doneV2 = false;
                xValue.Value = width / 4;
                yValue.Value = height / 2;
                doneSV2 = true;

                waveletPictureBox.Image = CreateBitmapForWavelet(currentImageD, width, height, (double)scaleValue.Value);
            }
        }

        private void synthesisButton_Click(object sender, EventArgs e)
        {
            if (currentImageD != null)
            {
                if(levelValue.Value != 0)
                {
                    waveletSynthesis = new WaveletSynthesis(currentImageD, width, height);
                    waveletSynthesis.SynthesisFromALevel((int)levelValue.Value);
                    currentImageD = waveletSynthesis.GetCurrentImageD();

                    levelsAnalysis = false;
                    waveletPictureBox.Image = CreateBitmapForReconstructedLevels(currentImageD, width, height, (double)scaleValue.Value, 1);
                }
            }
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
                    else
                    {
                        valuePixel = (int)Math.Round(value);
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

        public Bitmap CreateBitmapForReconstructed(double[,] currentImage, int width, int height, double scaleV)
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

                    if (doneH2 && doneV2)
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
                    else if (doneH1 && !doneV1)
                    {
                        if (i < halfW)
                        {
                            valuePixel = (int)Math.Round(value);
                        }
                        else
                        {
                            valuePixel = (int)Math.Round((value * scale) + offset);
                        }
                    }
                    else
                    {
                        valuePixel = (int)Math.Round(value);
                    }

                    if (valuePixel > 255) valuePixel = 255;
                    if (valuePixel < 0) valuePixel = 0;

                    Color pixelColor = Color.FromArgb(valuePixel, valuePixel, valuePixel);
                    bitmap.SetPixel(i, j, pixelColor);
                }
            }

            return bitmap;
        }

        public Bitmap CreateBitmapForReconstructedLevels(double[,] currentImage, int width, int height, double scale, int currentLevel)
        {
            Bitmap bitmap = new Bitmap(width, height);
            double offset = 128.0;

            int reconstructedW = width / (int)Math.Pow(2, currentLevel - 1);
            int reconstructedH = height / (int)Math.Pow(2, currentLevel - 1);

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    double value = currentImage[i, j];
                    int valuePixel = 0;

                    if (i < reconstructedW && j < reconstructedH)
                    {
                        valuePixel = (int)Math.Round(value);
                    }
                    else
                    {
                        valuePixel = (int)Math.Round((value * scale) + offset);
                    }

                    if (valuePixel > 255) valuePixel = 255;
                    if (valuePixel < 0) valuePixel = 0;

                    Color pixelColor = Color.FromArgb(valuePixel, valuePixel, valuePixel);
                    bitmap.SetPixel(i, j, pixelColor);
                }
            }

            return bitmap;
        }

        private void minMaxErrorButton_Click(object sender, EventArgs e)
        {
            CalculateErrors();
        }

        private void CalculateErrors()
        {
            int min = int.MaxValue;
            int max = int.MinValue;

            if (originalImageD != null && currentImageD != null)
            {
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        double reconstructedPixel = Math.Round(currentImageD[i, j]);

                        int error = (int)Math.Abs(originalImageD[i, j] - reconstructedPixel);

                        if (error < min)
                        {
                            min = error;
                        }

                        if (error > max)
                        {
                            max = error;
                        }
                    }
                }

                minMaxErrorTextBox.Text = $"Min error: {min}\nMax error: {max}";
            }
        }
    }
}
