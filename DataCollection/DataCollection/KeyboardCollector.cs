﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DataCollection
{

    public partial class KeyboardCollector : Form
    {
        Intercepter inter;
        public KeyboardCollector()
        {
            inter = new Intercepter(this);
            inter.run();
            InitializeComponent();
        }
    }
}
