using System;
using System.Collections.Concurrent;
using System.Linq;
using App.GUI.Util;
using App.DLL.Data;

namespace App.GUI.StreamManager
{
    public class StreamManager : IStreamManager
    {
        // size of ringbuffer == size  of events to keep
        private RingBuffer<float> buffer = new RingBuffer<float>(10);


        private readonly IValueChangedListener _listener;
        private readonly StreamTypes _managerType;
        public StreamManager(StreamTypes managerType, IValueChangedListener listener)
        {
            _listener = listener;
            _managerType = managerType;
        }

        public void process(global::App.DLL.Data.mdf_stream entry)
        {
            var last = float.Parse(entry.value);
            var avg = buffer.Average();
           
            var lastMinusAvg = last - avg;
            if (Math.Abs(lastMinusAvg) < avg * 0.01)
            {
                SendToGui(last);
            }
            else
            {
                SendErrorToGui(last);
               
            }

        }

        private void SendToGui(float last)
        {
            _listener.UpdateGui(_managerType, last);
        }

        private void SendErrorToGui(float last )
        {
            _listener.UpdateInvalidOnGui(_managerType, last);
        }
    }
}
