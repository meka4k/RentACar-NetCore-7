using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class FuelConfiguration : IEntityTypeConfiguration<Fuel> // bu sınıfı implement eden configleri bul
{
    public void Configure(EntityTypeBuilder<Fuel> builder)
    {
        builder.ToTable("Fuels").HasKey(b => b.Id);

        builder.Property(x => x.Id).IsRequired().HasColumnName("Id");
        builder.Property(x => x.Name).IsRequired().HasColumnName("Name");
        builder.Property(x => x.CreatedDate).IsRequired().HasColumnName("CreatedDate");
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(x => x.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: x => x.Name, name: "UK_Fuels_Name").IsUnique();
        builder.HasMany(x => x.Models);

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);  
    }
}
