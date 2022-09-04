using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;

namespace MB.UI.Helpers
{
    public class Api<T>
    {
        public static async Task<HttpResponseMessage> PostAsync(string url,object model,string? token=null)
        {
            var jsondata = JsonConvert.SerializeObject(model);
            var data = new StringContent(jsondata, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            if(token != null)
            {
                client.DefaultRequestHeaders.Authorization =
                 new AuthenticationHeaderValue("Bearer", token);
            }
            var response = await client.PostAsync(url, data);
            return response;
        }
        public static async Task<HttpResponseMessage> PutAsync(string url, object model, string? token = null)
        {
            var jsondata = JsonConvert.SerializeObject(model);
            var data = new StringContent(jsondata, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            if (token != null)
            {
                client.DefaultRequestHeaders.Authorization =
                 new AuthenticationHeaderValue("Bearer", token);
            }
            var response = await client.PutAsync(url, data);
            return response;
        }
        public static async Task<List<T>> GetAsync(string url, string? token = null)
        {


            using var client = new HttpClient();
            if (token != null)
            {
                client.DefaultRequestHeaders.Authorization =
                 new AuthenticationHeaderValue("Bearer", token);
            }
            var response = await client.GetAsync(url);
            var jsonstring = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<T>>(jsonstring);
            return values;
        }
        public static async Task<HttpResponseMessage> DeleteAsync(string url,string? token=null)
        {


            using var client = new HttpClient();
            if (token != null)
            {
                client.DefaultRequestHeaders.Authorization =
                 new AuthenticationHeaderValue("Bearer", token);
            }
            var response = await client.DeleteAsync(url);
            return response;
        }


    }
}
