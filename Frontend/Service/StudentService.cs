using Frontend.Entities.DTO.Student;
using Frontend.Entities.ModelView;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Newtonsoft.Json;
using System.Text;

namespace BookShopBlazor.Service
{
    public class StudentService : HttpClientBase
    {
        public StudentService(HttpClient httpClient) : base(httpClient) { }
        public async Task<StudentDTO> GetAuthorById(int authorId)
        {
            var httpRequest = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://localhost:7202/api/Admin_Author/{authorId}");

            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(httpRequest);
            var productJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<StudentDTO>(productJson);
            }
            return new StudentDTO();
        }
        public async Task<StudentDTO> AddStudent(CreateStudentDTO createStudent)
        {
            var studentJson = JsonConvert.SerializeObject(createStudent);
            var httpContent = new StringContent(studentJson, Encoding.UTF8, "application/json");

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7000/api/Students/");
            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
            httpRequest.Content = httpContent;

            var response = await httpClient.SendAsync(httpRequest);
            var studentDtoJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<StudentDTO>(studentDtoJson);
            }

            return new StudentDTO();
        }

        public async Task<List<StudentDTO>> GetAllStudent()
        {
            var httpRequest = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://localhost:7000/api/Students");

            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(httpRequest);
            var productJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<StudentDTO>> (productJson);
            }
            return new List<StudentDTO>();
        }
        public async Task DeleteStudent(int studentId)
        {
            var url = $"https://localhost:7000/api/Students/{studentId}";
            var httpRequest = new HttpRequestMessage(HttpMethod.Delete, url);
            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(httpRequest);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Student deletion failed.");
            }
        }

        /*  public async Task DeleteStudent(int studentId)
          {
              var httpRequest = new HttpRequestMessage(
                  HttpMethod.Delete,
                  $"https://localhost:7000/api/Students?studentId={studentId}");
              httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

              var response = await httpClient.SendAsync(httpRequest);

              if (!response.IsSuccessStatusCode)
              {
                  throw new Exception("Student deletion failed.");
              }
          }*/


        public async Task<UserDTO> GetImage(int imageId)
        {
            var httpRequest = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://localhost:7202/api/Files/5");

            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(httpRequest);
            var imageJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<UserDTO>(imageJson);
            }
            return new UserDTO();
        }
    }
}
