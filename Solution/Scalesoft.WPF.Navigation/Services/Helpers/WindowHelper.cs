using System.Windows;

namespace Scalesoft.WPF.Navigation.Services.Helpers
{
    public static class WindowHelper
    {
        public static void CloseAllWindows(Window window)
        {
            foreach (Window ownedWindow in window.OwnedWindows)
            {
                CloseAllWindows(ownedWindow);
            }
            window.Close();
        }

        public static void CloseAllOwnedWindows(Window window)
        {
            foreach (Window ownedWindow in window.OwnedWindows)
            {
                CloseAllWindows(ownedWindow);
            }
        }
    }
}
