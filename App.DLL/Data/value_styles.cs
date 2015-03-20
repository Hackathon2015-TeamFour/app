namespace GUI.Datos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("value_styles")]
    public partial class value_style
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        public string IMA { get; set; }

        [Column("Indicated market")]
        [StringLength(50)]
        public string Indicated_market { get; set; }
    }
}
