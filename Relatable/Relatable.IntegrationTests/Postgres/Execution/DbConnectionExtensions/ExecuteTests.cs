using Relatable.Execution;
using Shouldly;

namespace Relatable.IntegrationTests.Postgres.Execution.DbConnectionExtensions
{
  public class TestEntity
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateOnly CreatedDate { get; set; }
    public TimeOnly CreatedTime { get; set; }
    public Guid TestUUID { get; set; }
  }

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

      results.Count().ShouldBe(1);
      var onlyResult = results.Single();
      onlyResult.Id.ShouldBe(1);
      onlyResult.Name.ShouldBe("TestName");
      onlyResult.Description.ShouldBe("This is a test description");
      onlyResult.CreatedOn.ShouldBe(DateTime.Parse("2024-03-02 15:52:56.310556"));
      onlyResult.CreatedDate.ShouldBe(DateOnly.Parse("2024-03-02"));
      onlyResult.CreatedTime.ShouldBe(TimeOnly.Parse("16:13:31.333771"));
      onlyResult.TestUUID.ShouldBe(Guid.Parse("9b6768ba-5140-4b7e-8783-458224a98d06"));
    }
  }
}
