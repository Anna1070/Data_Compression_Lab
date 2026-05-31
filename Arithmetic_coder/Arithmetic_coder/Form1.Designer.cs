namespace Arithmetic_coder
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.inputText = new System.Windows.Forms.TextBox();
            this.compressButton = new System.Windows.Forms.Button();
            this.outputText = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.loadFileButton = new System.Windows.Forms.Button();
            this.loadEncodedFileButton = new System.Windows.Forms.Button();
            this.decodeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 15);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Testing side";
            // 
            // inputText
            // 
            this.inputText.Location = new System.Drawing.Point(16, 62);
            this.inputText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.inputText.Multiline = true;
            this.inputText.Name = "inputText";
            this.inputText.ReadOnly = true;
            this.inputText.Size = new System.Drawing.Size(231, 84);
            this.inputText.TabIndex = 1;
            // 
            // compressButton
            // 
            this.compressButton.Location = new System.Drawing.Point(289, 112);
            this.compressButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.compressButton.Name = "compressButton";
            this.compressButton.Size = new System.Drawing.Size(129, 34);
            this.compressButton.TabIndex = 2;
            this.compressButton.Text = "Compress";
            this.compressButton.UseVisualStyleBackColor = true;
            this.compressButton.Click += new System.EventHandler(this.compressButton_Click);
            // 
            // outputText
            // 
            this.outputText.Location = new System.Drawing.Point(16, 170);
            this.outputText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.outputText.Multiline = true;
            this.outputText.Name = "outputText";
            this.outputText.ReadOnly = true;
            this.outputText.Size = new System.Drawing.Size(231, 88);
            this.outputText.TabIndex = 3;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(16, 314);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(159, 116);
            this.listBox1.TabIndex = 4;
            // 
            // loadFileButton
            // 
            this.loadFileButton.Location = new System.Drawing.Point(289, 62);
            this.loadFileButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.loadFileButton.Name = "loadFileButton";
            this.loadFileButton.Size = new System.Drawing.Size(129, 34);
            this.loadFileButton.TabIndex = 5;
            this.loadFileButton.Text = "Load File";
            this.loadFileButton.UseVisualStyleBackColor = true;
            this.loadFileButton.Click += new System.EventHandler(this.loadFileButton_Click);
            // 
            // loadEncodedFileButton
            // 
            this.loadEncodedFileButton.Location = new System.Drawing.Point(289, 170);
            this.loadEncodedFileButton.Margin = new System.Windows.Forms.Padding(4);
            this.loadEncodedFileButton.Name = "loadEncodedFileButton";
            this.loadEncodedFileButton.Size = new System.Drawing.Size(129, 34);
            this.loadEncodedFileButton.TabIndex = 6;
            this.loadEncodedFileButton.Text = "Load File";
            this.loadEncodedFileButton.UseVisualStyleBackColor = true;
            this.loadEncodedFileButton.Click += new System.EventHandler(this.loadEncodedFileButton_Click);
            // 
            // decodeButton
            // 
            this.decodeButton.Location = new System.Drawing.Point(289, 224);
            this.decodeButton.Margin = new System.Windows.Forms.Padding(4);
            this.decodeButton.Name = "decodeButton";
            this.decodeButton.Size = new System.Drawing.Size(129, 34);
            this.decodeButton.TabIndex = 7;
            this.decodeButton.Text = "Decompress";
            this.decodeButton.UseVisualStyleBackColor = true;
            this.decodeButton.Click += new System.EventHandler(this.decodeButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 507);
            this.Controls.Add(this.decodeButton);
            this.Controls.Add(this.loadEncodedFileButton);
            this.Controls.Add(this.loadFileButton);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.outputText);
            this.Controls.Add(this.compressButton);
            this.Controls.Add(this.inputText);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox inputText;
        private System.Windows.Forms.Button compressButton;
        private System.Windows.Forms.TextBox outputText;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button loadFileButton;
        private System.Windows.Forms.Button loadEncodedFileButton;
        private System.Windows.Forms.Button decodeButton;
    }
}

