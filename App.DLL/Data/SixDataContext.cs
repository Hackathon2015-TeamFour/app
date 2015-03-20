namespace GUI.Datos
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
        public virtual DbSet<statistic_type> statistic_types { get; set; }
        public virtual DbSet<used_instrument> used_instruments { get; set; }
        public virtual DbSet<value_style> value_styles { get; set; }
        public virtual DbSet<value_type> value_types { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<market_code>()
                .Property(e => e.Exchange_or_Contributor_Name)
                .IsUnicode(false);

            modelBuilder.Entity<statistic_type>()
                .Property(e => e.OPE)
                .IsUnicode(false);

            modelBuilder.Entity<statistic_type>()
                .Property(e => e.Open)
                .IsUnicode(false);

            modelBuilder.Entity<used_instrument>()
                .Property(e => e.valorName)
                .IsUnicode(false);

            modelBuilder.Entity<used_instrument>()
                .Property(e => e.SecType)
                .IsUnicode(false);

            modelBuilder.Entity<value_style>()
                .Property(e => e.IMA)
                .IsUnicode(false);

            modelBuilder.Entity<value_style>()
                .Property(e => e.Indicated_market)
                .IsUnicode(false);

            modelBuilder.Entity<value_type>()
                .Property(e => e.TRA)
                .IsUnicode(false);

            modelBuilder.Entity<value_type>()
                .Property(e => e.Trade)
                .IsUnicode(false);


 




        }
    }
}
