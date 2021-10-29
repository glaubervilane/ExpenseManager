using ExpenseManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.Mapping
{
    public class ExpenseTypeMap : IEntityTypeConfiguration<ExpenseType>
    {
        public void Configure(EntityTypeBuilder<ExpenseType> builder)
        {
            builder.HasKey(td => td.ExpenseTypeId);
            builder.Property(td => td.Name).HasMaxLength(50).IsRequired();

            builder.HasMany(td => td.Expense).WithOne(td => td.ExpenseType).HasForeignKey(td => td.ExpenseTypeId);

            builder.ToTable("ExpenseTypes");
        }
    }
}
