namespace UPClient
{
    partial class RegistrationWnd
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
            this.submitBtn = new System.Windows.Forms.Button();
            this.usernameRTxt = new System.Windows.Forms.RichTextBox();
            this.passwordRTxt = new System.Windows.Forms.RichTextBox();
            this.passwordRTxt2 = new System.Windows.Forms.RichTextBox();
            this.usernameTxt = new System.Windows.Forms.TextBox();
            this.passwordTxt = new System.Windows.Forms.TextBox();
            this.passwordTxt2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(306, 154);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(75, 23);
            this.submitBtn.TabIndex = 0;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // usernameRTxt
            // 
            this.usernameRTxt.Location = new System.Drawing.Point(21, 38);
            this.usernameRTxt.Name = "usernameRTxt";
            this.usernameRTxt.Size = new System.Drawing.Size(225, 27);
            this.usernameRTxt.TabIndex = 1;
            this.usernameRTxt.Text = "";
            // 
            // passwordRTxt
            // 
            this.passwordRTxt.Location = new System.Drawing.Point(21, 97);
            this.passwordRTxt.Name = "passwordRTxt";
            this.passwordRTxt.Size = new System.Drawing.Size(225, 27);
            this.passwordRTxt.TabIndex = 2;
            this.passwordRTxt.Text = "";
            // 
            // passwordRTxt2
            // 
            this.passwordRTxt2.Location = new System.Drawing.Point(21, 156);
            this.passwordRTxt2.Name = "passwordRTxt2";
            this.passwordRTxt2.Size = new System.Drawing.Size(225, 27);
            this.passwordRTxt2.TabIndex = 3;
            this.passwordRTxt2.Text = "";
            // 
            // usernameTxt
            // 
            this.usernameTxt.BackColor = System.Drawing.SystemColors.Control;
            this.usernameTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usernameTxt.Location = new System.Drawing.Point(21, 12);
            this.usernameTxt.Name = "usernameTxt";
            this.usernameTxt.Size = new System.Drawing.Size(100, 13);
            this.usernameTxt.TabIndex = 4;
            this.usernameTxt.Text = "Username";
            // 
            // passwordTxt
            // 
            this.passwordTxt.BackColor = System.Drawing.SystemColors.Control;
            this.passwordTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordTxt.Location = new System.Drawing.Point(21, 71);
            this.passwordTxt.Name = "passwordTxt";
            this.passwordTxt.Size = new System.Drawing.Size(100, 13);
            this.passwordTxt.TabIndex = 5;
            this.passwordTxt.Text = "Password";
            // 
            // passwordTxt2
            // 
            this.passwordTxt2.BackColor = System.Drawing.SystemColors.Control;
            this.passwordTxt2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordTxt2.Location = new System.Drawing.Point(21, 130);
            this.passwordTxt2.Name = "passwordTxt2";
            this.passwordTxt2.Size = new System.Drawing.Size(100, 13);
            this.passwordTxt2.TabIndex = 6;
            this.passwordTxt2.Text = "Confirm Password";
            // 
            // registrationWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 204);
            this.Controls.Add(this.passwordTxt2);
            this.Controls.Add(this.passwordTxt);
            this.Controls.Add(this.usernameTxt);
            this.Controls.Add(this.passwordRTxt2);
            this.Controls.Add(this.passwordRTxt);
            this.Controls.Add(this.usernameRTxt);
            this.Controls.Add(this.submitBtn);
            this.Name = "registrationWnd";
            this.Text = "User Predictor - Registration";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HasClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.RichTextBox usernameRTxt;
        private System.Windows.Forms.RichTextBox passwordRTxt;
        private System.Windows.Forms.RichTextBox passwordRTxt2;
        private System.Windows.Forms.TextBox usernameTxt;
        private System.Windows.Forms.TextBox passwordTxt;
        private System.Windows.Forms.TextBox passwordTxt2;
    }
}