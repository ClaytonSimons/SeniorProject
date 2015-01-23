namespace UPClient
{
    partial class RunningWnd
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
            this.stopBtn = new System.Windows.Forms.Button();
            this.errorTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // stopBtn
            // 
            this.stopBtn.Location = new System.Drawing.Point(12, 12);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(265, 23);
            this.stopBtn.TabIndex = 0;
            this.stopBtn.Text = "Stop";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // errorTxt
            // 
            this.errorTxt.BackColor = System.Drawing.SystemColors.Control;
            this.errorTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorTxt.ForeColor = System.Drawing.Color.DarkRed;
            this.errorTxt.Location = new System.Drawing.Point(13, 42);
            this.errorTxt.Name = "errorTxt";
            this.errorTxt.Size = new System.Drawing.Size(100, 13);
            this.errorTxt.TabIndex = 1;
            // 
            // runningWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 67);
            this.Controls.Add(this.errorTxt);
            this.Controls.Add(this.stopBtn);
            this.Name = "runningWnd";
            this.Text = "User Predictor - Running";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HasClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.TextBox errorTxt;
    }
}