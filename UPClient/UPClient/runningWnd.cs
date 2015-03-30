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
    public partial class RunningWnd : Form
    {
        public Client client;
        public StartWnd parent;
        public RunningWnd(StartWnd p)
        {
            InitializeComponent();
            parent = p;
            //Need to retrieve serverAddress from an external txt file or something.

            client = new Client("WORKER", this);
        }
        public void updateError(String msg)
        {
            errorTxt.Text = msg;
        }
        public void clearError()
        {
            errorTxt.Text = "";
        }
        public void Start()
        {
            client.Start();
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
