using CRUD_Navigation.DbContexts;
using CRUD_Navigation.DTOs;
using CRUD_Navigation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace CRUD_Navigation.Services.DeleteElementService
{
    public class DatabaseDeleteElement : IDeleteService
    {
        private readonly CRUDDbContextFactory _dbContextFactory;

        public DatabaseDeleteElement(CRUDDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<bool> DeleteElement(int Id)
        {
            using (CRUDDbContext context = _dbContextFactory.CreateDbContext())
            {
                ElementDTO elementdto = await context.Elements.Where(t => t.Id == Id).SingleOrDefaultAsync();

                if (elementdto != null)
                {
                    await context.Elements.Where(t => t.Id == Id).ExecuteDeleteAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
    }
}
