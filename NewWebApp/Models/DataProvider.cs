using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Script.Serialization;
using NewWebApp.Models;

namespace NewWebApp.Models
{
    public class DataProvider
    {
        private string _conString = @"Data Source=lugh4.it.nuigalway.ie;Initial Catalog=msdb2300;Persist Security Info=True;User ID=msdb2300T;Password=";

        private List<MarketData> _dataList = new List<MarketData>();
        public DataProvider()
        {
            SqlConnection conn = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand("select * from MarketData", conn);
            SqlDataReader rdr = null;

            try
            {
                conn.Open();
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    MarketData m = new MarketData();
                    
                    m.Num = (int)rdr["num"];
                    m.tradeDate = (string)rdr["TRADE_DATE"];
                    m.delDate = (string)rdr["DELIVERY_DATE"];
                    m.delHr = (int)rdr["DELIVERY_HOUR"];
                    m.delInt = (int)rdr["DELIVERY_INTERVAL"];
                    m.runType = (string)rdr["RUN_TYPE"];
                    m.msq = (decimal)rdr["AGGREGATED_MSQ"];
                    m.smp = (decimal)rdr["SMP"];
                    m.currFlag = (string)rdr["CURRENCY_FLAG"];
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

        public IEnumerable<MarketData> getModel()
        {
            return _dataList;
        }
        
        public IEnumerable<MarketData> getDate(string date)
        {
            string dateVal = date.ToString();
            var sorted = _dataList.Where(x => x.delDate == dateVal);
            return sorted;
        }

    }
 }