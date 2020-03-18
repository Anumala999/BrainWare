using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    using Infrastructure;
    using System.Net.Http;
    using Web.Models;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {         

            IEnumerable<Order> orders = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"{Request.Url.AbsoluteUri}/api/");
                //HTTP GET
                var responseTask = client.GetAsync("order/1");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Order>>();
                    readTask.Wait();

                    orders = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..
                    orders = Enumerable.Empty<Order>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    return View("Error");
                }
            }
            return View(orders);
        }


    }
}
