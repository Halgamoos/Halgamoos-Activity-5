using System.Text.Json.Serialization;

public class Person
{
    [JsonPropertyName("name")]
    public string Name { get; }

    [JsonPropertyName("gender")]
    public string Gender { get; }

    [JsonPropertyName("probability")]
    public float Probability { get; }

    [JsonPropertyName("count")]
    public int Count { get; }

    [JsonConstructor]
    public Person(string name, 
                    string gender, 
                    float probability, 
                    int count)
    {
        Name = name;
        Gender = gender;
        Probability = probability;
        Count = count;
    }
}


