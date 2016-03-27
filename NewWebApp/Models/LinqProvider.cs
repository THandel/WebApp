﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using NewWebApp.Models;

namespace NewWebApp.Models
{
    public class LinqProvider
    {

        private string _conString = @"Data Source=lugh4.it.nuigalway.ie;Initial Catalog=msdb2300;Persist Security Info=True;User ID=msdb2300;Password=msdb2300TH";
        private List<DeliveryTime> _delTimeList = new List<DeliveryTime>();
        private List<ReportType> _repTypeList = new List<ReportType>();
        private List<MarketData> _dataList = new List<MarketData>();
        private List<combineData> _cDataList = new List<combineData>();

        public LinqProvider()
        {
            DelTimeProvider();
            RepTypeProvider();
            DataProvider();
            //newCombineData();
        }

        //method to try and combine data from all three tables in one list - not working yet
        public void newCombineData()
        {
            SqlConnection conn = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand("select * from dbo.DeliveryTime; select * from dbo.MarketData; select * from dbo.ReportType", conn);
            SqlDataReader rdr = null;
            try
            {
                conn.Open();
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    combineData c = new combineData();
                    c.tradeDate = (string)rdr["dbo.MarketData.TRADE_DATE"];
                    c.deliveryDate = (string)rdr["DELIVERY_DATE"];
                    c.deliveryTime = (string)rdr["DeliveryTime.Time"];
                    c.aggregateMSQ = (decimal)rdr["MarketData.AGGREGATED_MSQ"];
                    c.smp = (decimal)rdr["MarketData.SMP"];
                    c.curr = (string)rdr["MarketData.CURRENCY_FLAG"];
                    _cDataList.Add(c);
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
                    r.runType = (string)rdr["RUN_TYPE"];
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

        public void DataProvider()
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
    

        public IEnumerable<combineData> getCombineData()
        {
            var combineData = from md in _dataList
                              join d in _delTimeList
                              on new {md.delHr, md.delInt} equals new {d.delHr, d.delInt}
                              join r in _repTypeList
                              on md.runType equals r.runType
                              orderby d.time ascending
                              select new combineData()
                              {
                                  aggregateMSQ = md.msq,
                                  smp = md.smp,
                                  deliveryTime = d.time,
                                  deliveryDate = md.delDate,
                                  tradeDate = md.trDate,
                                  curr = md.currFlag
                              };

            List<combineData> newDataList = combineData.ToList<combineData>();
            return newDataList;
        }

        public IEnumerable<combineData> getCData(string curr)
        {
            //combineData newCData = new combineData();
            var combineData = from md in _dataList
                              join d in _delTimeList
                              on md.delHr equals d.delHr
                              join r in _repTypeList
                              on md.runType equals r.runType
                              // where md.trDate.Contains(dateVal)
                              where md.currFlag.ToString().Contains(curr)
                              select new combineData
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