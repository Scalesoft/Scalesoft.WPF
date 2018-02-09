using System;
using System.ComponentModel;
using System.Windows;

namespace Scalesoft.WPF.Navigation.Services.Helpers
{
    public class WindowBuilder
    {
        private readonly Window m_window;

        public WindowBuilder(Type windowType, Window owner)
        {
            m_window = (Window) Activator.CreateInstance(windowType);
            m_window.Owner = owner;
        }

        public WindowBuilder SetParameter(object parameter)
        {
            throw new NotSupportedException();
        }

        public WindowBuilder SetViewModel(INotifyPropertyChanged viewModel)
        {
            m_window.DataContext = viewModel;
            return this;
        }

        public WindowBuilder SetDisabled()
        {
            m_window.Owner.IsEnabled = false;

            return this;
        }

        public WindowBuilder SetAutoAdjust()
        {
            m_window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            return this;
        }

        public Window CreateWindow()
        {
            return m_window;
        }
    }
}
