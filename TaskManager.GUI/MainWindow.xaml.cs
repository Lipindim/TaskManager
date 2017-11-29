using Microsoft.Windows.Controls.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskManager.GUI.UserControls;
using TaskManager.GUI.UserControls.Base;
using TaskManager.Services.Contract;

namespace TaskManager.GUI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        IUserContract userContract;
        IAddDeleteUser iAddDeleteUser;
        ITree iTree;
        public MainWindow()
        {
            InitializeComponent();
            //canvas_content.Children.Add(new TreeControl());
        }

        private void menu_users_Click(object sender, RoutedEventArgs e)
        {
            UsersControl userControl = new UsersControl();
            iAddDeleteUser = userControl;
            grid_content.Children.Add(userControl);
        }

        private void menu_addUser_Click(object sender, RoutedEventArgs e)
        {
            iAddDeleteUser.AddUser();
        }

        private void menu_deleteUser_Click(object sender, RoutedEventArgs e)
        {
            iAddDeleteUser.DeleteUser();
        }

        private void menu_chooseBoss_Click(object sender, RoutedEventArgs e)
        {
            SelectUserWindow selectUserWindow = new SelectUserWindow(iTree.UserList);
            if (selectUserWindow.ShowDialog() == true)
            {
                iTree.ChooseBoss(selectUserWindow.SelectedUser);
                userContract.ChooseBoss(selectUserWindow.SelectedUser);
            }
        }

        private void RibbonWindow_Loaded(object sender, RoutedEventArgs e)
        {
            userContract = ChannelFactory<IUserContract>.CreateChannel(new NetTcpBinding() { MaxBufferSize = 64000000, MaxReceivedMessageSize = 64000000 }, new EndpointAddress("net.tcp://localhost:9000/IUserContract"));
        }


        private void menu_addChild_Click(object sender, RoutedEventArgs e)
        {
            SelectUserWindow selectUserWindow = new SelectUserWindow(iTree.UserList, true);
            if (selectUserWindow.ShowDialog() == true)
            {
                iTree.addChildUser(selectUserWindow.SelectedUser);
            }
        }

        private void ribbon_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (e.AddedItems[0] == tab_users)
            {
                if (iAddDeleteUser == null)
                {
                    UsersControl userControl = new UsersControl();
                    iAddDeleteUser = userControl;
                    grid_content.Children.Clear();
                    grid_content.Children.Add(userControl);
                }
                else
                {
                    grid_content.Children.Clear();
                    grid_content.Children.Add((UsersControl)iAddDeleteUser);
                }
            }
            if (e.AddedItems[0] == tab_organization)
            {
                if (iTree == null)
                {
                    TreeControl treeControl = new TreeControl();
                    iTree = treeControl;
                    grid_content.Children.Clear();
                    grid_content.Children.Add(treeControl);
                }
                else
                {
                    grid_content.Children.Clear();
                    grid_content.Children.Add((TreeControl)iTree);
                }
            }
        }

        private void menu_deleteChild_Click(object sender, RoutedEventArgs e)
        {
            iTree.deleteChildUser();
        }
    }
}
