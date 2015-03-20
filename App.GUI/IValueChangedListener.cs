using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.GUI.Util;

namespace App.GUI
{
    public interface IValueChangedListener
    {
       void UpdateGui(StreamTypes StreamId, float value);
        /// <summary>
        /// Invalid entries will be propagated via this method
        /// </summary>
        /// <param name="StreamId"></param>
        /// <param name="value"></param>
        void UpdateInvalidOnGui(StreamTypes StreamId, float value);
    }
}
