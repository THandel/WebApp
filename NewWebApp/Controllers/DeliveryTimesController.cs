using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using NewWebApp.Models;
using Microsoft.Data.OData;

namespace NewWebApp.Controllers
{

    public class DeliveryTimesController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();
        private DelTimeProvider _delTimeProvider = new DelTimeProvider();
        // GET: odata/DeliveryTimes
        public IHttpActionResult GetDeliveryTimes(ODataQueryOptions<DeliveryTime> queryOptions)
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

            var delTimeSorted = _delTimeProvider.getModel();
            return Ok<IEnumerable<DeliveryTime>>(delTimeSorted);
        }

        // GET: odata/DeliveryTimes(5)
        public IHttpActionResult GetDeliveryTime([FromODataUri] int key, ODataQueryOptions<DeliveryTime> queryOptions)
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

            // return Ok<DeliveryTime>(deliveryTime);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
