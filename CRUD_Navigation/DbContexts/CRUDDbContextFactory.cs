using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Navigation.DbContexts
{
    public class CRUDDbContextFactory
    {
        private string _connection_string;

        public CRUDDbContextFactory(string connection_string)
        {
            _connection_string = connection_string;
        }

        public CRUDDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connection_string).Options;
            return new CRUDDbContext(options);
        }
    }
}
