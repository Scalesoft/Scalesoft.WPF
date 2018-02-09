using Microsoft.WindowsAPICodePack.Dialogs;

namespace Scalesoft.WPF.Navigation.Services.Helpers
{
    public static class FileDialogHelper
    {
        public static CommonOpenFileDialog CreateOpenFolderDialog(string title, string currentDirectory = null)
        {
            var dialog = new CommonOpenFileDialog
            {
                Title = title,
                IsFolderPicker = true,
                InitialDirectory = currentDirectory,

                AddToMostRecentlyUsedList = false,
                AllowNonFileSystemItems = false,
                DefaultDirectory = currentDirectory,
                EnsureFileExists = true,
                EnsurePathExists = true,
                EnsureReadOnly = false,
                EnsureValidNames = true,
                Multiselect = false,
                ShowPlacesList = true
            };
            return dialog;
        }
    }
}
