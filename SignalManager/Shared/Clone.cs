using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace SignalManager.Shared
{
    public static class Clone
    {
        public static T DeepClone<T>(this T obj)
        {
            if (obj == null)
            {
                return default;
            }

            T child = Activator.CreateInstance<T>();
            foreach (PropertyInfo property in typeof(T).GetProperties())
            {
                if (property.GetMethod == null)
                {
                    continue;
                }

                if (property.SetMethod == null)
                {
                    continue;
                }

                property.SetValue(child, property.GetValue(obj));
            }

            return child;
        }
    }
}
