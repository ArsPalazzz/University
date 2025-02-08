using Microsoft.EntityFrameworkCore;
using WpfApp2.Models;


namespace WpfApp2
{
    public partial class CourseContext : DbContext
    {
        public virtual DbSet<DISCIPLINE> DISCIPLINE { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<CourseTable> CourseTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=WIN-OLMAANRL9OB;Database=CourseDB;Encrypt=False;Trusted_Connection=SSPI");
        }
    }
}
