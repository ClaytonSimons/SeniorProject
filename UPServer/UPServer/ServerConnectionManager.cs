using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace UPServer
{
    public class ServerConnectionManager
    {
        private List<UserClient> clients = new List<UserClient>();
        bool connected;
        List<UserClient> learningClients;
        Proctor proctor;
        List<UserClient> predictingClients;
        NetworkStream networkStream;
        StreamReader reader;
        StreamWriter writer;
        TcpListener server;
        Thread runThread;
        public ServerConnectionManager(Proctor p)
        {
            proctor = p;
            server = new TcpListener(1711);
            runThread = new Thread(new ThreadStart(Run));
            runThread.Start();
        }
        public void DisconnectClient(UserClient client)
        {
            client.Disconnect();
        }
        public List<UserClient> GetClients()
        {
            return clients;
        }
        public List<UserClient> GetPredictingClients()
        {
            return predictingClients;
        }
        public void Run()
        {
            try
            {
                server.Start();
                connected = true;
                while(connected)
                {
                    UserClient client = new UserClient(server.AcceptTcpClient(),proctor);
                    clients.Add(client);
                }
            }
            catch(Exception e)
            {
                
            }
        }
        public void Stop()
        {
            connected = false;
            server.Stop();
        }
        public void SetLearning(UserClient client, String Name, int ID)
        {

        }
        public void SetPredicting(UserClient client)
        {
            
        }
    }
}
