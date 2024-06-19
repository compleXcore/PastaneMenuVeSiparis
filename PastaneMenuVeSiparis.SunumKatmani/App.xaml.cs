using PastaneMenuVeSiparis.SunumKatmani.Views.LoginView;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PastaneMenuVeSiparis.SunumKatmani
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //LoginView loginView = new LoginView();
            MainWindow main = new MainWindow();
            LoginView loginVM = new LoginView();
            if (loginVM.ShowDialog() == true)
            {
                main.Show();
            }
            else
            {
                main.Close();
            }
        }
    }
}
