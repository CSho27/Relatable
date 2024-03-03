using Relatable.Execution;
using Shouldly;

namespace Relatable.IntegrationTests.Postgres.Execution.DbConnectionExtensions
{
  public class ExecuteTests
  {
    [Fact]
    public void Execute_ReturnsMappedRows()
    {
      // Arrange
      using var connection = PostgresConnectionFactory.OpenConnection();
      var sql = "SELECT * FROM test";

      // Act
      var results = connection.Execute<TestEntity>(sql);

      // Assert
      results.Count().ShouldBe(3);
      for(var i=0; i<3; i++)
      {
        var result = results.ElementAt(i);
        result.Id.ShouldBe(i+1);
        result.Name.ShouldBe("TestName");
        result.Description.ShouldBe("This is a test description");
        result.CreatedOn.ShouldBe(DateTime.Parse("2024-03-02 15:52:56.310556"));
        result.CreatedDate.ShouldBe(DateOnly.Parse("2024-03-02"));
        result.CreatedTime.ShouldBe(TimeOnly.Parse("16:13:31.333771"));
        result.TestUUID.ShouldBe(Guid.Parse("9b6768ba-5140-4b7e-8783-458224a98d06"));
      }

    }
  }
}
