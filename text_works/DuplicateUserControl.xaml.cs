using System.Windows;
using System.Windows.Controls;

namespace text_works
{
    /// <summary>
    /// Interaction logic for DuplicateUserControl.xaml
    /// </summary>
    public partial class DuplicateUserControl : UserControl
    {
        public DuplicateUserControl()
        {
            InitializeComponent();
        }
        
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            DuplicatesTextBlock.Text = string.Empty;
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            var duplicates = Resx.FindDuplicatesFromFile();

            foreach (var line in duplicates)
            {
                DuplicatesTextBlock.Text += line + "\n";
            }
        }
    }
}
