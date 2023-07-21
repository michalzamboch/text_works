using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace text_works
{
    public partial class MainWindow : Window
    {
        private string removedDiacritics => TextWithDiacritics.Text.RemoveDiacritics();
        public readonly RoutedCommand CopyCommand = new RoutedCommand();

        public MainWindow()
        {
            InitializeComponent();

            var keyGesture = new KeyGesture(Key.C, ModifierKeys.Control);
            CopyCommand.InputGestures.Add(keyGesture);

            TextWithDiacritics.TextChanged += TextWithDiacritics_TextChanged;
        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(removedDiacritics);
        }

        private void TextWithDiacritics_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            TextWithoutDiacritics.Text = removedDiacritics;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            TextWithDiacritics.Clear();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            var loadedText = FileManager.LoadTextFromOpenedFile();

            if (loadedText != "")
            {
                TextWithDiacritics.Text = loadedText;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            FileManager.SaveText(removedDiacritics);
        }
    }
}
