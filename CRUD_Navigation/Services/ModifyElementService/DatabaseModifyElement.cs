using CRUD_Navigation.DbContexts;
using CRUD_Navigation.DTOs;
using CRUD_Navigation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Navigation.Services.ModifyElementService
{
    public class DatabaseModifyElement : IModifyElement
    {
        private readonly CRUDDbContextFactory _dbContextFactory;

        public DatabaseModifyElement(CRUDDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public  async Task<bool> ModifyElement(int Id, Element element)
        {
            using (CRUDDbContext context = _dbContextFactory.CreateDbContext())
            {
                ElementDTO elementdto = await context.Elements.Where(t => t.Id == Id).FirstOrDefaultAsync();

                if (elementdto != null)
                {
                    await context.Elements.Where(t => t.Id == Id)
                        .ExecuteUpdateAsync(setters => setters
                        .SetProperty(t => t.Name, element.Name)
                        .SetProperty(t => t.Type, element.Type)
                        .SetProperty(t => t.Description, element.Description));
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
