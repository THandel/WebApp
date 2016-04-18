
namespace WebApp.Models
{
    public class DataContainer
    {
    }

    public class combineData
    {
        private string _Trade_Date;
        private string _Delivery_Date;
        private string _DeliveryTime;
        private decimal _Aggregate_MSQ;
        private decimal _SMP;
        private string _curr;

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

        public string deliveryDate
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
        public string curr
        {
            get
            {
                return this._curr;
            }
            set
            {
                this._curr = value;
            }
        }
    }
}