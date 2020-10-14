using SignalManager.Shared;
using System;
using System.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalManager.Client.Models
{
    public class Signal : Container<Signal>
    {
        public enum Pairs
        {
            UNDEFINED,
            EURUSD,
            EURGBP,
            GBPJPY,
            EURJPY,
            GBPUSD,
            USDJPY,
            AUDCAD,
            NZDUSD,
            USDRUB,
            USDCHF,
            AUDUSD,
            USDCAD,
            AUDJPY,
            GBPCAD,
            EURCAD,
            CHFJPY,
            CADCHF,
            EURAUD,
            USDNOK,
            EURNZD,
            USDSEK,
            USDPLN,
            AUDCHF,
            AUDNZD,
            CADJPY,
            EURCHF,
            NZDCAD,
            NZDJPY,
            EURNOK,
            CHFSGD,
            EURSGD,
            AUDNOK,
            AUDSEK,
            AUDSGD,
            CADNOK,
            CADPLN,
            EURDKK,
            EURMXN,
            EURZAR,
            NOKJPY,
            NOKSEK,
            NZDSGD,
            SEKJPY,
            SGDJPY,
            USDDKK,
            NZDCHF,
            USDCZK,
            USDHUF
        }

        public enum Directions
        {
            UNDEFINED,
            PUT,
            CALL
        }

        public enum Durations
        {
            UM = 1,
            DOIS = 2,
            TRÊS = 3,
            QUATRO = 4,
            CINCO = 5,
            DEZ = 10,
            QUINZE = 15
        }

        public string PairName
        {
            get
            {
                return this.Pair.ToString();
            }
        }

        public string DirectionName
        {
            get
            {
                return this.Direction.ToString();
            }
        }

        public bool Selected
        {
            get;
            set;
        }

        public string Uid
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public int Amount
        {
            get;
            set;
        }

        public int Martingale
        {
            get;
            set;
        }

        public int MartingaleValue
        {
            get;
            set;
        }

        public Pairs Pair
        {
            get;
            set;
        }

        public Directions Direction
        {
            get;
            set;
        }

        public Durations Duration
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
            this.Uid = Guid.NewGuid().ToString();
            this.Date = DateTime.Now;
            this.Duration = Durations.UM;
            this.Pair = Pairs.UNDEFINED;
            this.Direction = Directions.UNDEFINED;
            this.Editing = false;
        }
    }
}
