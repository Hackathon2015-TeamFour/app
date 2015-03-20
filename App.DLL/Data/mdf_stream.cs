namespace GUI.Datos
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
        public virtual market_code marketCode { get; set; }
        [ForeignKey("valorNumberId")]
        public virtual used_instrument valorNumber { get; set; }
        [ForeignKey("valueTypeId")]
        public virtual value_type valueType { get; set; }
        [ForeignKey("statisticTypeId")]
        public virtual statistic_type statisticType { get; set; }
        [ForeignKey("valueStyleId")]
        public virtual value_style valueStyle { get; set; }
        [ForeignKey("currencyCodeId")]
        public virtual currency_code currencyCode { get; set; }
 

    }
}
