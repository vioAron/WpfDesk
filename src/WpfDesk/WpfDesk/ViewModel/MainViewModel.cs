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

        public int RenderCapabilityValue
        {
            get
            {
                return RenderCapability.Tier >> 16;
            }
        }

        public void ShowClients()
        {
            var clientsWindow = new ClientsWindow();

            clientsWindow.Show();
        }
    }
}
