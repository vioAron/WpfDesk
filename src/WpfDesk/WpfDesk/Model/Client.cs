using System.Collections.Generic;

namespace WpfDesk.Model
{
    public class Client
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public IEnumerable<Account> Accounts { get; set; }
    }
}
