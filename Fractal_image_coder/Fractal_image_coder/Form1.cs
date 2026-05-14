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

namespace Fractal_image_coder
{
    public partial class Form1: Form
    {

        OpenFileClass file = new OpenFileClass();
        string originalFilePath;
        int width, height;

        public Form1()
        {
            InitializeComponent();
        }

        private void loadOrigImgButton_Click(object sender, EventArgs e)
        {
            file.OpenFile();
            originalFilePath = file.getFilePath();
            if (originalFilePath != null)
            {
                if (file.CheckBMPExtension(originalFilePath))
                {

                    MessageBox.Show("Image loaded");
                    originalImageBox.Image = Image.FromFile(originalFilePath);
                }
                else
                {
                    originalFilePath = null;
                    MessageBox.Show("You must choose a file with the .bmp extension");
                }
            }
        }

        private void processButton_Click(object sender, EventArgs e)
        {

        }

        private void saveProcessedButton_Click(object sender, EventArgs e)
        {
            if(originalFilePath != null)
            {
                //if ()
                //{
                //    string encodedFilePath = Path.GetFullPath(originalFilePath) + ".fc";
                //}
            }
        }

    }
}
