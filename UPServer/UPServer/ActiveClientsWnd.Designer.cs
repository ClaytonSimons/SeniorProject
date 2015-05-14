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
            this.setLearningBtn = new System.Windows.Forms.Button();
            this.setPredictingBtn = new System.Windows.Forms.Button();
            this.activeClientsLstView = new System.Windows.Forms.ListView();
            this.User = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UserID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PredictedUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PredictedUserID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PercentSure = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.medianModeBtn = new System.Windows.Forms.Button();
            this.meanModeBtn = new System.Windows.Forms.Button();
            this.compareModeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // setLearningBtn
            // 
            this.setLearningBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.setLearningBtn.Location = new System.Drawing.Point(387, 12);
            this.setLearningBtn.Name = "setLearningBtn";
            this.setLearningBtn.Size = new System.Drawing.Size(120, 23);
            this.setLearningBtn.TabIndex = 2;
            this.setLearningBtn.Text = "Set Learning Mode";
            this.setLearningBtn.UseVisualStyleBackColor = true;
            this.setLearningBtn.Click += new System.EventHandler(this.setLearningBtn_Click);
            // 
            // setPredictingBtn
            // 
            this.setPredictingBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.setPredictingBtn.Location = new System.Drawing.Point(387, 41);
            this.setPredictingBtn.Name = "setPredictingBtn";
            this.setPredictingBtn.Size = new System.Drawing.Size(120, 23);
            this.setPredictingBtn.TabIndex = 3;
            this.setPredictingBtn.Text = "Set Predicting Mode";
            this.setPredictingBtn.UseVisualStyleBackColor = true;
            this.setPredictingBtn.Click += new System.EventHandler(this.setPredictingBtn_Click);
            // 
            // activeClientsLstView
            // 
            this.activeClientsLstView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.activeClientsLstView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.User,
            this.UserID,
            this.PredictedUser,
            this.PredictedUserID,
            this.PercentSure});
            this.activeClientsLstView.FullRowSelect = true;
            this.activeClientsLstView.Location = new System.Drawing.Point(12, 12);
            this.activeClientsLstView.Name = "activeClientsLstView";
            this.activeClientsLstView.Size = new System.Drawing.Size(369, 274);
            this.activeClientsLstView.TabIndex = 4;
            this.activeClientsLstView.UseCompatibleStateImageBehavior = false;
            this.activeClientsLstView.View = System.Windows.Forms.View.Details;
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
            // PredictedUser
            // 
            this.PredictedUser.Text = "Predicted User";
            this.PredictedUser.Width = 91;
            // 
            // PredictedUserID
            // 
            this.PredictedUserID.Text = "Predicted UserID";
            this.PredictedUserID.Width = 94;
            // 
            // PercentSure
            // 
            this.PercentSure.Text = "%";
            // 
            // medianModeBtn
            // 
            this.medianModeBtn.Location = new System.Drawing.Point(387, 263);
            this.medianModeBtn.Name = "medianModeBtn";
            this.medianModeBtn.Size = new System.Drawing.Size(120, 23);
            this.medianModeBtn.TabIndex = 11;
            this.medianModeBtn.Text = "Median Mode";
            this.medianModeBtn.UseVisualStyleBackColor = true;
            this.medianModeBtn.Click += new System.EventHandler(this.medianModeBtn_Click);
            // 
            // meanModeBtn
            // 
            this.meanModeBtn.Location = new System.Drawing.Point(387, 234);
            this.meanModeBtn.Name = "meanModeBtn";
            this.meanModeBtn.Size = new System.Drawing.Size(120, 23);
            this.meanModeBtn.TabIndex = 10;
            this.meanModeBtn.Text = "Mean Mode";
            this.meanModeBtn.UseVisualStyleBackColor = true;
            this.meanModeBtn.Click += new System.EventHandler(this.meanModeBtn_Click);
            // 
            // compareModeBtn
            // 
            this.compareModeBtn.Location = new System.Drawing.Point(387, 205);
            this.compareModeBtn.Name = "compareModeBtn";
            this.compareModeBtn.Size = new System.Drawing.Size(120, 23);
            this.compareModeBtn.TabIndex = 9;
            this.compareModeBtn.Text = "Compare Mode";
            this.compareModeBtn.UseVisualStyleBackColor = true;
            this.compareModeBtn.Click += new System.EventHandler(this.compareModeBtn_Click);
            // 
            // ActiveClientsWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 310);
            this.Controls.Add(this.medianModeBtn);
            this.Controls.Add(this.meanModeBtn);
            this.Controls.Add(this.compareModeBtn);
            this.Controls.Add(this.activeClientsLstView);
            this.Controls.Add(this.setPredictingBtn);
            this.Controls.Add(this.setLearningBtn);
            this.Name = "ActiveClientsWnd";
            this.Text = "User Prediction - ActiveClients";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button setLearningBtn;
        private System.Windows.Forms.Button setPredictingBtn;
        private System.Windows.Forms.ListView activeClientsLstView;
        private System.Windows.Forms.ColumnHeader User;
        private System.Windows.Forms.ColumnHeader UserID;
        private System.Windows.Forms.ColumnHeader PredictedUser;
        private System.Windows.Forms.ColumnHeader PredictedUserID;
        private System.Windows.Forms.ColumnHeader PercentSure;
        private System.Windows.Forms.Button medianModeBtn;
        private System.Windows.Forms.Button meanModeBtn;
        private System.Windows.Forms.Button compareModeBtn;
    }
}