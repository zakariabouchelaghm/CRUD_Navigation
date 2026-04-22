using CRUD_Navigation.Commands;
using CRUD_Navigation.Models;
using CRUD_Navigation.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CRUD_Navigation.ViewModels
{
    class MainViewModel: ViewModelBase
    {

        private readonly NavigationStore _navigationStore;
        private readonly CRUD _crud;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        public ICommand View {  get; }
        public ICommand Add { get; }

        public ICommand Delete { get; }
        public ICommand Modify { get; }

        public MainViewModel(NavigationStore navigationstore,CRUD crud)
        {
            _navigationStore = navigationstore;
            _crud = crud;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            View = new ViewListCommand(navigationstore,_crud);
            Add = new ViewAddCommand(navigationstore, _crud);
            Delete = new ViewDeleteCommand(navigationstore, _crud);
            Modify = new ViewModifyCommand(navigationstore, _crud);
        }
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
