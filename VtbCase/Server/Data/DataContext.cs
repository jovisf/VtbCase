using Microsoft.EntityFrameworkCore;
using VtbCase.Shared;

namespace VtbCase.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=BlazorCrudDB;Trusted_Connection=true;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Segment>().HasData(
                    new Segment
                    {
                        Id = 1,
                        Nome = "The Hitchhiker's Guide to the Galaxy",
                        Descricao = "Books",
                    },
                    new Segment
                    {
                        Id = 2,
                        Nome = "Ready Player One",
                        Descricao = "Books",
                    },
                    new Segment
                    {
                        Id = 3,
                        Nome = "Back to the Future",
                        Descricao = "Movies",
                    },
                    new Segment
                    {
                        Id = 4,
                        Nome = "Toy Story",
                        Descricao = "Movies"
                    });

        }

        public DbSet<Segment> Segments => Set<Segment>();
    }
}