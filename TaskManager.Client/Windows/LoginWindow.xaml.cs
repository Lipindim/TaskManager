using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TaskManager.Domain.Entities;
using TaskManager.Services;
using TaskManager.Services.Contract;
using TaskManager.Services.Helpers;

namespace TaskManager.Client.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        IUserContract UserContract;

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btn_enter_Click(object sender, RoutedEventArgs e)
        {
            User currentUser = UserContract.GetUsers().FirstOrDefault(x => x.Login.Trim().ToLower() == tb_login.Text.Trim().ToLower());
            if (currentUser == null)
            {
                MessageBox.Show("Неверный логин");
                return;
            }
            if (CryptoHelper.VerifyMd5Hash(pass.Password, currentUser.Password))
            {
                GlobalSettings.CurrentUser = currentUser;
                new MainWindow().Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный пароль");
                return;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UserContract = ContractManager.GetUserContract();
        }
    }
}
