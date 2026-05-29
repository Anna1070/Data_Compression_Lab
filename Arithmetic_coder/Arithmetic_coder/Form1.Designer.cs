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
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Testing side";
            // 
            // inputText
            // 
            this.inputText.Location = new System.Drawing.Point(12, 50);
            this.inputText.Multiline = true;
            this.inputText.Name = "inputText";
            this.inputText.ReadOnly = true;
            this.inputText.Size = new System.Drawing.Size(174, 69);
            this.inputText.TabIndex = 1;
            // 
            // compressButton
            // 
            this.compressButton.Location = new System.Drawing.Point(217, 91);
            this.compressButton.Name = "compressButton";
            this.compressButton.Size = new System.Drawing.Size(97, 28);
            this.compressButton.TabIndex = 2;
            this.compressButton.Text = "Compress";
            this.compressButton.UseVisualStyleBackColor = true;
            this.compressButton.Click += new System.EventHandler(this.compressButton_Click);
            // 
            // outputText
            // 
            this.outputText.Location = new System.Drawing.Point(12, 138);
            this.outputText.Multiline = true;
            this.outputText.Name = "outputText";
            this.outputText.ReadOnly = true;
            this.outputText.Size = new System.Drawing.Size(174, 72);
            this.outputText.TabIndex = 3;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 255);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 95);
            this.listBox1.TabIndex = 4;
            // 
            // loadFileButton
            // 
            this.loadFileButton.Location = new System.Drawing.Point(217, 50);
            this.loadFileButton.Name = "loadFileButton";
            this.loadFileButton.Size = new System.Drawing.Size(97, 28);
            this.loadFileButton.TabIndex = 5;
            this.loadFileButton.Text = "Load File";
            this.loadFileButton.UseVisualStyleBackColor = true;
            this.loadFileButton.Click += new System.EventHandler(this.loadFileButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 412);
            this.Controls.Add(this.loadFileButton);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.outputText);
            this.Controls.Add(this.compressButton);
            this.Controls.Add(this.inputText);
            this.Controls.Add(this.textBox1);
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
    }
}

