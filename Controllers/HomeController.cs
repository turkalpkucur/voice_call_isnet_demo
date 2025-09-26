using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using System.Net;
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
        return Ok(response.StatusCode);
      }
      
    }


    [HttpPost]
    public async Task<IActionResult> GetControls()
    {

      string url = "https://mini.istecagrimerkezi.com";

      using var httpClient = new HttpClient();
      string html = await httpClient.GetStringAsync(url);

      // HtmlAgilityPack ile parse et
      var htmlDoc = new HtmlDocument();
      htmlDoc.LoadHtml(html);

      // �rnek: input[name='Kullan�c� Ad�'] alan�n� bul
      var inputNode = htmlDoc.DocumentNode.SelectSingleNode("//input[@type='text']");
      if (inputNode != null)
      {
        Console.WriteLine("Placeholder: " + inputNode.GetAttributeValue("placeholder", ""));
      }
      else
      {
        Console.WriteLine("Input bulunamad�.");
      }

      return Ok();

    }


    [HttpPost]
    public async Task<IActionResult> Login()
    {


      var handler = new HttpClientHandler
      {
        UseCookies = true,
        CookieContainer = new CookieContainer()
      };

      using var client = new HttpClient(handler);

      // Login endpoint (iframe formun action'�)
      string loginUrl = "https://mini.istecagrimerkezi.com/login";

      // G�nderilecek form verisi
      var formData = new FormUrlEncodedContent(new[]
      {
            new KeyValuePair<string, string>("username", "turkalp.kucur@infotec"),
            new KeyValuePair<string, string>("password", "Wease@34")
        });

      // POST iste�i
      var response = await client.GetAsync(loginUrl+"?username:turkalp.kucur@infotec&password:Wease@34");

      if (response.IsSuccessStatusCode)
      {
        Console.WriteLine("Login ba�ar�l�!");

        // Cookie veya token saklan�r
        var cookies = handler.CookieContainer.GetCookies(new Uri(loginUrl));
        foreach (Cookie cookie in cookies)
        {
          Console.WriteLine($"Cookie: {cookie.Name} = {cookie.Value}");
        }

        // �rnek: login sonras� ba�ka sayfaya eri�im
        var protectedPage = await client.GetStringAsync("https://mini.istecagrimerkezi.com/dashboard");
        Console.WriteLine(protectedPage.Substring(0, 200)); // ilk 200 karakteri yaz
      }
      else
      {
        Console.WriteLine("Login ba�ar�s�z: " + response.StatusCode);
      }

      return Ok();
    }



  }
}
