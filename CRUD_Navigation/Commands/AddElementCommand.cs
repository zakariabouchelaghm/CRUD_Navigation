using CRUD_Navigation.Models;
using CRUD_Navigation.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Navigation.Commands
{
    public class AddElementCommand : CommandBase
    {
        private readonly CRUD _crud;
        private readonly AddViewModel _addViewModel;

        public AddElementCommand(CRUD crud, AddViewModel addViewModel)
        {
            _crud = crud;
            _addViewModel = addViewModel;
        }

        public override async void Execute(object? parameter)
        {
            Element element = new Element(_addViewModel.Name,_addViewModel.SelectedType,_addViewModel.Description);
            await _crud.Add(element);
        }

        public override bool CanExecute(object? parameter)
        {
            return  _addViewModel.HasName &&_addViewModel.HasType && _addViewModel.HasDescription && base.CanExecute(parameter);
        }
    }
}
