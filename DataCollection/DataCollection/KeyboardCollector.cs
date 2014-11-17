using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;


namespace DataCollection
{

    public partial class KeyboardCollector : Form
    {
        Hashtable hasher;
        KeyBoardHook hooker;
        public KeyboardCollector()
        {
            InitializeComponent();
            //DataLstBox.Items.;
        }
        private void KeyboardCollector_Load(object sender, EventArgs e)
        {
            hooker = new KeyBoardHook();
            hooker.KeyDown += HookerKeyDown;
            hooker.KeyPress += HookerKeyPress;
            hooker.KeyUp += HookerKeyUp;
            hasher = new Hashtable();
        }
        public void updateList(LinkedList<String> list)
        {
            foreach (String i in list)
            {
                DataLstBox.Items.Add(i);
            }
        }
        public void updateList(String message)
        {
            DataLstBox.Items.Add(message);
        }
        private void HookerKeyUp(object sender, KeyEventArgs e)
        {
        }
        private void HookerKeyPress(object sender, KeyboardHookArgs e)
        {
            DataLstBox.Items.Add((char)e.vkCode + "time:" + e.time.ToString());

        }
        private void HookerKeyDown(object sender, KeyEventArgs e)
        {
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            if(!hooker.IsActive)
                hooker.Start();
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            if (hooker.IsActive)
                hooker.Stop();
        }

    }
}
