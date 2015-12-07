using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SplitViewMenu;
using HueDesign.Settings;
using HueDesign.Lights;
using HueDesign.Room;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HueDesign
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Network network = new Network();
            var mainViewModel = new MainViewModel();
            mainViewModel.MenuItems.Add(new SimpleNavMenuItem
            {
                Label = "Lights",
                DestinationPage = typeof(LightsPage),
                Symbol = (Symbol)Convert.ToChar(""),
                Arguments = network
            });
            mainViewModel.MenuItems.Add(new SimpleNavMenuItem
            {
                Label = "Room",
                DestinationPage = typeof(RoomPage),
                Symbol = Symbol.Street,
                Arguments = network
                
            });
            mainViewModel.MenuItems.Add(new SimpleNavMenuItem
            {
                Label = "Settings",
                DestinationPage = typeof(SettingsPage),
                Symbol = Symbol.Setting,
                Arguments = network
            });
            DataContext = mainViewModel;
        }
    }
}
