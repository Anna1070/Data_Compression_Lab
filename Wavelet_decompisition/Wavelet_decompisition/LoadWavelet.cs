using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wavelet_decompisition
{
    internal class LoadWavelet
    {
        private string encodedFilePath;
        private double[,] loadedImageD;
        private int width, height, level;

        public LoadWavelet(string encodedFilePath)
        {
            this.encodedFilePath = encodedFilePath;
        }

        public void StartReading()
        {
            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(encodedFilePath, FileMode.Open)))
                {
                    width = reader.ReadInt32();
                    height = reader.ReadInt32();
                    level = reader.ReadInt32();

                    loadedImageD = new double[width, height];

                    for (int j = 0; j < height; j++)
                    {
                        for (int i = 0; i < width; i++)
                        {
                            loadedImageD[i, j] = reader.ReadDouble();
                        }
                    }
                }
                MessageBox.Show("File successfully read");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while reading the file: {ex.Message}");
            }
        }

        public double[,] GetReadWavelet()
        {
            return loadedImageD;
        }
        public int GetWidth()
        {
            return width;
        }
        public int GetHeight()
        {
            return height;
        }
        public int GetLevel()
        {
            return level;
        }
    }
}
