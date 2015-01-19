using System;
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
    public partial class startWnd : Form
    {
        runningWnd running;
        loginWnd login;
        public startWnd()
        {
            InitializeComponent();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            if(predictionRadBtn.Checked)
            {
                running = new runningWnd(this);
                running.Show();
                Hide();
            }
            else if(learningRadBtn.Checked)
            {
                login = new loginWnd(this);
                login.Show();
                Hide();
            }
        }
    }
}
