using CRUD_Navigation.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Navigation.Services.ListElementsService
{
    public interface IListElements
    {
        Task<IEnumerable<ElementWithID>> ListElements();
    }
}
