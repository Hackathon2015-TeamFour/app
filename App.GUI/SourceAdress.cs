using GUI.Datos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.GUI;
using App.GUI.StreamManager;
using App.GUI.Util;

namespace App.GUI.DataAccess
{
    class SourceAdress : ISourceAccess
    {
        private IValueChangedListener listener;
        private IDictionary streamManagers = new Dictionary<StreamTypes, IStreamManager>();
        public SourceAdress(IValueChangedListener listener)
        {
            this.listener = listener;

            streamManagers.Add(StreamTypes.CHFEUR, new StreamManager.StreamManager(StreamTypes.CHFEUR,listener));
            streamManagers.Add(StreamTypes.EURCHF, new StreamManager.StreamManager(StreamTypes.EURCHF,listener));

        }




        public void start()
        {
            //TODO database load entries
            var DBContext = new SixDataContext();

            //   mdf_stream entry = entries.First();
            string value;


            //  StreamTypes type = parseEnum(value);

            //     if(streamManagers.Contains(type))
            //        streamManagers[type].process(entry);
            // TODO call the stream Manager
        }

        private static StreamTypes parseEnum(string value)
        {
            return (StreamTypes)Enum.Parse(typeof(StreamTypes), value.Replace("/", ""), true);
        }
    }
}
