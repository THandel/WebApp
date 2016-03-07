using System.Data.Linq.Mapping;

namespace NewWebApp.Models
{
    [Table(Name = "DeliveryTime")]
    public class DeliveryTime
    {
        private int _Delivery_Hour;
        private int _Delivery_Interval;
        private string _Time;
        public DeliveryTime(int delHr, int delInt, string time)
        {
            this._Delivery_Hour = delHr;
            this._Delivery_Interval = delInt;
            this._Time = time;
        }

        public DeliveryTime() { }

        [Column(IsPrimaryKey = true, Storage = "_Delivery_Hour")]
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

        [Column(IsPrimaryKey = true, Storage = "_Delivery_Interval")]
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

        public string time
        {
            get
            {
                return this._Time;
            }
            set
            {
                this._Time = value;
            }
        }
    }
}
