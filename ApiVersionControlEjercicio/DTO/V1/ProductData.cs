using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVersionControlEjercicio.DTO.V1
{
    public class Product
    {
        public int id { get; set; }
        public string? title { get; set; }
        public float price { get; set; }
        public string? description { get; set; }
        public string? category { get; set; }
        public string? image { get; set; }
        public Rating rating {get;set;}
    }
}