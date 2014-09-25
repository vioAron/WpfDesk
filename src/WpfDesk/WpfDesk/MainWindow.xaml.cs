using System.Windows;

namespace WpfDesk
{
    public partial class MainWindow
    {
        private ClientsWindow _clientsWindow;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            _clientsWindow = new ClientsWindow();
            _clientsWindow.Show();
        }
    }
}
