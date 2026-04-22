using CRUD_Navigation.Commands;
using CRUD_Navigation.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CRUD_Navigation.ViewModels
{
    public class AddViewModel : ViewModelBase
    {
        private readonly  CRUD _crud;
        private List<string> _types;
        public List<string> Types => _types;

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
                (Add as AddElementCommand)?.OnCanExecutedChanged();
            }
        }

        private string _description;

        

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
                (Add as AddElementCommand)?.OnCanExecutedChanged();
            }
        }
        private string _selectedtype;
        public string SelectedType
        {
            get => _selectedtype;
            set
            {
                _selectedtype = value;
                OnPropertyChanged(nameof(SelectedType));
                (Add as AddElementCommand)?.OnCanExecutedChanged();
            }
        }

        public bool HasName => !string.IsNullOrEmpty(Name);
        public bool HasType => !string.IsNullOrEmpty(SelectedType);
        public bool HasDescription => !string.IsNullOrEmpty(Description);

        public ICommand Add { get; set;  }

        public AddViewModel(CRUD crud)
        {
            _crud = crud;
            _types = ["Type 1", "Type 2", "Type 3", "Type 3", "Type 4"];
            Add = new AddElementCommand(_crud,this); 

        }

         

    }
}


        
        
