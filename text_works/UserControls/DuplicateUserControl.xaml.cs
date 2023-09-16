using System.Windows;
using System.Windows.Controls;
using Model;
using UI.UIServices;

namespace UI.UserControls
{
    /// <summary>
    /// Interaction logic for DuplicateUserControl.xaml
    /// </summary>
    public partial class DuplicateUserControl : UserControl
    {
        private readonly IServices services;

        public DuplicateUserControl()
        {
            services = ((MainWindow)Application.Current.MainWindow).Services;
            InitializeComponent();
        }
        
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            services.Status.Set("Buffer cleared.");
            DuplicatesTextBlock.Text = string.Empty;
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            var duplicates = Resx.FindDuplicatesFromFile();
            
            if (duplicates.Count == 0)
            {
                DuplicatesTextBlock.Text = string.Empty;
                services.Status.Set("No duplicates found.");
            }
            else
            {
                DuplicatesTextBlock.Text = string.Join("\n", duplicates);
                services.Status.Set($"{duplicates.Count} duplicates found.");
            }
        }
    }
}
