using System;
using System.Windows.Input;
using WpfDesk.ViewModel;

namespace WpfDesk.Command
{
    public class AddClientCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var viewModel = (MainViewModel) parameter;

            viewModel.AddClient();
        }

        public event EventHandler CanExecuteChanged;
    }
}
