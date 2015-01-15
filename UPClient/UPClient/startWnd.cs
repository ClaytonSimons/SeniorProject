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
        loginWnd login = new loginWnd();
        registrationWnd registration = new registrationWnd();
        public startWnd()
        {
            InitializeComponent();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            if(predictionRadBtn.Checked)
            {
                login.Show();
                Hide();
            }
            else if(learningRadBtn.Checked)
            {
                registration.Show();
                Hide();
            }
        }
    }
}
