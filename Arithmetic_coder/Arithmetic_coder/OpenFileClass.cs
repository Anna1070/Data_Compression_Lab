using System.IO;
using System.Windows.Forms;

namespace Arithmetic_coder
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
            if (Path.GetExtension(filePath).ToLower() != ".bmp")
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
            if (Path.GetExtension(filePath) != ".ac")
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