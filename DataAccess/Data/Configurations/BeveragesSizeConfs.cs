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
    internal class BeveragesSizeConfs : IEntityTypeConfiguration<BeveragesSize>
    {
        public void Configure(EntityTypeBuilder<BeveragesSize> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Volume).IsRequired();
            builder.Property(x => x.PriceModifier).IsRequired();
        }
    }
}
