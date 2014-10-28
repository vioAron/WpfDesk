using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using WpfDesk.Model;
using WpfDesk.TypeConverters;

namespace WpfDesk.Controls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ClientUserControl : UserControl
    {
        private Client _client;

        public ClientUserControl()
        {
            InitializeComponent();
        }

        [TypeConverter(typeof(ClientTypeConverter))]
        public Client Client
        {
            get { return _client; }
            set
            {
                _client = value;
                DataContext = _client;
            }
        }

        //public static readonly DependencyProperty ClientProperty =
        //    DependencyProperty.Register("Client", typeof(string), typeof(Client),
        //    new PropertyMetadata(null));
    }
}
