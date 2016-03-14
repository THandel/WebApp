using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewWebApp.Models;

namespace NewWebApp.Models
{
    public class DataContainer
    {
    }

    public class combineData
    {
        private string _Trade_Date;
        private DateTime _Delivery_Date;
        private string _DeliveryTime;
        private decimal _Aggregate_MSQ;
        private decimal _SMP;

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
        public decimal aggregateMSQ
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

        public DateTime deliveryDate
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
        public string deliveryTime
        {
            get
            {
                return this._DeliveryTime;
            }
            set
            {
                this._DeliveryTime = value;
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

    }
}