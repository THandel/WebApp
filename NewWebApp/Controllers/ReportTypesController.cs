using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using NewWebApp.Models;
using Microsoft.Data.OData;

namespace NewWebApp.Controllers
{

    public class ReportTypesController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();
        private RepTypeProvider _rptTypeProvider = new RepTypeProvider();
        // GET: odata/ReportTypes
        public IHttpActionResult GetReportTypes(ODataQueryOptions<ReportType> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            var rptSorted = _rptTypeProvider.getModel();
            return Ok<IEnumerable<ReportType>>(rptSorted);
        }

        // GET: odata/ReportTypes(5)
        public IHttpActionResult GetReportType([FromODataUri] string key, ODataQueryOptions<ReportType> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<ReportType>(reportType);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
