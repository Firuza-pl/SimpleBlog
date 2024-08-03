using Microsoft.AspNetCore.Components;
using Blog.Client.HttpClients;
using Blog.Shared.DTOs;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Resources;
using Blog.Domain.Entities.ProductAggregate;

namespace Blog.Client.Pages.OrderDetails
{
    public class CreateOrderBase : ComponentBase
    {
        [Inject] NavigationManager _navigationManager { get; set; }
        [Inject] IToastService _toastService { get; set; }
        [Inject] OrderDetailsHttpClient _orderDetailsHttpClient { get; set; }
        [Inject] ProductHttpClient _productHttpClient { get; set; }
        [Inject] AuthenticationStateProvider _authenticationStateProvider { get; set; }

        protected bool isUserAuthenticated = false;
        public Guid ProductId { get; set; }

        public CreateOrderDetailsDTO newOrder = new CreateOrderDetailsDTO();

        public List<ProductDTO> _productList = new List<ProductDTO>();
        protected override async Task OnInitializedAsync()
        {
            var response = (await _productHttpClient.GetProductAsync()).ToList();
            _productList = response;
        }

        public async Task HandleValidSubmit()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            isUserAuthenticated = authState.User.Identity.IsAuthenticated;

            await _orderDetailsHttpClient.CreateOrderDetailsAsync(newOrder);

            _toastService.ShowSuccess(Messages.PostSaved, Messages.Success);
            _navigationManager.NavigateTo("/Order");
        }


    }
}
