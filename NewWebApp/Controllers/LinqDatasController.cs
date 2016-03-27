using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using NewWebApp.Models;
using Microsoft.Data.OData;
using System;

namespace NewWebApp.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using NewWebApp.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<LinqData>("LinqDatas");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class LinqDatasController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();
        private LinqProvider _newLinqProvider = new LinqProvider();

        // GET: odata/LinqDatas
        public IHttpActionResult GetLinqDatas(ODataQueryOptions<combineData> queryOptions)
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

            var sorted = _newLinqProvider.getCombineData();
            return Ok(sorted);
        }

       /* // GET: odata/LinqDatas()
        public IHttpActionResult GetLinqDatas([FromODataUri] string date, string curr, ODataQueryOptions<MarketData> queryOptions)
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

            var sorted = _newLinqProvider.getCData(curr);
            return Ok<IEnumerable<combineData>>(sorted);
        }*/
    }
}
