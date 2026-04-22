using CRUD_Navigation.Models;
using CRUD_Navigation.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace CRUD_Navigation.Commands
{
    public class SearchElementCommand : CommandBase
    {
        private readonly CRUD _crud;
        private readonly ViewViewModel _viewViewModel;

        public SearchElementCommand(ViewViewModel viewViewModel,CRUD crud)
        {
            _crud = crud;
            _viewViewModel = viewViewModel;
        }

        public override async void Execute(object? parameter)
        {
            
            string Id = _viewViewModel.SearchID;
           
                try
                {
                    ElementWithID element = await _crud.SearchElement(int.Parse(Id));
                    if (element != null)
                    {
                        _viewViewModel.elements.Clear();
                        _viewViewModel.elements.Add(element);
                    }
                    else
                    {
                        _viewViewModel.elements.Clear();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

        public override bool CanExecute(object? parameter)
        {
             return int.TryParse(_viewViewModel.SearchID, out _) && base.CanExecute(parameter);
        }
            
        
        
    }
}
