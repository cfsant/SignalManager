using SignalManager.Client.Shared.Components;
using SignalManager.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalManager.Client.Controlers
{
    public class DataController<T> : Collection<T>
    {
        public T this[string Uid]
        {
            get
            {
                return this.GetByUid(Uid);
            }
        }

        public T GetByUid(string Uid)
        {
            if (string.IsNullOrEmpty(Uid) || string.IsNullOrWhiteSpace(Uid))
            {
                return default;
            }

            if (this == default || this.Count < 1)
            {
                return default;
            }

            return this.Single<T>(x => x.GetType()?.GetProperty("Uid")?.GetValue(x).ToString() == Uid);
        }

        public void Update(T model, string Uid)
        {
            this.Any<T>(x => {
                if (x.GetType()?.GetProperty("Uid")?.GetValue(x).ToString() != Uid)
                {
                    return false;
                }

                x = model;

                return true;
            });
        }
    }
}
