using System.Windows;
using WpfDesk.ViewModel;

namespace WpfDesk.View
{
    /// <summary>
    /// Interaction logic for ClientsWindow.xaml
    /// </summary>
    public partial class ClientsWindow
    {
        public ClientsWindow()
        {
            InitializeComponent();
        }

        private void ClientsWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            DataContext = new ClientsViewModel();
        }
    }
}
