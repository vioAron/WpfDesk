using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfDesk.ViewModel;

namespace WpfDesk.Command
{
    public class AddClientClickCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var viewModel = (MainViewModel) parameter;
            viewModel.ShowAddClient();
        }

        public event EventHandler CanExecuteChanged;
    }
}
