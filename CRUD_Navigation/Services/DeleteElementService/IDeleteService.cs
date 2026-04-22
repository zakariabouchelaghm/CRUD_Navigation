using CRUD_Navigation.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Navigation.Services.DeleteElementService
{
    public  interface IDeleteService
    {
        Task<bool> DeleteElement(int Id);
    }
}
