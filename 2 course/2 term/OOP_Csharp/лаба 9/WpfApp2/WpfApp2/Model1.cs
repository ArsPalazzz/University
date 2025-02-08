using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WpfApp2
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<ADDRESS> ADDRESS { get; set; }
        public virtual DbSet<PASSPORT> PASSPORT { get; set; }
        public virtual DbSet<PERSON> PERSON { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ADDRESS>()
                .Property(e => e.country)
                .IsFixedLength();

            modelBuilder.Entity<ADDRESS>()
                .Property(e => e.city)
                .IsFixedLength();

            modelBuilder.Entity<ADDRESS>()
                .Property(e => e.street)
                .IsFixedLength();

            modelBuilder.Entity<PASSPORT>()
                .Property(e => e.serial)
                .IsFixedLength();

            modelBuilder.Entity<PERSON>()
                .Property(e => e.first_name)
                .IsFixedLength();

            modelBuilder.Entity<PERSON>()
                .Property(e => e.middle_name)
                .IsFixedLength();

            modelBuilder.Entity<PERSON>()
                .Property(e => e.last_name)
                .IsFixedLength();

            modelBuilder.Entity<PERSON>()
                .Property(e => e.phone)
                .IsFixedLength();
        }
    }
}
