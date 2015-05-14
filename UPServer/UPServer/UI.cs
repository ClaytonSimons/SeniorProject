using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UPServer
{
    public partial class UI : Form
    {
        Proctor proctor;
        AllUsersWnd allWnd;
        ActiveClientsWnd activeWnd;
        public UI()
        {
            InitializeComponent();
            proctor = new Proctor();
        }

        private void UI_Load(object sender, EventArgs e)
        {

        }

        private void usersBtn_Click(object sender, EventArgs e)
        {
            if (allWnd != null)
            {
                allWnd.Close();
            }
            allWnd = new AllUsersWnd(proctor);
            allWnd.Show(); 
        }

        private void activeClientsBtn_Click(object sender, EventArgs e)
        {
            if (activeWnd != null)
            {
                activeWnd.Close();
            }
            activeWnd = new ActiveClientsWnd(proctor);
            activeWnd.Show();
        }

        private void Closed(object sender, FormClosedEventArgs e)
        {
            proctor.GetConnection().Stop();
            if(allWnd != null)
                allWnd.Close();
            if(activeWnd != null)
                activeWnd.Close();
        }
    }
}
