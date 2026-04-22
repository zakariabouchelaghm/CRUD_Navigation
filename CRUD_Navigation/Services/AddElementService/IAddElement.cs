using CRUD_Navigation.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Navigation.Services.AddElementService
{
    public interface IAddElement
    {
        Task AddElement(Element element);
    }
}
