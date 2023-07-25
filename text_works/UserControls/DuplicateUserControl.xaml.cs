using System.Windows;
using System.Windows.Controls;
using Model;

namespace UI.UserControls
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
            
            if (duplicates.Count == 0)
            {
                DuplicatesTextBlock.Text = string.Empty;
                status.Set("No duplicates found.");
            }
            else
            {
                DuplicatesTextBlock.Text = string.Join("\n", duplicates);
                status.Set($"{duplicates.Count} duplicates found.");
            }
        }
    }
}
