using Microsoft.EntityFrameworkCore;


namespace Urok1.DAL
{
        public class AppDbContext : DbContext
        {
            public DbSet<Student> Students { get; set; }

            private string ConectionString => "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Students_1;Integrated Security=True;Connect Timeout=30;";


            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(ConectionString);
            }
        }
}
