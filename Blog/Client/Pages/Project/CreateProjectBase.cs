using Microsoft.AspNetCore.Components;
using Blog.Client.HttpClients;
using Blog.Shared.DTOs;
using Resources;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;

namespace Blog.Client.Pages.Project
{
    public class CreateProjectBase : ComponentBase
    {
        [Inject] NavigationManager _navigationManager { get; set; }
        [Inject] IToastService _toastService { get; set; }
        [Inject] ProjectHttpClient _projectHttpClient { get; set; }
        [Inject] AuthenticationStateProvider _authenticationStateProvider { get; set; }

        protected bool isUserAuthenticated = false;

        public CreateProjectDTO newProject = new CreateProjectDTO();

        public async Task HandleValidSubmit()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            isUserAuthenticated = authState.User.Identity.IsAuthenticated; //false->true

            await _projectHttpClient.CreateProjectAsync(newProject);

            _toastService.ShowSuccess(Messages.PostSaved, Messages.Success);
            _navigationManager.NavigateTo("/Project");
        }


    }
}
