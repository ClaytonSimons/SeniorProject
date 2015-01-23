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
using KeyData;

namespace UPClient
{
    class ClientConnectionManager:TcpClient
    {
        String serverAddress;
        NetworkStream networkStream;
        StreamWriter serverWriter;
        StreamReader serverReader;
        public ClientConnectionManager(String ServerAddress)
        {
            serverAddress = ServerAddress == "localhost" ? "127.0.0.1" : ServerAddress;
        }
        public bool CheckCredentials(String UserName, String Password)
        {
            return true;
        }
        private void ReadLoop()
        {
            String msg;
            while(Connected)
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
        public bool SendData(List<KeyEntry> Data)
        {
            bool success = true;
            if (Connected)
            {
                IFormatter formatter = new BinaryFormatter();
                List<KeyEntry> listtest = new List<KeyEntry>();
                //KeyEntry test = new KeyEntry(new Byte(), 123, "test Type");
                //listtest.Add(test);
                //listtest.Add(test);
                //listtest.Add(test);
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
            Thread readThread = new Thread(new ThreadStart(ReadLoop));
            readThread.Start();
        }
        public void Disconnect()
        {
            networkStream.Close();
            Close();
        }
    }
}
