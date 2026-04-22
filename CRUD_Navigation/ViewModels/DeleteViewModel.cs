using CRUD_Navigation.Commands;
using CRUD_Navigation.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CRUD_Navigation.ViewModels
{
    public class DeleteViewModel: ViewModelBase
    {
        private readonly CRUD _crud;

        private string _id;



        public string Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
                (Delete as DeleteElementCommand)?.OnCanExecutedChanged();
            }
        }

        public ICommand Delete {  get; set; }

        public DeleteViewModel(CRUD crud)
        {
            _crud = crud;
            Delete = new DeleteElementCommand(_crud,this);
        }


    }
}
