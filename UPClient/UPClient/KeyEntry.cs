using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPClient
{
    [Serializable]
    public class KeyEntry
    {
        byte keyValue;
        int time;
        string keyboardType;
        public KeyEntry(byte key, int t, string type)
        {
            keyValue = key;
            time = t;
            keyboardType = type;
        }
    }
}
