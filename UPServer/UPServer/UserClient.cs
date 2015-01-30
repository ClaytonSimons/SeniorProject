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
        int userID;
        String userName;
        TcpClient client;
        bool connected;
        public UserClient()
        { }
        public UserClient(TcpClient c,Proctor p)
        {
            client = c;
            proctor = p;
            networkStream = client.GetStream();
            streamReader = new StreamReader(networkStream);
            streamWriter = new StreamWriter(networkStream);
            Thread readThread = new Thread(new ThreadStart(ReadLoop));
            readThread.Start();
        }
        public void Disconnect()
        {
            connected = false;
            streamReader.Close();
            networkStream.Close();
            client.Close();
        }
        public void DataCollection()
        {
            IFormatter formatter = new BinaryFormatter();
            try
            {
                List<KeyEntry> entry = (List<KeyEntry>)formatter.Deserialize(networkStream);
                proctor.SaveData(this,entry);
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
                case "CheckCredentials":
                    if (proctor.CheckCredentials(msg[1], msg[2]))
                        streamWriter.WriteLine("Response,true");
                    else
                        streamWriter.WriteLine("Response,false");
                    streamWriter.Flush();
                    break;
                case "Data":
                    DataCollection();
                    break;
                default:
                    break;
            }
        }
        public void SaveData(UserClient client, List<KeyEntry> data)
        {

        }
        public void SetID(int id)
        {

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
    }
}
