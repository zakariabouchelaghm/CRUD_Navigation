using CRUD_Navigation.Commands;
using CRUD_Navigation.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace CRUD_Navigation.ViewModels
{
    public class ViewViewModel : ViewModelBase
    {
        private readonly CRUD _crud;
        public ObservableCollection<ElementWithID> elements;

        private List<string> _types;
        public List<string> SortingTypes => _types;
        public IEnumerable<ElementWithID> Elements => elements;

        public string _SearchID;
        public string SearchID
        {
            get => _SearchID;
            set
            {
                _SearchID = value;
                OnPropertyChanged(nameof(SearchID));
                (Search as SearchElementCommand)?.OnCanExecutedChanged();
                if (value == null)
                {
                    Load_Elements_async();
                }
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
               
                    Sort_Elements_async();
                
            }
        }

        public ICommand Search {  get; set; }

        public ViewViewModel(CRUD crud)
        {
            _crud = crud;
            _types = ["ID","Name", "Type", "Description"];
            elements = new ObservableCollection<ElementWithID>();
            Search = new SearchElementCommand(this, _crud);
            Load_Elements_async();

        }

        private async void Load_Elements_async()
        {

            elements.Clear();
            try
            {
                // Await the task from the store
                IEnumerable<ElementWithID> elementss = await _crud.ListELements();

                foreach (var element in elementss)
                {
                    elements.Add(element);
                }
            }
            catch (Exception ex)
            {
                // Optional: Handle errors (e.g., show a message box)
                MessageBox.Show("Failed to load tickets: " + ex.Message);
            }
        }

        private async void Sort_Elements_async()
        {
            List<ElementWithID> oldelementss = elements.ToList();

            
            try
            {
                // Await the task from the store
                IEnumerable<ElementWithID> elementss = _crud.SortedList(SelectedType,oldelementss);
                elements.Clear();
                foreach (var element in elementss)
                {
                    elements.Add(element);
                }
                
            }
            catch (Exception ex)
            {
                // Optional: Handle errors (e.g., show a message box)
                MessageBox.Show("Failed to sort elements: " + ex.Message);
            }
        }
    }
}
