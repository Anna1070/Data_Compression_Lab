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

namespace Arithmetic_coder
{
    public partial class Form1 : Form
    {
        private OpenFileClass file = new OpenFileClass();
        string inputFile;

        public Form1()
        {
            InitializeComponent();
        }

        private void loadFileButton_Click(object sender, EventArgs e)
        {
            file.OpenFile();
            inputFile = file.getFilePath();

            if (inputFile != null )
            {
                string text = File.ReadAllText(inputFile);
                inputText.Text = text;
            }
        }

        private void compressButton_Click(object sender, EventArgs e)
        {
            if(inputFile != null)
            {
                ArithmeticCoder coder = new ArithmeticCoder();
                coder.InitializeStaticModel();

                string encodedFile = Path.GetFullPath(inputFile).ToLower() + ".ac";
                BitWriter bitWriter = new BitWriter(encodedFile);

                string inputT = inputText.Text;
                foreach (char c in inputT)
                {
                    if(c == 'A' || c == 'B')
                    {
                        coder.EncodeSymbol(c, bitWriter);
                    }
                }

                coder.EncodeSymbol(ArithmeticCoder.EOF, bitWriter);
                coder.DoneEncoding(bitWriter);

                bitWriter.Close();

                MessageBox.Show($"Compression successful! Encoded file: {encodedFile}");
            }
        }
    }
}
