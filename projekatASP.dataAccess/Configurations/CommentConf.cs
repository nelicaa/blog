using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projekatASP.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.dataAccess.Configurations
{
    public class CommentConf : EntityConfiguration<Comments>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Comments> builder)
        {
            builder.Property(x => x.Comment).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Rate).HasMaxLength(1).IsRequired();

        }
    }
}
