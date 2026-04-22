using CRUD_Navigation.Models;
using CRUD_Navigation.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace CRUD_Navigation.Commands
{
    public class DeleteElementCommand : CommandBase
    {
        private readonly CRUD _crud;
        private readonly DeleteViewModel _deleteViewModel;

        public DeleteElementCommand(CRUD crud, DeleteViewModel deleteViewModel)
        {
            _crud = crud;
            _deleteViewModel = deleteViewModel;
        }

        public override async void Execute(object? parameter)
        {
            int id = int.Parse(_deleteViewModel.Id);
            bool idseleted=await _crud.Delete(id);

            if (!idseleted) { 
                MessageBox.Show($"Element With the ID: {id} does not exist!","Error",MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return int.TryParse(_deleteViewModel.Id, out _) && base.CanExecute(parameter);
        }
    }
}
