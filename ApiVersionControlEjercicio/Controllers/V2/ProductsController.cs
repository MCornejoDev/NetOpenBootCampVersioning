using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ApiVersionControlEjercicio.DTO.V2;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersionControlEjercicio.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private const string ApiTestURL = "https://fakestoreapi.com/products";
        private readonly HttpClient _httpClient;

        public ProductsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [MapToApiVersion("2.0")]
        [HttpGet(Name = "GetProductData")]
        public async Task<IActionResult> GetProductsDataAsync()
        {
            _httpClient.DefaultRequestHeaders.Clear();
            var response = await _httpClient.GetStreamAsync(ApiTestURL);

            var productData = await JsonSerializer.DeserializeAsync<List<Product>>(response);
            
            foreach (var product in productData)
            {
                product.InternalId = Guid.NewGuid();
            }

            return Ok(productData);
        }
    }
}
