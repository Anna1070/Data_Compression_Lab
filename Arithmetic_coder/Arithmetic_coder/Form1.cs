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
        string encodedFilePath;

        public Form1()
        {
            InitializeComponent();
        }

        private void loadFileButton_Click(object sender, EventArgs e)
        {
            file.OpenFile();
            inputFile = file.getFilePath();

            //if (inputFile != null )
            //{
            //    string text = File.ReadAllText(inputFile);
            //    inputText.Text = text;
            //}
        }

        private void compressButton_Click(object sender, EventArgs e)
        {
            if(inputFile != null)
            {
                ArithmeticCoder coder = new ArithmeticCoder();
                coder.InitializeDynamicModel();

                string encodedFile = Path.GetFullPath(inputFile).ToLower() + ".ac";
                BitWriter bitWriter = new BitWriter(encodedFile);

                //string inputT = inputText.Text;
                //foreach (char c in inputT)
                //{
                //    if(c == 'A' || c == 'B')
                //    {
                //        coder.EncodeSymbol(c, bitWriter);
                //    }
                //}

                //coder.EncodeSymbol(ArithmeticCoder.EOF, bitWriter);
                //coder.DoneEncoding(bitWriter);

                //bitWriter.Close();

                using (FileStream fs = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
                {
                    int b;
                    while ((b = fs.ReadByte()) != -1)
                    {
                        coder.EncodeSymbol(b, bitWriter);
                    }
                }

                // Trimitem noul marker EOF (256) și închidem fișierul
                coder.EncodeSymbol(ArithmeticCoder.eofIndex, bitWriter);
                coder.DoneEncoding(bitWriter);
                bitWriter.Close();

                MessageBox.Show($"Compression successful!");
            }
        }

        private void loadEncodedFileButton_Click(object sender, EventArgs e)
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
                    MessageBox.Show("Please choose a file with the .ac extension");
                }
            }
        }

        private void decodeButton_Click(object sender, EventArgs e)
        {
            if(encodedFilePath != null)
            {
                BitReader bitReader = new BitReader(encodedFilePath);
                ArithmeticDecoder decoder = new ArithmeticDecoder();
                decoder.InitializeDecoder(bitReader);

                //StringBuilder finalText = new StringBuilder();
                //while (true)
                //{
                //    char symbol = decoder.DecodeSymbol(bitReader);

                //    if(symbol == ArithmeticCoder.EOF)
                //    {
                //        break;
                //    }

                //    finalText.Append(symbol);
                //}

                //bitReader.Close();
                //outputText.Text = finalText.ToString();

                string directory = Path.GetDirectoryName(encodedFilePath);
                string originalFileWithoutAC = Path.GetFileNameWithoutExtension(encodedFilePath);
                string newFileName = "decoded_" + originalFileWithoutAC;
                string decodedFilePath = Path.Combine(directory, newFileName);

                using (FileStream fsOut = new FileStream(decodedFilePath, FileMode.Create, FileAccess.Write))
                {
                    while (true)
                    {
                        int symbol = decoder.DecodeSymbol(bitReader);

                        if (symbol == ArithmeticDecoder.eofIndex)
                        {
                            break;
                        }

                        fsOut.WriteByte((byte)symbol);
                    }
                }

                bitReader.Close();

                MessageBox.Show($"Decoding successful!");
            }
        }
    }
}
