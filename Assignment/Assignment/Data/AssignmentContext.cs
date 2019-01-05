using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment.Models;

namespace Assignment.Models
{
    public class AssignmentContext : DbContext
    {
        public AssignmentContext (DbContextOptions<AssignmentContext> options)
            : base(options)
        {
        }
        public DbSet<Assignment.Models.Student> Student { get; set; }
        public DbSet<Assignment.Models.Account> Account { get; set; }

    }
}
