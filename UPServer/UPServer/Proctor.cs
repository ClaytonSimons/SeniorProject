using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using KeyData;

namespace UPServer
{
    public class Proctor
    {
        private ServerConnectionManager connection;
        private UserData database;
        private Thread predictThread;
        private bool predicting = false;
        private ActiveClientsWnd activeClientWnd;
        public bool needsUpdate = false;
        ~Proctor()
        {
            if (predictThread != null && predictThread.IsAlive)
                predictThread.Abort();
        }
        public Proctor()
        {
            connection = new ServerConnectionManager(this);
            database = new UserData();
        }
        public void SaveData(UserClient client, List<KeyData.KeyEntry> data)
        {
            bool GotHere = database.SaveData(client, data);
        }
        public void StartPrediction(ActiveClientsWnd wnd)
        {
            activeClientWnd = wnd;
            predictThread = new Thread(new ThreadStart(RunPrediction));
            predicting = true;
            predictThread.Start();
        }
        public void StopPrediction()
        {
            predicting = false;
            predictThread = null;
        }
        public void RunPrediction()
        {
            while (predicting)
            {
                //Monitor.Enter();
                List<KeyValuePair<UserClient, KeyValuePair<int, double>>> answer = Predict();
                if (answer.Count > 0 && answer[0].Value.Value != 0)
                {
                    bool didSomething = true;
                    activeClientWnd.UpdatePredictions(answer);
                }
                if (needsUpdate)
                {
                    activeClientWnd.Populate();
                    needsUpdate = false;
                }
                Thread.Sleep(1000);
            }
        }
        public List<KeyValuePair<UserClient, KeyValuePair<int, double>>> Predict()
        {
            List<UserClient> Pclients = connection.GetPredictingClients();
            List<KeyValuePair<UserClient, KeyValuePair<int, double>>> predictions = new List<KeyValuePair<UserClient, KeyValuePair<int, double>>>();
            //foreach (UserClient client in Pclients)
            for(int i = 0; i<Pclients.Count;i++)
            {
                predictions.Add(new KeyValuePair<UserClient,KeyValuePair<int,double>>(Pclients[i],predict(Pclients[i])));
            }
            return predictions;
        }
        private KeyValuePair<int, double> predict(UserClient client)
        {
            KeyValuePair<int, double> answer;
            List<KeyValuePair<int, double>> answerlist = new List<KeyValuePair<int, double>>();
            double likeness = 0;
            List<WordData> predictionData = ToWords(client.GetPredictionData());
            if (predictionData.Count > 0)
            {
                UserDBDataSetWorkerTableAdapters.UserClientTableAdapter userAdapt = new UserDBDataSetWorkerTableAdapters.UserClientTableAdapter();
                UserDBDataSetWorker.UserClientDataTable userTable = userAdapt.GetUserClientData();
                foreach (UserDBDataSetWorker.UserClientRow userRow in userTable)
                {
                    int count = 0;
                    foreach (WordData word in predictionData)
                    {
                        UserDBDataSetWorkerTableAdapters.WordDataTableAdapter wordAdapt = new UserDBDataSetWorkerTableAdapters.WordDataTableAdapter();
                        UserDBDataSetWorker.WordDataDataTable wordTable = wordAdapt.GetDataByUserIDandWord(userRow.UserID, word.GetWord());
                        if (wordTable.Count > 0)
                        {
                            foreach (UserDBDataSetWorker.WordDataRow wordRow in wordTable)
                            {
                                UserDBDataSetWorkerTableAdapters.TimingTableAdapter timeAdapt = new UserDBDataSetWorkerTableAdapters.TimingTableAdapter();
                                UserDBDataSetWorker.TimingDataTable timeTable = timeAdapt.GetDataByWordID(wordRow.WordID);
                                if (timeTable.Count > 0)
                                {
                                    int[] timing = new int[timeTable.Count];
                                    for (int i = 0; i < timeTable.Count; i++)
                                    {
                                        timing[i] = timeTable[i].Timing;
                                    }
                                    double comp = Compare(word, new WordData(wordRow.Word, timing, userRow.UserID));
                                    if (comp > 0)
                                    {
                                        likeness += Compare(word, new WordData(wordRow.Word, timing, userRow.UserID));
                                        count++;
                                    }
                                }
                            }
                        }
                    }
                    answerlist.Add(new KeyValuePair<int, double>(userRow.UserID, likeness / count));
                    bool problem;
                    if (likeness/count > 1)
                        problem = true;
                    likeness = 0;
                    count = 0;
                }
            }
            if (answerlist.Count > 1)
                answer = MaxValue(answerlist);//most probable prediction
            else
                answer = new KeyValuePair<int, double>(0, 0);
            return answer;
        }
        private KeyValuePair<int,double> MaxValue(List<KeyValuePair<int,double>> list)
        {
            KeyValuePair<int,double> answer = list[0];
            for(int i = 1; i < list.Count; i++)
            {
                if (list[i].Value > answer.Value)
                    answer = list[i];
            }
            return answer;
        }
        public double Compare(WordData word1, WordData word2)
        {
            double answer = 0;
            if (word1.GetWord().Length == word2.GetWord().Length)
            {
                double tolerance = 50;
                int length = word1.GetWord().Length-1;
                int count = 0;
                for (int i = 0; i < length; i++)
                {
                    double numerator = tolerance;
                    if (i < length && i < word2.GetWord().Length - 1)
                    {
                        numerator -= Math.Abs(word1.GetTiming()[i] - word2.GetTiming()[i]);
                        answer += numerator / tolerance;
                        count++;
                    }
                }
                answer = answer / (count);
                if (answer < 0)
                    answer = 0;
                bool stop;
                if(answer > 1)
                    stop = true;
            }
            return answer;
        }
        private List<WordData> ToWords(List<KeyEntry> data)
        {
            List<WordData> answer = new List<WordData>();
            String word = "";
            int ctime = 0, ptime = 0;
            List<int> timing = new List<int>();
            String KeyboardType = "";
            foreach (KeyEntry entry in data)
            {
                if (KeyboardType == "")
                    KeyboardType = entry.keyboardType;
                if (entry.keyValue == ' ' || entry.keyValue == ',' || entry.keyValue == ':' || KeyboardType != entry.keyboardType)
                {
                    int[] time = new int[timing.Count];
                    for (int i = 0; i < timing.Count; i++)
                    {
                        time[i] = timing[i];
                    }
                    timing.Clear();
                    if(word != "")
                        answer.Add(new WordData(word, time, -1));
                    word = "";
                    ctime = 0;
                    ptime = 0;
                }
                else
                {
                    word += (char)entry.keyValue;
                    ctime = entry.time;
                    if (ctime - ptime > 0 && word.Length > 1)
                        timing.Add(ctime - ptime);
                    ptime = ctime;
                    KeyboardType = entry.keyboardType;
                }
            }
            return answer;
        }
        public ServerConnectionManager GetConnection()
        {
            return connection;
        }
        public bool CheckCredentials(String UserName, String Password)
        {
            return database.CheckCredentials(UserName, Password);
        }
        public bool RegisterCredentials(String UserName, String Password)
        {
            return database.RegisterCredentials(UserName, Password);
        }
        public UserClient GetUserInfo(String name, String pass)
        {
            UserClient answer = new UserClient();
            UserDBDataSetWorkerTableAdapters.UserClientTableAdapter adapter = new UserDBDataSetWorkerTableAdapters.UserClientTableAdapter();
            answer.SetID((int)adapter.GetUserID(name,pass));
            answer.SetUsername(name);
            answer.SetPass(pass);
            return answer;
        }
    }
}