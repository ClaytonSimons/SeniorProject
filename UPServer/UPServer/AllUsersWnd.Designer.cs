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
            this.allUsersLstView = new System.Windows.Forms.ListView();
            this.User = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UserID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.WordCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // resetLearningBtn
            // 
            this.resetLearningBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.resetLearningBtn.Location = new System.Drawing.Point(307, 9);
            this.resetLearningBtn.Name = "resetLearningBtn";
            this.resetLearningBtn.Size = new System.Drawing.Size(120, 23);
            this.resetLearningBtn.TabIndex = 3;
            this.resetLearningBtn.Text = "Reset Learning Data";
            this.resetLearningBtn.UseVisualStyleBackColor = true;
            this.resetLearningBtn.Click += new System.EventHandler(this.resetLearningBtn_Click);
            // 
            // allUsersLstView
            // 
            this.allUsersLstView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.allUsersLstView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.User,
            this.UserID,
            this.WordCount});
            this.allUsersLstView.FullRowSelect = true;
            this.allUsersLstView.Location = new System.Drawing.Point(12, 9);
            this.allUsersLstView.Name = "allUsersLstView";
            this.allUsersLstView.Size = new System.Drawing.Size(289, 278);
            this.allUsersLstView.TabIndex = 5;
            this.allUsersLstView.UseCompatibleStateImageBehavior = false;
            this.allUsersLstView.View = System.Windows.Forms.View.Details;
            // 
            // User
            // 
            this.User.Text = "User";
            this.User.Width = 79;
            // 
            // UserID
            // 
            this.UserID.Text = "UserID";
            this.UserID.Width = 74;
            // 
            // WordCount
            // 
            this.WordCount.Text = "Word Count";
            this.WordCount.Width = 85;
            // 
            // AllUsersWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 299);
            this.Controls.Add(this.allUsersLstView);
            this.Controls.Add(this.resetLearningBtn);
            this.Name = "AllUsersWnd";
            this.Text = "User Predictor - AllUsers";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button resetLearningBtn;
        private System.Windows.Forms.ListView allUsersLstView;
        private System.Windows.Forms.ColumnHeader User;
        private System.Windows.Forms.ColumnHeader UserID;
        private System.Windows.Forms.ColumnHeader WordCount;
    }
}