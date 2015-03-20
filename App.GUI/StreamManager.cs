using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.GUI;

namespace App.GUI.StreamManager
{
    public class StreamManager  : IStreamManager
    {
        private RingBuffer<float> buffer = new RingBuffer<float>(10);
        
        ConcurrentQueue<float> lastValues = new ConcurrentQueue<float>();

        private IValueChangedListener listener;
        public StreamManager(IValueChangedListener listener)
        {
            this.listener = listener;
        }

        public void process(global::GUI.Datos.mdf_stream entry)
        {
            buffer.Add(float.Parse(entry.value));
            buffer.Average;
            throw new NotImplementedException();
        }
    }
}
