using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace NewWebApp.Models
{
    public class DataProvider
    {

        //github test comment
        private string _conString = @"Data Source=lugh4.it.nuigalway.ie;Initial Catalog=msdb2300;Persist Security Info=True;User ID=msdb2300;Password=msdb2300TH";

        private List<MarketData> _dataList = new List<MarketData>();
        public DataProvider()
        {
            SqlConnection conn = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand("select * from MarketData2", conn);
            SqlDataReader rdr = null;

            try
            {
                conn.Open();
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    MarketData m = new MarketData();
                    m.RptName = (string)rdr["Report_Name"];
                    m.RptDate = (DateTime)rdr["RPT_Date"];
                    m.trDate = (string)rdr["Trade_Date"];
                    m.num = (int)rdr["Num2"];
                    m.tradeDate = (DateTime)rdr["Trade_Date3"];
                    m.delDate = (DateTime)rdr["Delivery_Date"];
                    m.delHr = (int)rdr["Delivery_Hour"];
                    m.delInt = (int)rdr["Delivery_Interval"];
                    m.msq = (decimal)rdr["Aggregate_MSQ"];
                    m.smp = (decimal)rdr["SMP"];
                    m.currFlag = (string)rdr["Currency_Flag"];
                    _dataList.Add(m);
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

        public IEnumerable<MarketData> getDate(DateTime date)
        {
            var sorted = _dataList.Where(x => x.tradeDate == date).OrderBy(x => x.tradeDate);
            return sorted;
        }

        public IEnumerable<MarketData> getModel()
        {
            return _dataList;
        }
    }
 }