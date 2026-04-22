using CRUD_Navigation.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Navigation.Services.ModifyElementService
{
    public interface IModifyElement
    {  

        Task<bool> ModifyElement(int Id,Element element);
    }
}
