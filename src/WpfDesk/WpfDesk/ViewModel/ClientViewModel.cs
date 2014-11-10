using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WpfDesk.MVVM.Infrastructure;
using WpfDesk.Model;

namespace WpfDesk.ViewModel
{
    public class ClientViewModel : ViewModelBase
    {
        private readonly Client _client;

        [Required]
        public string Id
        {
            get { return GetValue(() => _client.Id); }
            set { SetValue(() => _client.Id, value); }
        }

        public string Description { get { return _client.Description; } }

        public IEnumerable<AccountViewModel> AccountViewModels { get; private set; }

        public ClientViewModel(Client client, IEnumerable<AccountViewModel> accountViewModels)
        {
            if (client == null)
                throw new ArgumentNullException("client");
            if (accountViewModels == null)
                throw new ArgumentNullException("accountViewModels");

            _client = client;

            AccountViewModels = accountViewModels;
        }

        public static ClientViewModel New(int idSuffix)
        {
            return new ClientViewModel(new Client { Id = string.Format("Client{0}", idSuffix), Description = string.Format("Great client{0}", idSuffix) },
                new[] { new AccountViewModel(Account.New(idSuffix)), new AccountViewModel(Account.New(idSuffix)) });
        }
    }
}
