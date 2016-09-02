using System;

using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace Raptor.LevelEditor.UWP.Views {
    public class BasePage : Page {
        public async void ShowMessage(string content, string title = Common.Constants.APP_NAME) {
            var md = new MessageDialog(content, title);

            await md.ShowAsync();
        }
    }
}