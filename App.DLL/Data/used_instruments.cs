namespace GUI.Datos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("used-instruments")]
    public partial class used_instrument
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int valorNumber { get; set; }

        [StringLength(50)]
        public string valorName { get; set; }

        public int? Currency { get; set; }

        [StringLength(50)]
        public string SecType { get; set; }
    }
}
