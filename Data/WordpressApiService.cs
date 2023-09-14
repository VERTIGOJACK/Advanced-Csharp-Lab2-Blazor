using Advanced_Csharp_Lab2_Blazor.Models;
using Advanced_Csharp_Lab2_Blazor.Models.wpmedia;
using Advanced_Csharp_Lab2_Blazor.Models.wppage;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Advanced_Csharp_Lab2_Blazor.Data
{
    public class WordpressApiService
    {
        HttpClient client = new HttpClient();

        public WordpressApiService(IOptions<WordpressApiOptions> options) 
        {
            this.client.BaseAddress = new Uri(options.Value.BaseUrl);
        }

        public async Task<WpPage> GetPage(int id)
        {
            //define endpoint
            string endpoint = "pages/";

            //prepare page obj
            WpPage page = new WpPage();

            HttpResponseMessage response = await client.GetAsync(endpoint + id);

            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string content = await response.Content.ReadAsStringAsync();

                //deserialize into object
                 page = JsonSerializer.Deserialize<WpPage>(content);
               
            }

            return page;
        }

        public async Task<WpMedia> GetMedia(int id)
        {
            //define endpoint
            string endpoint = "media/";

            //prepare media obj
            WpMedia media = new WpMedia();

            HttpResponseMessage response = await client.GetAsync(endpoint + id);

            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string content = await response.Content.ReadAsStringAsync();

                //deserialize into object
                media = JsonSerializer.Deserialize<WpMedia>(content);

            }

            return media;
        }
    }
}
