using CRUD_Navigation.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Navigation.Services.SearchElementService
{
    public interface ISearchElement
    {
        Task<ElementWithID> SearchElement(int? ElementID); 
    }
}
