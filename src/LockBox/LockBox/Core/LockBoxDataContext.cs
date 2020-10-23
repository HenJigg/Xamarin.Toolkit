using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace LockBox.Core
{
    public class LockBoxDataContext : DbContext
    {
        private readonly string databasepath;

        public LockBoxDataContext(string databasepath)
        {
            this.databasepath = databasepath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlite($"FileName={databasepath}");
        }

        public DbSet<LockBoxDetail> LockBoxDetails { get; set; }

        public DbSet<LockBoxMaster> LockBoxMasters { get; set; }
    }
}
