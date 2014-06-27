namespace PolarFileConverter
{
    partial class PolarFileConverterForm
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.selectFilesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // selectFilesButton
            // 
            this.selectFilesButton.Location = new System.Drawing.Point(12, 12);
            this.selectFilesButton.Name = "selectFilesButton";
            this.selectFilesButton.Size = new System.Drawing.Size(130, 23);
            this.selectFilesButton.TabIndex = 0;
            this.selectFilesButton.Text = "Select files to convert";
            this.selectFilesButton.UseVisualStyleBackColor = true;
            this.selectFilesButton.Click += new System.EventHandler(this.selectFilesButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 431);
            this.Controls.Add(this.selectFilesButton);
            this.Name = "Form1";
            this.Text = "PolarFileConverter";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button selectFilesButton;
    }
}

