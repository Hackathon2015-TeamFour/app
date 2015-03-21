using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using App.DLL.Data;
using App.GUI.StreamManager;
using App.GUI.Util;

namespace App.GUI.DataAccess
{
    class SourceAdress : ISourceAccess
    {
        private readonly IValueChangedListener listener;
        private readonly IDictionary<StreamTypes, IDictionary<int, IStreamManager>> _streamManagers = new Dictionary<StreamTypes, IDictionary<int, IStreamManager>>();
        private const int ReadEntriesAmount = 1000;
        private List<KeyValuePair<int, string>> valueTypes = new List<KeyValuePair<int, string>>();
  
        public SourceAdress(IValueChangedListener listener)
        {
            this.listener = listener;
                     
            #region valuetypes
        valueTypes.Add(new KeyValuePair<int,string>(1,"TRA"));
        valueTypes.Add(new KeyValuePair<int,string>(2,"BID"));
        valueTypes.Add(new KeyValuePair<int,string>(3,"ASK"));
        valueTypes.Add(new KeyValuePair<int,string>(4,"MID"));
        valueTypes.Add(new KeyValuePair<int,string>(5,"ISS"));
        valueTypes.Add(new KeyValuePair<int,string>(6,"REP"));
        valueTypes.Add(new KeyValuePair<int,string>(7,"SET"));
        valueTypes.Add(new KeyValuePair<int,string>(8,"ETO"));
        valueTypes.Add(new KeyValuePair<int,string>(9,"LIS"));
        valueTypes.Add(new KeyValuePair<int,string>(11,"OIN"));
        valueTypes.Add(new KeyValuePair<int,string>(12,"KAS"));
        valueTypes.Add(new KeyValuePair<int,string>(13,"JYI"));
        valueTypes.Add(new KeyValuePair<int,string>(14,"EAR"));
        valueTypes.Add(new KeyValuePair<int,string>(16,"VOL"));
        valueTypes.Add(new KeyValuePair<int,string>(17,"TUR"));
        valueTypes.Add(new KeyValuePair<int,string>(38,"VLY"));
        valueTypes.Add(new KeyValuePair<int,string>(61,"ADA"));
        valueTypes.Add(new KeyValuePair<int,string>(70,"HIS"));
        valueTypes.Add(new KeyValuePair<int,string>(71,"HIV"));
        valueTypes.Add(new KeyValuePair<int,string>(79,"HVO"));
        valueTypes.Add(new KeyValuePair<int,string>(112,"EUM"));
        valueTypes.Add(new KeyValuePair<int,string>(134,"UOO"));
        valueTypes.Add(new KeyValuePair<int,string>(247,"PSP"));
        valueTypes.Add(new KeyValuePair<int,string>(253,"AHT"));
        valueTypes.Add(new KeyValuePair<int,string>(452,"TIK"));
        valueTypes.Add(new KeyValuePair<int,string>(688,"1WV"));
        valueTypes.Add(new KeyValuePair<int,string>(689,"HVY"));
#endregion valuetypes
            foreach (StreamTypes type in Enum.GetValues(typeof(StreamTypes)))
            {
                AddManager(type);
            }
            
      
        }

     private void AddManager(StreamTypes types){
         IDictionary<int,IStreamManager> innerDictionary = new Dictionary<int, IStreamManager>();
         foreach (var entry in valueTypes)
         {
             innerDictionary.Add(entry.Key, new StreamManager.StreamManager(types, entry.Value,listener));
             
         }
         _streamManagers.Add(types, innerDictionary);
        }



        public async void Start()
        {
            listener.ShowErrorOnGui("startet "+DateTime.Now);
            //TODO database load entries
            using (var DBContext = new SixDataContext())
            {
                // thread this:
               var listOfAllEntries =  DBContext.mdf_stream.OrderBy(x => x.GSN);
               var total = listOfAllEntries.Count();
               for (int offset = 0; offset < total; offset += ReadEntriesAmount)
                {
                    var queryResult = TakeNext(listOfAllEntries, offset);

                    foreach (var result in queryResult)
                    {
                        //   mdf_stream entry = entries.First();
                        var value = result.valorNumber.valorName;

                        if (result.valueType.Symbol.Equals("MID") || result.valueType.Symbol.Equals("VLY"))
                        {
                            continue;
                            
                        }

                        var type = parseEnum(value);

                        try
                        {
                            var manager = _streamManagers[type];
                            manager[result.valueType.Id].Process(result);
                            // sleep 20 microsecond

                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine("no Manager Found for " + value + "/"+result.valueType+" " + e.Message);
                        }

                    }
                }
            }
            listener.ShowErrorOnGui("end "+DateTime.Now );
            // thread end:
        }

        private bool NotAcceptedValueTypes(value_type value_type)
        {
            /**
             * 1,TRA,Trade
2,BID,Bid
3,ASK,Ask
4,MID,Mid
5,ISS,Issue
6,REP,Redemption Price
7,SET,Settlement
8,ETO,Single turnover Off-Market
9,LIS,Listino
11,OIN,Open interest
12,KAS,Cash
13,JYI,Annualized distribution
14,EAR,Earnings
16,VOL,Volume
17,TUR,Turnover
38,VLY,Historical Volatility (30 days)
61,ADA,Average daily volume
70,HIS,Historical Volatility (180 days)
71,HIV,Rolling calender year
79,HVO,Historical Volatility (90 days)
112,EUM,Part of turnover
134,UOO,Turnover ON + OFF
247,PSP,Percentage Spread Bid/Ask
253,AHT,Number of trading days
452,TIK,Number of Ticks
688,1WV,1 week average daily volatility
689,HVY,Historical volatility year to date
**/
            return !(value_type.Id < 5);
        }

        private static List<mdf_stream> TakeNext(IQueryable<mdf_stream> ctx, long offset)
        {
            return ctx.Skip((int)(10 * offset)).Take(ReadEntriesAmount).ToList();
        }

        private static StreamTypes parseEnum(string value)
        {
            return (StreamTypes)Enum.Parse(typeof(StreamTypes), value.Replace("/", ""), true);
        }
    }
}