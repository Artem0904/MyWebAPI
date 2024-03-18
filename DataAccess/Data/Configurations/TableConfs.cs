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
    public class TableConfs : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CountChairs).IsRequired();
            builder.Property(x => x.IsReserved).IsRequired();

            builder.HasOne(x => x.Client).WithMany(x => x.Tables).HasForeignKey(x => x.ClientId);
        }
    }
}
