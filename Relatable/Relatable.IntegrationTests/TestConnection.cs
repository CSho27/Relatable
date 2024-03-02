using Npgsql;

namespace Relatable.IntegrationTests
{
  public class IntegrationTest1
  {
    [Fact]
    public async Task Test1()
    {
      var connectionString = "Server=localhost:5432;Database=relatable;User Id=postgres;Password=Ba5eba11";
      using var connection = new NpgsqlConnection(connectionString);
      connection.Open();

      var sql = "SELECT * FROM Test";

      using var command = new NpgsqlCommand(sql, connection);
      using var reader = command.ExecuteReader();
      while (await reader.ReadAsync())
      {
        var hasRows = reader.HasRows;
        var id = reader["Id"];
        var name = reader["Name"];
        var description = reader["Description"];
        Assert.True(hasRows);
        Assert.Equal(1, id);
        Assert.Equal("TestName", name);
        Assert.Equal("This is a test description", description);
      }
    }
  }
}