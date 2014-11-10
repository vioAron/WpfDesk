using System.Windows.Input;

namespace WpfDesk
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CommandBinding_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }
    }
}
