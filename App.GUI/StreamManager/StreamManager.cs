﻿using System;
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
        private const float ONE_PERCENT = 0.01f;

        private readonly IValueChangedListener _listener;
        private readonly StreamTypes _managerType;
        public StreamManager(StreamTypes managerType, IValueChangedListener listener)
        {
            _listener = listener;
            _managerType = managerType;
        }
        /// <summary>
        /// only receives entries for it's instruments
        /// </summary>
        /// <param name="entry"></param>
        public void Process(mdf_stream entry)
        {
            // save to the right contributor
         //   var key = 
          //  _sourceDictionary.Add(entry.ExchangeOrContributor,new RingBuffer<float>());
            //TODO put machine learning here
            var last = float.Parse(entry.value);
            var average = buffer.Average();
           
            var lastMinusAvg = last - average;
            // This is the current rule, we should find the same results as they are
     
            if (Math.Abs(lastMinusAvg) < average * ONE_PERCENT)
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
            //TODO remove for production
            Debug.WriteLine("accepted " + last + " " + _managerType);
            _listener.UpdateGui(_managerType, last);
        }

        private void SendErrorToGui(float last )
        {
            //TODO remove for production
            Debug.WriteLine("declined " + last + " " + _managerType);
            _listener.UpdateInvalidOnGui(_managerType, last);
        }

   
    }
}
