using System.Windows;

namespace Scalesoft.WPF.Helpers.Behaviors
{
    public class CloseWindowBehaviors
    {
        public static readonly DependencyProperty IsClosedProperty = DependencyProperty.RegisterAttached("IsClosed", typeof(bool), typeof(CloseWindowBehaviors), new PropertyMetadata(true, OnIsClosedChanged));

        public static bool GetIsClosed(Window element)
        {
            return (bool)element.GetValue(IsClosedProperty);
        }

        public static void SetIsClosed(Window element, bool value)
        {
            element.SetValue(IsClosedProperty, value);
        }

        private static void OnIsClosedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var window = d as Window;
            if (window == null)
                return;

            if ((bool) e.NewValue)
            {
                window.Close();
            }
        }
    }
}
