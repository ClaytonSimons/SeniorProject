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
        List<UserClient> learningClients = new List<UserClient>();
        Proctor proctor;
        List<UserClient> predictingClients = new List<UserClient>();
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
        ~ServerConnectionManager()
        {
            if (runThread != null && runThread.IsAlive)
                runThread.Abort();
        }
        public void DisconnectClient(UserClient client)
        {
            clients.Remove(client);
            learningClients.Remove(client);
            predictingClients.Remove(client);
            proctor.needsUpdate = true;
            client.Disconnect();
        }
        public void AddToLearning(UserClient client)
        {
            learningClients.Add(client);
            predictingClients.Remove(client);
        }
        public void AddToPredicting(UserClient client)
        {
            predictingClients.Add(client);
            learningClients.Remove(client);
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
                    UserClient client = new UserClient(server.AcceptTcpClient(),proctor,this);
                    clients.Add(client);
                    predictingClients.Add(client);
                    proctor.needsUpdate = true;
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
        public void SetLearning(UserClient target, String name, String pass, int userID)
        {
            UserClient temp = GetClientByName(target.GetName());
            temp.SetPass(pass);
            temp.SetID(userID);
            temp.SetUsername(name);
            temp.SetLearning(true);
            AddToLearning(temp);
        }
        public void SetPredicting(UserClient client)
        {
            client.SetID(-1);
            client.SetUsername(UniqueName());
            client.SetPass("");
            client.SetLearning(false);
            AddToPredicting(client);
        }
        public UserClient GetClientByName(String name)
        {
            UserClient answer = null;
            foreach(UserClient client in clients)
            {
                if (client.GetName() == name)
                    answer = client;
            }
            return answer;
        }
        public string UniqueName()
        {
            string answer = "User";
            int i = 0;
            answer += (clients.Count+i).ToString();
            while(GetClientByName(answer)!=null)
            {
                answer = "User" + (clients.Count + ++i).ToString();
            }
            return answer;
        }
    }
}
