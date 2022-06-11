using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projekatASP.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.dataAccess.Configurations
{
    public class ImagesConf : EntityConfiguration<Images>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Images> builder)
        {
            builder.Property(x => x.Image).HasMaxLength(250).IsRequired();

        }
    }
}
