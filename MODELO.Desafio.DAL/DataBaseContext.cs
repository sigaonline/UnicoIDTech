using MODELO.Desafio.DAL.Interface.EntitieMappers;
using MODELO.Desafio.DAL.Interface.Entities;
using Microsoft.EntityFrameworkCore;

namespace MODELO.Desafio.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        public DbSet<Fair> Fairs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Fair>(new FairMap().Configure);
        }

    }
}

