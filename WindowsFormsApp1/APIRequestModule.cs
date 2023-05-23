using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Reflection;

namespace WindowsFormsApp1
{
    class APIRequestModule
    {
        private static string authToken = "";

        private static HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:8000/") };

        public static string getAuthToken()
        {
            return authToken;
        }

        public static void setAuthToken(string token)
        {
            authToken = token;
        }

        public static async Task<JsonElement> sendGetRequest(string uri, bool authorized = false)
        {
            // Create HttpRequestMessage
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);

            // Set headers
            if (authorized)
            {
                request.Headers.Add("Authorization", $"Token {authToken}");
            }

            // Send the request
            HttpResponseMessage response = await client.SendAsync(request);

            // Read the response body
            string responseBody = await response.Content.ReadAsStringAsync();

            // Parse the JSON response body
            JsonElement parsedResponse = ParseJson(responseBody);

            // Display response status code, body, and parsed JSON
            Console.WriteLine("Response Status Code: " + response.StatusCode);
            Console.WriteLine("Response Body: " + responseBody);
            Console.WriteLine("Parsed JSON: " + parsedResponse);

            return parsedResponse;
        }

        public static async Task<JsonElement> sendPostRequest(string uri, object body, bool authorized = false)
        {
            // Convert the object to JSON string
            string requestBody = ConvertToJson(body);

            // Create HttpContent from the request body
            var httpContent = new StringContent(requestBody, Encoding.UTF8, "application/json");

            // Set headers
            if (authorized)
            {
                httpContent.Headers.Add("Authorization", $"Token {authToken}");
            }

            // Send the POST request
            HttpResponseMessage response = await client.PostAsync(uri, httpContent);

            // Read the response body
            string responseBody = await response.Content.ReadAsStringAsync();

            // Parse the JSON response body
            JsonElement parsedResponse = ParseJson(responseBody);

            // Display response status code, body, and parsed JSON
            Console.WriteLine("Response Status Code: " + response.StatusCode);
            Console.WriteLine("Response Body: " + responseBody);
            Console.WriteLine("Parsed JSON: " + parsedResponse);

            return parsedResponse;
        }

        public static async Task<JsonElement> sendPutRequest(string uri, object body, bool authorized = false)
        {
            // Convert the object to JSON string
            string requestBody = ConvertToJson(body);

            // Create HttpContent from the request body
            var httpContent = new StringContent(requestBody, Encoding.UTF8, "application/json");

            // Set headers
            if (authorized)
            {
                httpContent.Headers.Add("Authorization", $"Token {authToken}");
            }

            // Send the POST request
            HttpResponseMessage response = await client.PutAsync(uri, httpContent);

            // Read the response body
            string responseBody = await response.Content.ReadAsStringAsync();

            // Parse the JSON response body
            JsonElement parsedResponse = ParseJson(responseBody);

            // Display response status code, body, and parsed JSON
            Console.WriteLine("Response Status Code: " + response.StatusCode);
            Console.WriteLine("Response Body: " + responseBody);
            Console.WriteLine("Parsed JSON: " + parsedResponse);

            return parsedResponse;
        }

        public static async Task<JsonElement> sendDeleteRequest(string uri, object body, bool authorized = false)
        {
            // Create HttpRequestMessage
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, uri);

            // Convert the object to JSON string
            string requestBody = ConvertToJson(body);

            // Create HttpContent from the request body
            var httpContent = new StringContent(requestBody, Encoding.UTF8, "application/json");

            // Set the request content
            request.Content = httpContent;

            // Set headers
            if (authorized)
            {
                request.Headers.Add("Authorization", $"Token {authToken}");
            }

            // Send the request
            HttpResponseMessage response = await client.SendAsync(request);

            // Read the response body
            string responseBody = await response.Content.ReadAsStringAsync();

            // Parse the JSON response body
            JsonElement parsedResponse = ParseJson(responseBody);

            // Display response status code, body, and parsed JSON
            Console.WriteLine("Response Status Code: " + response.StatusCode);
            Console.WriteLine("Response Body: " + responseBody);
            Console.WriteLine("Parsed JSON: " + parsedResponse);

            return parsedResponse;
        }

        public static string ConvertToJson(object data)
        {
            // Convert object to JSON string using System.Text.Json
            string jsonString = JsonSerializer.Serialize(data);
            return jsonString;
        }

        public static JsonElement ParseJson(string json)
        {
            // Parse JSON logic goes here
            // Modify this method according to your JSON parsing requirements
            // It should return the parsed object
            return JsonSerializer.Deserialize<JsonElement>(json);
        }

    }
}
