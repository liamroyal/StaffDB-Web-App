using System;
using Microsoft.EntityFrameworkCore;

namespace StaffDatabase.Model
{
    public class StaffDatabaseContext : DbContext
    {
        public StaffDatabaseContext(DbContextOptions<StaffDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<StaffDatabase.Model.StaffMember> StaffMember { get; set; }
    }
}
    