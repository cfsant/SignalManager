using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SignalManager.Shared
{
    public class Container<T> where T : class
    {
        public Container()
        {

        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}