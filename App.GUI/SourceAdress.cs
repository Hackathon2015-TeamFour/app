using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.GUI.DataAccess
{
    class SourceAdress : ISourceAccess

    {
        private IValueChangedListener listener;
        public SourceAdress(IValueChangedListener listener){
            this.listener = listener;
            listener.updateGUI("EUR/CHF", 123.12f);
        }




        public void start()
        {
            while (read) { 
            switch(read.streamId) // eq CHF-EUR
                case "CHF-EUR":
                    CHFEURManager.process(read)
            }
        }
    }
}
