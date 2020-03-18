using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Order
    {
        public int OrderId { get; set; }

        [Display(Name="Company Name")]
        public string CompanyName { get; set; }

        [Display(Name ="Description")]
        public string Description { get; set; }
        [Display(Name ="Order Total")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal OrderTotal { get; set; }

        public List<OrderProduct> OrderProducts { get; set; }

    }


    public class OrderProduct
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        [Display(Name = "Total Price")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Price { get; set; }

    }

    public class Product
    {
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Display(Name = "Product Price")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Price { get; set; }
    }
}