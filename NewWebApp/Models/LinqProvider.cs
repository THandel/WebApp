using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace NewWebApp.Models
{
    public class LinqProvider
    {

        private string _conString = @"Data Source=lugh4.it.nuigalway.ie;Initial Catalog=msdb2300;Persist Security Info=True;User ID=msdb2300;Password=msdb2300TH";
        private List<DeliveryTime> _delTimeList = new List<DeliveryTime>();
        private List<ReportType> _repTypeList = new List<ReportType>();
        private List<MarketData> _dataList = new List<MarketData>();
        public LinqProvider()
        {
            RepTypeProvider();
            DataProvider();
            DelTimeProvider();        
        }

        public void RepTypeProvider()
        {
            SqlConnection conn = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand("select * from ReportType", conn);
            SqlDataReader rdr = null;

            try
            {
                conn.Open();
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    ReportType r = new ReportType();
                    r.RptName = (string)rdr["Report_Name"];
                    r.runType = (string)rdr["Run_Type"];
                    r.title = (string)rdr["Title"];
                    r.runType4 = (string)rdr["Run_Type4"];
                    _repTypeList.Add(r);
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
        public void DataProvider()
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
        public void DelTimeProvider()
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
                    d.delInt = (int)rdr["Delivery_Interval"];
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
        public IEnumerable<CombinedData> getCombineData()
        {
            var combineData = from md in _dataList
                              join d in _delTimeList
                              on md.delHr equals d.delHr
                              join r in _repTypeList
                              on md.RptName equals r.RptName
                              select new CombinedData
                              {
                                  AggregateMSQ = md.msq,
                                  Smp = md.smp,
                                  DeliveryTime = d.time,
                                  DeliveryDate = md.delDate,
                                  TradeDate = md.trDate
                              };

            Debug.WriteLine("I have been called");
            return combineData;
        }

        public System.Collections.IEnumerable getData(DateTime dateVal, string curr)
        {
            var combineData = from md in _dataList
                              join d in _delTimeList
                              on md.delHr equals d.delHr
                              join r in _repTypeList
                              on md.RptName equals r.RptName
                              where md.trDate.Equals(dateVal)
                              where md.currFlag.Equals(curr)
                              select new
                              {
                                  aggregateMSQ = md.msq,
                                  smp = md.smp,
                                  deliveryTime = d.time,
                                  deliveryDate = md.delDate,
                                  tradeDate = md.trDate
                              };
            return combineData;
        }
    }
}