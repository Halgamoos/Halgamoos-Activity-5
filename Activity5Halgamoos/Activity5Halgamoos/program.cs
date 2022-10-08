using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();
serviceCollection.AddHttpClient();
var services = serviceCollection.BuildServiceProvider();

var httpClientFactory = services.GetRequiredService<IHttpClientFactory>();
var client = httpClientFactory.CreateClient(); 
client.BaseAddress = new Uri("https://api.genderize.io");

List<Person> people = new();
if (people == null) throw new ArgumentNullException(nameof(people));
List<string> peopleNames = new() { "Sarah", "Bob", "Joseph", "Vanessa" };

foreach (var personName in peopleNames)
    people.Add(await client.GetFromJsonAsync<Person>($"?name={personName}", new JsonSerializerOptions(JsonSerializerDefaults.Web)));

foreach (var person in people)
{
    Console.WriteLine($"Name: {person.Name}");
    Console.WriteLine($"The gender of someone named {person.Name} is mostly likely: {person.Gender}");
    Console.WriteLine($"The probability of a {person.Name} being a {person.Gender} is {person.Probability}");
    Console.WriteLine($"Count: {person.Count}");
    Console.WriteLine("==========================================");
}

