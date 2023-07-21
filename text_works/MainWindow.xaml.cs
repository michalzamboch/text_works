﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace text_works
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
