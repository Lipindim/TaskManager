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
using TaskManager.Services.Contract;

namespace TaskManager.GUI.UserControls
{
    /// <summary>
    /// Логика взаимодействия для TreeControl.xaml
    /// </summary>
    public partial class TreeControl : UserControl
    {
        IUserContract userContract;
        ObservableCollection<User> userCollection;

        public TreeControl()
        {
            InitializeComponent();

            userContract = ChannelFactory<IUserContract>.CreateChannel(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:9000/IUserContract"));
            userCollection = new ObservableCollection<User>(userContract.GetUsers());

            User mainUser = userCollection.FirstOrDefault(x => x.ManagerID == null);
            TreeViewItem item = new TreeViewItem();
            item.Tag = mainUser;
            item.Header = $"{mainUser.FIO}\n({mainUser.Post})";
            //tree.Items.Add(item);
            item.ExpandSubtree();
            AddNode(item);
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

        private void AddNode(TreeViewItem item)
        {
            item.Items.Clear();
            User mainUser = (User)item.Tag;
            var users = userCollection.Where(x => x.ManagerID == mainUser.ID);

            foreach (User user in users)
            {
                TreeViewItem newItem = new TreeViewItem();
                newItem.Tag = user;
                newItem.Header = $"{user.FIO}\n({user.Post})";
                newItem.Items.Add("*");
                item.Items.Add(newItem);
                if (user.IsManager)
                {
                    AddNode(newItem);
                    item.ExpandSubtree();
                }
            }
        }
    }
}
