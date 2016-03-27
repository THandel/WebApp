using System.Data.Linq.Mapping;


namespace NewWebApp.Models
{
    [Table(Name = "ReportType")]
    public class ReportType
    {
        private string _Report_Name;
        private string _Run_Type;
        private string _Title;
        private string _Run_Type4;

        public ReportType(string RptName, string runType, string title, string runType4)
        {
            this._Report_Name = RptName;
            this._Run_Type = runType;
            this._Title = title;
            this._Run_Type4 = runType4;
        }

        public ReportType() { }

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

         [Column(IsPrimaryKey = true, Storage = "_Run_Type")]
        public string runType
        {
            get
            {
                return this._Run_Type;
            }
            set
            {
                this._Run_Type = value;
            }
        }

        public string title
        {
            get
            {
                return this._Title;
            }
            set
            {
                this._Title = value;
            }
        }

        public string runType4
        {
            get
            {
                return this._Run_Type4;
            }
            set
            {
                this._Run_Type4 = value;
            }
        }
    }
}