using System;
using System.Collections.Generic;
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
using TaskManager.Services.Contract;

namespace TaskManager.GUI.UserControls
{
    /// <summary>
    /// Логика взаимодействия для UserControl.xaml
    /// </summary>
    public partial class UsersControl : UserControl
    {
        IUserContract userContract;

        public UsersControl()
        {
            InitializeComponent();

            userContract = ChannelFactory<IUserContract>.CreateChannel(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:9000/IUserContract"));
            grid_user.ItemsSource = userContract.GetUsers();
        }
    }
}
