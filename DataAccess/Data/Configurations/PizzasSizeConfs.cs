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
    public class PizzasSizeConfs : IEntityTypeConfiguration<PizzasSize>
    {
        public void Configure(EntityTypeBuilder<PizzasSize> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Diametr).IsRequired();
        }
    }
}