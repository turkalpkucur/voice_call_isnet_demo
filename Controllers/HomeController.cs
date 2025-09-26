using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace ssoiframe.Controllers
{
  public class HomeController : Controller
  {


    public IActionResult Index()
    {
      return View();
    }

 
    [HttpPost("call")]
    public async Task<IActionResult> CallAsync()
    {
      var client = new HttpClient();
      var request = new HttpRequestMessage
      {
        Method = HttpMethod.Post,
        RequestUri = new Uri("https://api.wrtcdev.voyce.cc/Auth/v1/SSO"),
        Headers =
    {
        { "Accept", "application/json" },
    },
        Content = new StringContent("{\n  \"username\": \"tayfun.gul\"," +
        "                             \n  \"domain\": \"infotec\"," +
                "                             \n  \"queue\": \"infotec\"," +
                                "                             \n  \"remoteNumber\": \"05054270123\"," +
        "                             \n  \"ctiToken\": \"101659ca56bd2cf1393d58c6924b3c08\"" +
        "" +
        "                             \n}")
        {
          Headers =
        {
            ContentType = new MediaTypeHeaderValue("application/json")
        }
        }
      };
      using (var response = await client.SendAsync(request))
      {
        response.EnsureSuccessStatusCode();
        var body = await response.Content.ReadAsStringAsync();
        Console.WriteLine(body);
      }
      return Ok();
    }


  }
}
