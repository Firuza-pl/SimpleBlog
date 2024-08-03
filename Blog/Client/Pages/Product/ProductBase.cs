using Blazored.Toast.Services;
using Blog.Client.HttpClients;
using Blog.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Resources;

namespace Blog.Client.Pages.Product
{
    public class ProductBase : ComponentBase
    {
        [Inject] ProductHttpClient _producthttpClient { get; set; }
        [Inject] NavigationManager _navigationManager { get; set; }
        [Inject] AuthenticationStateProvider _authenticationStateProvider { get; set; }
        [Inject] IToastService _toastService { get; set; }

        protected bool isUserAuthenticated = false;

        public List<ProductDTO> _productList = new List<ProductDTO>();

        protected override async Task OnInitializedAsync()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            isUserAuthenticated = authState.User.Identity.IsAuthenticated;
        }

        //in here we dont have any prm accepted
        protected override async Task OnParametersSetAsync()
        {
            //we use it only if we have received prm from razor such as pagination number
            await GetProduct();
        }

        private async Task GetProduct() //we load _productList in our razor page
        {
            var response = await _producthttpClient.GetProductAsync();
            _productList = response;
        }

        public async Task DeleteProduct(Guid productId)
        {
            //calling method when using delete onclick
            await _producthttpClient.DeleteProductAsync(productId);
            _toastService.ShowSuccess(Messages.PostDeleted, Messages.Success);
            _navigationManager.NavigateTo($"/Product");
        }

    }
}
