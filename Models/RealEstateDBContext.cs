using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace GropProject3.Models
{
    public class RealEstateDBContext: DbContext
    {
        public RealEstateDBContext(DbContextOptions<RealEstateDBContext> options) : base(options) { }
            public DbSet<User> user { get; set; }
            public DbSet<HomeListing> homes { get; set; }
    }
    }


