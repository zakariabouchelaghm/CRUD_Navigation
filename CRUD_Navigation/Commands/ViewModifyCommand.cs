using CRUD_Navigation.Models;
using CRUD_Navigation.Stores;
using CRUD_Navigation.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Navigation.Commands
{
    public class ViewModifyCommand : CommandBase
    {
        private NavigationStore _navigationStore;
        private CRUD _crud;

        public ViewModifyCommand(NavigationStore navigationStore, CRUD crud)
        {
            _navigationStore = navigationStore;
            _crud = crud;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel= new ModifyViewModel(_crud);
        }
    }
}
