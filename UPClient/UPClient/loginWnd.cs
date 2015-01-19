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
    public partial class loginWnd : Form
    {
        startWnd parent;
        runningWnd running;
        registrationWnd registration;
        public loginWnd(startWnd p)
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
            if(running == null)
                running = new runningWnd(parent);
            if (running.client.Login(usernameRTxt.Text, passwordRTxt.Text))
            {
                running.Show();
                Hide();
            }
            else
            {
                //ask for resubmission with new username
            }
        }

        private void registrationBtn_Click(object sender, EventArgs e)
        {
            registration = new registrationWnd(parent);
            registration.Show();
            Close();
        }
    }
}
