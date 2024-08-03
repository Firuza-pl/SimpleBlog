using Blog.Shared.DTOs;
using System.Net.Http.Json;

namespace Blog.Client.HttpClients
{
    public class OrderDetailsHttpClient
    {
        private readonly HttpClient _httpClient;
        public OrderDetailsHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<OrderDetailsDTO>> GetOrderDetailAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<OrderDetailsDTO>>("api/OrderDetails/GetOrderList");
            return response;
        }

        public async Task<OrderDetailsDTO> GetOrderDetailsById(Guid detailsId)
        {
            var response = await _httpClient.GetFromJsonAsync<OrderDetailsDTO>($"api/OrderDetails/GetOrderById");
            return response;
        }

        public async Task CreateOrderDetailsAsync(CreateOrderDetailsDTO createOrderDetails)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/OrderDetails/CreateOrderDetails", createOrderDetails);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateOrderDetailsAsync(UpdateOrderDetailsDTO updateOrderDetails)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/OrderDetails/UpdateOrderDetails/{updateOrderDetails.OrderDetailId}", updateOrderDetails);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteOrderDetailsAsync(Guid orderDetailsId)
        {
            var response = await _httpClient.DeleteAsync($"api/OrderDetails/DelteOrderDetails/{orderDetailsId}");
            response.EnsureSuccessStatusCode();
        }

    }
}

