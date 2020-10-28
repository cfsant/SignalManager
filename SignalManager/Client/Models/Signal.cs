using SignalManager.Shared;
using System;
using System.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;

namespace SignalManager.Client.Models
{
    public class Signal : IqOptionAdminSignalDomain
    {
        public bool Selected
        {
            get;
            set;
        }

        public bool Editing
        {
            get;
            set;
        }

        public Signal()
        {
        }
    }
}
