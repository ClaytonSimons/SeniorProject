using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace UPClient
{
    class Client
    {
        ClientConnectionManager connection;
        KeyLogger keyLogger;
        Thread runThread;
        runningWnd UI;
        public Client(String serverAddress, runningWnd parent)
        {
            connection = new ClientConnectionManager(serverAddress);
        }
        public void Login()
        {
            
        }
        public void Register()
        {

        }
        public void SendData()
        {

        }
        public void Start()
        {

        }
        public void Stop()
        {

        }
    }
}
