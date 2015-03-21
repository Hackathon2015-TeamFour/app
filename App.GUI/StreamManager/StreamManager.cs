using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using App.GUI.Util;
using App.DLL.Data;

namespace App.GUI.StreamManager
{
    public class StreamManager : IStreamManager
    {
        // size of ringbuffer == size  of events to keep
        private RingBuffer<float> buffer = new RingBuffer<float>(10);
        private IDictionary<int,RingBuffer<float>>  _sourceDictionary = new Dictionary<int, RingBuffer<float>>(); 
        private const float OnePercent = 0.01f;

        private readonly IValueChangedListener _listener;
        private readonly StreamTypes _managerType;
        private StreamTypes types;
        private string valueType;
    

        /// <summary>
        /// value Type like TRAde, bid, ask etc
        /// </summary>
        /// <param name="types"></param>
        /// <param name="valueType"></param> 
        /// <param name="listener"></param>
        public StreamManager(StreamTypes types, string valueType, IValueChangedListener listener)
        {
            // TODO: Complete member initialization
            this.types = types;
            this.valueType = valueType;
            this._listener = listener;
        }
        /// <summary>
        /// only receives entries for it's instruments
        /// </summary>
        /// <param name="entry"></param>
        public void Process(mdf_stream entry)
        {
            try
            {
                // save to the right contributor
                //   var key = 
                //  _sourceDictionary.Add(entry.ExchangeOrContributor,new RingBuffer<float>());
                //TODO put machine learning here
                float last = (float)entry.value;
                var average = buffer.Average();

                var lastMinusAvg = last - average;
                // This is the current rule, we should find the same results as they are
                buffer.Add(last);
                if (buffer.Count() != buffer.Capacity || Math.Abs(lastMinusAvg) < average*OnePercent)
                {
                   
                   
                    SendToGui(last);
                }
                else
                {
                    SendErrorToGui(last);
                    _listener.ShowErrorOnGui("Manager: "+_managerType+" type "+valueType+" entry: "+entry.GSN);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("error in streammanager "+_managerType+" : "+e.Message);
            }

        }

        private void SendToGui(float last)
        {
            //TODO remove for production
           
            _listener.UpdateGui(_managerType, last);
        }

        private void SendErrorToGui(float last )
        {
            //TODO remove for production
            Debug.WriteLine("declined " + last + " " + _managerType);
            
        }

   
    }
}
