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
    public class PizzaSizeConfs : IEntityTypeConfiguration<PizzaSize>
    {
        public void Configure(EntityTypeBuilder<PizzaSize> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Diametr).IsRequired();
        }
    }
}