namespace App.DLL.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SixDataContext : DbContext
    {
        public SixDataContext()
            : base("name=SixDataContext")
        {
            Database.SetInitializer<SixDataContext>(null);
        }

        public virtual DbSet<currency_code> currency_codes { get; set; }
        public virtual DbSet<market_code> market_codes { get; set; }
        public virtual DbSet<mdf_stream> mdf_stream { get; set; }
        public virtual DbSet<mdf_stream_incorrect> incorrect_streams { get; set; }
        public virtual DbSet<statistic_type> statistic_types { get; set; }
        public virtual DbSet<used_instrument> used_instruments { get; set; }
        public virtual DbSet<value_style> value_styles { get; set; }
        public virtual DbSet<value_type> value_types { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {







        }
    }
}
