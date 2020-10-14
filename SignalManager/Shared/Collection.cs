using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalManager.Shared
{
    public class Collection<T> : List<T>
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
