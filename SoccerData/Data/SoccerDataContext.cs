using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoccerData.Models;


namespace SoccerData.Data
{
    public class SoccerDataContext : DbContext
    {
        public SoccerDataContext(DbContextOptions<SoccerDataContext> options)
            : base(options)
        {
        }
        public DbSet<SoccerData.Models.Stadistics> SoccerData { get; set; }

    }
}
