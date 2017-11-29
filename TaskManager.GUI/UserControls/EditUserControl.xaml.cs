using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        private void picture_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Нажато!");
        }

        private void btn_loadPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image|*.jpg; *.jpeg; *.gif; *.png" ;
            if (dialog.ShowDialog() == true)
            {
                BitmapImage bm1 = new BitmapImage();
                bm1.BeginInit();
                bm1.UriSource = new Uri(dialog.FileName, UriKind.Relative);
                bm1.CacheOption = BitmapCacheOption.OnLoad;
                bm1.EndInit();
                //picture.Source = bm1;
                (this.DataContext as User).PictureImage = bm1;

                //System.Drawing.Image image = System.Drawing.Image.FromFile(dialog.FileName);
                //(this.DataContext as User).PictureImage = image;
            }
        }
    }
}
