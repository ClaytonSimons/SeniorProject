using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace UPClient
{
    class ClientConnectionManager:TcpClient
    {
        String serverAddress;
        NetworkStream networkStream;
        StreamWriter serverWriter;
        StreamReader serverReader;
        bool connected;
        public ClientConnectionManager(String ServerAddress)
        {
            serverAddress = ServerAddress;
            connected = false;
        }
        public bool CheckCredentials(String UserName, String Password)
        {
            return true;
        }
        private void ReadLoop()
        {
            String msg;
            while(connected)
            {
                try
                {
                    msg = serverReader.ReadLine();
                    switch(msg)
                    {
                        default:
                            break;
                    }
                }
                catch(Exception e)
                {
                    Debug.WriteLine(e);
                }
            }
        }
        public bool SendData(String UserName, String Password, List<KeyEntry> Data)
        {
            bool success = true;
            if (connected)
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(networkStream, Data);
            }
            else
                success = false;
            return success;
        }
        public bool RegisterCredentials(String UserName, String Password)
        {
            return true;
        }
        public void Connect()
        {
            Connect(serverAddress, 1711);
            networkStream = GetStream();
            serverWriter = new StreamWriter(networkStream);
            serverReader = new StreamReader(networkStream);
            connected = true;
            Thread readThread = new Thread(new ThreadStart(ReadLoop));
            readThread.Start();
        }
        public void Disconnect()
        {
            connected = false;
            networkStream.Close();
            Close();
        }
    }
}
