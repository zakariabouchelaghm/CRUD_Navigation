using CRUD_Navigation.DbContexts;
using CRUD_Navigation.DTOs;
using CRUD_Navigation.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Navigation.Services.SearchElementService
{
    public class DatabaseSearchElement : ISearchElement
    {
        private readonly CRUDDbContextFactory _dbContextFactory;

        public DatabaseSearchElement(CRUDDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<ElementWithID> SearchElement(int? ELementID)
        {
            using (CRUDDbContext context = _dbContextFactory.CreateDbContext())
            {
                ElementDTO ElementDTO = context.Elements.FirstOrDefault(r => r.Id == ELementID);
                if (ElementDTO!=null) {
                    return toElement(ElementDTO); }
                else
                {
                    return null;
                }

            }
        }

        private ElementWithID toElement(ElementDTO t)
        {
            return new ElementWithID(t.Id, t.Name, t.Type, t.Description);

        }
    }
}
