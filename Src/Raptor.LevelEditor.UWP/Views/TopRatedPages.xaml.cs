﻿using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

using Raptor.LevelEditor.UWP.ViewModels;

namespace Raptor.LevelEditor.UWP.Views {
    public sealed partial class TopRatedLevelsPages : Page {
        private TopRatedPageViewModel viewModel => (TopRatedPageViewModel)DataContext;

        public TopRatedLevelsPages() {
            this.InitializeComponent();

            DataContext = new TopRatedPageViewModel();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e) {
            var result = await viewModel.LoadData();
        }
    }
}