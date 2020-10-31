using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace Toolkit.Core
{
    public class ToolkitContext : DbContext
    {
        private readonly string databasepath;

        public ToolkitContext(string databasepath)
        {
            this.databasepath = databasepath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlite($"FileName={databasepath}");
        }

        public DbSet<ToolkitDetail> ToolkitDetails { get; set; }

        public DbSet<ToolkitMaster> ToolkitMasters { get; set; }
    }
}
