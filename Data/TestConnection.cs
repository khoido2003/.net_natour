using MongoDB.Driver;
using Microsoft.Extensions.Hosting;

namespace NetNatour.Data
{
  public class TestConnection : IHostedService
  {
    private readonly string _connectionString = "";

    public TestConnection(IConfiguration configuration)
    {
      _connectionString = configuration.GetConnectionString("NatourMongo")!;
      Console.WriteLine(_connectionString);
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
      // Create a MongoClient
      var client = new MongoClient(_connectionString);
      try
      {
        // Attempt to connect to the database
        var database = client.GetDatabase("natour");
        var collections = database.ListCollections().ToList();

        Console.WriteLine("Connected successfully to MongoDB!");
        Console.WriteLine("Collections in 'natour' database:");

        foreach (var collection in collections)
        {
          Console.WriteLine(collection["name"]);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine("Connection failed: " + ex.Message);
      }
      return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
      // Clean up resources if needed
      return Task.CompletedTask;
    }
  }
}
