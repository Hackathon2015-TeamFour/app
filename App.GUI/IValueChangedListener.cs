using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.GUI.Util;

namespace App.GUI
{
    public interface IValueChangedListener
    {
       void updateGUI(StreamTypes StreamId, float value);
    }
}
