using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPServer
{
    public class Proctor
    {
        private ServerConnectionManager connection;
        private UserData database;
        public Proctor()
        {
            connection = new ServerConnectionManager(this);
            database = new UserData();
        }
        public void SaveData(UserClient client, List<KeyData.KeyEntry> data)
        {
            bool GotHere = true;
        }
        public ServerConnectionManager GetConnection()
        {
            return connection;
        }
        public bool CheckCredentials(String UserName, String Password)
        {
            return true;
        }
    }
}