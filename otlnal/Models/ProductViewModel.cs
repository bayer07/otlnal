using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace otlnal.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count{ get; set; }
        public ProductTypeViewModel Type { get; set; }
    }

    public class ProductTypeViewModel
    {
        public int Id { get; set; }
    }
}