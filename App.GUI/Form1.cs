using App.GUI.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.GUI.Util;
using System.Threading;

namespace App.GUI
{

    public partial class Form1 : Form, IValueChangedListener
    {
        private readonly CheapBindings bindingEURCHF = new CheapBindings();
        private static ISourceAccess _sourceAdress;
        public Form1()
        {
            _sourceAdress = new SourceAdress(this);
            InitializeComponent();
            DoBindings();
        }

        public void UpdateInvalidOnGui(StreamTypes StreamId, float value)
        {
            // TODO implement gui logic


        }

        public async void ShowErrorOnGui(string entry)
        {
            var appended = errorLog.Lines.ToList();
            appended.Add(entry);
            errorLog.Lines = appended.ToArray();
           
        }

        public void UpdateGui(StreamTypes StreamId, float value)
        {
            switch (StreamId)
            {
                case StreamTypes.CHFEUR:

                    break;

                case StreamTypes.EURCHF:
                    this.BeginInvoke((Action)delegate()
                    {
                        textBoxEURCHF.Text = value + "";
                    });

                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Debug.WriteLine("started");
            //try
            //{
            //    var workerThread = new Thread(_sourceAdress.Start);
            //    workerThread.Start();
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine("Exception!: " + ex.Message);
            //}
            _sourceAdress.Start();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DoBindings()
        {
            this.textBoxEURCHF.DataBindings.Add(new Binding("Text", bindingEURCHF, "Value"));
        }
    }

    class CheapBindings
    {
        public string Value { get; set; }
    }
}
