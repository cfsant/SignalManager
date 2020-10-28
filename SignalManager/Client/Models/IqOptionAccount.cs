using SignalManager.Shared;
using System;

namespace SignalManager.Client.Models
{
    public class IqOptionAccount : Container<IqOptionAccount>
    {
        public int Platform
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public EnmPlatform EnmPlatform
        {
            get;
            set;
        } = EnmPlatform.IQ_OPTIONS;

        public EnmAccountType EnmAccountType
        {
            get;
            set;
        } = EnmAccountType.TREINAMENTO;

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

        public string Uid
        {
            get;
            set;
        }

        public IqOptionAccount() => this.Uid = Guid.NewGuid().ToString();
    }

    public enum EnmPlatform
    {
        IQ_OPTIONS = 1
    }

    public enum EnmAccountType
    {
        TREINAMENTO = 1,
        REAL
    }
}