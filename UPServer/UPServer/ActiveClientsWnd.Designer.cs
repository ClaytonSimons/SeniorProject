namespace UPServer
{
    partial class ActiveClientsWnd
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
            this.activeUsersChkLstBox = new System.Windows.Forms.CheckedListBox();
            this.setLearningBtn = new System.Windows.Forms.Button();
            this.setPredictingBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // activeUsersChkLstBox
            // 
            this.activeUsersChkLstBox.FormattingEnabled = true;
            this.activeUsersChkLstBox.Location = new System.Drawing.Point(12, 12);
            this.activeUsersChkLstBox.Name = "activeUsersChkLstBox";
            this.activeUsersChkLstBox.Size = new System.Drawing.Size(252, 274);
            this.activeUsersChkLstBox.TabIndex = 1;
            // 
            // setLearningBtn
            // 
            this.setLearningBtn.Location = new System.Drawing.Point(270, 12);
            this.setLearningBtn.Name = "setLearningBtn";
            this.setLearningBtn.Size = new System.Drawing.Size(120, 23);
            this.setLearningBtn.TabIndex = 2;
            this.setLearningBtn.Text = "Set Learning Mode";
            this.setLearningBtn.UseVisualStyleBackColor = true;
            // 
            // setPredictingBtn
            // 
            this.setPredictingBtn.Location = new System.Drawing.Point(270, 41);
            this.setPredictingBtn.Name = "setPredictingBtn";
            this.setPredictingBtn.Size = new System.Drawing.Size(120, 23);
            this.setPredictingBtn.TabIndex = 3;
            this.setPredictingBtn.Text = "Set Predicting Mode";
            this.setPredictingBtn.UseVisualStyleBackColor = true;
            // 
            // ActiveClients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 305);
            this.Controls.Add(this.setPredictingBtn);
            this.Controls.Add(this.setLearningBtn);
            this.Controls.Add(this.activeUsersChkLstBox);
            this.Name = "ActiveClients";
            this.Text = "User Prediction - ActiveClients";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox activeUsersChkLstBox;
        private System.Windows.Forms.Button setLearningBtn;
        private System.Windows.Forms.Button setPredictingBtn;
    }
}