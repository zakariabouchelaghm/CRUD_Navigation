using CRUD_Navigation.Models;
using CRUD_Navigation.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace CRUD_Navigation.Commands
{
    public class ModifyElementCommand : CommandBase
    {
        private readonly CRUD _crud;
        private readonly ModifyViewModel _modifyViewModel;

        public ModifyElementCommand(CRUD crud, ModifyViewModel modifyViewModel)
        {
            _crud = crud;
            _modifyViewModel = modifyViewModel;
        }

        public override async void Execute(object? parameter)
        {
            int id = int.Parse(_modifyViewModel.Id);
            Element element = new Element(_modifyViewModel.Name, _modifyViewModel.SelectedType, _modifyViewModel.Description);
            bool ismodified = await _crud.Modify(id, element);
            if (!ismodified)
            {
                MessageBox.Show($"Element with The ID: {id} not found!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public override bool CanExecute(object? parameter)
        {
            return _modifyViewModel.HasName && _modifyViewModel.HasType && _modifyViewModel.HasDescription && int.TryParse(_modifyViewModel.Id, out _) && base.CanExecute(parameter);
        }
    }
}
