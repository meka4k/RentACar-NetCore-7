using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand> // bu sınıfı implement eden configleri bul
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.ToTable("Brands").HasKey(b=>b.Id);

        builder.Property(x=>x.Id).IsRequired().HasColumnName("Id");
        builder.Property(x=>x.Name).IsRequired().HasColumnName("Name");
        builder.Property(x=>x.CreatedDate).IsRequired().HasColumnName("CreatedDate");
        builder.Property(x=>x.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(x=>x.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: x => x.Name, name: "UK_Brands_Name").IsUnique();
        builder.HasMany(x => x.Models);

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue); //soft deleteleri getirme 
    }
}
