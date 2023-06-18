using BookShopBlazor.Service;
using Frontend.Entities.ModelView;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Newtonsoft.Json;

namespace Frontend.Service
{
    public class StatisticsService : HttpClientBase
    {
        public StatisticsService(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<List<StudentDTO>> GetStudentToMaxAge20()
        {
            var httpRequest = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://localhost:7000/api/Statistics/Student-AgeTo20");

            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(httpRequest);
            var productJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<StudentDTO>>(productJson);
            }
            return new List<StudentDTO>();
        }

        public async Task<List<StudentDTO>> GetStudentFromAugustToSeptember()
        {
            var httpRequest = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://localhost:7000/api/Statistics/Student-Month-August-September");

            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(httpRequest);
            var productJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<StudentDTO>>(productJson);
            }
            return new List<StudentDTO>();
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
                return JsonConvert.DeserializeObject<List<StudentDTO>>(productJson);
            }
            return new List<StudentDTO>();
        }

        public async Task<List<TeacherDTO>> GetAllTeachers()
        {
            var httpRequest = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://localhost:7000/api/Teachers");

            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(httpRequest);
            var productJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<TeacherDTO>>(productJson);
            }
            return new List<TeacherDTO>();
        }
        public async Task<List<TeacherDTO>> GetTeacherAgeCompare55()
        {
            var httpRequest = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://localhost:7000/api/Statistics/Teacher-Age-Compare-55");

            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(httpRequest);
            var productJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<TeacherDTO>>(productJson);
            }
            return new List<TeacherDTO>();
        }

        public async Task<Tuple<List<StudentDTO>, List<TeacherDTO>>> GetBeelineUser()
        {
            var httpRequest = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://localhost:7000/api/Statistics/Beeline-Users");

            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(httpRequest);
            var productJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Tuple<List<StudentDTO>,List<TeacherDTO>>>(productJson);
            }
            return new Tuple<List<StudentDTO>, List<TeacherDTO>>(new List<StudentDTO>(), new List<TeacherDTO>());
        }

        public async Task<List<StudentDTO>> GetStudentsByUserName(string name)
        {
            var httpRequest = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://localhost:7000/api/Statistics/Get-User-By-Name?name={name}");

            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(httpRequest);
            var productJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<StudentDTO>>(productJson);
            }
            return new List<StudentDTO>();
        }

        public async Task<List<TeacherDTO>> GetTeacherByStudentMaxBallFrom97()
        {
            var httpRequest = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://localhost:7000/api/Statistics/Get-Teacher-By-From-Ball-97");

            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(httpRequest);
            var productJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<TeacherDTO>>(productJson);
            }
            return new List<TeacherDTO>();
        }

        public async Task<SubjectDTO> GetSubjectByStudentBall(int studentId)
        {
            var httpRequest = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://localhost:7000/api/Statistics/Get-Subject-By-Student-Ball?studentId={studentId}");

            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(httpRequest);
            var Json = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<SubjectDTO>(Json);
            }
            return new SubjectDTO();
        }

        public async Task<List<SubjectDTO>> GetSubjectByStudentBall10(int teacherId)
        {
            var httpRequest = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://localhost:7000/api/Statistics/Get-Subject-By-Student-MaxBall10?teacherId={teacherId}");

            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(httpRequest);
            var Json = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<SubjectDTO>>(Json);
            }
            return new List<SubjectDTO>();
        }

        public async Task<SubjectDTO> GetSubjectHighestAverageScore()
        {
            var httpRequest = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://localhost:7000/api/Statistics/Get-Subject-By-MaxScore");

            httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(httpRequest);
            var productJson = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<SubjectDTO>(productJson);
            }
            return new SubjectDTO();
        }
    }
}
