using Microsoft.EntityFrameworkCore;
using Order.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Command> commandes { get; set; }
        public DbSet<Composant> Composants { get; set; }
    }
}
