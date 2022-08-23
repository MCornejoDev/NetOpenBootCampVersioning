using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ApiVersionControlEjercicio.DTO.V1;

namespace ApiVersionControlEjercicio.Controllers.V1
{
    [ApiVersion("1.0")]
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

        [MapToApiVersion("1.0")]
        [HttpGet(Name = "GetProductData")]
        public async Task<IActionResult> GetProductsDataAsync()
        {
            _httpClient.DefaultRequestHeaders.Clear();
            var response = await _httpClient.GetStreamAsync(ApiTestURL);

            var productData = await JsonSerializer.DeserializeAsync<List<Product>>(response);

            return Ok(productData);
        }
    }
}
