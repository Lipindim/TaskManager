using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Helper
{
    public static class ReflectionHelper
    {
        public static void CopyFields<T>(T fromObj, T toObj)
        {
            foreach(var property in typeof(T).GetProperties())
            {
                var value = property.GetValue(fromObj);
                property.SetValue(toObj, value);
            }
        }
    }
}
