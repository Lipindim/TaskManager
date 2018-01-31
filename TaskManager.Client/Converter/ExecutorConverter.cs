using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TaskManager.Domain.Entities;

namespace TaskManager.Client.Converter
{
    public class ExecutorConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            User user = (User)value;
            if (user.ID != GlobalSettings.CurrentUser.ID)
            {
                return $" | Исполнитель: {user.FIO}";
            }
            else
            {
                return string.Empty;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
