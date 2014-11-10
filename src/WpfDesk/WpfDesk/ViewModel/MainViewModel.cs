using System.Windows.Input;
using System.Windows.Media;
using WpfDesk.Command;
using WpfDesk.View;

namespace WpfDesk.ViewModel
{
    public class MainViewModel
    {
        public ICommand ClientsClickCommand
        {
            get
            {
                return new ShowClientsCommand();
            }
        }

        public ICommand CloseCommand
        {
            get
            {
                return ApplicationCommands.Close;
            }
        }

        public int RenderCapabilityValue
        {
            get
            {
                return RenderCapability.Tier >> 16;
            }
        }

        public ICommand AddClientClickCommand
        {
            get { return new AddClientClickCommand(); }
        }

        public void ShowClients()
        {
            var clientsWindow = new ClientsWindow();

            clientsWindow.Show();
        }

        public void AddClient()
        {
            throw new System.NotImplementedException();
        }

        public void ShowAddClient()
        {
            var addClientWindow = new AddClientWindow();

            addClientWindow.ShowDialog();
        }
    }
}
