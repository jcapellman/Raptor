﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

using Raptor.LevelEditor.UWP.Annotations;

namespace Raptor.LevelEditor.UWP.ViewModels {
    public class BaseViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}