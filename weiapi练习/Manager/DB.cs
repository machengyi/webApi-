

namespace weiapi练习.Manager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Data.Entity;
    using weiapi练习.Models;
    public partial class DB:DbContext
    {
        
        public DB()
            :base("name=EmployeeDB")
        {
        }
        public virtual DbSet<StaffTable> StaffTable {get;set;}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StaffTable>()
                .Property(e => e.Nickname)
                .IsUnicode(false);
            modelBuilder.Entity<StaffTable>()
                .Property(e => e.Password)
                .IsUnicode(false);
            modelBuilder.Entity<StaffTable>()
                .Property(e => e.ImgURL)
                .IsUnicode(false);
        }
    }
}