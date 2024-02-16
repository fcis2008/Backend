using Newtonsoft.Json;

namespace Backend
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                // Create an instance of HttpClient
                using HttpClient client = new();

                // Set the base URL of the API
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

                // Make a GET request to fetch photos with albumId=3
                HttpResponseMessage response = await client.GetAsync("photos?albumId=3");

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the content of the response and deserialize it to a list of photos
                    string jsonString = await response.Content.ReadAsStringAsync();
                    Photo[] photos = JsonConvert.DeserializeObject<Photo[]>(jsonString);

                    // Display photo IDs and titles
                    Console.WriteLine("Photo IDs and Titles:");
                    foreach (var photo in photos)
                    {
                        Console.WriteLine($"ID: {photo.Id} - Title: {photo.Title}");
                    }
                }
                else
                {
                    Console.WriteLine($"Failed to fetch photos. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
