using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using NewWebApp.Models;
using Microsoft.Data.OData;

namespace NewWebApp.Controllers
{
   
    public class LinqDatasController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();
        private LinqProvider _newLinqProvider = new LinqProvider();

        // GET: odata/LinqDatas
        [EnableQuery] //allow filtering using ?$filter
        public IHttpActionResult Get(ODataQueryOptions<combineData> queryOptions)
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

        // GET: odata/LinqDatas(5)
        [EnableQuery] //allow filtering using ?$filter
        public IHttpActionResult Get([FromODataUri] string key, ODataQueryOptions<combineData> queryOptions)
        {
            //validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            var sorted = _newLinqProvider.getCData(key);
            return Ok<IEnumerable<combineData>>(sorted);
        }
    }
}
