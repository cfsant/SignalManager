using SignalManager.Client.Models;
using SignalManager.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalManager.Client.Controlers
{
    public class BagControler : Collection<Bag>
    {
        public Bag this[string Key]
        {
            get
            {
                return this.GetByKey(Key);
            }
        }

        public Bag GetByKey(string Key)
        {
            if (string.IsNullOrEmpty(Key) || string.IsNullOrWhiteSpace(Key))
            {
                return null;
            }

            if (this == default || this.Count < 1)
            {
                return null;
            }

            try
            {
                return this.Single<Bag>(x => x.Key == Key);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public void Set(Bag bag)
        {
            if (bag == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(bag.Key) || string.IsNullOrWhiteSpace(bag.Key))
            {
                return;
            }

            Bag b = this[bag.Key];
            if (b != null && b.Key == bag.Key)
            {
                this.Remove(b);
            }

            this.Add(bag);
        }

        public void Remove(string Key)
        {
            if (string.IsNullOrEmpty(Key) || string.IsNullOrWhiteSpace(Key))
            {
                return;
            }

            Bag b = this[Key];
            if (b != null && b.Key == Key)
            {
                this.Remove(b);
            }
        }

        public object Get(string Key)
        {
            return this[Key]?.Value;
        }
    }
}
