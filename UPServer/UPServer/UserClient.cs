using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
using KeyData;

namespace UPServer
{
    
    public class UserClient
    {
        ServerConnectionManager parent;
        String password;
        Proctor proctor;
        NetworkStream networkStream;
        StreamReader streamReader;
        StreamWriter streamWriter;
        int userID = -1;
        String userName;
        TcpClient client;
        bool learning;
        bool connected;
        Thread readThread;
        List<KeyEntry> predictionData = new List<KeyEntry>();

        public UserClient()
        { }
        ~UserClient()
        {
            if(readThread != null && readThread.IsAlive)
                readThread.Abort();
        }
        public UserClient(TcpClient c, Proctor p, ServerConnectionManager par)
        {
            client = c;
            parent = par;
            proctor = p;
            networkStream = client.GetStream();
            streamReader = new StreamReader(networkStream);
            streamWriter = new StreamWriter(networkStream);
            readThread = new Thread(new ThreadStart(ReadLoop));
            readThread.Start();
            learning = false;
            userName = parent.UniqueName();
        }
        public override string ToString()
        {
            String idString;
            if (userID != -1)
                idString = userName +
                    ", UserID:" + userID;
            else
                idString = "Unknown User";
            return idString;
        }
        public void Disconnect()
        {
            connected = false;
            streamReader.Close();
            networkStream.Close();
            client.Close();
            readThread.Abort();
        }
        public void DataCollection()
        {
            IFormatter formatter = new BinaryFormatter();
            try
            {
                List<KeyEntry> entry = (List<KeyEntry>)formatter.Deserialize(networkStream);
                if (learning)
                    proctor.SaveData(this, entry);
                else
                    SaveData(entry);
            }
            catch(Exception e)
            {
                Debug.Write(e);
            }
        }
        public void ReadLoop()
        {
            while(client.Connected)
            {
                try
                {
                    String msg = streamReader.ReadLine();
                    string[] comp = msg.Split(',');
                    HandleMessage(comp);
                }
                catch(Exception e)
                {
                    Debug.WriteLine(e);
                }
            }
        }
        private void HandleMessage(string[] msg)
        {
            switch (msg[0])
            {
                case "Username":
                    SetUsername(msg[1]);
                    break;
                case "Password":
                    SetPass(msg[1]);
                    parent.AddToLearning(this);
                    break;
                case "CheckCredentials":
                    if (proctor.CheckCredentials(msg[1], msg[2]))
                    {
                        streamWriter.WriteLine("Response,true");
                        UserClient temp = proctor.GetUserInfo(msg[1], msg[2]);
                        userName = temp.userName;
                        password = temp.password;
                        userID = temp.userID;
                    }
                    else
                        streamWriter.WriteLine("Response,false");
                    streamWriter.Flush();
                    break;
                case "RegisterCredentials":
                    if (proctor.RegisterCredentials(msg[1], msg[2]))
                    {
                        streamWriter.WriteLine("Response,true");
                        UserClient temp = proctor.GetUserInfo(msg[1],msg[2]);
                        userName = temp.userName;
                        password = temp.password;
                        userID = temp.userID;
                    }
                    else
                        streamWriter.WriteLine("Response,false");
                    streamWriter.Flush();
                    
                    break;
                case "Data":
                    DataCollection();
                    break;
                case "Learning":
                    learning = true;
                    parent.AddToLearning(this);
                    break;
                case "Disconnect":
                    parent.DisconnectClient(this);
                    break;
                default:
                    break;
            }
        }
        public void SaveData(List<KeyEntry> data)
        {
            predictionData.AddRange(data);
        }
        public void SetID(int id)
        {
            userID = id;
        }
        public int GetID()
        {
            return userID;
        }
        public void SetUsername(String name)
        {
            userName = name;
            if(connected)
            {
                
            }
        }
        public void SetPass(String pass)
        {
            password = pass;
        }
        public String GetName()
        {
            return userName;
        }
        public String GetPass()
        {
            return password;
        }
        public bool isLearning()
        {
            return learning;
        }
        public void SetLearning(bool value)
        {
            learning = value;
        }
        public List<KeyEntry> GetPredictionData()
        {
            return predictionData;
        }
    }
}
