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
    public partial class registrationWnd : Form
    {
        public registrationWnd()
        {
            InitializeComponent();
        }

        private void Closed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
