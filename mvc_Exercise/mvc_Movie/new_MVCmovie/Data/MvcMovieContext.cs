using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using new_MVCmovie.Models;

namespace MvcMovie.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<new_MVCmovie.Models.Movie> Movie { get; set; } = default!;

        public DbSet<new_MVCmovie.Models.Studio> Studio { get; set; } = default!;

        public DbSet<new_MVCmovie.Models.Artist> Artist { get; set; } = default!;

        public DbSet<new_MVCmovie.Models.User> User { get; set; } = default!;
    }
}
