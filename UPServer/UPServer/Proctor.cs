using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPServer
{
    class Proctor
    {
        private ServerConnectionManager SCM;
        private UserData Data;
        public void Proctor()
        {
            SCM = new ServerConnectionManager();
            Data = new UserData();
        }
    }
}
