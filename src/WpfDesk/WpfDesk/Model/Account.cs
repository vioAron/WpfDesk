namespace WpfDesk.Model
{
    public class Account
    {
        public string Id { get; set; }
        public string Description { get; set; }
    
        public static Account New(int idSuffix)
        {
            return new Account { Id = string.Format("Account_{0}", idSuffix), 
                Description = string.Format("GreatAccount_{0}", idSuffix) };
        }
    }
}
