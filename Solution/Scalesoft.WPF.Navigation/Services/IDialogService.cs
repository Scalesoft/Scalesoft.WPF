using System.ComponentModel;
using System.Windows;
using Scalesoft.WPF.Navigation.Services.Helpers;
using Scalesoft.WPF.Navigation.Types;

namespace Scalesoft.WPF.Navigation.Services
{
    public interface IDialogService
    {
        void ShowModal<T>() where T : Window;

        void ShowModal<T>(object parameter) where T : Window;

        void ShowModal(INotifyPropertyChanged viewModel);

        void Show<T>() where T : Window;

        void Show<T>(object parameter) where T : Window;

        void Show(INotifyPropertyChanged viewModel);

        DialogResult ShowMessageDialog(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon);

        string ShowOpenFileDialog(FileDialogFilterBuilder filterBuilder);

        string ShowOpenFileDialog(string filter);

        string ShowSaveFileDialog(FileDialogFilterBuilder filterBuilder, string fileName);

        string ShowSaveFileDialog(string filter, string fileName);

        string ShowOpenFolderDialog();

        void ShutdownApplication(int returnCode = 0);

        void CloseAllDialogs();
    }
}
