using GUI.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.GUI.StreamManager
{
    interface IStreamManager
    {
        public void process(mdf_stream entry);
    }
}
