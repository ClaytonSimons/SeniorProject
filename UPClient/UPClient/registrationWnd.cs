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
    public partial class RegistrationWnd : Form
    {
        StartWnd parent;
        RunningWnd running;
        public RegistrationWnd(StartWnd p)
        {
            InitializeComponent();
            parent = p;
        }

        private void HasClosed(object sender, FormClosedEventArgs e)
        {
            parent.Show();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (running == null)
                running = new RunningWnd(parent);
            if (running.client.Register(usernameRTxt.Text, passwordRTxt.Text))
            {
                running.Show();
                Hide();
                running.Start();
            }
            else
            {
                //ask for resubmission with new username
            }
        }
    }
}
