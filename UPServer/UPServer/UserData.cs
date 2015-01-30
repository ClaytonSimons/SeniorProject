using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace UPServer
{
    public class UserData
    {
        public bool SaveData(UserClient client, List<KeyData.KeyEntry> data)
        {
            SqlConnection connection = new SqlConnection();
            return true;
        }
    }

}
