using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.GUI
{
    interface IValueChangedListener
    {
       public void updateGUI(string StreamId, float value);
    }
}
