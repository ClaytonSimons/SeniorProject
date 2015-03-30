namespace UPClient
{
    partial class StartWnd
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
            this.startBtn = new System.Windows.Forms.Button();
            this.predictionRadBtn = new System.Windows.Forms.RadioButton();
            this.learningRadBtn = new System.Windows.Forms.RadioButton();
            this.errorRTxt = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(12, 12);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(75, 23);
            this.startBtn.TabIndex = 0;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // predictionRadBtn
            // 
            this.predictionRadBtn.AutoSize = true;
            this.predictionRadBtn.Location = new System.Drawing.Point(171, 12);
            this.predictionRadBtn.Name = "predictionRadBtn";
            this.predictionRadBtn.Size = new System.Drawing.Size(102, 17);
            this.predictionRadBtn.TabIndex = 1;
            this.predictionRadBtn.TabStop = true;
            this.predictionRadBtn.Text = "Prediction Mode";
            this.predictionRadBtn.UseVisualStyleBackColor = true;
            // 
            // learningRadBtn
            // 
            this.learningRadBtn.AutoSize = true;
            this.learningRadBtn.Location = new System.Drawing.Point(171, 35);
            this.learningRadBtn.Name = "learningRadBtn";
            this.learningRadBtn.Size = new System.Drawing.Size(96, 17);
            this.learningRadBtn.TabIndex = 2;
            this.learningRadBtn.TabStop = true;
            this.learningRadBtn.Text = "Learning Mode";
            this.learningRadBtn.UseVisualStyleBackColor = true;
            // 
            // errorRTxt
            // 
            this.errorRTxt.BackColor = System.Drawing.SystemColors.Control;
            this.errorRTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorRTxt.ForeColor = System.Drawing.Color.Maroon;
            this.errorRTxt.Location = new System.Drawing.Point(12, 41);
            this.errorRTxt.Name = "errorRTxt";
            this.errorRTxt.Size = new System.Drawing.Size(153, 18);
            this.errorRTxt.TabIndex = 3;
            this.errorRTxt.Text = "";
            // 
            // StartWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 71);
            this.Controls.Add(this.errorRTxt);
            this.Controls.Add(this.learningRadBtn);
            this.Controls.Add(this.predictionRadBtn);
            this.Controls.Add(this.startBtn);
            this.Name = "StartWnd";
            this.Text = "User Prediction - Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.RadioButton predictionRadBtn;
        private System.Windows.Forms.RadioButton learningRadBtn;
        private System.Windows.Forms.RichTextBox errorRTxt;
    }
}

