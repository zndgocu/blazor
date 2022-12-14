using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ramfree.Extensions.Web
{
    public static class HttpExtension
    {
        public static bool IsOk(this Task<HttpResponseMessage>? response, out string message)
        {
            if (response == null)
            {
                message = $"Request failed. Error message: {"response is Null"}";
                return false;
            }
            if (response.Result == null)
            {
                message = $"Request failed. Error message: {"Result is Null"}";
                return false;
            }
            return response.Result.IsOk(out message);
        }

        public static bool IsOk(this HttpResponseMessage? response, out string message)
        {
            if (response == null)
            {
                message = $"Request failed. Error message: {"response is Null"}";
                return false;
            }
            if(response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                message = $"Request failed. Error status code: {response.StatusCode}";
            }
            message = "Ok";
            return true;
        }

        public static async Task<T> GetContent<T>(this HttpContent content)
        {
            try
            {
                var stringContent = await content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(stringContent);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        public static async Task<string> GetContentString(this HttpContent content)
        {
            try
            {
                var stringContent = await content.ReadAsStringAsync();
                return stringContent;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
