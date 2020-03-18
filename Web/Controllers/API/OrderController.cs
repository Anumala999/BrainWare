using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Controllers
{
    using System.Web.Mvc;
    using Infrastructure;
    using Models;

    public class OrderController : ApiController
    {
        [HttpGet]
        public IEnumerable<Order> GetOrders(int id = 1)
        {
            try
            {
                var data = new OrderService();

                var order = data.GetOrdersForCompany(id);

                return data.GetOrdersForCompany(id);
            }
            catch (Exception e)
            {
                //For demo purpose i put the try ctach and writting into the console.
                //in real scenarios we can log exception to log file or write into databse.
                Console.WriteLine(e.Message);
                return new List<Order>();
            }
        }
    }
}
