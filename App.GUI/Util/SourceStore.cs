using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using App.DLL.Data;

namespace App.GUI.Util
{
    /// <summary>
    /// Stores the latest values for a Source
    /// </summary>
    public class SourceStore
    {
        private market_code _source;

        private readonly IList<KeyValuePair<float,DateTime>> _values = new List<KeyValuePair<float, DateTime>>();
        private int _marketCode;
        public SourceStore(market_code source)
        {
            _source = source;
            _marketCode= source.marketCode;
        }

        private int  GetMarketCodeID()
        {
            return _marketCode;
        }

        public void AddValue(float value, DateTime dateTime)
        {
            _values.Add(new KeyValuePair<float, DateTime>(value,dateTime));
        }

        public KeyValuePair<float, DateTime> GetLastEntry()
        {
        return   _values.Last();
        } 
    }
}