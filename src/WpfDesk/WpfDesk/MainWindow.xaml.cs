using System.Windows;
using System.Windows.Media;
using WpfDesk.View;
using WpfDesk.ViewModel;

namespace WpfDesk
{
    public partial class MainWindow
    {
        private ClientsWindow _clientsWindow;

        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new MainViewModel();
        }
        
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            _clientsWindow = new ClientsWindow();

            _clientsWindow.Show();
        }
    }
}
