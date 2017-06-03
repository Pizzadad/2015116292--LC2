﻿using _2015116292_ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_PER.Configurations
{
    public class lineatelefonicaConfiguration : EntityTypeConfiguration<lineatelefonica>
    {
        public lineatelefonicaConfiguration()
        {
            ToTable("lineatelefonica");
            HasKey(li => li.lineatelefonica_id);

            HasRequired(li => li.AdmiLinea)
                .WithMany(li => li._lineatelefonica);
 }
    }
}
