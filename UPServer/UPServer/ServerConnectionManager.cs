using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace UPServer
{
    public class ServerConnectionManager
    {
        private List<UserClient> clients;
        bool connected;
        List<UserClient> learningClients;
        Proctor proctor;
        List<UserClient> predictingClients;
        NetworkStream networkStream;
        StreamReader reader;
        StreamWriter writer;
        public ServerConnectionManager()
        {

        }
        public void DisconnectClient(UserClient client)
        {

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

        }
        public void SetLearning(UserClient client, String Name, int ID)
        {

        }
        public void SetPredicting(UserClient client)
        {
            
        }
    }
}
