using System;
using System.Data.Linq.Mapping;

namespace NewWebApp.Models
{
    [Table(Name = "MarketData2")]
    public class MarketData
    {
        private string _Report_Name;
        private DateTime _RPT_Date;
        private string _Trade_Date;
        private int _Num2;
        private DateTime _Trade_Date3;
        private DateTime _Delivery_Date;
        private int _Delivery_Hour;
        private int _Delivery_Interval;
        private decimal _Aggregate_MSQ;
        private decimal _SMP;
        private string _Currency_Flag;

        public MarketData(string RptName, DateTime RptDate, string trDate, int num, DateTime tradeDate, DateTime delDate, int delHr, int delInt, decimal msq, decimal smp, string currFlag)
        {
            this._Report_Name = RptName;
            this._RPT_Date = RptDate.Date;
            this._Trade_Date = trDate;
            this._Num2 = num;
            this._Trade_Date3 = tradeDate.Date;
            this._Delivery_Date = delDate.Date;
            this._Delivery_Hour = delHr;
            this._Delivery_Interval = delInt;
            this._Aggregate_MSQ = msq;
            this._SMP = smp;
            this._Currency_Flag = currFlag;
        }

        public MarketData() { }

        public string RptName
        {
            get
            {
                return this._Report_Name;
            }
            set
            {
                this._Report_Name = value;
            }
        }
        public DateTime RptDate
        {
            get
            {
                return this._RPT_Date;
            }
            set
            {
                this._RPT_Date = value;
            }
        }
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

        [Column(IsPrimaryKey = true, Storage = "_Num2")]
        public int num
        {
            get
            {
                return this._Num2;
            }
            set
            {
                this._Num2 = value;
            }
        }

        public DateTime tradeDate
        {
            get
            {
                return this._Trade_Date3;
            }
            set
            {
                this._Trade_Date3 = value;
            }
        }

        public DateTime delDate
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