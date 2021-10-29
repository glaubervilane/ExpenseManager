using ExpenseManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.Mapping
{
    public class MonthMap : IEntityTypeConfiguration<Month>
    {
        public void Configure(EntityTypeBuilder<Month> builder)
        {
            builder.HasKey(m => m.MonthId);
            builder.Property(m => m.MonthId).ValueGeneratedNever();
            builder.Property(m => m.Name).HasMaxLength(50).IsRequired();
            builder.HasMany(m => m.Expense).WithOne(m => m.Month).HasForeignKey(m => m.MonthId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(m => m.Salary).WithOne(m => m.Month).OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Months");
        }
    }
}
