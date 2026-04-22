using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Navigation.DbContexts
{
    public class IDesignTimeDbContextFactory: IDesignTimeDbContextFactory<CRUDDbContext>
    {

        public CRUDDbContext CreateDbContext(string[] args)
        {
            // 1. Create a builder for your specific context type
            var optionsBuilder = new DbContextOptionsBuilder<CRUDDbContext>();

            // 2. Configure it to use SQLite
            // This creates a local file 'CRUD_Migrations.db' for development
            optionsBuilder.UseSqlite("Data Source=CRUD_Migrations.db");

            // 3. Instantiate the context with these options
            return new CRUDDbContext(optionsBuilder.Options);
        }
    }
}
