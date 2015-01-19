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

namespace UPServer
{
    
    public class UserClient
    {
        ServerConnectionManager parent;
        String password;
        Proctor proctor;
        NetworkStream networkStream;
        StreamReader streamReader;
        Thread runThread;
        int userID;
        String userName;
        public UserClient()
        {

        }
        public void Disconnect(UserClient client)
        {

        }
        public void DataLoop()
        {
            IFormatter formatter = new BinaryFormatter();
            KeyEntry entry = (KeyEntry)formatter.Deserialize(networkStream);
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
