using Blog.Shared.DTOs;
using System.Net.Http.Json;

namespace Blog.Client.HttpClients
{
    public class ProductHttpClient
    {
        private readonly HttpClient _httpClient;
        public ProductHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ProductDTO>> GetProductAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<ProductDTO>>("api/Product/GetList");
            return response;
        }

        //along EditBy UpdateBy and DeleteBy we use {productId} to pass/get ID from URL
        public async Task<ProductDTO> GetProductByIdAsync(Guid productId)
        {
            var response = await _httpClient.GetFromJsonAsync<ProductDTO>($"api/Product/EditBy/{productId}");
            return response;
        }

        public async Task CreateProductAsync(CreateProductDTO createProductDTO)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/Product/CreateProduct", createProductDTO);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateProductAsync(UpdateProductDTO updateProduct)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Product/UpdateBy/{updateProduct.ProductId}", updateProduct);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteProductAsync(Guid productId)
        {
            var response = await _httpClient.DeleteAsync($"api/Product/DeleteBy/{productId}");
            response.EnsureSuccessStatusCode();
        }
    }
}
