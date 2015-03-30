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
    public partial class LoginWnd : Form
    {
        ActiveClientsWnd parent;
        UserClient target;
        public LoginWnd(ActiveClientsWnd p,UserClient t)
        {
            parent = p;
            target = t;
            InitializeComponent();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            bool passed = false;
            if (parent.proctor.CheckCredentials(usernameRTxt.Text, passwordRTxt.Text))
            {
                UserDBDataSetWorkerTableAdapters.UserClientTableAdapter adapter = new UserDBDataSetWorkerTableAdapters.UserClientTableAdapter();
                UserDBDataSetWorker.UserClientDataTable userTable = adapter.GetCheckCredentials(usernameRTxt.Text,passwordRTxt.Text);
                parent.proctor.GetConnection().SetLearning(target, userTable[0].UserName, userTable[0].Pass, userTable[0].UserID);
                Hide();
                parent.Populate();
            }
            else
            {
                //ask for resubmission with new username
            }
        }
    }
}
