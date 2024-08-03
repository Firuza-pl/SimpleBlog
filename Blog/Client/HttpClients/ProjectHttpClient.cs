using Blog.Shared.DTOs;
using System.Net.Http.Json;

namespace Blog.Client.HttpClients
{
    public class ProjectHttpClient
    {
        private readonly HttpClient _httpClient;
        public ProjectHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProjectDTO>> GetProjectAsync()
        {
            //calling api from client class 
            var response = await _httpClient.GetFromJsonAsync<List<ProjectDTO>>("api/Project/GetList");
            return response;
        }

        public async Task<ProjectDTO> GetProjectIdAsync(Guid projectId)
        {
            var reponse = await _httpClient.GetFromJsonAsync<ProjectDTO>($"api/Project/EditBy/{projectId}");
            return reponse;
        }

        public async Task CreateProjectAsync(CreateProjectDTO createProjectDTO)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/Project/CreateProject", createProjectDTO);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateProjectAsync(UpdateProjectDTO updateProjectDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Project/UpdateBy/{updateProjectDTO.ProjectId}", updateProjectDTO);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteProjectAsync(Guid projectId)
        {
            var response = await _httpClient.DeleteAsync($"api/Project/{projectId}");
            response.EnsureSuccessStatusCode();
        }

    }
}
