using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ASM.Models;

namespace ASM.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ASM.Models.Account> Account { get; set; }
        public DbSet<ASM.Models.Subject> Subject { get; set; }
        public DbSet<ASM.Models.Mark> Mark { get; set; }
    }
}
