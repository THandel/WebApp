using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace NewWebApp.Models
{
    public class DelTimeProvider
    {
        private string _conString = @"Data Source=lugh4.it.nuigalway.ie;Initial Catalog=msdb2300;Persist Security Info=True;User ID=msdb2300;Password=msdb2300TH";
        private List<DeliveryTime> _delTimeList = new List<DeliveryTime>();
        public DelTimeProvider()
        {
            SqlConnection conn = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand("select * from DeliveryTime", conn);
            SqlDataReader rdr = null;

            try
            {
                conn.Open();
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    DeliveryTime d = new DeliveryTime();
                    d.delHr = (int)rdr["Delivery_Hour"];
                    d.delInt= (int)rdr["Delivery_Interval"];
                    d.time = (string)rdr["Time"];
                    _delTimeList.Add(d);
                }

            }

            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public IEnumerable<DeliveryTime> getDate(string time)
        {
            var sorted = _delTimeList.Where(x => x.time == time).OrderBy(x => x.time);
            return sorted;
        }

        public IEnumerable<DeliveryTime> getModel()
        {
            return _delTimeList;
        }
    }
}
    
