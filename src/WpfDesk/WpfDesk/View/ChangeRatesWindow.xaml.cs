using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using c = MahApps.Metro.Controls;

namespace WpfDesk.View
{
    /// <summary>
    /// Interaction logic for ChangeRatesWindow.xaml
    /// </summary>
    public partial class ChangeRatesWindow
    {
        public ChangeRatesWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            EditChangeRateFlyout.IsOpen = true;
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            OverlayGrid.Visibility = Visibility.Visible;
            EditChangeRateFlyout.IsEnabled = false;
            var task = Task.Factory.StartNew(() => Thread.Sleep(5000));

            task.ContinueWith(t =>
            {
                EditChangeRateFlyout.IsEnabled = true;
                OverlayGrid.Visibility = Visibility.Collapsed;
                EditChangeRateFlyout.IsOpen = false;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddChangeRateWindow();
            window.Show();
        }
    }
}
