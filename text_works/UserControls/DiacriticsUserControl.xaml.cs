using Model;
using System.Windows;
using System.Windows.Controls;
using UI.UIServices;

namespace UI.UserControls
{
    public partial class DiacriticsUserControl : UserControl
    {
        private string removedDiacritics => TextWithDiacritics.Text.RemoveDiacritics();
        private readonly IServices services;

        public DiacriticsUserControl()
        {
            services = ((MainWindow)Application.Current.MainWindow).Services;
            InitializeComponent();
        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            services.Status.Set("Copy");
            Clipboard.SetText(removedDiacritics);
        }

        private void TextWithDiacritics_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextWithoutDiacritics.Text = removedDiacritics;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            services.Status.Set("Clear");
            TextWithDiacritics.Clear();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            services.Status.Set("Load");
            var loadedText = FileManager.LoadTextFromOpenedFile();

            if (!string.IsNullOrEmpty(loadedText))
            {
                TextWithDiacritics.Text = loadedText;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(removedDiacritics))
            {
                services.Status.Set("Nothing to save.");
            }
            else
            {
                FileManager.SaveText(removedDiacritics);
                services.Status.Set("Saved.");
            }
        }
    }
}
