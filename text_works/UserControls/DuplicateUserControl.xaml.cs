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

            DuplicatesTextBlock.Text = string.Empty;
            foreach (var line in duplicates)
            {
                DuplicatesTextBlock.Text += line + "\n";
            }
            
            status.Set("Duplicates found.");
        }
    }
}
