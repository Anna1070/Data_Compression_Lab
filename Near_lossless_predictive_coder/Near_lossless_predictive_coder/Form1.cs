using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.AxHost;

namespace Near_lossless_predictive_coder
{
    public partial class Form1: Form
    {
        OpenFileClass file = new OpenFileClass();
        string originalFilePath;
        int width, height;

        //Predictor
        byte[] first1078Bytes;
        Predictor predictor;
        int predictorOption;
        int[,] errorPMatrixPredictor, errorPQMatrixPredictor;
        byte[,] decodedImagePredictor;
        StoreEncoded store;

        //Decoder
        byte[] first1078BytesEncoded;
        string encodedFilePath;
        Decoder decoder;
        byte[,] decodedMatrixDecoder;
        int[,] errorPQMatrixDecoder, errorPDQMatrixDecoder;

        //Error
        int min = int.MaxValue;
        int max = int.MinValue;


        public Form1()
        {
            InitializeComponent();
            string[] predictorOptionList = { "128", "A", "B", "C", "A+B-C", "A+(B-C)/2", "B+(A-C)/2", "(A+B)/2", "jpegLS" };
            string[] saveOptionsList = { "Fixed", "Table", "Arithmetic" };
            string[] histogramoptionsList = { "Original image", "Prediction error image", "Q prediction error image (C)", "Decoded image (C)", "Q prediction error image (D)",
                                               "DQ prediction error image (D)", "Decoded image (D)"};
            string[] errorImgOptionsList = { "Prediction error", "Q prediction error" };

            predictorSelectionBox.Items.AddRange(predictorOptionList);
            saveModeBox.Items.AddRange(saveOptionsList);
            sourceHistogramBox.Items.AddRange(histogramoptionsList);
            errorImgOptionsBox.Items.AddRange(errorImgOptionsList);

            histogram.Series.Clear();
            histogram.ChartAreas.Clear();

        }

        private void loadImgButton_Click(object sender, EventArgs e)
        {
            file.OpenFile();
            originalFilePath = file.getFilePath();
            if (originalFilePath != null)
            {
                if (file.CheckBMPExtension(originalFilePath))
                {

                    MessageBox.Show("Image loaded");
                    origImg.Image = Image.FromFile(originalFilePath);
                }
                else
                {
                    originalFilePath = null;
                    MessageBox.Show("You must choose a file with the .bmp extension");
                }
            }
        }

        private void encodeButton_Click(object sender, EventArgs e)
        {
            if (originalFilePath != null)
            {
                if (predictorSelectionBox.CheckedItems.Count == 1)
                {
                    Bitmap originalImg = new Bitmap(originalFilePath);
                    //width = origImg.Width;
                    //height = origImg.Height;
                    width = 256;
                    height = 256;

                    first1078Bytes = GetFirst1078Bytes(originalFilePath);
                    Console.WriteLine(first1078Bytes.Length);

                    predictor = new Predictor(originalFilePath, width, height, (int)kValue.Value);
                    Predict(predictorSelectionBox.CheckedItems[0]);
                }
                else
                {
                    MessageBox.Show("Please select only one of the predictors");
                }
            }
            else
            {
                MessageBox.Show("Please select an image first");
            }
        }

        public void Predict(Object option)
        {
            switch (option)
            {
                case "128":
                    Console.WriteLine("Predictor 128 selected");
                    predictor.Predictor128();
                    predictorOption = 1;
                    break;

                case "A":
                    Console.WriteLine("Predictor A selected");
                    predictor.PredictorA();
                    predictorOption = 2;
                    break;

                case "B":
                    Console.WriteLine("Predictor B selected");
                    predictor.PredictorB();
                    predictorOption = 3;
                    break;

                case "C":
                    Console.WriteLine("Predictor C selected");
                    predictor.PredictorC();
                    predictorOption = 4;
                    break;

                case "A+B-C":
                    Console.WriteLine("Predictor A+B-C selected");
                    predictor.Predictor5();
                    predictorOption = 5;
                    break;

                case "A+(B-C)/2":
                    Console.WriteLine("Predictor A+(B-C)/2 selected");
                    predictor.Predictor6();
                    predictorOption = 6;
                    break;

                case "B+(A-C)/2":
                    Console.WriteLine("Predictor B+(A-C)/2 selected");
                    predictor.Predictor7();
                    predictorOption = 7;
                    break;

                case "(A+B)/2":
                    Console.WriteLine("Predictor (A+B)/2 selected");
                    predictor.Predictor8();
                    predictorOption = 8;
                    break;

                case "jpegLS":
                    Console.WriteLine("Predictor jpegLS selected");
                    predictor.Predictor9();
                    predictorOption = 9;
                    break;
            }

            errorPMatrixPredictor = predictor.GetPredictionErrorMatrix();
            errorPQMatrixPredictor = predictor.GetQuantizedPredictionErrorMatrix();
            decodedImagePredictor = predictor.GetDecodedPredictorImage();
            MessageBox.Show("Finished encoding");
        }

        private void saveEncButton_Click(object sender, EventArgs e)
        {
            if (originalFilePath != null)
            {
                if (saveModeBox.CheckedItems.Count == 1)
                {
                    if (errorPQMatrixPredictor != null)
                    {
                        string saveMode = saveModeBox.CheckedItems[0].ToString();
                        string encodedFilePath;
                        switch (saveMode)
                        {
                            case "Fixed":
                                encodedFilePath = Path.GetFullPath(originalFilePath) + "." + "k" + kValue.Value + "p" + predictorOption + "F" + ".nl";
                                store = new StoreEncoded(width, height, predictorOption, first1078Bytes, (int)kValue.Value, encodedFilePath, errorPQMatrixPredictor);
                                store.StartStoringFixed();
                                break;

                            case "Table":
                                encodedFilePath = Path.GetFullPath(originalFilePath) + "." + "k" + kValue.Value + "p" + predictorOption + "T" + ".nl";
                                store = new StoreEncoded(width, height, predictorOption, first1078Bytes, (int)kValue.Value, encodedFilePath, errorPQMatrixPredictor);
                                store.StartStoringTable();
                                break;

                            case "Arithmetic":
                                encodedFilePath = Path.GetFullPath(originalFilePath) + "." + "k" + kValue.Value + "p" + predictorOption + "A" + ".nl";
                                store = new StoreEncoded(width, height, predictorOption, first1078Bytes, (int)kValue.Value, encodedFilePath, errorPQMatrixPredictor);
                                store.StartStoringArithmetic();
                                break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select one save mode");
                }
            }
            else
            {
                MessageBox.Show("Please select an image first");
            }
        }

        private void refreshErrorImgButton_Click(object sender, EventArgs e)
        {
            if(errorImgOptionsBox.CheckedItems.Count == 1)
            {
                string errorImageOption = errorImgOptionsBox.CheckedItems[0].ToString();
                switch (errorImageOption)
                {
                    case "Prediction error":
                        if(errorPMatrixPredictor != null)
                        {
                            errorImg.Image = CreateBitmapForPredictionError(errorPMatrixPredictor, (double)contrastValue.Value);
                        }
                        else
                        {
                            MessageBox.Show("Please encode an image first");
                        }
                        break;

                    case "Q prediction error":
                        if (errorPQMatrixPredictor != null)
                        {
                            errorImg.Image = CreateBitmapForPredictionError(errorPQMatrixPredictor, (double)contrastValue.Value);
                        }
                        else
                        {
                            MessageBox.Show("Please encode an image first");
                        }
                        break;
                }
            }
            else
            {
                MessageBox.Show("Please select one of the options first");
            }
        }

        public Bitmap CreateBitmapForPredictionError(int[,] errorMatrix, double contrast)
        {
            Bitmap bitmap = new Bitmap(width, height);

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    int value = (int)(128 + errorMatrix[i, j] * contrast);

                    if (value > 255)
                    {
                        value = 255;
                    }
                    else if (value < 0)
                    {
                        value = 0;
                    }

                    Color pixelColor = Color.FromArgb(value, value, value);
                    bitmap.SetPixel(i, j, pixelColor);
                }
            }

            return bitmap;
        }

        private void RefreshHistoButton_Click(object sender, EventArgs e)
        {
            if (sourceHistogramBox.CheckedItems.Count != 1)
            {
                MessageBox.Show("Please choose only one option for the histogram");
            }
            else
            {
                if(originalFilePath != null)
                {
                    histogram.Series.Clear();
                    histogram.ChartAreas.Clear();

                    string histogramOption = sourceHistogramBox.CheckedItems[0].ToString();
                    int[] myHistogram = new int[511];

                    ChartArea chartArea = new ChartArea
                    {
                        AxisX = { Title = "Intensity", Minimum = -255, Maximum = 256, Interval = 50 },
                        AxisY = { Title = "Frequency (# of pixels)" }
                    };
                    histogram.ChartAreas.Add(chartArea);

                    Series series = new Series
                    {
                        ChartType = SeriesChartType.Column
                    };

                    Bitmap originalImage = new Bitmap(originalFilePath);
                    width = originalImage.Width;
                    height = originalImage.Height;

                    switch (histogramOption)
                    {
                        case "Original image":
                            for (int j = 0; j < height; j++)
                            {
                                for (int i = 0; i < width; i++)
                                {
                                    
                                    int value = originalImage.GetPixel(i, j).R;
                                    myHistogram[value + 255]++;
                                }
                            }
                            break;
                        
                        case "Prediction error image":
                            if (errorPMatrixPredictor == null)
                            {
                                MessageBox.Show("Please encode the image first!");
                                return;
                            }
                            for (int j = 0; j < height; j++)
                            {
                                for (int i = 0; i < width; i++)
                                {
                                    int val = errorPMatrixPredictor[i, j];

                                    if (val < -255)
                                    {
                                        val = -255;
                                    }
                                    if (val > 255)
                                    {
                                        val = 255;
                                    }

                                    myHistogram[val + 255]++;
                                }
                            }
                            break;

                        case "Q prediction error image (C)":
                            if (errorPQMatrixPredictor == null)
                            {
                                MessageBox.Show("Please encode the image first!");
                                return;
                            }
                            for (int j = 0; j < height; j++)
                            {
                                for (int i = 0; i < width; i++)
                                {
                                    int val = errorPQMatrixPredictor[i, j];

                                    if (val < -255)
                                    {
                                        val = -255;
                                    }
                                    if (val > 255)
                                    {
                                        val = 255;
                                    }

                                    myHistogram[val + 255]++;
                                }
                            }
                            break;

                        case "Decoded image (C)":
                            if (decodedImagePredictor == null)
                            {
                                MessageBox.Show("Please encode the image first!");
                                return;
                            }

                            for (int j = 0; j < height; j++)
                            {
                                for (int i = 0; i < width; i++)
                                {

                                    int value = decodedImagePredictor[i, j];
                                    myHistogram[value + 255]++;
                                }
                            }
                            break;

                        case "Q prediction error image (D)":
                            if (errorPQMatrixDecoder == null)
                            {
                                MessageBox.Show("Please decode an image first!");
                                return;
                            }
                            for (int j = 0; j < height; j++)
                            {
                                for (int i = 0; i < width; i++)
                                {
                                    int val = errorPQMatrixDecoder[i, j];

                                    if (val < -255)
                                    {
                                        val = -255;
                                    }
                                    if (val > 255)
                                    {
                                        val = 255;
                                    }

                                    myHistogram[val + 255]++;
                                }
                            }
                            break;

                        case "DQ prediction error image (D)":
                            if (errorPDQMatrixDecoder == null)
                            {
                                MessageBox.Show("Please decode an image first!");
                                return;
                            }
                            for (int j = 0; j < height; j++)
                            {
                                for (int i = 0; i < width; i++)
                                {
                                    int val = errorPDQMatrixDecoder[i, j];

                                    if (val < -255)
                                    {
                                        val = -255;
                                    }
                                    if (val > 255)
                                    {
                                        val = 255;
                                    }

                                    myHistogram[val + 255]++;
                                }
                            }
                            break;

                        case "Decoded image (D)":
                            if (decodedMatrixDecoder == null)
                            {
                                MessageBox.Show("Please decode an image first!");
                                return;
                            }

                            Bitmap decodedImageBitmap = CreateBitmapForDecodedMatrix(decodedMatrixDecoder, width, height);
                            for (int j = 0; j < height; j++)
                            {
                                for (int i = 0; i < width; i++)
                                {

                                    int value = decodedImageBitmap.GetPixel(i, j).R;
                                    myHistogram[value + 255]++;
                                }
                            }

                            break;

                    }

                    for (int i = 0; i < myHistogram.Length; i++)
                    {
                        series.Points.AddXY(i - 255, myHistogram[i] * scaleHistogramValue.Value);
                    }

                    histogram.Series.Add(series);
                }
                else
                {
                    MessageBox.Show($"Data missing for {sourceHistogramBox.CheckedItems[0].ToString()}");
                }
            }
        }

        private void loadCodedButton_Click(object sender, EventArgs e)
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
                    MessageBox.Show("Please choose a file with the .nl extension");
                }
            }
            else
            {
                MessageBox.Show("Please choose an encoded file");
            }
        }

        private void decodeButton_Click(object sender, EventArgs e)
        {
            if (encodedFilePath == null)
            {
                MessageBox.Show("Please load an encoded file first");
            }
            else
            {
                first1078BytesEncoded = GetFirst1078Bytes(encodedFilePath);
                Console.WriteLine(first1078BytesEncoded.Length);

                int width = 256;
                int height = 256;

                Decoder decoder = new Decoder(encodedFilePath, width, height);

                decoder.StartDecoding();
                decodedMatrixDecoder = decoder.GetDecodedImageDecoder();
                errorPQMatrixDecoder = decoder.GetPQMatrixDecoder();
                errorPDQMatrixDecoder = decoder.GetPDQMatrixDecoder();
                decodedImg.Image = CreateBitmapForDecodedMatrix(decodedMatrixDecoder, width, height);
            }
        }

        private void saveDecodedButton_Click(object sender, EventArgs e)
        {
            if (encodedFilePath != null && decodedMatrixDecoder != null)
            {
                width = 256; height = 256;
                string decodedFilePath = Path.GetFullPath(encodedFilePath) + ".bmp";
                StoreDecoded storeDecoded = new StoreDecoded(first1078BytesEncoded, decodedFilePath, CreateBitmapForDecodedMatrix(decodedMatrixDecoder,width, height), width, height);
                storeDecoded.startStoring();
            }
            else
            {
                MessageBox.Show("Please load an encoded file first and decode it");
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

        private void computeErrorButton_Click(object sender, EventArgs e)
        {
            if(originalFilePath == null || decodedMatrixDecoder == null)
            {
                MessageBox.Show("Please choose an image and decode it first");
            }
            else
            {
                Bitmap origImg = new Bitmap(originalFilePath);
                ComputeReconstructionError(ConvertBitmapToByteMatrix(origImg, width, height), decodedMatrixDecoder, width, height);
                computeErrorValues.Text = $"Min : {min} \nMax : {max}";
            }
        }

        public byte[,] ConvertBitmapToByteMatrix(Bitmap bmp, int width, int height)
        {
            byte[,] matrix = new byte[width, height];

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    matrix[i, j] = bmp.GetPixel(i, j).R;
                }
            }

            return matrix;
        }

        public void ComputeReconstructionError(byte[,] originalMatrix, byte[,] decodedMatrix, int width, int height)
        {
            int[,] errorMatrix = new int[width, height];

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    errorMatrix[i, j] = originalMatrix[i, j] - decodedMatrix[i, j];
                    if (errorMatrix[i, j] > max)
                    {
                        max = errorMatrix[i, j];
                    }
                    if (errorMatrix[i, j] < min)
                    {
                        min = errorMatrix[i, j];
                    }
                }
            }
        }

        public Bitmap CreateBitmapForDecodedMatrix(byte[,] decodedMatrix, int width, int height)
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


       
    }
}
