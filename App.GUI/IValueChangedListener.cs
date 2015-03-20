using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.GUI
{
    interface IValueChangedListener
    {
        updateGUI(string StreamId, float value);
    }
}
