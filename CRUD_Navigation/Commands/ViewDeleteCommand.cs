using CRUD_Navigation.Models;
using CRUD_Navigation.Stores;
using CRUD_Navigation.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Navigation.Commands
{
    public class ViewDeleteCommand : CommandBase
    {
        private NavigationStore _navigationStore;
        private CRUD _crud;

        public ViewDeleteCommand(NavigationStore navigationStore, CRUD crud)
        {
            _navigationStore = navigationStore;
            _crud = crud;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new DeleteViewModel(_crud);
        }
    }
}
