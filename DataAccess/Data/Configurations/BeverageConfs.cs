using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Configurations
{
    public class BeverageConfs : IEntityTypeConfiguration<Beverage>
    {
        public void Configure(EntityTypeBuilder<Beverage> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.BeveragesSizeId).IsRequired();

            builder.HasOne(x => x.BeveragesSize).WithMany(x => x.Beverages).HasForeignKey(x => x.BeveragesSizeId);
            builder.HasMany(x => x.Orders).WithMany(x => x.Beverages);
        }
    }
}
