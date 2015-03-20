using System.Collections.Concurrent;
using System.Linq;
using App.GUI.Util;

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

        public void process(global::GUI.Datos.mdf_stream entry)
        {
            var last = float.Parse(entry.value);
            var avg = buffer.Average();

            var lastMinusAvg = last - avg;
            if (true)
            {
                _listener.UpdateGui(_managerType, last);
            }
            else
            {
                // TODO log or save as false detected values
            }

        }
    }
}
