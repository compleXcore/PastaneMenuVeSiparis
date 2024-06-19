using PastaneMenuVeSiparis.IsKatmani;
using System.Windows;

namespace PastaneMenuVeSiparis.SunumKatmani.Views.LoginView
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using(KullaniciManager kullaniciManager = new KullaniciManager())
            {
                if(kullaniciManager.Giris(txtKullaniciAdi.Text, txtParola.Password))
                {
                    lblError.Text = "";
                    this.DialogResult = true;
                }
                else
                {
                    lblError.Text = "Kullanıcı Adı yada parola hatalı";
                }
            }
        }
    }
}
