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
        public IHttpActionResult GetMarketDatas(ODataQueryOptions<MarketData> queryOptions)
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

            var sorted = _newDataProvider.getModelas();
            return Ok(sorted);
        }

        // GET: odata/MarketDataJSON
        public IHttpActionResult GetMarketDataJSON(ODataQueryOptions<MarketData> queryOptions)
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

            var sorted = _newDataProvider.getModelasJSON();
            return Ok(sorted);
        }

        // GET: odata/MarketDatas(5)
        public IHttpActionResult GetMarketData([FromODataUri] DateTime key, ODataQueryOptions<MarketData> queryOptions)
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

            var sortedDate = _newDataProvider.getDate(key);
            return Ok<IEnumerable<MarketData>>(sortedDate);
        }
    }
}
