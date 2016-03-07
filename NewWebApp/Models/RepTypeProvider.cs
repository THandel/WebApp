using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace NewWebApp.Models
{
    public class RepTypeProvider
    {
        private string _conString = @"Data Source=lugh4.it.nuigalway.ie;Initial Catalog=msdb2300;Persist Security Info=True;User ID=msdb2300;Password=msdb2300TH";
        private List<ReportType> _repTypeList = new List<ReportType>();
        public RepTypeProvider()
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

        public IEnumerable<ReportType> getDate(string type)
        {
            var sorted = _repTypeList.Where(x => x.RptName == type).OrderBy(x => x.RptName);
            return sorted;
        }

        public IEnumerable<ReportType> getModel()
        {
            return _repTypeList;
        }
    }
}