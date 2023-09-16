using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using UI.UIServices;

namespace UI
{
    public partial class MainWindow : Window
    {
        public readonly RoutedCommand CopyCommand = new RoutedCommand();
        public readonly IServices Services;

        public MainWindow()
        {
            InitializeComponent();
            Services = new Services(this);

            var keyGesture = new KeyGesture(Key.C, ModifierKeys.Control);
            CopyCommand.InputGestures.Add(keyGesture);
        }

        private void CloseCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private void TabSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Services.Status.Clear();
        }
    }
}
