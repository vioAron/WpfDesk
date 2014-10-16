using System.Collections.ObjectModel;

namespace WpfDesk.ViewModel
{
    public class ClientsViewModel
    {
        public ObservableCollection<ClientViewModel> ClientViewModels { get; private set; }

        private const int NumberOfClients = 100;

        public ClientsViewModel()
        {
            ClientViewModels = new ObservableCollection<ClientViewModel>();

            LoadClients();
        }

        private void LoadClients()
        {
            for (var i = 0; i < NumberOfClients; i++)
            {
                ClientViewModels.Add(ClientViewModel.New(i));
            }
        }
    }
}
