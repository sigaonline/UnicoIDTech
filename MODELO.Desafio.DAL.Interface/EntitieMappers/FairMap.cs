using MODELO.Desafio.DAL.Interface.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MODELO.Desafio.DAL.Interface.EntitieMappers
{
    public class FairMap : IEntityTypeConfiguration<Fair>
    {
        public void Configure(EntityTypeBuilder<Fair> builder)
        {
            builder.ToTable("Fair");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.District)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("District")
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Region)
               .HasConversion(prop => prop, prop => prop)
               .IsRequired()
               .HasColumnName("Region")
               .HasColumnType("varchar(100)");

            builder.Property(prop => prop.NameFair)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("NameFair")
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Neighborhood)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Neighborhood")
                .HasColumnType("varchar(100)");

        }
    }
}
