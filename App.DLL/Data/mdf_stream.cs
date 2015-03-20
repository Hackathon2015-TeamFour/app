namespace App.DLL.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class mdf_stream
    {
        [Key]
        [StringLength(255)]
        public string GSN { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        public int? marketCodeId { get; set; }

        public int? currencyCodeId { get; set; }

        public int? valorNumberId { get; set; }

        public int? valueTypeId { get; set; }

        public int? statisticTypeId { get; set; }

        public int? valueStyleId { get; set; }

        [StringLength(255)]
        public string value { get; set; }

        [ForeignKey("marketCodeId")]
        public virtual market_code ExchangeOrContributorName { get; set; }
        [ForeignKey("valorNumberId")]
        public virtual used_instrument valorNumber { get; set; }
        [ForeignKey("valueTypeId")]
        public virtual value_type valueType { get; set; }
        /// <summary>
        /// 2,OPE,Open
        /// 3,LAS,Last
        /// 4,HIG,Daily high
        /// 5,LOW,Daily low
        /// 6,DER,Derived
        /// 9,REF,Reference
        /// 10,SPE,Special
        /// 11,BES,Best
        /// 12,VAL,Valuation SIX Financial Information
        /// 13,YIE,Yield
        /// 14,CUM,Cumulated
        /// 20,YCL,Year close
        /// 25,VLT,Volatility
        /// 30,MON,Monthly
        /// </summary>
        [ForeignKey("statisticTypeId")]
        public virtual statistic_type statisticType { get; set; }
        /// <summary>
        /// 9,IMA,Indicated market
        /// 19,CLS,Closing price
        /// 56,OFF,Official
        /// 246,DFU,Derived futures price
        /// 553,DCV,Derived Constituents Value
        /// </summary>
        [ForeignKey("valueStyleId")]
        public virtual value_style valueStyle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("currencyCodeId")]
        public virtual currency_code currencyCode { get; set; }


    }
}
