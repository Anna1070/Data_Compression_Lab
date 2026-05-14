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
            this.domainPictureBox = new System.Windows.Forms.PictureBox();
            this.rangePictureBox = new System.Windows.Forms.PictureBox();
            this.psnrValueTextBox = new System.Windows.Forms.TextBox();
            this.parametersRangeTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.originalImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.decodedImgBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberStepsDecode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.domainPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rangePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // originalImageBox
            // 
            this.originalImageBox.Location = new System.Drawing.Point(32, 21);
            this.originalImageBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.originalImageBox.Name = "originalImageBox";
            this.originalImageBox.Size = new System.Drawing.Size(512, 512);
            this.originalImageBox.TabIndex = 0;
            this.originalImageBox.TabStop = false;
            this.originalImageBox.Paint += new System.Windows.Forms.PaintEventHandler(this.originalImageBox_Paint);
            this.originalImageBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.originalImageBox_MouseClick);
            // 
            // decodedImgBox
            // 
            this.decodedImgBox.Location = new System.Drawing.Point(727, 21);
            this.decodedImgBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.decodedImgBox.Name = "decodedImgBox";
            this.decodedImgBox.Size = new System.Drawing.Size(512, 512);
            this.decodedImgBox.TabIndex = 1;
            this.decodedImgBox.TabStop = false;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(32, 566);
            this.progressBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.progressBar.Maximum = 4096;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(769, 21);
            this.progressBar.TabIndex = 2;
            // 
            // loadOrigImgButton
            // 
            this.loadOrigImgButton.Location = new System.Drawing.Point(32, 607);
            this.loadOrigImgButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.loadOrigImgButton.Name = "loadOrigImgButton";
            this.loadOrigImgButton.Size = new System.Drawing.Size(74, 29);
            this.loadOrigImgButton.TabIndex = 3;
            this.loadOrigImgButton.Text = "Load";
            this.loadOrigImgButton.UseVisualStyleBackColor = true;
            this.loadOrigImgButton.Click += new System.EventHandler(this.loadOrigImgButton_Click);
            // 
            // saveProcessedButton
            // 
            this.saveProcessedButton.Location = new System.Drawing.Point(32, 648);
            this.saveProcessedButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.saveProcessedButton.Name = "saveProcessedButton";
            this.saveProcessedButton.Size = new System.Drawing.Size(74, 29);
            this.saveProcessedButton.TabIndex = 4;
            this.saveProcessedButton.Text = "Save";
            this.saveProcessedButton.UseVisualStyleBackColor = true;
            this.saveProcessedButton.Click += new System.EventHandler(this.saveProcessedButton_Click);
            // 
            // processButton
            // 
            this.processButton.Location = new System.Drawing.Point(118, 607);
            this.processButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.processButton.Name = "processButton";
            this.processButton.Size = new System.Drawing.Size(74, 29);
            this.processButton.TabIndex = 5;
            this.processButton.Text = "Process";
            this.processButton.UseVisualStyleBackColor = true;
            this.processButton.Click += new System.EventHandler(this.processButton_Click);
            // 
            // loadInitialImgButton
            // 
            this.loadInitialImgButton.Location = new System.Drawing.Point(1079, 569);
            this.loadInitialImgButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.loadInitialImgButton.Name = "loadInitialImgButton";
            this.loadInitialImgButton.Size = new System.Drawing.Size(74, 29);
            this.loadInitialImgButton.TabIndex = 6;
            this.loadInitialImgButton.Text = "Load Initial";
            this.loadInitialImgButton.UseVisualStyleBackColor = true;
            this.loadInitialImgButton.Click += new System.EventHandler(this.loadInitialImgButton_Click);
            // 
            // loadProcessedImgButton
            // 
            this.loadProcessedImgButton.Location = new System.Drawing.Point(1165, 566);
            this.loadProcessedImgButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.loadProcessedImgButton.Name = "loadProcessedImgButton";
            this.loadProcessedImgButton.Size = new System.Drawing.Size(74, 37);
            this.loadProcessedImgButton.TabIndex = 7;
            this.loadProcessedImgButton.Text = "Load Processed";
            this.loadProcessedImgButton.UseVisualStyleBackColor = true;
            this.loadProcessedImgButton.Click += new System.EventHandler(this.loadProcessedImgButton_Click);
            // 
            // decodeButton
            // 
            this.decodeButton.Location = new System.Drawing.Point(1165, 610);
            this.decodeButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.decodeButton.Name = "decodeButton";
            this.decodeButton.Size = new System.Drawing.Size(74, 29);
            this.decodeButton.TabIndex = 8;
            this.decodeButton.Text = "Decode";
            this.decodeButton.UseVisualStyleBackColor = true;
            this.decodeButton.Click += new System.EventHandler(this.decodeButton_Click);
            // 
            // saveDecodedButton
            // 
            this.saveDecodedButton.Location = new System.Drawing.Point(1165, 652);
            this.saveDecodedButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.saveDecodedButton.Name = "saveDecodedButton";
            this.saveDecodedButton.Size = new System.Drawing.Size(74, 29);
            this.saveDecodedButton.TabIndex = 9;
            this.saveDecodedButton.Text = "Save";
            this.saveDecodedButton.UseVisualStyleBackColor = true;
            this.saveDecodedButton.Click += new System.EventHandler(this.saveDecodedButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1058, 614);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(42, 20);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "#steps";
            // 
            // numberStepsDecode
            // 
            this.numberStepsDecode.Location = new System.Drawing.Point(1103, 614);
            this.numberStepsDecode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numberStepsDecode.Name = "numberStepsDecode";
            this.numberStepsDecode.Size = new System.Drawing.Size(50, 20);
            this.numberStepsDecode.TabIndex = 11;
            // 
            // domainPictureBox
            // 
            this.domainPictureBox.Location = new System.Drawing.Point(641, 607);
            this.domainPictureBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.domainPictureBox.Name = "domainPictureBox";
            this.domainPictureBox.Size = new System.Drawing.Size(160, 160);
            this.domainPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.domainPictureBox.TabIndex = 12;
            this.domainPictureBox.TabStop = false;
            // 
            // rangePictureBox
            // 
            this.rangePictureBox.Location = new System.Drawing.Point(481, 607);
            this.rangePictureBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rangePictureBox.Name = "rangePictureBox";
            this.rangePictureBox.Size = new System.Drawing.Size(80, 80);
            this.rangePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rangePictureBox.TabIndex = 13;
            this.rangePictureBox.TabStop = false;
            // 
            // psnrValueTextBox
            // 
            this.psnrValueTextBox.Location = new System.Drawing.Point(1117, 696);
            this.psnrValueTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.psnrValueTextBox.Multiline = true;
            this.psnrValueTextBox.Name = "psnrValueTextBox";
            this.psnrValueTextBox.Size = new System.Drawing.Size(122, 27);
            this.psnrValueTextBox.TabIndex = 14;
            // 
            // parametersRangeTextBox
            // 
            this.parametersRangeTextBox.Location = new System.Drawing.Point(32, 695);
            this.parametersRangeTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.parametersRangeTextBox.Multiline = true;
            this.parametersRangeTextBox.Name = "parametersRangeTextBox";
            this.parametersRangeTextBox.Size = new System.Drawing.Size(150, 69);
            this.parametersRangeTextBox.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1327, 823);
            this.Controls.Add(this.parametersRangeTextBox);
            this.Controls.Add(this.psnrValueTextBox);
            this.Controls.Add(this.rangePictureBox);
            this.Controls.Add(this.domainPictureBox);
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
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.originalImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.decodedImgBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberStepsDecode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.domainPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rangePictureBox)).EndInit();
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
        private System.Windows.Forms.PictureBox domainPictureBox;
        private System.Windows.Forms.PictureBox rangePictureBox;
        private System.Windows.Forms.TextBox psnrValueTextBox;
        private System.Windows.Forms.TextBox parametersRangeTextBox;
    }
}

