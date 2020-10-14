using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalManager.Client.Models
{
    public enum EnmLevelAccess
    {
        DEFAULT = 0,
        ADMIN
    }

    public class User
    {
        public string Username
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public EnmLevelAccess LevelAccess
        {
            get;
            set;
        } = EnmLevelAccess.ADMIN;
    }
}
