using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using MahApps.Metro;
using WpfDesk.Command;
using WpfDesk.View;

namespace WpfDesk.ViewModel
{
    public class AccentColorMenuData
    {
        public string Name { get; set; }
        public Brush BorderColorBrush { get; set; }
        public Brush ColorBrush { get; set; }

        private ICommand _changeAccentCommand;

        public ICommand ChangeAccentCommand
        {
            get { return _changeAccentCommand ?? (_changeAccentCommand = new SimpleCommand { CanExecuteDelegate = x => true, ExecuteDelegate = x => DoChangeTheme(x) }); }
        }

        protected virtual void DoChangeTheme(object sender)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            var accent = ThemeManager.GetAccent(this.Name);
            ThemeManager.ChangeAppStyle(Application.Current, accent, theme.Item1);
        }
    }

    public class AppThemeMenuData : AccentColorMenuData
    {
        protected override void DoChangeTheme(object sender)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            var appTheme = ThemeManager.GetAppTheme(Name);
            ThemeManager.ChangeAppStyle(Application.Current, theme.Item2, appTheme);
        }
    }

    public class MainViewModel
    {
        public MainViewModel()
        {
            // create metro theme color menu items for the demo
            AppThemes = ThemeManager.AppThemes
                                           .Select(a => new AppThemeMenuData { Name = a.Name, BorderColorBrush = a.Resources["BlackColorBrush"] as Brush, ColorBrush = a.Resources["WhiteColorBrush"] as Brush })
                                           .ToList();
        }
        public ICommand ClientsClickCommand
        {
            get
            {
                return new ShowClientsCommand();
            }
        }

        public ICommand CloseCommand
        {
            get
            {
                return ApplicationCommands.Close;
            }
        }

        public int RenderCapabilityValue
        {
            get
            {
                return RenderCapability.Tier >> 16;
            }
        }

        public ICommand AddClientClickCommand
        {
            get { return new AddClientClickCommand(); }
        }

        public List<AppThemeMenuData> AppThemes { get; set; }

        public ICommand ChangeRatesClickCommand
        {
            get { return new ChangeRatesClickCommand(); }
        }

        public void ShowClients()
        {
            var clientsWindow = new ClientsWindow();

            clientsWindow.Show();
        }

        public void AddClient()
        {
            throw new System.NotImplementedException();
        }

        public void ShowAddClient()
        {
            var addClientWindow = new AddClientWindow();

            addClientWindow.ShowDialog();
        }
    }
}
