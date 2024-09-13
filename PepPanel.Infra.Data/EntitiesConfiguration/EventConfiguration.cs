using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PepPanel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepPanel.Infra.Data.EntitiesConfiguration
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => e.Id);  
            builder.Property(e => e.EventDateTime).IsRequired();
            builder.Property(e => e.Description).IsRequired();
            builder.Property(e => e.Responsible).IsRequired();
        }
    }
}
