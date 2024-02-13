using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace BambooCardTest.Integrations
{
    public class ApiCall
    {
        public static async Task<T> GetAsync<T>(string baseurl, string APIName)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    //Passing service base url
                    client.BaseAddress = new Uri(baseurl);
                    client.DefaultRequestHeaders.Clear();
                    //Define request data format
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                    HttpResponseMessage Res = await client.GetAsync(APIName);
                    //Checking the response is successful or not which is sent using HttpClient
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var Response = Res.Content.ReadAsStringAsync().Result;
                        //Deserializing the response recieved from web api and storing into the Employee list
                        return JsonConvert.DeserializeObject<T>(Response);
                    }
                }
                catch (Exception ex)
                {

                }

                //returning the employee list to view
                return default(T);
            }
        }

    }
}