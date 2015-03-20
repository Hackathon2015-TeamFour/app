using App.GUI.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.GUI.Util;

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

        public void UpdateInvalidOnGui(StreamTypes StreamId, float value)
        {
            // TODO implement gui logic

        }

        public void UpdateGui(StreamTypes StreamId, float value)
        {
            throw new NotImplementedException();
        }
    }
}
