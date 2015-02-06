using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Configuration;

namespace UPServer
{
    public class UserData
    {
        SqlConnection connection;
        UserDBDataSetWorker dataSet;
        public UserData()
        {
            dataSet = new UserDBDataSetWorker();
            UserClient testclient = new UserClient();
            //testclient.SetUsername("Clay");
            //testclient.SetPass("Simons");
            //List<KeyData.KeyEntry> testdata = new List<KeyData.KeyEntry>();
            //testdata.Add(new KeyData.KeyEntry((Byte)'h', 12345, "type"));
            //testdata.Add(new KeyData.KeyEntry((Byte)'e', 12355, "type"));
            //testdata.Add(new KeyData.KeyEntry((Byte)'l', 12375, "type"));
            //testdata.Add(new KeyData.KeyEntry((Byte)'l', 12395, "type"));
            //testdata.Add(new KeyData.KeyEntry((Byte)'o', 12595, "type"));
            //testdata.Add(new KeyData.KeyEntry((Byte)' ', 12745, "type"));
            //testdata.Add(new KeyData.KeyEntry((Byte)' ', 12755, "type"));
            //testdata.Add(new KeyData.KeyEntry((Byte)'t', 12765, "type"));
            //testdata.Add(new KeyData.KeyEntry((Byte)'o', 12775, "type"));
            //SaveData(testclient, testdata);
        }
        public bool SaveData(UserClient client, List<KeyData.KeyEntry> data)
        {
            WordInsert Data = new WordInsert();
            List<WordInsert> words = new List<WordInsert>();
            String PKBT,CKBT;//Previous and current keyboard type
            PKBT = data[0].keyboardType;
            List<UserDBDataSetWorker.TimingRow> timingEntries = new List<UserDBDataSetWorker.TimingRow>();
            int Ptime = Ptime = 0, Ctime = 0;
            Data.word = "";
            foreach(KeyData.KeyEntry entry in data)//extract data from parameter data
            {
                UserDBDataSetWorker.TimingRow timingEntry = dataSet.Timing.NewTimingRow();
                Ctime = entry.time;
                timingEntry.Timing = Ctime - Ptime;
                CKBT = entry.keyboardType;
                if(entry.keyValue == ':' || entry.keyValue == ',' || entry.keyValue == ' ')
                {
                    if (Data.word != "")
                    {
                        Data.KeyboardType = keyToInt(CKBT);
                        Data.UserID = GetUserClientID(client.GetName(), client.GetPass());
                        words.Add(Data);
                    }
                    Data = new WordInsert();
                    Data.word = "";
                    Ctime = 0;
                }
                else if (CKBT != PKBT)
                {
                    if (Data.word != "")
                    {
                        Data.KeyboardType = keyToInt(CKBT);
                        Data.UserID = GetUserClientID(client.GetName(), client.GetPass());
                        words.Add(Data);
                    }
                    Data = new WordInsert();
                    Data.word = "";
                    Ctime = 0;
                    Data.word += entry.keyValue.ToString();
                }
                else
                {
                    Data.word += (char)entry.keyValue;
                    if (timingEntry.Timing != Ctime)
                        timingEntries.Add(timingEntry);
                }
                Ptime = Ctime;
                PKBT = CKBT;
            }
            //Get straggling data.
            Data.KeyboardType = keyToInt(data[data.Count-1].keyboardType);
            Data.UserID = GetUserClientID(client.GetName(), client.GetPass());
            words.Add(Data);

            foreach (WordInsert word in words)//enter words
            {
                UserDBDataSetWorkerTableAdapters.WordDataTableAdapter adapter = new UserDBDataSetWorkerTableAdapters.WordDataTableAdapter();
                int test1 = GetUserClientID(client.GetName(), client.GetPass());
                adapter.WordInsert(test1, word.word, word.KeyboardType);
                int test = GetLatestWordID();
                for (int i = 1; i < word.word.Length;i++)//enter timing for words
                {
                    UserDBDataSetWorkerTableAdapters.TimingTableAdapter timeAdapter = new UserDBDataSetWorkerTableAdapters.TimingTableAdapter();
                    timeAdapter.TimingInsert(GetLatestWordID(),timingEntries[i].Timing,i);
                }
            }
            return true;
        }
        public int keyToInt(string keyboardType)
        {
            int answer = -1;
            switch(keyboardType)
            {
                case "00000409":
                    answer = 1;
                    break;
                case "00002009":
                    answer = 1;
                    break;
                case "00002409":
                    answer = 1;
                    break;
                case "00020409":
                    answer = 2;
                    break;
                case "00010409":
                    answer = 3;
                    break;
                case "00030409":
                    answer = 4;
                    break;
                case "00040409":
                    answer = 5;
                    break;
                default:
                    break;
            }
            return answer;
        }
        private int GetUserClientID(String UserName, String Password)
        {
            UserDBDataSetWorkerTableAdapters.UserClientTableAdapter checkAdapter = new UserDBDataSetWorkerTableAdapters.UserClientTableAdapter();
            UserDBDataSetWorker.UserClientDataTable table = new UserDBDataSetWorker.UserClientDataTable();
            checkAdapter.CheckCredentials(table, UserName, Password);
            if (table.Count == 1)
                return table[0].UserID;
            return -1;
        }
        public bool CheckCredentials(String UserName, String Password)
        {

            UserDBDataSetWorkerTableAdapters.UserClientTableAdapter checkAdapter = new UserDBDataSetWorkerTableAdapters.UserClientTableAdapter();
            UserDBDataSetWorker.UserClientDataTable table = new UserDBDataSetWorker.UserClientDataTable();
            checkAdapter.CheckCredentials(table,UserName,Password);
            if (table.Count == 1)
                return true;
            return false;
        }
        public bool RegisterCredentials(String UserName, String Password)
        {
            bool answer = false;
            if(!CheckCredentials(UserName,Password))//if username and password is not in the database already.
            {
                UserDBDataSetWorkerTableAdapters.UserClientTableAdapter adapter = new UserDBDataSetWorkerTableAdapters.UserClientTableAdapter();
                adapter.UserClientInsert(UserName, Password);
                answer = true;
            }
            return answer;
        }
        public int GetLatestWordID()
        {
            int answer = 0;
            UserDBDataSetWorkerTableAdapters.WordDataTableAdapter adapter = new UserDBDataSetWorkerTableAdapters.WordDataTableAdapter();
            UserDBDataSetWorker.UserClientDataTable table = new UserDBDataSetWorker.UserClientDataTable();
            answer = adapter.MaxWordID().Value;
            return answer;
        }
    }
    public struct WordInsert
    {
        public String word;
        public int[] timing;
        public int WordID;
        public int UserID;
        public int KeyboardType;
    }
}
