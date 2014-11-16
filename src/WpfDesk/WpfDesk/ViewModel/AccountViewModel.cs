using System;
using PropertyChanged;
using WpfDesk.Model;

namespace WpfDesk.ViewModel
{
    [ImplementPropertyChanged]
    public class AccountViewModel
    {
        private readonly Account _account;

        public string Id { get { return _account.Id; } }

        public string Description { get { return _account.Description; } }

        public AccountViewModel(Account account)
        {
            if (account == null)
                throw new ArgumentNullException("account");

            _account = account;
        }

        public static AccountViewModel New(int idSuffix)
        {
            return new AccountViewModel(new Account { Id = string.Format("Account_{0}", idSuffix), Description = string.Format("GreatAccount_{0}", idSuffix) });
        }
    }
}
