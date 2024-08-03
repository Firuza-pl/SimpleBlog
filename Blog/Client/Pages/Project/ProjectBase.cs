using Microsoft.AspNetCore.Components;
using Blog.Client.HttpClients;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.Toast.Services;
using Blog.Shared.DTOs;
using Blog.Shared.Pagination;
using Resources;

namespace Blog.Client.Pages.Project
{
    public class ProjectBase : ComponentBase
    {
        [Inject] ProjectHttpClient _projectHttpClient { get; set; }
        [Inject] NavigationManager _navigationManager { get; set; }
        [Inject] AuthenticationStateProvider _authenticationStateProvider { get; set; }
        [Inject] IToastService _toastService { get; set; }

        protected bool isUserAuthenticated = false;

        public List<ProjectDTO> _projectList = new List<ProjectDTO>();


        protected override async Task OnInitializedAsync()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            isUserAuthenticated = authState.User.Identity.IsAuthenticated; //false->true
        }

        protected override async Task OnParametersSetAsync()
        {
            await GetProject();
        }
        private async Task GetProject()
        {
            var pagingResponse = await _projectHttpClient.GetProjectAsync();
            _projectList = pagingResponse;
        }

        public async Task DeleteProject(Guid projectId)
        {
            await _projectHttpClient.DeleteProjectAsync(projectId);
            _toastService.ShowSuccess(Messages.PostDeleted, Messages.Success);
            _navigationManager.NavigateTo($"/Project");
        }

    }
}
