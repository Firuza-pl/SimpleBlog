using Microsoft.AspNetCore.Components;
using Blog.Client.HttpClients;
using Blog.Shared.DTOs;
using Resources;
using Blazored.Toast.Services;

namespace Blog.Client.Pages.Project
{
    public class EditProjectBase : ComponentBase
    {
        [Parameter]
        public Guid ProjectId { get; set; }
        [Inject] NavigationManager _navigationManager { get; set; }
        [Inject] IToastService _toastService { get; set; }
        [Inject] ProjectHttpClient _projectHttpClient { get; set; }

        public UpdateProjectDTO editExistingProject = new UpdateProjectDTO();

        protected override async Task OnInitializedAsync()
        {
            var prokeject = await _projectHttpClient.GetProjectIdAsync(ProjectId);

            editExistingProject.ProjectId = prokeject.ProjectId;
            editExistingProject.Title = prokeject.Title;
            editExistingProject.Description = prokeject.Description;
        }

        public async Task HandleValidSubmit()
        {
            await _projectHttpClient.UpdateProjectAsync(editExistingProject);
            _toastService.ShowSuccess(Messages.PostSaved, Messages.Success);
            _navigationManager.NavigateTo("/Project");
        }

    }
}
