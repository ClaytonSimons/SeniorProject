namespace UPServer
{
    partial class AllUsersWnd
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
            this.resetLearningBtn = new System.Windows.Forms.Button();
            this.allUsersChkLstBox = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // resetLearningBtn
            // 
            this.resetLearningBtn.Location = new System.Drawing.Point(286, 12);
            this.resetLearningBtn.Name = "resetLearningBtn";
            this.resetLearningBtn.Size = new System.Drawing.Size(120, 23);
            this.resetLearningBtn.TabIndex = 3;
            this.resetLearningBtn.Text = "Reset Learning Data";
            this.resetLearningBtn.UseVisualStyleBackColor = true;
            // 
            // allUsersChkLstBox
            // 
            this.allUsersChkLstBox.FormattingEnabled = true;
            this.allUsersChkLstBox.Location = new System.Drawing.Point(12, 12);
            this.allUsersChkLstBox.Name = "allUsersChkLstBox";
            this.allUsersChkLstBox.Size = new System.Drawing.Size(250, 274);
            this.allUsersChkLstBox.TabIndex = 4;
            // 
            // AllUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 292);
            this.Controls.Add(this.allUsersChkLstBox);
            this.Controls.Add(this.resetLearningBtn);
            this.Name = "AllUsers";
            this.Text = "User Predictor - AllUsers";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button resetLearningBtn;
        private System.Windows.Forms.CheckedListBox allUsersChkLstBox;
    }
}