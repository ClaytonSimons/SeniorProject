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
            connection = new ServerConnectionManager();
            database = new UserData();
        }
    }
}
