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
    public partial class ActiveClientsWnd : Form
    {
        public Proctor proctor;
        LoginWnd loginWnd;
        delegate void SetPredictionTextCallback(List<KeyValuePair<UserClient, KeyValuePair<int, double>>> data);
        delegate void PopulateCallback();
        public ActiveClientsWnd(Proctor p)
        {
            InitializeComponent();
            proctor = p;
            proctor.StartPrediction(this);
            Populate();
        }
        public void Populate()
        {
            if (activeClientsLstView.InvokeRequired)
            {
                PopulateCallback d = new PopulateCallback(Populate);
                this.Invoke(d);
            }
            else
            {
                List<UserClient> dat = proctor.GetConnection().GetClients();
                activeClientsLstView.Items.Clear();
                foreach (UserClient client in dat)
                {
                    string[] subItems = new string[5];
                    subItems[0] = client.GetName();
                    subItems[1] = client.GetID().ToString();
                    ListViewItem item = new ListViewItem(subItems);
                    item.Name = client.GetName();
                    item.SubItems[1].Name = "UserID";
                    item.SubItems[2].Name = "PredictedUser";
                    item.SubItems[3].Name = "PredictedUserID";
                    item.SubItems[4].Name = "PercentSure";
                    activeClientsLstView.Items.Add(item);
                }
            }
        }
        /// <summary>
        /// Updates the activeClientListView predictions for predicting mode clients.
        /// </summary>
        /// <param name="data">
        /// The prediction data from proctor.
        /// </param>
        public void UpdatePredictions(List<KeyValuePair<UserClient, KeyValuePair<int, double>>> data)
        {
            if (activeClientsLstView.InvokeRequired)
            {
                SetPredictionTextCallback d = new SetPredictionTextCallback(UpdatePredictions);
                this.Invoke(d, data);
            }
            else
            {
                if (activeClientsLstView.Items.Count > 0 && data.Count > 0)
                    foreach (KeyValuePair<UserClient, KeyValuePair<int, double>> prediction in data)
                    {
                        UserDBDataSetWorkerTableAdapters.UserClientTableAdapter adapter = new UserDBDataSetWorkerTableAdapters.UserClientTableAdapter();
                        UserDBDataSetWorker.UserClientDataTable userClientTable = adapter.GetDataByUserID(prediction.Value.Key);
                        ListViewItem item = activeClientsLstView.Items[prediction.Key.GetName()];
                        ListViewItem test = activeClientsLstView.Items[0];
                        item.SubItems[2].Text = userClientTable[0].UserName;
                        item.SubItems[3].Text = userClientTable[0].UserID.ToString();
                        item.SubItems[4].Text = (prediction.Value.Value * 100).ToString();
                    }
            }
        }
        private void Closing(object sender, FormClosingEventArgs e)
        {
            proctor.StopPrediction();
            proctor.SaveAnswers();
        }

        private void setLearningBtn_Click(object sender, EventArgs e)
        {
            if (activeClientsLstView.FocusedItem != null)
            {
                UserClient temp = proctor.GetConnection().GetClientByName(activeClientsLstView.FocusedItem.Text);
                if (temp != null)
                {
                    loginWnd = new LoginWnd(this, temp);
                    loginWnd.Show();
                }
            }
            Populate();
        }

        private void setPredictingBtn_Click(object sender, EventArgs e)
        {
            if (activeClientsLstView.FocusedItem != null)
            {
                UserClient temp = proctor.GetConnection().GetClientByName(activeClientsLstView.FocusedItem.Text);
                if (temp != null)
                {
                    proctor.GetConnection().SetPredicting(temp);
                }
            }
            Populate();
        }
        private void compareModeBtn_Click(object sender, EventArgs e)
        {
            proctor.predictionMode = 0;
        }

        private void meanModeBtn_Click(object sender, EventArgs e)
        {
            proctor.predictionMode = 1;
        }

        private void medianModeBtn_Click(object sender, EventArgs e)
        {
            proctor.predictionMode = 2;
        }
    }
}