﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using KeyData;

namespace UPClient
{
    public class Client
    {
        ClientConnectionManager connection;
        KeyLogger keyLogger;
        Thread runThread;
        RunningWnd UI;
        int ID;
        public Client(String serverAddress, RunningWnd parent)
        {
            keyLogger = new KeyLogger();
            connection = new ClientConnectionManager(serverAddress);
            UI = parent;
            try
            {
                connection.Connect();
            }
            catch(Exception e)
            {
                UI.parent.ErrorMessage("Could not connect to Server");
            }
            runThread = new Thread(new ThreadStart(SendData));
            runThread.Start();
        }
        public bool Login(String UserName, String Password)
        {
            bool answer = connection.CheckCredentials(UserName, Password);
            if(answer)
            {
                connection.SendMessage("Learning");
            }
            return answer;
        }
        public bool Register(String UserName, String Password)
        {
            bool answer = connection.RegisterCredentials(UserName,Password);
            if (answer)
            {
                connection.SendMessage("Learning");
            }
            return answer;
        }
        public void SendData()
        {
            while(connection.Connected)
            {
                if (keyLogger.GetData().Count > 100 && keyLogger != null)
                {

                    connection.SendData(keyLogger.GetData());
                    keyLogger.GetData().Clear();
                }
                System.Threading.Thread.Sleep(2000);
            }
        }
        public void Start()
        {
            if(!keyLogger.IsActive)
                keyLogger.Start();
        }
        public void Stop()
        {
            if(keyLogger.IsActive)
                keyLogger.Stop();
            connection.SendMessage("Disconnect");
            connection.Disconnect();
        }
        public bool isConnected()
        {
            return connection.Connected;
        }
    }
}
