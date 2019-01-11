using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Redo.Models;

namespace Redo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Redo.Models.Account> Account { get; set; }
        public DbSet<Redo.Models.FptClass> FptClass { get; set; }
        public DbSet<Redo.Models.Subject> Subject { get; set; }
    }
}
