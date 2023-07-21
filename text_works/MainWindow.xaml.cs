using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.TextFormatting;
using Microsoft.Win32;

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
            var filePath = FileOpener.GetOpenFilePath();
            Debug.Write(filePath);

            try
            {
                TextWithDiacritics.Text = File.ReadAllText(filePath);
            }
            catch
            {
                Debug.Write($"Can not load {filePath}");
            }
        }
    }
}
