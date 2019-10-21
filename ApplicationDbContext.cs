using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Navi2.Data;

namespace Navi2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Navi2.Data.AuditTable> AuditTable { get; set; }
        public DbSet<Navi2.Data.Dept> Dept { get; set; }
        public DbSet<Navi2.Data.Employees> Employees { get; set; }
        public DbSet<Navi2.Data.User> User { get; set; }
        public DbSet<Navi2.Data.UserRole> UserRole { get; set; }
    }
}
