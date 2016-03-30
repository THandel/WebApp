using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using NewWebApp.Models;
using Microsoft.Data.OData;
using System;
using System.Collections;

namespace NewWebApp.Controllers
{
    public class MarketDatasController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();
        private DataProvider _newDataProvider = new DataProvider();
        //private LinqProvider _newLinqProvider = new LinqProvider();

        // GET: odata/MarketDatas
        public IHttpActionResult Get(ODataQueryOptions<MarketData> queryOptions)
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

            var sorted = _newDataProvider.getModel();
            return Ok(sorted);
        }


        // GET: odata/MarketDatas(5)
        public IHttpActionResult Get([FromODataUri] string key)
        {
            // validate the query.
           /* try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }*/

            var sortedDate = _newDataProvider.getDate(key);
            return Ok<IEnumerable<MarketData>>(sortedDate);
        }
    }
}
