using System;
using System.Data.Linq.Mapping;

namespace WebApp.Models
{
    [Table(Name = "MarketData")]
    public class MarketData
    {
        private int _num;
        private string _Trade_Date;
        private string _Delivery_Date;
        private int _Delivery_Hour;
        private int _Delivery_Interval;
        private string _Run_Type;
        private decimal _Aggregate_MSQ;
        private decimal _SMP;
        private string _Currency_Flag;

        public MarketData(int Num, string tradeDate, string delDate, int delHr, int delInt, string runType, decimal msq, decimal smp, string currFlag)
        {
            this._Trade_Date = tradeDate;
            this._num = Num;
            this._Delivery_Date = delDate;
            this._Delivery_Hour = delHr;
            this._Delivery_Interval = delInt;
            this._Run_Type = runType;
            this._Aggregate_MSQ = msq;
            this._SMP = smp;
            this._Currency_Flag = currFlag;
        }

        public MarketData() { }

        [Column(IsPrimaryKey = true, Storage = "_Trade_Date")]
        public string trDate
        {
            get
            {
                return this._Trade_Date;
            }
            set
            {
                this._Trade_Date = value;
            }
        }

        [Column(IsPrimaryKey = true, Storage = "_num")]
        public int Num
        {
            get
            {
                return this._num;
            }
            set
            {
                this._num = value;
            }
        }

        public string tradeDate
        {
            get
            {
                return this._Trade_Date;
            }
            set
            {
                this._Trade_Date = value;
            }
        }

        public string delDate
        {
            get
            {
                return this._Delivery_Date;
            }
            set
            {
                this._Delivery_Date = value;
            }
        }
        
        public int delHr
        {
            get
            {
                return this._Delivery_Hour;
            }
            set
            {
                this._Delivery_Hour = value;
            }
        }
        public int delInt
        {
            get
            {
                return this._Delivery_Interval;
            }
            set
            {
                this._Delivery_Interval = value;
            }
        }

        public string runType
        {
            get
            {
                return this._Run_Type;
            }
            set
            {
                this._Run_Type = value;
            }
        }

        public decimal msq
        {
            get
            {
                return this._Aggregate_MSQ;
            }
            set
            {
                this._Aggregate_MSQ = value;
            }
        }
        public decimal smp
        {
            get
            {
                return this._SMP;
            }
            set
            {
                this._SMP = value;
            }
        }
        public string currFlag
        {
            get
            {
                return this._Currency_Flag;
            }
            set
            {
                this._Currency_Flag = value;
            }
        }
    }
}