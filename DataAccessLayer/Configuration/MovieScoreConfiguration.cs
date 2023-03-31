using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Configuration
{
    public class MovieScoreConfiguration : IEntityTypeConfiguration<MovieScore>
    {
        public void Configure(EntityTypeBuilder<MovieScore> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Note).IsRequired();
            builder.Property(x => x.Score).IsRequired().HasColumnType("int");
            builder.HasOne(x => x.MovieDetail).WithMany(x => x.MovieScores).HasForeignKey(x => x.MovieDetailId);
            builder.HasOne(x => x.User).WithMany(x => x.MovieScores).HasForeignKey(x => x.UserId);
        }
    }
}
