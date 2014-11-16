using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfDesk.View;

namespace WpfDesk.Command
{
    public class ChangeRatesClickCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var view = new ChangeRatesWindow();
            view.Show();
        }

        public event EventHandler CanExecuteChanged;
    }
}
