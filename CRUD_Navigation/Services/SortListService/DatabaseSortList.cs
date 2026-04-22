using CRUD_Navigation.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Navigation.Services.SortListService
{
    public class DatabaseSortList : ISortService
    {
        public IEnumerable<ElementWithID> Sortlist(string type, IEnumerable<ElementWithID> elementslist)
        {
            if (type == "ID")
            {
                return elementslist.OrderBy(e => e.ID);
            }
            if (type == "Name")
            {
                return elementslist.OrderBy(e => e.Name);
            }
            if (type == "Type")
            {
                return elementslist.OrderBy(e => e.Type);
            }
            if (type == "Description")
            {
                return elementslist.OrderBy(e => e.Description);
            }
            return elementslist;
        }
    }
}
