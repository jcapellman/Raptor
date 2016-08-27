using System;
using System.Collections.Generic;

using Windows.UI.Xaml.Controls;

using Raptor.LevelEditor.UWP.ViewModels;

namespace Raptor.LevelEditor.UWP.Views {
    public class MenuItem {
        public Symbol Icon { get; set; }

        public string Name { get; set; }

        public Type PageType { get; set; }

        public static List<MenuItem> GetMainItems() {
            var items = new List<MenuItem>();

            items.Add(new MenuItem() { Icon = Symbol.Contact, Name = "Your Levels", PageType = typeof(Views.YourLevelsPage) });
            items.Add(new MenuItem() { Icon = Symbol.World, Name = "Top Rated Levels", PageType = typeof(Views.TopRatedLevelsPages) });
            items.Add(new MenuItem() { Icon = Symbol.Setting, Name = "Settings", PageType = typeof(Views.SettingsPage) });

            return items;
        }        
    }

    public sealed partial class MainPage : Page {        
        private MainPageViewModel viewModel => (MainPageViewModel) DataContext;

        public MainPage() {
            this.InitializeComponent();

            hmMain.ItemsSource = MenuItem.GetMainItems();

            DataContext = new MainPageViewModel();
        }

        private void hmMain_ItemClick(object sender, ItemClickEventArgs e) {
            if (!(e.ClickedItem is MenuItem)) {
                return;
            }

            var item = (MenuItem)e.ClickedItem;

            fMain.Navigate(item.PageType);
        }
    }
}