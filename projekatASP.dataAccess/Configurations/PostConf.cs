using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projekatASP.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.dataAccess.Configurations
{
    public class PostConf : EntityConfiguration<Post>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Post> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(25).IsRequired();
            builder.Property(x => x.Text).HasMaxLength(250).IsRequired();
            builder.Property(x => x.MainPic).HasMaxLength(250).IsRequired();

            builder.HasIndex(x => x.Title).IsUnique();


            builder.HasMany(x => x.Comments).WithOne(x => x.Post).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Posts).WithOne(x => x.Post).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Likes).WithOne(x => x.Post).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Images).WithOne(x => x.Post).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
