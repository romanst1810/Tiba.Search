using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tiba.Core.Domain;

namespace Tiba.DataLayer
{
    public class BookmarkItemMap : IEntityTypeConfiguration<RepositoryItem>
    {
        public void Configure(EntityTypeBuilder<RepositoryItem> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(x => x.FullName)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(x => x.Url)
                .IsRequired()
                .HasMaxLength(4000);

            builder.Property(x => x.UserId)
               .IsRequired();

            builder.ToTable("Bookmark");
        }
    }
}
