using HueDesign.Settings;
using HueDesign.Welcome;
using SplitViewMenu;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HueDesign
{
    public class MainViewModel: INotifyPropertyChanged
    {
        public MainViewModel()
        {
            MenuItems = new ObservableCollection<SimpleNavMenuItem>();
            
            InitialPage = typeof(WelcomePage);
        }

        public ObservableCollection<SimpleNavMenuItem> MenuItems { get; }
        public Type InitialPage { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
