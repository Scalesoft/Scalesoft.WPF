using System;
using System.ComponentModel;

namespace Scalesoft.WPF.Navigation.Services
{
    public interface IDialogTypeLocator
    {
        Type Locate(INotifyPropertyChanged viewModel);
    }
}