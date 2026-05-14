namespace Fractal_image_coder
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
            this.decodedImgBox = new System.Windows.Forms.PictureBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.loadOrigImgButton = new System.Windows.Forms.Button();
            this.saveProcessedButton = new System.Windows.Forms.Button();
            this.processButton = new System.Windows.Forms.Button();
            this.loadInitialImgButton = new System.Windows.Forms.Button();
            this.loadProcessedImgButton = new System.Windows.Forms.Button();
            this.decodeButton = new System.Windows.Forms.Button();
            this.saveDecodedButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.numberStepsDecode = new System.Windows.Forms.NumericUpDown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.psnrValueTextBox = new System.Windows.Forms.TextBox();
            this.parametersRangeTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.originalImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.decodedImgBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberStepsDecode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // originalImageBox
            // 
            this.originalImageBox.Location = new System.Drawing.Point(42, 26);
            this.originalImageBox.Name = "originalImageBox";
            this.originalImageBox.Size = new System.Drawing.Size(390, 346);
            this.originalImageBox.TabIndex = 0;
            this.originalImageBox.TabStop = false;
            // 
            // decodedImgBox
            // 
            this.decodedImgBox.Location = new System.Drawing.Point(677, 26);
            this.decodedImgBox.Name = "decodedImgBox";
            this.decodedImgBox.Size = new System.Drawing.Size(390, 346);
            this.decodedImgBox.TabIndex = 1;
            this.decodedImgBox.TabStop = false;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(42, 394);
            this.progressBar.Maximum = 4095;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1025, 26);
            this.progressBar.TabIndex = 2;
            // 
            // loadOrigImgButton
            // 
            this.loadOrigImgButton.Location = new System.Drawing.Point(42, 444);
            this.loadOrigImgButton.Name = "loadOrigImgButton";
            this.loadOrigImgButton.Size = new System.Drawing.Size(98, 36);
            this.loadOrigImgButton.TabIndex = 3;
            this.loadOrigImgButton.Text = "Load";
            this.loadOrigImgButton.UseVisualStyleBackColor = true;
            this.loadOrigImgButton.Click += new System.EventHandler(this.loadOrigImgButton_Click);
            // 
            // saveProcessedButton
            // 
            this.saveProcessedButton.Location = new System.Drawing.Point(42, 495);
            this.saveProcessedButton.Name = "saveProcessedButton";
            this.saveProcessedButton.Size = new System.Drawing.Size(98, 36);
            this.saveProcessedButton.TabIndex = 4;
            this.saveProcessedButton.Text = "Save";
            this.saveProcessedButton.UseVisualStyleBackColor = true;
            this.saveProcessedButton.Click += new System.EventHandler(this.saveProcessedButton_Click);
            // 
            // processButton
            // 
            this.processButton.Location = new System.Drawing.Point(157, 444);
            this.processButton.Name = "processButton";
            this.processButton.Size = new System.Drawing.Size(98, 36);
            this.processButton.TabIndex = 5;
            this.processButton.Text = "Process";
            this.processButton.UseVisualStyleBackColor = true;
            this.processButton.Click += new System.EventHandler(this.processButton_Click);
            // 
            // loadInitialImgButton
            // 
            this.loadInitialImgButton.Location = new System.Drawing.Point(855, 444);
            this.loadInitialImgButton.Name = "loadInitialImgButton";
            this.loadInitialImgButton.Size = new System.Drawing.Size(98, 36);
            this.loadInitialImgButton.TabIndex = 6;
            this.loadInitialImgButton.Text = "Load Initial";
            this.loadInitialImgButton.UseVisualStyleBackColor = true;
            // 
            // loadProcessedImgButton
            // 
            this.loadProcessedImgButton.Location = new System.Drawing.Point(969, 440);
            this.loadProcessedImgButton.Name = "loadProcessedImgButton";
            this.loadProcessedImgButton.Size = new System.Drawing.Size(98, 45);
            this.loadProcessedImgButton.TabIndex = 7;
            this.loadProcessedImgButton.Text = "Load Processed";
            this.loadProcessedImgButton.UseVisualStyleBackColor = true;
            // 
            // decodeButton
            // 
            this.decodeButton.Location = new System.Drawing.Point(969, 495);
            this.decodeButton.Name = "decodeButton";
            this.decodeButton.Size = new System.Drawing.Size(98, 36);
            this.decodeButton.TabIndex = 8;
            this.decodeButton.Text = "Decode";
            this.decodeButton.UseVisualStyleBackColor = true;
            // 
            // saveDecodedButton
            // 
            this.saveDecodedButton.Location = new System.Drawing.Point(969, 546);
            this.saveDecodedButton.Name = "saveDecodedButton";
            this.saveDecodedButton.Size = new System.Drawing.Size(98, 36);
            this.saveDecodedButton.TabIndex = 9;
            this.saveDecodedButton.Text = "Save";
            this.saveDecodedButton.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(827, 500);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(54, 22);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "#steps";
            // 
            // numberStepsDecode
            // 
            this.numberStepsDecode.Location = new System.Drawing.Point(887, 500);
            this.numberStepsDecode.Name = "numberStepsDecode";
            this.numberStepsDecode.Size = new System.Drawing.Size(66, 22);
            this.numberStepsDecode.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(534, 444);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(234, 206);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(343, 444);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(160, 140);
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // psnrValueTextBox
            // 
            this.psnrValueTextBox.Location = new System.Drawing.Point(905, 600);
            this.psnrValueTextBox.Multiline = true;
            this.psnrValueTextBox.Name = "psnrValueTextBox";
            this.psnrValueTextBox.Size = new System.Drawing.Size(162, 32);
            this.psnrValueTextBox.TabIndex = 14;
            // 
            // parametersRangeTextBox
            // 
            this.parametersRangeTextBox.Location = new System.Drawing.Point(42, 553);
            this.parametersRangeTextBox.Multiline = true;
            this.parametersRangeTextBox.Name = "parametersRangeTextBox";
            this.parametersRangeTextBox.Size = new System.Drawing.Size(199, 84);
            this.parametersRangeTextBox.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 677);
            this.Controls.Add(this.parametersRangeTextBox);
            this.Controls.Add(this.psnrValueTextBox);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.numberStepsDecode);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.saveDecodedButton);
            this.Controls.Add(this.decodeButton);
            this.Controls.Add(this.loadProcessedImgButton);
            this.Controls.Add(this.loadInitialImgButton);
            this.Controls.Add(this.processButton);
            this.Controls.Add(this.saveProcessedButton);
            this.Controls.Add(this.loadOrigImgButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.decodedImgBox);
            this.Controls.Add(this.originalImageBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.originalImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.decodedImgBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberStepsDecode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox originalImageBox;
        private System.Windows.Forms.PictureBox decodedImgBox;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button loadOrigImgButton;
        private System.Windows.Forms.Button saveProcessedButton;
        private System.Windows.Forms.Button processButton;
        private System.Windows.Forms.Button loadInitialImgButton;
        private System.Windows.Forms.Button loadProcessedImgButton;
        private System.Windows.Forms.Button decodeButton;
        private System.Windows.Forms.Button saveDecodedButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.NumericUpDown numberStepsDecode;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox psnrValueTextBox;
        private System.Windows.Forms.TextBox parametersRangeTextBox;
    }
}

