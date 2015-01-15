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
        Client client;
        public runningWnd()
        {
            InitializeComponent();
        }
        public void updateError(String msg)
        {
            errorTxt.Text = msg;
        }
        public void clearError()
        {
            errorTxt.Text = "";
        }

        private void Closed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
