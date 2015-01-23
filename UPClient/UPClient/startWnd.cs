﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UPClient
{
    public partial class StartWnd : Form
    {
        RunningWnd running;
        LoginWnd login;
        public StartWnd()
        {
            InitializeComponent();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            if(predictionRadBtn.Checked)
            {
                running = new RunningWnd(this);
                running.Show();
                Hide();
            }
            else if(learningRadBtn.Checked)
            {
                login = new LoginWnd(this);
                login.Show();
                Hide();
            }
        }
    }
}
