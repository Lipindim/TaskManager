using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
    /// Логика взаимодействия для TreeControl.xaml
    /// </summary>
    public partial class TreeControl : UserControl, ITree
    {
        IUserContract userContract;

        public List<User> UserList { get; set; }

        public TreeControl()
        {
            InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            userContract = ChannelFactory<IUserContract>.CreateChannel(new NetTcpBinding() { MaxBufferSize = 64000000, MaxReceivedMessageSize = 64000000 }, new EndpointAddress("net.tcp://localhost:9000/IUserContract"));
            UserList = userContract.GetUsers().ToList();
            tree.ItemsSource = new List<User>() { UserList.FirstOrDefault(x => x.IsBoss) };
            //Построить дерево
            foreach (User user in UserList)
            {
                if (user.Manager != null)
                {
                    User manager = UserList.FirstOrDefault(x => x.ID == user.ManagerID);
                    manager.AddChildUser(user);
                    user.Manager = manager;
                }
            }
        }

        private void tree_Expanded(object sender, RoutedEventArgs e)
        {
            //TreeViewItem item = (TreeViewItem)e.OriginalSource;
            //item.Items.Clear();
            //User mainUser = (User)item.Tag;
            //var users = userCollection.Where(x => x.ManagerID == mainUser.ID);

            //foreach (User user in users)
            //{
            //    TreeViewItem newItem = new TreeViewItem();
            //    newItem.Tag = user;
            //    newItem.Header = $"{user.FIO}\n({user.Post})";
            //    newItem.Items.Add("*");
            //    item.Items.Add(newItem);
            //}
        }

        //private void AddNode(TreeViewItem item)
        //{
        //    item.Items.Clear();
        //    User mainUser = (User)item.Tag;
        //    var users = userCollection.Where(x => x.ManagerID == mainUser.ID);

        //    foreach (User user in users)
        //    {
        //        TreeViewItem newItem = new TreeViewItem();
        //        newItem.Tag = user;
        //        newItem.Header = $"{user.FIO}\n({user.Post})";
        //        newItem.Items.Add("*");
        //        item.Items.Add(newItem);
        //        if (user.IsManager)
        //        {
        //            AddNode(newItem);
        //            item.ExpandSubtree();
        //        }
        //    }
        //}

        public void ChooseBoss(User boss)
        {
            tree.ItemsSource = new List<User>() { boss } ;
        }

        public void addChildUser(User childUser)
        {
            if (tree.SelectedItem == null)
            {
                return;
            }
            (tree.SelectedItem as User).AddChildUser(childUser);
            userContract.UpdateUser(childUser);
        }

        public void deleteChildUser()
        {
            User selectedUser = tree.SelectedItem as User;
            selectedUser.RemoveManager();
            userContract.UpdateUser(selectedUser);
        }

        
    }
}
