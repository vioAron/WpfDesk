using System;
using System.Windows.Input;
using WpfDesk.ViewModel;

namespace WpfDesk.Command
{
    public class ShowClientsCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            var viewModel = (MainViewModel)parameter;
            
            viewModel.ShowClients();
        }
    }
}
