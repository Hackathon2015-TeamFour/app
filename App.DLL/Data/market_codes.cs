namespace GUI.Datos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("market_codes")]
    public partial class market_code
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int marketCode { get; set; }

        public string Exchange_or_Contributor_Name { get; set; }
    }
}
