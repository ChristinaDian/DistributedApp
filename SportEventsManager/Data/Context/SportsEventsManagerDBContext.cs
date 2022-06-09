using Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class SportsEventsManagerDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }  
        public DbSet<Organisation> Organizations { get; set; }
        public DbSet<Event> Events { get; set; }
               
    }
}
