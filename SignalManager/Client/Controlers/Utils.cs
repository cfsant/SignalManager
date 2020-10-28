using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SignalManager.Client.Controlers
{
    public static class Utils
    {
        public static O Parse<I, O>(I input, O output)
        {
            if (input == null)
            {
                return default;
            }

            foreach (PropertyInfo propertyInput in input.GetType().GetProperties())
            {
                try
                {
                    if (propertyInput.GetMethod == null || propertyInput.GetMethod == default)
                    {
                        continue;
                    }

                    if (propertyInput.SetMethod == null || propertyInput.SetMethod == default)
                    {
                        continue;
                    }

                    PropertyInfo propertyOutput = output.GetType().GetProperty(propertyInput.Name);
                    if (propertyOutput == null)
                    {
                        continue;
                    }

                    propertyOutput.SetValue(output, propertyInput.GetValue(input));
                }
                catch (Exception)
                {
                    continue;
                }
            }

            return output;
        }
    }
}
