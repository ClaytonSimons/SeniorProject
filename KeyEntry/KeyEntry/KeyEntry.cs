using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyData
{
    [Serializable()]
    public class KeyEntry
    {
        public byte keyValue;
        public int time;
        public string keyboardType;
        public KeyEntry(byte key, int t, string type)
        {
            keyValue = key;
            time = t;
            keyboardType = type;
        }
    }
}
