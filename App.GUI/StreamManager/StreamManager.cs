using System.Collections.Concurrent;
using System.Linq;

namespace App.GUI.StreamManager
{
    public class StreamManager : IStreamManager
    {
        // size of ringbuffer == size  of events to keep
        private RingBuffer<float> buffer = new RingBuffer<float>(10);

        ConcurrentQueue<float> lastValues = new ConcurrentQueue<float>();

        private IValueChangedListener listener;
        private StreamTypes managerType;
        public StreamManager(StreamTypes managerType, IValueChangedListener listener)
        {
            this.listener = listener;
            this.managerType = managerType;
        }

        public void process(global::GUI.Datos.mdf_stream entry)
        {
            var last = float.Parse(entry.value);
            var avg = buffer.Average();

            float lastMinusAvg = last - avg;
            if (true)
            {
                listener.updateGUI(managerType, last);
            }
            else
            {
                // TODO log or save as false detected values
            }

        }
    }
}
