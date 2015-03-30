using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Collections;

namespace UPServer
{
    public class WordData
    {
        String word;
        int[] timing;
        int UserID;
        public WordData(String w, int[] t,int uid)
        {
            word = w;
            timing = t;
        }
        public String GetWord()
        {
            return word;
        }
        public int[] GetTiming()
        {
            return timing;
        }
    }
}
