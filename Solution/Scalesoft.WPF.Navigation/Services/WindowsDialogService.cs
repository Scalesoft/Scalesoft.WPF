using System.ComponentModel;
using System.Linq;
using System.Windows;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using Scalesoft.WPF.Navigation.Services.Helpers;
using Scalesoft.WPF.Navigation.Types;

namespace Scalesoft.WPF.Navigation.Services
{
    public class WindowsDialogService<TMainWindow> : IDialogService where TMainWindow : Window
    {
        private readonly IDialogTypeLocator m_dialogTypeLocator;

        public WindowsDialogService(IDialogTypeLocator dialogTypeLocator)
        {
            m_dialogTypeLocator = dialogTypeLocator;
        }

        private Window CurrentActiveWindow
        {
            get
            {
                var windows = Application.Current.Windows;
                var window = windows.OfType<Window>().FirstOrDefault(x => x.IsActive) ??
                             windows.OfType<TMainWindow>().SingleOrDefault();
                return window;
            }
        }

        public void ShowModal<T>() where T : Window
        {
            var newView = new WindowBuilder(typeof(T), CurrentActiveWindow)
                .SetAutoAdjust()
                .CreateWindow();
            newView.ShowDialog();
        }

        public void ShowModal<T>(object parameter) where T : Window
        {
            var newView = new WindowBuilder(typeof(T), CurrentActiveWindow)
                .SetAutoAdjust()
                .SetParameter(parameter)
                .CreateWindow();
            newView.ShowDialog();
        }

        public void ShowModal(INotifyPropertyChanged viewModel)
        {
            var viewType = m_dialogTypeLocator.Locate(viewModel);
            var newView = new WindowBuilder(viewType, CurrentActiveWindow)
                .SetAutoAdjust()
                .SetViewModel(viewModel)
                .CreateWindow();

            newView.ShowDialog();
        }

        public void Show<T>() where T : Window
        {
            var newView = new WindowBuilder(typeof(T), CurrentActiveWindow)
                .SetAutoAdjust()
                .CreateWindow();
            newView.Show();
        }

        public void Show<T>(object parameter) where T : Window
        {
            var newView = new WindowBuilder(typeof(T), CurrentActiveWindow)
                .SetAutoAdjust()
                .SetParameter(parameter)
                .CreateWindow();
            newView.Show();
        }

        public void Show(INotifyPropertyChanged viewModel)
        {
            var viewType = m_dialogTypeLocator.Locate(viewModel);
            var newView = new WindowBuilder(viewType, CurrentActiveWindow)
                .SetAutoAdjust()
                .SetViewModel(viewModel)
                .CreateWindow();

            newView.Show();
        }

        public DialogResult ShowMessageDialog(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon)
        {
            var result = MessageBox.Show(CurrentActiveWindow, messageBoxText, caption, button, icon);
            return MessageBoxHelper.ConvertMessageBoxResult(result);
        }

        public string ShowOpenFileDialog(FileDialogFilterBuilder filterBuilder)
        {
            var filter = filterBuilder.ToFilterString();
            return ShowOpenFileDialog(filter);
        }
        
        public string ShowOpenFileDialog(string filter)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = filter,
            };

            var dialogResult = openFileDialog.ShowDialog(CurrentActiveWindow);

            return dialogResult == true ? openFileDialog.FileName : null;
        }

        public string ShowSaveFileDialog(FileDialogFilterBuilder filterBuilder, string fileName)
        {
            var filter = filterBuilder.ToFilterString();
            return ShowSaveFileDialog(filter, fileName);
        }

        public string ShowSaveFileDialog(string filter, string fileName)
        {
            var saveFileDialog = new SaveFileDialog
            {
                FileName = fileName,
                Filter = filter,
            };

            var dialogResult = saveFileDialog.ShowDialog(CurrentActiveWindow);

            return dialogResult == true ? saveFileDialog.FileName : null;
        }

        public string ShowOpenFolderDialog()
        {
            var openFolderDialog = FileDialogHelper.CreateOpenFolderDialog(null);
            
            var dialogeResult = openFolderDialog.ShowDialog(CurrentActiveWindow);
            
            return dialogeResult == CommonFileDialogResult.Ok ? openFolderDialog.FileName : null;
        }

        public void ShutdownApplication(int returnCode = 0)
        {
            Application.Current.Shutdown(returnCode);
        }

        public void CloseAllDialogs()
        {
            var mainWindow = Application.Current.Windows.OfType<TMainWindow>().SingleOrDefault();
            if (mainWindow != null)
            {
                WindowHelper.CloseAllOwnedWindows(mainWindow);
            }
        }
    }
}
