using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanApp.Models
{
    public class ApiContext : IdentityDbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options):base(options){ }
        public DbSet<Cards> Cards { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    }
}
