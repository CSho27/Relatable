using Microsoft.Extensions.Configuration;
using Relatable.IntegrationTests.Utilities;

namespace Relatable.IntegrationTests
{
  public class AppSettingsProvider
  {
    private readonly IConfigurationRoot _configuration;

    public AppSettingsProvider()
    {
      var projectPath = FileSystemUtilities.GetProjectRootDirectory();
      if (string.IsNullOrEmpty(projectPath))
        throw new Exception("Failed to find project root directory");

      var appSettingsPath = Path.Combine(projectPath, "appsettings.json");
      var configBuilder = new ConfigurationBuilder().AddJsonFile(appSettingsPath);
      _configuration = configBuilder.Build();
    }

    public ConnectionStrings ConnectionStrings
    {
      get
      {
        var postgres = _configuration.GetConnectionString("Postgres");
        if (string.IsNullOrEmpty(postgres))
          throw new Exception("Invalid configuration. Missing ConnectionString for Postgres");

        return new ConnectionStrings(postgres);
      }
    }
  }

  public record ConnectionStrings(string Postgres);
}
