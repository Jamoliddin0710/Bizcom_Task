using BookShopBlazor.Service;
using Frontend.Entities.DTO.Teacher;
using Frontend.Entities.ModelView;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Frontend.Service
{
    public class TeacherService : HttpClientBase
    {
        public TeacherService(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<HttpResponseMessage> Register(CreateTeacherDTO teacher)
        {
            try
            {
                var json = JsonConvert.SerializeObject(teacher);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("https://localhost:7000/api/Account/register", content);

                return response;
            }
            catch (Exception ex)
            {
                // Hata durumunu ele almak için gerekli işlemleri burada yapabilirsiniz
                throw new Exception("Kayıt sırasında bir hata oluştu.", ex);
            }
        }
        public async Task<UserAuthInfo> SignUp(CreateTeacherDTO createTeacher)
        {
            var requestUri = "https://localhost:7000/api/Account/register";

            var request = new HttpRequestMessage(HttpMethod.Post, requestUri);
            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var jsonContent = new StringContent(JsonConvert.SerializeObject(createTeacher), Encoding.UTF8, "application/json");
            request.Content = jsonContent;

            var response = await httpClient.SendAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var userAuthInfo = JsonConvert.DeserializeObject<UserAuthInfo>(responseContent);
                return userAuthInfo;
            }
            else
            {
                // Handle error response
                Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                return null;
            }
        }


    }

}
