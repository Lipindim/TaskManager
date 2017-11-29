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
using TaskManager.GUI.UserControls.Base;
using TaskManager.Services.Contract;

namespace TaskManager.GUI.UserControls
{
    /// <summary>
    /// Логика взаимодействия для UserControl.xaml
    /// </summary>
    public partial class UsersControl : UserControl, IAddDeleteUser
    {
        IUserContract userContract;
        ObservableCollection<User> userCollection;
        private bool isNew;

        public UsersControl()
        {
            InitializeComponent();
        }

        private void RefreshData()
        {
            userCollection = new ObservableCollection<User>(userContract.GetUsers());
            list_user.ItemsSource = userCollection;
        }

        private void list_user_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (list_user.SelectedItem != null)
            {
                editUser.SetUser(list_user.SelectedItem as User);
                isNew = false;
                editUser.IsEnabled = true;
            }
        }


        private void btn_new_Click(object sender, RoutedEventArgs e)
        {
            editUser.SetUser(new User());
            editUser.IsEnabled = true;
            isNew = true;
        }


        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            userContract.DeleteUser(userCollection[list_user.SelectedIndex].ID);
            RefreshData();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            userContract = ChannelFactory<IUserContract>.CreateChannel(new NetTcpBinding() { MaxBufferSize = 64000000, MaxReceivedMessageSize = 64000000}, new EndpointAddress("net.tcp://localhost:9000/IUserContract"));
            RefreshData();
            editUser.FinishedChange += EditUser_FinishedChange;
        }

        private void EditUser_FinishedChange(bool isSave, User user)
        {
            if (isSave)
            {
                if (isNew)
                {
                    userContract.AddUser(user);
                }
                else
                {
                    userContract.UpdateUser(user);
                }
            }
            editUser.IsEnabled = false;
            RefreshData();
        }

        public void DeleteUser()
        {
            userContract.DeleteUser(userCollection[list_user.SelectedIndex].ID);
            RefreshData();
            editUser.SetUser(null);
            editUser.IsEnabled = false;
        }

        public void AddUser()
        {
            editUser.SetUser(new User());
            editUser.IsEnabled = true;
            isNew = true;
        }
    }
}
