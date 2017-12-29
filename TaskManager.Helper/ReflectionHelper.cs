using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Helper
{
    public static class ReflectionHelper
    {
        public static void CopyFields<T>(T fromObj, T toObj, params string[] exceptionFields)
        {
            foreach (var property in typeof(T).GetProperties())
            {
                if (!exceptionFields.Contains(property.Name) && property.SetMethod != null)
                {
                    var value = property.GetValue(fromObj);
                    property.SetValue(toObj, value);
                }
            }
        }
    }
}
