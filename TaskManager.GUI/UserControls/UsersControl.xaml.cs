using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskManager.Domain.Entities;
using TaskManager.Services.Contract;

namespace TaskManager.GUI.UserControls
{
    /// <summary>
    /// Логика взаимодействия для UserControl.xaml
    /// </summary>
    public partial class UsersControl : UserControl
    {
        IUserContract userContract;
        ObservableCollection<User> userCollection;
        User selectedUser;
        private bool isNew;

        public UsersControl()
        {
            InitializeComponent();

            userContract = ChannelFactory<IUserContract>.CreateChannel(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:9000/IUserContract"));
            RefreshData();
            combo_role.ItemsSource = Enum.GetValues(typeof(Role));
        }

        private void RefreshData()
        {
            userCollection = new ObservableCollection<User>(userContract.GetUsers());
            list_user.ItemsSource = userCollection;
        }

        private void list_user_MouseUp(object sender, MouseButtonEventArgs e)
        {
            stack_details.Width = 300;

            selectedUser = userCollection[list_user.SelectedIndex];
            tb_email.Text = selectedUser.Email;
            tb_fio.Text = selectedUser.FIO;
            tb_login.Text = selectedUser.Login;
            if (selectedUser.Manager != null)
            {
                tb_manager.Text = selectedUser.Manager.FIO;
            }
            else
            {
                tb_manager.Clear();
            }
            tb_phone.Text = selectedUser.Phone;
            tb_post.Text = selectedUser.Post;
            tb_subdivision.Text = selectedUser.Subdivision;
            check_manager.IsChecked = selectedUser.IsManager;
            combo_role.SelectedValue = selectedUser.Role;

            isNew = false;
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (isNew)
            {

            }
            else
            {
                selectedUser.Email = tb_email.Text;
                selectedUser.FIO = tb_fio.Text;
                selectedUser.IsManager = (bool)check_manager.IsChecked;
                selectedUser.Login = tb_login.Text;
                selectedUser.Phone = tb_phone.Text;
                selectedUser.Post = tb_post.Text;
                selectedUser.Role = (Role)combo_role.SelectedValue;
                selectedUser.Subdivision = tb_subdivision.Text;

                userContract.UpdateUser(selectedUser);
            }
            stack_details.Width = 0;
            RefreshData();
        }

    }
}
