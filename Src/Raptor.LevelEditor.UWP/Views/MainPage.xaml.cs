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
            var items = new List<MenuItem> {
                new MenuItem() {Icon = Symbol.Contact, Name = "Your Levels", PageType = typeof (Views.YourLevelsPage)},
                new MenuItem() {
                    Icon = Symbol.World,
                    Name = "Top Rated Levels",
                    PageType = typeof (Views.TopRatedLevelsPages)
                },
                new MenuItem() {Icon = Symbol.Setting, Name = "Settings", PageType = typeof (Views.SettingsPage)}
            };
            
            return items;
        }
    }

    public sealed partial class MainPage {
        private MainPageViewModel viewModel => (MainPageViewModel)DataContext;

        public MainPage() {
            this.InitializeComponent();

            hmMain.ItemsSource = MenuItem.GetMainItems();

            DataContext = new MainPageViewModel();
        }

        private void hmMain_ItemClick(object sender, ItemClickEventArgs e) {
            var clickedItem = (e.ClickedItem as MenuItem);

            if (clickedItem == null) {
                return;
            }

            fMain.Navigate(clickedItem.PageType);
        }
    }
}