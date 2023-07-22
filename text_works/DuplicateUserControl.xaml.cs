﻿using System.Windows;
using System.Windows.Controls;

namespace text_works
{
    /// <summary>
    /// Interaction logic for DuplicateUserControl.xaml
    /// </summary>
    public partial class DuplicateUserControl : UserControl
    {
        private readonly IStatus status;

        public DuplicateUserControl()
        {
            status = ((MainWindow)Application.Current.MainWindow).status;
            InitializeComponent();
        }
        
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            status.Set("Buffer cleared.");
            DuplicatesTextBlock.Text = string.Empty;
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            var duplicates = Resx.FindDuplicatesFromFile();

            foreach (var line in duplicates)
            {
                DuplicatesTextBlock.Text += line + "\n";
            }
            status.Set("Duplicates found.");
        }
    }
}
