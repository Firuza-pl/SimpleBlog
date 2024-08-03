using Microsoft.AspNetCore.Components;
using Blog.Client.HttpClients;
using Blog.Shared.DTOs;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Resources;

namespace Blog.Client.Pages.Product
{
    public class CreateProductBase : ComponentBase
    {
        [Inject] NavigationManager _navigationManager { get; set; }
        [Inject] IToastService _toastService { get; set; }
        [Inject] ProductHttpClient _productHttpClient { get; set; }
        [Inject] AuthenticationStateProvider _authenticationStateProvider { get; set; }

        protected bool isUserAuthenticated = false;

        public CreateProductDTO newProduct = new CreateProductDTO();
       
        //save for product page
        public async Task HandleValidSubmit()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            isUserAuthenticated = authState.User.Identity.IsAuthenticated; //false->true 

            await _productHttpClient.CreateProductAsync(newProduct);

            _toastService.ShowSuccess(Messages.PostSaved, Messages.Success);
            _navigationManager.NavigateTo("/Product");
        }
    }
}
