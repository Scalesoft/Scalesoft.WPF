using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Scalesoft.WPF.Helpers.Behaviors
{
    public static class TextBoxBehaviors
    {
        public static readonly DependencyProperty EnterCommandProperty = DependencyProperty.RegisterAttached("EnterCommand", typeof(ICommand), typeof(TextBoxBehaviors), new PropertyMetadata(default(ICommand), OnEnterCommandChanged));

        public static ICommand GetEnterCommand(UIElement element)
        {
            return (ICommand)element.GetValue(EnterCommandProperty);
        }

        public static void SetEnterCommand(UIElement element, ICommand value)
        {
            element.SetValue(EnterCommandProperty, value);
        }

        private static void OnEnterCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textBox = d as TextBox;
            if (textBox == null)
                return;

            if (e.OldValue == null && e.NewValue != null)
            {
                textBox.PreviewKeyDown += OnPreviewKeyDown;
            }
            else if (e.OldValue != null && e.NewValue == null)
            {
                textBox.PreviewKeyDown -= OnPreviewKeyDown;
            }
        }

        private static void OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var textBox = sender as TextBox;
                if (textBox == null)
                    return;

                var textBinding = textBox.GetBindingExpression(TextBox.TextProperty);
                textBinding?.UpdateSource();

                var enterCommand = GetEnterCommand(textBox);
                if (enterCommand != null && enterCommand.CanExecute(null))
                    enterCommand.Execute(null);
            }
        }
    }
}