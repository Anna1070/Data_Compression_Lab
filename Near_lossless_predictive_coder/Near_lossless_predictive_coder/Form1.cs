using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Near_lossless_predictive_coder
{
    public partial class Form1: Form
    {
        OpenFileClass file = new OpenFileClass();
        string originalFilePath;

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
    }
}
