using System.Windows;
using System.Windows.Controls;
using Model;

namespace UI.UserControls
{
    /// <summary>
    /// Interaction logic for DiacriticsUserControl.xaml
    /// </summary>
    public partial class DiacriticsUserControl : UserControl
    {
        private string removedDiacritics => TextWithDiacritics.Text.RemoveDiacritics();
        private readonly IStatus status;
        
        public DiacriticsUserControl()
        {
            status = ((MainWindow)Application.Current.MainWindow).status;
            InitializeComponent();
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
