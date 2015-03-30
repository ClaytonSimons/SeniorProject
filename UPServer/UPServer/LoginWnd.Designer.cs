namespace UPServer
{
    partial class LoginWnd
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
            this.registrationBtn = new System.Windows.Forms.Button();
            this.errorTxt = new System.Windows.Forms.TextBox();
            this.submitBtn = new System.Windows.Forms.Button();
            this.passwordTxt = new System.Windows.Forms.TextBox();
            this.usernameTxt = new System.Windows.Forms.TextBox();
            this.passwordRTxt = new System.Windows.Forms.RichTextBox();
            this.usernameRTxt = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // registrationBtn
            // 
            this.registrationBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.registrationBtn.Location = new System.Drawing.Point(265, 33);
            this.registrationBtn.Name = "registrationBtn";
            this.registrationBtn.Size = new System.Drawing.Size(75, 23);
            this.registrationBtn.TabIndex = 19;
            this.registrationBtn.Text = "Register";
            this.registrationBtn.UseVisualStyleBackColor = true;
            // 
            // errorTxt
            // 
            this.errorTxt.BackColor = System.Drawing.SystemColors.Control;
            this.errorTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorTxt.ForeColor = System.Drawing.Color.DarkRed;
            this.errorTxt.Location = new System.Drawing.Point(184, 16);
            this.errorTxt.Name = "errorTxt";
            this.errorTxt.Size = new System.Drawing.Size(200, 13);
            this.errorTxt.TabIndex = 18;
            // 
            // submitBtn
            // 
            this.submitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.submitBtn.Location = new System.Drawing.Point(265, 87);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(75, 23);
            this.submitBtn.TabIndex = 17;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // passwordTxt
            // 
            this.passwordTxt.BackColor = System.Drawing.SystemColors.Control;
            this.passwordTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordTxt.Location = new System.Drawing.Point(12, 68);
            this.passwordTxt.Name = "passwordTxt";
            this.passwordTxt.Size = new System.Drawing.Size(100, 13);
            this.passwordTxt.TabIndex = 16;
            this.passwordTxt.Text = "Password";
            // 
            // usernameTxt
            // 
            this.usernameTxt.BackColor = System.Drawing.SystemColors.Control;
            this.usernameTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usernameTxt.Location = new System.Drawing.Point(12, 16);
            this.usernameTxt.Name = "usernameTxt";
            this.usernameTxt.Size = new System.Drawing.Size(100, 13);
            this.usernameTxt.TabIndex = 15;
            this.usernameTxt.Text = "Username";
            // 
            // passwordRTxt
            // 
            this.passwordRTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordRTxt.Location = new System.Drawing.Point(12, 87);
            this.passwordRTxt.Name = "passwordRTxt";
            this.passwordRTxt.Size = new System.Drawing.Size(225, 27);
            this.passwordRTxt.TabIndex = 14;
            this.passwordRTxt.Text = "";
            // 
            // usernameRTxt
            // 
            this.usernameRTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usernameRTxt.Location = new System.Drawing.Point(12, 35);
            this.usernameRTxt.Name = "usernameRTxt";
            this.usernameRTxt.Size = new System.Drawing.Size(225, 27);
            this.usernameRTxt.TabIndex = 13;
            this.usernameRTxt.Text = "";
            // 
            // LoginWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 140);
            this.Controls.Add(this.registrationBtn);
            this.Controls.Add(this.errorTxt);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.passwordTxt);
            this.Controls.Add(this.usernameTxt);
            this.Controls.Add(this.passwordRTxt);
            this.Controls.Add(this.usernameRTxt);
            this.Name = "LoginWnd";
            this.Text = "UserPrediction - Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button registrationBtn;
        private System.Windows.Forms.TextBox errorTxt;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.TextBox passwordTxt;
        private System.Windows.Forms.TextBox usernameTxt;
        private System.Windows.Forms.RichTextBox passwordRTxt;
        private System.Windows.Forms.RichTextBox usernameRTxt;
    }
}