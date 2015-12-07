using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HueDesign.Lights
{
    public class LightsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand _addTodoItemCommand;

        public ObservableCollection<CustomListItem> Items
        {
            get; set;
        } = new ObservableCollection<CustomListItem>();

        private string _newItemDescription;

        public string NewItemDescription
        {
            get { return _newItemDescription; }
            set
            {
                _newItemDescription = value;
                onPropertyChanged(nameof(NewItemDescription));
            }
        }
        public LightsViewModel()
        {
            _addTodoItemCommand = new DelegateCommand(AddNewTodoItem);
        }

        private void AddNewTodoItem()
        {
           //
        }

        public ICommand AddNewTodoItemCommand
        {
            get { return _addTodoItemCommand; }
        }

        private void onPropertyChanged(string propertyName)
        {
            var eventHandler = PropertyChanged;

            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
