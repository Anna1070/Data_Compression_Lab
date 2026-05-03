using System.IO;
using System.Windows.Forms;

namespace Near_lossless_predictive_coder
{
    internal class OpenFileClass
    {
        private OpenFileDialog openFileDialog;
        private string filePath;

        public void OpenFile()
        {
            openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
            }
        }
        public string getFilePath()
        {
            return filePath;
        }

        public bool CheckBMPExtension(string filePath)
        {
            if (Path.GetExtension(filePath) != ".bmp")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckEncodedExtension(string filePath)
        {
            if (Path.GetExtension(filePath) != ".nl")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}