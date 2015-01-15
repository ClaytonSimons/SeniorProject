using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPClient
{
    class KeyEntry
    {
        byte keyValue;
        int time;
        public KeyEntry(byte key, int t)
        {
            keyValue = key;
            time = t;
        }
    }
}
