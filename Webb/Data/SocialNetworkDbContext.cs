using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TddSocialNetwork.Model;

namespace Webb.Data
{
    public class SocialNetworkDbContext : DbContext
    {
        public SocialNetworkDbContext (DbContextOptions<SocialNetworkDbContext> options)
            : base(options)
        {
        }

        public DbSet<TddSocialNetwork.Model.Post> Post { get; set; }
    }
}
