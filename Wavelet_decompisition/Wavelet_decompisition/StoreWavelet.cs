using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wavelet_decompisition
{
    internal class StoreWavelet
    {
        double[,] currentImageD;
        string encodedFilePath;
        int width, height, level;

        public StoreWavelet(double[,] currentImageD, string encodedFilePath, int width, int height, int level)
        {
            this.currentImageD = currentImageD;
            this.encodedFilePath = encodedFilePath;
            this.width = width;
            this.height = height;
            this.level = level;
        }

        public void StartStoring()
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(encodedFilePath, FileMode.Create)))
                {
                    writer.Write(width);
                    writer.Write(height);
                    writer.Write(level);

                    for (int j = 0; j < height; j++)
                    {
                        for (int i = 0; i < width; i++)
                        {
                            writer.Write(currentImageD[i, j]);
                        }
                    }
                }
                MessageBox.Show("Storing completed!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error when storing the wavelet: {ex.Message}");
            }
        }
        
    }
}
