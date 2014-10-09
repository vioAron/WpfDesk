using System;
using WpfDesk.Model;

namespace WpfDesk.ViewModel
{
    public class ClientViewModel
    {
        private readonly Client _client;

        public string Id { get { return _client.Id; } }

        public string Description { get { return _client.Description; } }

        public ClientViewModel(Client client)
        {
            if (client == null)
                throw new ArgumentNullException("client");

            _client = client;
        }

        public static ClientViewModel New(int idSuffix)
        {
            return new ClientViewModel(new Client { Id = string.Format("Client{0}", idSuffix), Description = string.Format("Great client{0}", idSuffix) });
        }
    }
}
