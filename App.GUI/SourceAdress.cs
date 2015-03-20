﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using App.DLL.Data;
using App.GUI.StreamManager;
using App.GUI.Util;

namespace App.GUI.DataAccess
{
    class SourceAdress : ISourceAccess
    {
        private IValueChangedListener listener;
        private readonly IDictionary<StreamTypes, IStreamManager> streamManagers = new Dictionary<StreamTypes, IStreamManager>();
        public SourceAdress(IValueChangedListener listener)
        {
            this.listener = listener;

            streamManagers.Add(StreamTypes.CHFEUR, new StreamManager.StreamManager(StreamTypes.CHFEUR, listener));
            streamManagers.Add(StreamTypes.EURCHF, new StreamManager.StreamManager(StreamTypes.EURCHF, listener));

        }




        public void Start()
        {
            //TODO database load entries
            using (var DBContext = new SixDataContext())
            {
                var total = DBContext.mdf_stream.Count();
                for (int offset = 0; offset < total; offset += 10)
                {
                    var queryResult = TakeNext(DBContext, offset);

                    foreach (var result in queryResult)
                    {
                        //   mdf_stream entry = entries.First();
                        string value = result.valorNumber.valorName;


                        var type = parseEnum(value);

                        try
                        {
                            var manager = streamManagers[type];
                            manager.Process(result);

                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine("no Manager Found for " + value + " " + e.Message);
                        }
                    }
                }
            }
        }

        private static List<mdf_stream> TakeNext(SixDataContext DBContext, long offset)
        {
            return DBContext.mdf_stream.Skip((int)(10 * offset)).Take(10).ToList();
        }

        private static StreamTypes parseEnum(string value)
        {
            return (StreamTypes)Enum.Parse(typeof(StreamTypes), value.Replace("/", ""), true);
        }
    }
}
