using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FlurlTest
{
    public class FakeJsonService
    {
        private readonly HttpClient _httpClient;

        public FakeJsonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetFakeData()
        {
            var templateDados = @"{
                                  ""token"": ""4UByP0KUbLPL_KMIZNWRbg"",
                                  ""data"": {
                                    ""id"": ""personNickname"",
                                    ""email"": ""internetEmail"",
                                    ""last_login"": {
                                      ""date_time"": ""dateTime|UNIX"",
                                      ""ip4"": ""internetIP4""
                                    }
                                  }
                                }";

            var response = await _httpClient.PostAsync(
                                                    "https://app.fakejson.com/q",
                                                    new StringContent(
                                                        templateDados, 
                                                        Encoding.UTF8, 
                                                        "application/json"
                                                    )
                                                );

            return await response.Content.ReadAsStringAsync();
        }
    }
}
