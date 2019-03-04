using Flurl.Http.Testing;
using FlurlTest;
using FlurlTest.Tests;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class FakeJsonServiceTests
    {
        private FakeJsonService _fakeJsonService;

        [Test]
        public async Task GetFakeDataShouldCallFakeJsonServerWithCorrectParameters()
        {
            using (var httpTest = new HttpTest())
            {
                _fakeJsonService = new FakeJsonService(new HttpClient(new FakeHttpClientMessageHandler()));

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

                var response = await _fakeJsonService.GetFakeData();

                httpTest.ShouldHaveCalled("https://app.fakejson.com/q")
                         .WithVerb(HttpMethod.Post)
                         .WithContentType("application/json")
                         .WithRequestBody(templateDados)
                         .Times(1);
            }
        }
    }
}