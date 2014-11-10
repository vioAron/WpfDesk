using System.Windows.Input;
using WpfDesk.Command;
using WpfDesk.MVVM.Infrastructure;

namespace WpfDesk.ViewModel
{
    public class AddClietViewModel : ViewModelBase
    {
        public ICommand AddClient
        {
            get { return new AddClientCommand(); }
        }
    }
}