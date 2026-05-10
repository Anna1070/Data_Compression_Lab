namespace Near_lossless_predictive_coder
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.origImg = new System.Windows.Forms.PictureBox();
            this.errorImg = new System.Windows.Forms.PictureBox();
            this.decodedImg = new System.Windows.Forms.PictureBox();
            this.loadImgButton = new System.Windows.Forms.Button();
            this.encodeButton = new System.Windows.Forms.Button();
            this.saveEncButton = new System.Windows.Forms.Button();
            this.saveDecodedButton = new System.Windows.Forms.Button();
            this.decodeButton = new System.Windows.Forms.Button();
            this.loadCodedButton = new System.Windows.Forms.Button();
            this.predictorSelectionBox = new System.Windows.Forms.CheckedListBox();
            this.histogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.refreshErrorImgButton = new System.Windows.Forms.Button();
            this.sourceHistogramBox = new System.Windows.Forms.CheckedListBox();
            this.errorImgOptionsBox = new System.Windows.Forms.CheckedListBox();
            this.kValue = new System.Windows.Forms.NumericUpDown();
            this.contrastValue = new System.Windows.Forms.NumericUpDown();
            this.scaleHistogramValue = new System.Windows.Forms.NumericUpDown();
            this.RefreshHistoButton = new System.Windows.Forms.Button();
            this.saveModeBox = new System.Windows.Forms.CheckedListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.computeErrorButton = new System.Windows.Forms.Button();
            this.computeErrorValues = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.origImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.decodedImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contrastValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleHistogramValue)).BeginInit();
            this.SuspendLayout();
            // 
            // origImg
            // 
            this.origImg.Location = new System.Drawing.Point(28, 12);
            this.origImg.Name = "origImg";
            this.origImg.Size = new System.Drawing.Size(328, 315);
            this.origImg.TabIndex = 0;
            this.origImg.TabStop = false;
            // 
            // errorImg
            // 
            this.errorImg.Location = new System.Drawing.Point(693, 12);
            this.errorImg.Name = "errorImg";
            this.errorImg.Size = new System.Drawing.Size(328, 315);
            this.errorImg.TabIndex = 1;
            this.errorImg.TabStop = false;
            // 
            // decodedImg
            // 
            this.decodedImg.Location = new System.Drawing.Point(1268, 22);
            this.decodedImg.Name = "decodedImg";
            this.decodedImg.Size = new System.Drawing.Size(328, 315);
            this.decodedImg.TabIndex = 2;
            this.decodedImg.TabStop = false;
            // 
            // loadImgButton
            // 
            this.loadImgButton.Location = new System.Drawing.Point(48, 337);
            this.loadImgButton.Name = "loadImgButton";
            this.loadImgButton.Size = new System.Drawing.Size(125, 44);
            this.loadImgButton.TabIndex = 3;
            this.loadImgButton.Text = "Load";
            this.loadImgButton.UseVisualStyleBackColor = true;
            this.loadImgButton.Click += new System.EventHandler(this.loadImgButton_Click);
            // 
            // encodeButton
            // 
            this.encodeButton.Location = new System.Drawing.Point(206, 337);
            this.encodeButton.Name = "encodeButton";
            this.encodeButton.Size = new System.Drawing.Size(125, 44);
            this.encodeButton.TabIndex = 4;
            this.encodeButton.Text = "Encode";
            this.encodeButton.UseVisualStyleBackColor = true;
            this.encodeButton.Click += new System.EventHandler(this.encodeButton_Click);
            // 
            // saveEncButton
            // 
            this.saveEncButton.Location = new System.Drawing.Point(127, 387);
            this.saveEncButton.Name = "saveEncButton";
            this.saveEncButton.Size = new System.Drawing.Size(125, 44);
            this.saveEncButton.TabIndex = 5;
            this.saveEncButton.Text = "Save";
            this.saveEncButton.UseVisualStyleBackColor = true;
            this.saveEncButton.Click += new System.EventHandler(this.saveEncButton_Click);
            // 
            // saveDecodedButton
            // 
            this.saveDecodedButton.Location = new System.Drawing.Point(1388, 415);
            this.saveDecodedButton.Name = "saveDecodedButton";
            this.saveDecodedButton.Size = new System.Drawing.Size(125, 44);
            this.saveDecodedButton.TabIndex = 8;
            this.saveDecodedButton.Text = "Save";
            this.saveDecodedButton.UseVisualStyleBackColor = true;
            this.saveDecodedButton.Click += new System.EventHandler(this.saveDecodedButton_Click);
            // 
            // decodeButton
            // 
            this.decodeButton.Location = new System.Drawing.Point(1471, 365);
            this.decodeButton.Name = "decodeButton";
            this.decodeButton.Size = new System.Drawing.Size(125, 44);
            this.decodeButton.TabIndex = 7;
            this.decodeButton.Text = "Decode";
            this.decodeButton.UseVisualStyleBackColor = true;
            this.decodeButton.Click += new System.EventHandler(this.decodeButton_Click);
            // 
            // loadCodedButton
            // 
            this.loadCodedButton.Location = new System.Drawing.Point(1313, 365);
            this.loadCodedButton.Name = "loadCodedButton";
            this.loadCodedButton.Size = new System.Drawing.Size(125, 44);
            this.loadCodedButton.TabIndex = 6;
            this.loadCodedButton.Text = "Load";
            this.loadCodedButton.UseVisualStyleBackColor = true;
            this.loadCodedButton.Click += new System.EventHandler(this.loadCodedButton_Click);
            // 
            // predictorSelectionBox
            // 
            this.predictorSelectionBox.FormattingEnabled = true;
            this.predictorSelectionBox.Location = new System.Drawing.Point(28, 479);
            this.predictorSelectionBox.Name = "predictorSelectionBox";
            this.predictorSelectionBox.Size = new System.Drawing.Size(313, 259);
            this.predictorSelectionBox.TabIndex = 10;
            // 
            // histogram
            // 
            chartArea1.Name = "ChartArea1";
            this.histogram.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.histogram.Legends.Add(legend1);
            this.histogram.Location = new System.Drawing.Point(906, 491);
            this.histogram.Name = "histogram";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.histogram.Series.Add(series1);
            this.histogram.Size = new System.Drawing.Size(734, 414);
            this.histogram.TabIndex = 11;
            // 
            // refreshErrorImgButton
            // 
            this.refreshErrorImgButton.Location = new System.Drawing.Point(951, 399);
            this.refreshErrorImgButton.Name = "refreshErrorImgButton";
            this.refreshErrorImgButton.Size = new System.Drawing.Size(125, 44);
            this.refreshErrorImgButton.TabIndex = 12;
            this.refreshErrorImgButton.Text = "Refresh";
            this.refreshErrorImgButton.UseVisualStyleBackColor = true;
            this.refreshErrorImgButton.Click += new System.EventHandler(this.refreshErrorImgButton_Click);
            // 
            // sourceHistogramBox
            // 
            this.sourceHistogramBox.FormattingEnabled = true;
            this.sourceHistogramBox.Location = new System.Drawing.Point(546, 491);
            this.sourceHistogramBox.Name = "sourceHistogramBox";
            this.sourceHistogramBox.Size = new System.Drawing.Size(313, 259);
            this.sourceHistogramBox.TabIndex = 13;
            // 
            // errorImgOptionsBox
            // 
            this.errorImgOptionsBox.FormattingEnabled = true;
            this.errorImgOptionsBox.Location = new System.Drawing.Point(683, 337);
            this.errorImgOptionsBox.Name = "errorImgOptionsBox";
            this.errorImgOptionsBox.Size = new System.Drawing.Size(253, 106);
            this.errorImgOptionsBox.TabIndex = 14;
            // 
            // kValue
            // 
            this.kValue.Location = new System.Drawing.Point(379, 539);
            this.kValue.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.kValue.Name = "kValue";
            this.kValue.Size = new System.Drawing.Size(82, 22);
            this.kValue.TabIndex = 15;
            // 
            // contrastValue
            // 
            this.contrastValue.DecimalPlaces = 1;
            this.contrastValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.contrastValue.Location = new System.Drawing.Point(951, 365);
            this.contrastValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.contrastValue.Name = "contrastValue";
            this.contrastValue.Size = new System.Drawing.Size(82, 22);
            this.contrastValue.TabIndex = 16;
            // 
            // scaleHistogramValue
            // 
            this.scaleHistogramValue.DecimalPlaces = 1;
            this.scaleHistogramValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.scaleHistogramValue.Location = new System.Drawing.Point(903, 935);
            this.scaleHistogramValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.scaleHistogramValue.Name = "scaleHistogramValue";
            this.scaleHistogramValue.Size = new System.Drawing.Size(82, 22);
            this.scaleHistogramValue.TabIndex = 17;
            // 
            // RefreshHistoButton
            // 
            this.RefreshHistoButton.Location = new System.Drawing.Point(1034, 913);
            this.RefreshHistoButton.Name = "RefreshHistoButton";
            this.RefreshHistoButton.Size = new System.Drawing.Size(125, 44);
            this.RefreshHistoButton.TabIndex = 18;
            this.RefreshHistoButton.Text = "Refresh";
            this.RefreshHistoButton.UseVisualStyleBackColor = true;
            this.RefreshHistoButton.Click += new System.EventHandler(this.RefreshHistoButton_Click);
            // 
            // saveModeBox
            // 
            this.saveModeBox.FormattingEnabled = true;
            this.saveModeBox.Location = new System.Drawing.Point(28, 775);
            this.saveModeBox.Name = "saveModeBox";
            this.saveModeBox.Size = new System.Drawing.Size(313, 106);
            this.saveModeBox.TabIndex = 19;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(28, 451);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(118, 22);
            this.textBox1.TabIndex = 20;
            this.textBox1.Text = "Predictor selection";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(28, 747);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(83, 22);
            this.textBox2.TabIndex = 21;
            this.textBox2.Text = "Save mode";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(951, 337);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(58, 22);
            this.textBox3.TabIndex = 22;
            this.textBox3.Text = "Contrast";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(379, 511);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(51, 22);
            this.textBox4.TabIndex = 23;
            this.textBox4.Text = "k value";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(546, 463);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(134, 22);
            this.textBox5.TabIndex = 24;
            this.textBox5.Text = "Source for histogram";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(903, 911);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(118, 22);
            this.textBox6.TabIndex = 25;
            this.textBox6.Text = "Scale";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(906, 463);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(71, 22);
            this.textBox7.TabIndex = 26;
            this.textBox7.Text = "Histogram";
            // 
            // computeErrorButton
            // 
            this.computeErrorButton.Location = new System.Drawing.Point(546, 777);
            this.computeErrorButton.Name = "computeErrorButton";
            this.computeErrorButton.Size = new System.Drawing.Size(125, 44);
            this.computeErrorButton.TabIndex = 27;
            this.computeErrorButton.Text = "Compute error";
            this.computeErrorButton.UseVisualStyleBackColor = true;
            this.computeErrorButton.Click += new System.EventHandler(this.computeErrorButton_Click);
            // 
            // computeErrorValues
            // 
            this.computeErrorValues.Location = new System.Drawing.Point(546, 827);
            this.computeErrorValues.Multiline = true;
            this.computeErrorValues.Name = "computeErrorValues";
            this.computeErrorValues.Size = new System.Drawing.Size(147, 53);
            this.computeErrorValues.TabIndex = 28;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1680, 969);
            this.Controls.Add(this.computeErrorValues);
            this.Controls.Add(this.computeErrorButton);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.saveModeBox);
            this.Controls.Add(this.RefreshHistoButton);
            this.Controls.Add(this.scaleHistogramValue);
            this.Controls.Add(this.contrastValue);
            this.Controls.Add(this.kValue);
            this.Controls.Add(this.errorImgOptionsBox);
            this.Controls.Add(this.sourceHistogramBox);
            this.Controls.Add(this.refreshErrorImgButton);
            this.Controls.Add(this.histogram);
            this.Controls.Add(this.predictorSelectionBox);
            this.Controls.Add(this.saveDecodedButton);
            this.Controls.Add(this.decodeButton);
            this.Controls.Add(this.loadCodedButton);
            this.Controls.Add(this.saveEncButton);
            this.Controls.Add(this.encodeButton);
            this.Controls.Add(this.loadImgButton);
            this.Controls.Add(this.decodedImg);
            this.Controls.Add(this.errorImg);
            this.Controls.Add(this.origImg);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.origImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.decodedImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contrastValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleHistogramValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox origImg;
        private System.Windows.Forms.PictureBox errorImg;
        private System.Windows.Forms.PictureBox decodedImg;
        private System.Windows.Forms.Button loadImgButton;
        private System.Windows.Forms.Button encodeButton;
        private System.Windows.Forms.Button saveEncButton;
        private System.Windows.Forms.Button saveDecodedButton;
        private System.Windows.Forms.Button decodeButton;
        private System.Windows.Forms.Button loadCodedButton;
        private System.Windows.Forms.CheckedListBox predictorSelectionBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart histogram;
        private System.Windows.Forms.Button refreshErrorImgButton;
        private System.Windows.Forms.CheckedListBox sourceHistogramBox;
        private System.Windows.Forms.CheckedListBox errorImgOptionsBox;
        private System.Windows.Forms.NumericUpDown kValue;
        private System.Windows.Forms.NumericUpDown contrastValue;
        private System.Windows.Forms.NumericUpDown scaleHistogramValue;
        private System.Windows.Forms.Button RefreshHistoButton;
        private System.Windows.Forms.CheckedListBox saveModeBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Button computeErrorButton;
        private System.Windows.Forms.TextBox computeErrorValues;
    }
}

