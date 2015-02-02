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
            testclient.SetUsername("Clay");
            testclient.SetPass("Simons");
            List<KeyData.KeyEntry> testdata = new List<KeyData.KeyEntry>();
            testdata.Add(new KeyData.KeyEntry((Byte)'h', 12345, "type"));
            testdata.Add(new KeyData.KeyEntry((Byte)'e', 12355, "type"));
            testdata.Add(new KeyData.KeyEntry((Byte)'l', 12375, "type"));
            testdata.Add(new KeyData.KeyEntry((Byte)'l', 12395, "type"));
            testdata.Add(new KeyData.KeyEntry((Byte)'o', 12595, "type"));
            testdata.Add(new KeyData.KeyEntry((Byte)' ', 12745, "type"));
            testdata.Add(new KeyData.KeyEntry((Byte)' ', 12755, "type"));
            testdata.Add(new KeyData.KeyEntry((Byte)'t', 12765, "type"));
            testdata.Add(new KeyData.KeyEntry((Byte)'o', 12775, "type"));
            testdata.Add(new KeyData.KeyEntry((Byte)' ', 12785, "type"));
            SaveData(testclient, testdata);
        }
        public bool SaveData(UserClient client, List<KeyData.KeyEntry> data)
        {
            UserDBDataSetWorker.WordDataRow Data = dataSet.WordData.NewWordDataRow();
            List<UserDBDataSetWorker.WordDataRow> words = new List<UserDBDataSetWorker.WordDataRow>();
            String PKBT,CKBT;//Previous and current keyboard type
            PKBT = data[0].keyboardType;
            List<UserDBDataSetWorker.TimingRow> timingEntries = new List<UserDBDataSetWorker.TimingRow>();
            int Ptime = Ptime = 0, Ctime = 0;
            Data.Word = "";
            foreach(KeyData.KeyEntry entry in data)//extract data from parameter data
            {
                UserDBDataSetWorker.TimingRow timingEntry = dataSet.Timing.NewTimingRow();
                Ctime = entry.time;
                timingEntry.Timing = Ctime - Ptime;
                CKBT = entry.keyboardType;
                if(entry.keyValue == ':' || entry.keyValue == ',' || entry.keyValue == ' ')
                {
                    if (Data.Word != "")
                    {
                        Data.KeyboardType = keyToInt(CKBT);
                        words.Add(Data);
                    }
                    Data = dataSet.WordData.NewWordDataRow();
                    Data.Word = "";
                    Ctime = 0;
                }
                else if (CKBT != PKBT)
                {
                    if (Data.Word != "")
                    {
                        Data.KeyboardType = keyToInt(CKBT);
                        words.Add(Data);
                    }
                    Data = dataSet.WordData.NewWordDataRow();
                    Data.Word = "";
                    Ctime = 0;
                    Data.Word += entry.keyValue.ToString();
                }
                else
                {
                    Data.Word += (char)entry.keyValue;
                    if (timingEntry.Timing != Ctime)
                        timingEntries.Add(timingEntry);
                }
                Ptime = Ctime;
                PKBT = CKBT;
            }
            foreach (UserDBDataSetWorker.WordDataRow word in words)
            {
                UserDBDataSetWorker.WordDataRow newWord = dataSet.WordData.NewWordDataRow();
                //dataSet.WordData.AddWordDataRow();
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
    }
}
