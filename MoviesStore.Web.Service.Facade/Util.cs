using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MoviesStore.Web.Service.Facade
{
    public static class Util
    {
        /// <summary>
        /// Helper Method to call external REST Service Get Method.
        /// </summary>
        /// <param name="baseAddress">Base Address of the Requesting Application</param>
        /// <param name="requestURI"> Relative URI of the Requesting Application </param>
        /// <param name="acceptEncodings"> List of Encodings Which your Application accepts </param>
        /// <param name="compressionFlag"> Flag to decompress or not</param>
        /// <param name="psConnectionStringKey"> Flag to decompress or not</param>
        /// <returns> Response of request as object </returns>
        public static async Task<T> GetDataFromService<T>(string baseAddress, string requestURI, string[] acceptEncodings, bool compressionFlag = false)
        {
            T result = default(T);
            using (var client = new HttpClient())
            {
                client.Timeout.Add(new TimeSpan(0, 0, 10));
                client.BaseAddress = new Uri(baseAddress);
                if (acceptEncodings != null)
                {
                    foreach (string item in acceptEncodings)
                    {
                        client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue(item));
                    }
                }
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                try
                {
                    HttpResponseMessage response = await client.GetAsync(requestURI);
                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsAsync<T>();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return result;
            }
        }
        /// <summary>
        /// Helper Method to call external REST Service Get Method.
        /// </summary>
        /// <param name="baseAddress">Base Address of the Requesting Application</param>
        /// <param name="requestURI"> Relative URI of the Requesting Application </param>
        /// <param name="acceptEncodings"> List of Encodings Which your Application accepts </param>
        /// <param name="compressionFlag"> Flag to decompress or not</param>
        /// <param name="psConnectionStringKey"> Flag to decompress or not</param>
        /// <returns> Response of request as object </returns>
        public static async Task<object> GetDataFromService(string baseAddress, string requestURI, string[] acceptEncodings, bool compressionFlag = false, string psConnectionStringKey = null)
        {
            object result = null;
            using (var client = new HttpClient())
            {
                client.Timeout.Add(new TimeSpan(0, 0, 10));
                client.BaseAddress = new Uri(baseAddress);
                if (acceptEncodings != null)
                {
                    foreach (string item in acceptEncodings)
                    {
                        client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue(item));
                    }
                }
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                try
                {
                    HttpResponseMessage response = await client.GetAsync(requestURI);
                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsAsync<object>();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return result;
            }
        }
        /// <summary>
        /// Helper Method to call external REST Service Get Method.
        /// </summary>
        /// <param name="baseAddress">Base Address of the Requesting Application</param>
        /// <param name="requestURI"> Relative URI of the Requesting Application </param>
        /// <param name="acceptEncodings"> List of Encodings Which your Application accepts </param>
        /// <param name="compressionFlag"> Flag to decompress or not</param>

        /// <returns> Response of request as object </returns>
        public static async Task<object> GetDataFromPostService(string baseAddress, string requestURI, object postObject, string[] acceptEncodings, bool compressionFlag = false)
        {
            object result = null;
            using (var client = new HttpClient())
            {
                client.Timeout.Add(new TimeSpan(0, 0, 10));
                client.BaseAddress = new Uri(baseAddress);

                if (acceptEncodings != null)
                {
                    foreach (string item in acceptEncodings)
                    {
                        client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue(item));
                    }
                }
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.PostAsJsonAsync(requestURI, postObject);
                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsAsync<object>();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return result;
            }
        }

        /// <summary>
        /// Helper Method to call external REST Service Get Method.
        /// </summary>
        /// <param name="baseAddress">Base Address of the Requesting Application</param>
        /// <param name="requestURI"> Relative URI of the Requesting Application </param>
        /// <param name="acceptEncodings"> List of Encodings Which your Application accepts </param>
        /// <param name="compressionFlag"> Flag to decompress or not</param>
        /// <param name="psConnectionStringKey"> Flag to decompress or not</param>
        /// <returns> Response of request as object </returns>
        public static async Task<T> GetDataFromPostService<T>(string baseAddress, string requestURI, object postObject, string[] acceptEncodings, bool compressionFlag = false, string psConnectionStringKey = null)
        {
            T result = default(T);
            using (var client = new HttpClient())
            {
                client.Timeout.Add(new TimeSpan(0, 0, 10));
                client.BaseAddress = new Uri(baseAddress);
                if (acceptEncodings != null)
                {
                    foreach (string item in acceptEncodings)
                    {
                        client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue(item));
                    }
                }
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                try
                {
                    HttpResponseMessage response = await client.PostAsJsonAsync(requestURI, postObject);

                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsAsync<T>();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return result;
            }
        }
    }
}
