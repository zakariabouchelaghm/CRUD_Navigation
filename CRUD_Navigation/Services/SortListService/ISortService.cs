using CRUD_Navigation.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Navigation.Services.SortListService
{
     public interface ISortService
    {
        public IEnumerable<ElementWithID> Sortlist(string type, IEnumerable<ElementWithID> elementslist);
        

    }
}
