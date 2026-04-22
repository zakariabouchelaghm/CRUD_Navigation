using CRUD_Navigation.DbContexts;
using CRUD_Navigation.DTOs;
using CRUD_Navigation.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Navigation.Services.AddElementService
{
    public class DatabaseAddElement : IAddElement
    {
        private readonly CRUDDbContextFactory _dbContextFactory;

        public DatabaseAddElement(CRUDDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task AddElement(Element element)
        {
            using (CRUDDbContext context = _dbContextFactory.CreateDbContext())
            {
                ElementDTO elementDTO = ElementDTO(element);

                context.Elements.Add(elementDTO);
                await context.SaveChangesAsync();

            }
        }

        private ElementDTO ElementDTO(Element element)
        {
            return new ElementDTO()
            {
                Name = element.Name,
                Type = element.Type,
                Description = element.Description,
            };
        }
    }
}
