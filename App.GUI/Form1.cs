﻿using App.GUI.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.GUI
{

    public partial class Form1 : Form, IValueChangedListener
    {
        private static ISourceAccess sourceAdress;
        public Form1()
        {
             sourceAdress = new SourceAdress(this);
            InitializeComponent();
        }

          private void updateGUI(string StreamId, float value){
        }
    }
}