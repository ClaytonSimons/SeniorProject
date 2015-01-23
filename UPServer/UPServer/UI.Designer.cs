namespace UPServer
{
    partial class UI
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
            this.activeClientsBtn = new System.Windows.Forms.Button();
            this.usersBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // activeClientsBtn
            // 
            this.activeClientsBtn.Location = new System.Drawing.Point(12, 12);
            this.activeClientsBtn.Name = "activeClientsBtn";
            this.activeClientsBtn.Size = new System.Drawing.Size(125, 23);
            this.activeClientsBtn.TabIndex = 0;
            this.activeClientsBtn.Text = "Active Clients";
            this.activeClientsBtn.UseVisualStyleBackColor = true;
            this.activeClientsBtn.Click += new System.EventHandler(this.activeClientsBtn_Click);
            // 
            // usersBtn
            // 
            this.usersBtn.Location = new System.Drawing.Point(156, 12);
            this.usersBtn.Name = "usersBtn";
            this.usersBtn.Size = new System.Drawing.Size(127, 23);
            this.usersBtn.TabIndex = 1;
            this.usersBtn.Text = "All Users";
            this.usersBtn.UseVisualStyleBackColor = true;
            this.usersBtn.Click += new System.EventHandler(this.usersBtn_Click);
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 55);
            this.Controls.Add(this.usersBtn);
            this.Controls.Add(this.activeClientsBtn);
            this.Name = "UI";
            this.Text = "User Prediction Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Closed);
            this.Load += new System.EventHandler(this.UI_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button activeClientsBtn;
        private System.Windows.Forms.Button usersBtn;
    }
}

