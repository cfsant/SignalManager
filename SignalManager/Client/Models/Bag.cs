using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalManager.Client.Models
{
    public class Bag
    {
        public Bag()
        {

        }

        public Bag(string Key, object Value)
        {
            this.Key = Key;
            this.Value = Value;
        }

        public string Key { get; set; }

        public object Value { get; set; }
    }
}
