using CRUD_Navigation.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Navigation.DbContexts
{
    public class CRUDDbContext: DbContext
    {
        public CRUDDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ElementDTO> Elements { get; set; }
    }
}
