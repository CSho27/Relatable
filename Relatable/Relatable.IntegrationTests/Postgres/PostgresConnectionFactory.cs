using Npgsql;
using System.Data;

namespace Relatable.IntegrationTests.Postgres
{
  public class PostgresConnectionFactory
  {
    public static IDbConnection OpenConnection()
    {
      var appSettingsProvider = new AppSettingsProvider();
      var connection = new NpgsqlConnection(appSettingsProvider.ConnectionStrings.Postgres);
      connection.Open();
      return connection;
    }
  }
}
