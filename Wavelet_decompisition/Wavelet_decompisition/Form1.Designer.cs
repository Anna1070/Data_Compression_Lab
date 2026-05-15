namespace Wavelet_decompisition
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
            this.originalImageBox = new System.Windows.Forms.PictureBox();
            this.loadOriginalButton = new System.Windows.Forms.Button();
            this.minMaxErrorButton = new System.Windows.Forms.Button();
            this.minMaxErrorTextBox = new System.Windows.Forms.TextBox();
            this.waveletPictureBox = new System.Windows.Forms.PictureBox();
            this.saveEncodedButton = new System.Windows.Forms.Button();
            this.loadEncodedButton = new System.Windows.Forms.Button();
            this.refreshWaveletButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.scaleValue = new System.Windows.Forms.NumericUpDown();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.xValue = new System.Windows.Forms.NumericUpDown();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.yValue = new System.Windows.Forms.NumericUpDown();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.analysisH1Button = new System.Windows.Forms.Button();
            this.analysisV1Button = new System.Windows.Forms.Button();
            this.synthesisH1Button = new System.Windows.Forms.Button();
            this.synthesisV1Button = new System.Windows.Forms.Button();
            this.levelValue = new System.Windows.Forms.NumericUpDown();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.synthesisButton = new System.Windows.Forms.Button();
            this.analysisButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.originalImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waveletPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelValue)).BeginInit();
            this.SuspendLayout();
            // 
            // originalImageBox
            // 
            this.originalImageBox.Location = new System.Drawing.Point(12, 12);
            this.originalImageBox.Name = "originalImageBox";
            this.originalImageBox.Size = new System.Drawing.Size(512, 512);
            this.originalImageBox.TabIndex = 0;
            this.originalImageBox.TabStop = false;
            // 
            // loadOriginalButton
            // 
            this.loadOriginalButton.Location = new System.Drawing.Point(12, 546);
            this.loadOriginalButton.Name = "loadOriginalButton";
            this.loadOriginalButton.Size = new System.Drawing.Size(113, 34);
            this.loadOriginalButton.TabIndex = 1;
            this.loadOriginalButton.Text = "Load";
            this.loadOriginalButton.UseVisualStyleBackColor = true;
            // 
            // minMaxErrorButton
            // 
            this.minMaxErrorButton.Location = new System.Drawing.Point(12, 611);
            this.minMaxErrorButton.Name = "minMaxErrorButton";
            this.minMaxErrorButton.Size = new System.Drawing.Size(113, 34);
            this.minMaxErrorButton.TabIndex = 2;
            this.minMaxErrorButton.Text = "Min Max Error";
            this.minMaxErrorButton.UseVisualStyleBackColor = true;
            // 
            // minMaxErrorTextBox
            // 
            this.minMaxErrorTextBox.Location = new System.Drawing.Point(150, 611);
            this.minMaxErrorTextBox.Multiline = true;
            this.minMaxErrorTextBox.Name = "minMaxErrorTextBox";
            this.minMaxErrorTextBox.Size = new System.Drawing.Size(132, 71);
            this.minMaxErrorTextBox.TabIndex = 3;
            // 
            // waveletPictureBox
            // 
            this.waveletPictureBox.Location = new System.Drawing.Point(563, 12);
            this.waveletPictureBox.Name = "waveletPictureBox";
            this.waveletPictureBox.Size = new System.Drawing.Size(512, 512);
            this.waveletPictureBox.TabIndex = 4;
            this.waveletPictureBox.TabStop = false;
            // 
            // saveEncodedButton
            // 
            this.saveEncodedButton.Location = new System.Drawing.Point(591, 546);
            this.saveEncodedButton.Name = "saveEncodedButton";
            this.saveEncodedButton.Size = new System.Drawing.Size(113, 34);
            this.saveEncodedButton.TabIndex = 5;
            this.saveEncodedButton.Text = "Save";
            this.saveEncodedButton.UseVisualStyleBackColor = true;
            // 
            // loadEncodedButton
            // 
            this.loadEncodedButton.Location = new System.Drawing.Point(591, 611);
            this.loadEncodedButton.Name = "loadEncodedButton";
            this.loadEncodedButton.Size = new System.Drawing.Size(113, 34);
            this.loadEncodedButton.TabIndex = 6;
            this.loadEncodedButton.Text = "Load";
            this.loadEncodedButton.UseVisualStyleBackColor = true;
            // 
            // refreshWaveletButton
            // 
            this.refreshWaveletButton.Location = new System.Drawing.Point(734, 546);
            this.refreshWaveletButton.Name = "refreshWaveletButton";
            this.refreshWaveletButton.Size = new System.Drawing.Size(113, 99);
            this.refreshWaveletButton.TabIndex = 7;
            this.refreshWaveletButton.Text = "Refresh Wavelet Img";
            this.refreshWaveletButton.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(884, 546);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(67, 20);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "Scale";
            // 
            // scaleValue
            // 
            this.scaleValue.DecimalPlaces = 1;
            this.scaleValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.scaleValue.Location = new System.Drawing.Point(967, 546);
            this.scaleValue.Name = "scaleValue";
            this.scaleValue.Size = new System.Drawing.Size(79, 20);
            this.scaleValue.TabIndex = 9;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(884, 572);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(67, 20);
            this.textBox2.TabIndex = 10;
            this.textBox2.Text = "Offset";
            // 
            // xValue
            // 
            this.xValue.Location = new System.Drawing.Point(967, 598);
            this.xValue.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.xValue.Name = "xValue";
            this.xValue.Size = new System.Drawing.Size(79, 20);
            this.xValue.TabIndex = 13;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(884, 598);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(67, 20);
            this.textBox3.TabIndex = 12;
            this.textBox3.Text = "x";
            // 
            // yValue
            // 
            this.yValue.Location = new System.Drawing.Point(967, 625);
            this.yValue.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.yValue.Name = "yValue";
            this.yValue.Size = new System.Drawing.Size(79, 20);
            this.yValue.TabIndex = 15;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(884, 625);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(67, 20);
            this.textBox4.TabIndex = 14;
            this.textBox4.Text = "y";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(967, 572);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(67, 20);
            this.textBox5.TabIndex = 16;
            this.textBox5.Text = "128";
            // 
            // analysisH1Button
            // 
            this.analysisH1Button.Location = new System.Drawing.Point(1101, 12);
            this.analysisH1Button.Name = "analysisH1Button";
            this.analysisH1Button.Size = new System.Drawing.Size(113, 34);
            this.analysisH1Button.TabIndex = 17;
            this.analysisH1Button.Text = "An H1";
            this.analysisH1Button.UseVisualStyleBackColor = true;
            // 
            // analysisV1Button
            // 
            this.analysisV1Button.Location = new System.Drawing.Point(1101, 52);
            this.analysisV1Button.Name = "analysisV1Button";
            this.analysisV1Button.Size = new System.Drawing.Size(113, 34);
            this.analysisV1Button.TabIndex = 18;
            this.analysisV1Button.Text = "An V1";
            this.analysisV1Button.UseVisualStyleBackColor = true;
            // 
            // synthesisH1Button
            // 
            this.synthesisH1Button.Location = new System.Drawing.Point(1237, 12);
            this.synthesisH1Button.Name = "synthesisH1Button";
            this.synthesisH1Button.Size = new System.Drawing.Size(113, 34);
            this.synthesisH1Button.TabIndex = 19;
            this.synthesisH1Button.Text = "Sy H1";
            this.synthesisH1Button.UseVisualStyleBackColor = true;
            // 
            // synthesisV1Button
            // 
            this.synthesisV1Button.Location = new System.Drawing.Point(1238, 52);
            this.synthesisV1Button.Name = "synthesisV1Button";
            this.synthesisV1Button.Size = new System.Drawing.Size(113, 34);
            this.synthesisV1Button.TabIndex = 20;
            this.synthesisV1Button.Text = "Sy V1";
            this.synthesisV1Button.UseVisualStyleBackColor = true;
            // 
            // levelValue
            // 
            this.levelValue.Location = new System.Drawing.Point(1184, 228);
            this.levelValue.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.levelValue.Name = "levelValue";
            this.levelValue.Size = new System.Drawing.Size(79, 20);
            this.levelValue.TabIndex = 22;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(1101, 228);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(67, 20);
            this.textBox6.TabIndex = 21;
            this.textBox6.Text = "Level";
            // 
            // synthesisButton
            // 
            this.synthesisButton.Location = new System.Drawing.Point(1101, 303);
            this.synthesisButton.Name = "synthesisButton";
            this.synthesisButton.Size = new System.Drawing.Size(113, 34);
            this.synthesisButton.TabIndex = 24;
            this.synthesisButton.Text = "Synthesis";
            this.synthesisButton.UseVisualStyleBackColor = true;
            // 
            // analysisButton
            // 
            this.analysisButton.Location = new System.Drawing.Point(1101, 263);
            this.analysisButton.Name = "analysisButton";
            this.analysisButton.Size = new System.Drawing.Size(113, 34);
            this.analysisButton.TabIndex = 23;
            this.analysisButton.Text = "Analysis";
            this.analysisButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1363, 731);
            this.Controls.Add(this.synthesisButton);
            this.Controls.Add(this.analysisButton);
            this.Controls.Add(this.levelValue);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.synthesisV1Button);
            this.Controls.Add(this.synthesisH1Button);
            this.Controls.Add(this.analysisV1Button);
            this.Controls.Add(this.analysisH1Button);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.yValue);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.xValue);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.scaleValue);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.refreshWaveletButton);
            this.Controls.Add(this.loadEncodedButton);
            this.Controls.Add(this.saveEncodedButton);
            this.Controls.Add(this.waveletPictureBox);
            this.Controls.Add(this.minMaxErrorTextBox);
            this.Controls.Add(this.minMaxErrorButton);
            this.Controls.Add(this.loadOriginalButton);
            this.Controls.Add(this.originalImageBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.originalImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waveletPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox originalImageBox;
        private System.Windows.Forms.Button loadOriginalButton;
        private System.Windows.Forms.Button minMaxErrorButton;
        private System.Windows.Forms.TextBox minMaxErrorTextBox;
        private System.Windows.Forms.PictureBox waveletPictureBox;
        private System.Windows.Forms.Button saveEncodedButton;
        private System.Windows.Forms.Button loadEncodedButton;
        private System.Windows.Forms.Button refreshWaveletButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.NumericUpDown scaleValue;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.NumericUpDown xValue;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.NumericUpDown yValue;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button analysisH1Button;
        private System.Windows.Forms.Button analysisV1Button;
        private System.Windows.Forms.Button synthesisH1Button;
        private System.Windows.Forms.Button synthesisV1Button;
        private System.Windows.Forms.NumericUpDown levelValue;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button synthesisButton;
        private System.Windows.Forms.Button analysisButton;
    }
}

