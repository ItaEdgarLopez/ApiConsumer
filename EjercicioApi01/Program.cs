using System.Text.Json;

var url = "https://localhost:44430/api/prueba/lista";


JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive= true};



using (var httpClient = new HttpClient())
{
    var response = await httpClient.GetAsync(url);
    if (response.IsSuccessStatusCode)
    {
        var contenido = await response.Content.ReadAsStringAsync();

        //Console.WriteLine(contenido);

        var data = JsonSerializer.Deserialize<List<Data>>(contenido, options);

        foreach (var item in data)
        {
            Console.WriteLine($"{item.cancionId} {item.cancionTitulo} {item.cancionAlbum} ");
        }

    }
    else
        Console.WriteLine("Error");

    Console.ReadLine();
}


public class Data
{
    public int cancionId { get; set; }
    public string cancionTitulo { get; set; }
    public string cancionArtista { get; set; }
    public string cancionAlbum { get; set; }
    public string cancionBanda { get; set; }
    public string cancionGenero { get; set; }
    public string cancionAño { get; set; }
    public object cancionAdd { get; set; }
}  


