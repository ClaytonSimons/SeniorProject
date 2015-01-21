﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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
        int userID;
        String userName;
        TcpClient client;
        bool connected;
        public UserClient(TcpClient c)
        {
            client = c;
            networkStream = client.GetStream();
            streamReader = new StreamReader(networkStream);
            Thread dataThread = new Thread(new ThreadStart(DataLoop));
            dataThread.Start();
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
        public void DataLoop()
        {
            while (connected)
            {
                IFormatter formatter = new BinaryFormatter();
                List<KeyEntry> entry = (List<KeyEntry>)formatter.Deserialize(networkStream);
            }
        }
        public void ReadLoop()
        {

        }
        public void SaveData(UserClient client, List<KeyEntry> data)
        {

        }
        public void SetID(int id)
        {

        }
        public void SetUsername(String name)
        {

        }
    }
}
