using System.Windows;
using System.Windows.Input;

namespace UI
{
    public partial class MainWindow : Window
    {
        public readonly RoutedCommand CopyCommand = new RoutedCommand();
        public readonly IStatus status;

        public MainWindow()
        {
            InitializeComponent();
            status = new Status(StatusLabel);

            var keyGesture = new KeyGesture(Key.C, ModifierKeys.Control);
            CopyCommand.InputGestures.Add(keyGesture);
        }

        private void CloseCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }
    }
}
