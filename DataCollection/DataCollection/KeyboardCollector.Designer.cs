namespace DataCollection
{
    partial class KeyboardCollector
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
            this.DataLstBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // DataLstBox
            // 
            this.DataLstBox.FormattingEnabled = true;
            this.DataLstBox.Location = new System.Drawing.Point(3, 49);
            this.DataLstBox.Name = "DataLstBox";
            this.DataLstBox.Size = new System.Drawing.Size(232, 251);
            this.DataLstBox.TabIndex = 0;
            // 
            // KeyboardCollector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 296);
            this.Controls.Add(this.DataLstBox);
            this.Name = "KeyboardCollector";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox DataLstBox;
    }
}

