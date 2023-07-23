using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Model;

namespace UI
{
    public partial class MainWindow : Window
    {
        private string removedDiacritics => TextWithDiacritics.Text.RemoveDiacritics();
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

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            status.Set("Copy");
            Clipboard.SetText(removedDiacritics);
        }

        private void TextWithDiacritics_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextWithoutDiacritics.Text = removedDiacritics;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            status.Set("Clear");
            TextWithDiacritics.Clear();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            status.Set("Load");
            var loadedText = FileManager.LoadTextFromOpenedFile();

            if (!string.IsNullOrEmpty(loadedText))
            {
                TextWithDiacritics.Text = loadedText;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            status.Set("Save");
            FileManager.SaveText(removedDiacritics);
        }
    }
}
