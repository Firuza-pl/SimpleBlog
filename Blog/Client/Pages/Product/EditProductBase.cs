using Blazored.Toast.Services;
using Blog.Client.HttpClients;
using Blog.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using Resources;

namespace Blog.Client.Pages.Product
{
    public class EditProductBase : ComponentBase
    {
        [Parameter]
        public Guid ProductId { get; set; }
        [Inject] NavigationManager _navigationManager { get; set; }
        [Inject] IToastService _toastService { get; set; }
        [Inject] ProductHttpClient _productHttpClient { get; set; } 

        public UpdateProductDTO editExistingPro = new UpdateProductDTO();

        protected override async Task OnInitializedAsync()
        {
            var productDTO = await _productHttpClient.GetProductByIdAsync(ProductId);

            editExistingPro.ProductId = productDTO.ProductId;
            editExistingPro.ProductName = productDTO.ProductName;
            editExistingPro.ProductCode = productDTO.ProductCode;
            editExistingPro.Description = productDTO.Description;
            editExistingPro.ListPrice = productDTO.ListPrice;
        }

        public async Task HandleValidSubmit()
        {
            await _productHttpClient.UpdateProductAsync(editExistingPro);
            _toastService.ShowSuccess(Messages.PostSaved, Messages.Success);
            _navigationManager.NavigateTo("/Product");
        }


    }
} 
