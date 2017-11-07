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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskManager.Domain.Entities;

namespace TaskManager.GUI.UserControls
{
    /// <summary>
    /// Логика взаимодействия для EditUserControl.xaml
    /// </summary>
    public partial class EditUserControl : UserControl
    {

        public event Action<bool, User> FinishedChange;


        public EditUserControl()
        {
            InitializeComponent();
        }

        public void SetUser(User user)
        {
            this.DataContext = user;
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (FinishedChange != null)
            {
                FinishedChange(true, this.DataContext as User);
            }
            this.DataContext = null;
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            if (FinishedChange != null)
            {
                FinishedChange(false, null);
            }
            this.DataContext = null;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            combo_role.ItemsSource = Enum.GetValues(typeof(Role));
        }
    }
}
