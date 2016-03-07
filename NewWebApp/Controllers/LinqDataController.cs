using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using NewWebApp.Models;
using Microsoft.Data.OData;
using System;

namespace NewWebApp.Controllers
{
    public class LinqDataController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();
        private LinqProvider _newLinqProvider = new LinqProvider();

        // GET: odata/LinqData
        public IHttpActionResult GetLinqData(ODataQueryOptions<LinqData> queryOptions)
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

            var sorted = _newLinqProvider.getModel();
            return Ok<IEnumerable<LinqData>>(sorted);
        }
    }
}
