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
    public partial class runningWnd : Form
    {
        public Client client;
        private startWnd parent;
        public runningWnd(startWnd p)
        {
            InitializeComponent();
            parent = p;
            //Need to retrieve serverAddress from an external txt file or something.
            client = new Client("localhost", this);
        }
        public void updateError(String msg)
        {
            errorTxt.Text = msg;
        }
        public void clearError()
        {
            errorTxt.Text = "";
        }

        private void HasClosed(object sender, FormClosedEventArgs e)
        {
            client.Stop();
            parent.Show();
        }
        private void stopBtn_Click(object sender, EventArgs e)
        {
            client.Stop();
            parent.Show();
            Close();
        }
    }
}
