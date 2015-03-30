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
    public partial class AllUsersWnd : Form
    {
        Proctor proctor;
        public AllUsersWnd(Proctor p)
        {
            InitializeComponent();
            proctor = p;
            Populate();
        }
        /// <summary>
        /// Add users on database to screen.
        /// </summary>
        public void Populate()
        {
            UserDBDataSetWorkerTableAdapters.UserClientTableAdapter adapter = new UserDBDataSetWorkerTableAdapters.UserClientTableAdapter();
            UserDBDataSetWorker.UserClientDataTable userTable = adapter.GetUserWordCount();
            allUsersLstView.Items.Clear();
            foreach (UserDBDataSetWorker.UserClientRow row in userTable)
            {
                string[] subItems = new string[3];
                subItems[0] = row.UserName;
                subItems[1] = row.UserID.ToString(); 
                subItems[2] = row.ItemArray[3].ToString();
                allUsersLstView.Items.Add(new ListViewItem(subItems));
            }
        }

        private void Closing(object sender, FormClosingEventArgs e)
        {
        }

        private void resetLearningBtn_Click(object sender, EventArgs e)
        {
            if (allUsersLstView.FocusedItem != null)
            {
                int userID = int.Parse(allUsersLstView.FocusedItem.SubItems[1].Text);
                UserDBDataSetWorkerTableAdapters.WordDataTableAdapter wordAdapter = new UserDBDataSetWorkerTableAdapters.WordDataTableAdapter();
                UserDBDataSetWorkerTableAdapters.TimingTableAdapter timingAdapter = new UserDBDataSetWorkerTableAdapters.TimingTableAdapter();
                timingAdapter.DeleteByUserID(userID);
                wordAdapter.DeleteByUserID(userID);
                Populate();
            }
        }
    }
}
