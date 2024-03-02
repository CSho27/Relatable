using Relatable.Utilities;
using System.Data;
using System.Data.Common;

namespace Relatable.Execution
{
  public static class DbConnectionExtensions
  {
    public static T ExecuteScalar<T>(this IDbConnection connection, string sql)
    {
      using var command = connection.CreateCommand();
      command.CommandText = sql;
      return command.ExecuteScalar().ConvertValue<T>();
    }

    public static async Task<T> ExecuteScalarAsync<T>(this IDbConnection connection, string sql)
    {
      using var genericCommand = connection.CreateCommand();
      if (genericCommand is not DbCommand command)
        throw new InvalidOperationException("Provided DbConnection does not support async execution");

      command.CommandText = sql;
      var result = await command.ExecuteScalarAsync();
      return result.ConvertValue<T>();
    }

    public static IEnumerable<T> Execute<T>(this IDbConnection connection, string sql)
    {
      using var command = connection.CreateCommand();
      command.CommandText = sql;
      using var reader = command.ExecuteReader();
      return reader.ReadAllRows<T>();
    }
  }
}
