using System.Text.Json;

namespace Sorted.RainfallApi.Extensions
{
    public static class HttpClientExtension
    {
        public static async Task<TResponse> GetAsync<TResponse>(this HttpClient client, string requestUri)
        {
            HttpResponseMessage httpResponse = await client.GetAsync(requestUri);
            string httpResponseString = await httpResponse.Content.ReadAsStringAsync();
            TResponse? response = JsonSerializer.Deserialize<TResponse>(httpResponseString);

            return response;
        }
    }
}
