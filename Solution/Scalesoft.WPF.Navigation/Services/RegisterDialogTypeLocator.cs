using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace Scalesoft.WPF.Navigation.Services
{
    public class RegisterDialogTypeLocator : IDialogTypeLocator
    {
        private readonly Dictionary<string, Type> m_locatorDictionary = new Dictionary<string, Type>();

        public Type Locate(INotifyPropertyChanged viewModel)
        {
            var name = viewModel.GetType().FullName;
            if (m_locatorDictionary.TryGetValue(name, out var type))
            {
                return type;
            }

            throw new ArgumentException($"No view is registered for ViewModel {name}. Use Add method of RegisterDialogTypeLocator to register.");
        }

        public void Add(Type viewModelType, Type viewType)
        {
            var name = viewModelType.FullName;
            m_locatorDictionary.Add(name, viewType);
        }

        public void Add<TViewModel, TView>() where TViewModel : INotifyPropertyChanged where TView : Window
        {
            var viewModelType = typeof(TViewModel);
            var viewType = typeof(TView);
            Add(viewModelType, viewType);
        }
    }
}