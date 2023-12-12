using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ModelConfiguration : IEntityTypeConfiguration<Model> // bu sınıfı implement eden configleri bul
{
    public void Configure(EntityTypeBuilder<Model> builder)
    {
        builder.ToTable("Models").HasKey(b => b.Id);

        builder.Property(x => x.Id).IsRequired().HasColumnName("Id");
        builder.Property(x => x.Name).IsRequired().HasColumnName("Name");
        builder.Property(x => x.BrandId).IsRequired().HasColumnName("BrandId");
        builder.Property(x => x.FuelId).IsRequired().HasColumnName("FuelId");
        builder.Property(x => x.TransmissionId).IsRequired().HasColumnName("TransmissionId");
        builder.Property(x => x.DailyPrice).IsRequired().HasColumnName("DailyPrice");
        builder.Property(x => x.ImageUrl).IsRequired().HasColumnName("ImageUrl");




        builder.Property(x => x.CreatedDate).IsRequired().HasColumnName("CreatedDate");
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(x => x.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: x => x.Name, name: "UK_Models_Name").IsUnique();
        builder.HasOne(x => x.Transmission);
        builder.HasOne(x => x.Brand);
        builder.HasOne(x => x.Fuel);

        builder.HasMany(x => x.Cars);

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}
