using System.Text.Json;

namespace Sorted.RainfallApi.Extensions
{
    /// <summary>
    /// Provides extension methods for HttpClient
    /// </summary>
    public static class HttpClientExtension
    {
        /// <summary>
        /// Executes Get requests and deserializes the response
        /// </summary>
        /// <typeparam name="TResponse">The response type</typeparam>
        /// <param name="client">HttpClient</param>
        /// <param name="requestUri">Request Uri</param>
        /// <returns></returns>
        public static async Task<TResponse> GetAsync<TResponse>(this HttpClient client, string requestUri)
        {
            HttpResponseMessage httpResponse = await client.GetAsync(requestUri);
            string httpResponseString = await httpResponse.Content.ReadAsStringAsync();
            TResponse? response = JsonSerializer.Deserialize<TResponse>(httpResponseString);

            return response;
        }
    }
}
