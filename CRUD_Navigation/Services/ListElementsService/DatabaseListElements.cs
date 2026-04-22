using CRUD_Navigation.DbContexts;
using CRUD_Navigation.DTOs;
using CRUD_Navigation.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Navigation.Services.ListElementsService
{
    public class DatabaseListElements : IListElements
    {
        private readonly CRUDDbContextFactory _dbContextFactory;

        public DatabaseListElements(CRUDDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<ElementWithID>> ListElements()
        {
            using (CRUDDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<ElementDTO> ElementsDTOs = await context.Elements.ToListAsync();
                return ElementsDTOs.Select(t => toElement(t));

            }
        }

        private ElementWithID toElement(ElementDTO t)
        {
            return new ElementWithID(t.Id, t.Name, t.Type, t.Description);
              
        }
    }
}
