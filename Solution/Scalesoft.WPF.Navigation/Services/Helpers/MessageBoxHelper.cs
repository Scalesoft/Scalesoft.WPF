using System;
using System.Windows;
using Scalesoft.WPF.Navigation.Types;

namespace Scalesoft.WPF.Navigation.Services.Helpers
{
    public static class MessageBoxHelper
    {
        public static DialogResult ConvertMessageBoxResult(MessageBoxResult result)
        {
            switch (result)
            {
                case MessageBoxResult.None:
                case MessageBoxResult.Cancel:
                case MessageBoxResult.No:
                    return DialogResult.Cancel;
                case MessageBoxResult.OK:
                case MessageBoxResult.Yes:
                    return DialogResult.Success;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
