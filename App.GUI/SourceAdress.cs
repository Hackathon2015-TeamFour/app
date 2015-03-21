using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using App.DLL.Data;
using App.GUI.DataAccess;
using App.GUI.StreamManager;
using App.GUI.Util;

namespace App.GUI
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
               var listOfAllEntries =  DBContext.mdf_stream.OrderBy(x => x.GSN);
               var total = listOfAllEntries.Count();
                for (int offset = 0; offset < total; offset += 10)
                {
                    var queryResult = TakeNext(listOfAllEntries, offset);

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

        private static List<mdf_stream> TakeNext(IQueryable<mdf_stream> ctx, long offset)
        {
            return ctx.Skip((int)(10 * offset)).Take(10).ToList();
        }

        private static StreamTypes parseEnum(string value)
        {
            return (StreamTypes)Enum.Parse(typeof(StreamTypes), value.Replace("/", ""), true);
        }
    }
}