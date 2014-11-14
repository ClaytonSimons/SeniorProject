using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
using UPKeyLogger;

namespace DataCollection
{
    class Intercepter
    {
        KeyboardCollector parent;
        int count;
        Thread updateThread;
        public Intercepter(KeyboardCollector p)
        {
            parent = p;
            count = 0;
        }
        public void Start()
        {
            KeyLogger.run();
            updateThread = new Thread(Update);
            updateThread.Start();
        }
        public void Stop()
        {

        }
        public void Update()
        {
            while(true)
                if(KeyLogger.getKeyStrokes().Count != count)
                {
                    parent.Text = "hi";
                }
        }
        public LinkedList<String> getKeyStrokes()
        {
            LinkedList<String> list = new LinkedList<String>();
            return list;
        }
        public void Reset()
        {

        }

    }
}
