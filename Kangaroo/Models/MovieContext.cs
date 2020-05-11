using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kangaroo.Models
{
    public class MovieContext : DbContext
    {
        public DbSet<MovieModel> Movies { get; set; }
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieModel>()
                .Property(e => e.Genres)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                );
        }

    }
}
