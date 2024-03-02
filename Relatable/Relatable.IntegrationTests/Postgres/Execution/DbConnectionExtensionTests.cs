using Relatable.Execution;
using Shouldly;

namespace Relatable.IntegrationTests.Postgres.Execution
{
  public enum TestEnum { A, B, C }

  public class DbConnectionExtensionTests
  {
    [Fact]
    public void ExecuteScalar_ReturnsEnum()
    {
      // Arrange
      using var connection = PostgresConnectionFactory.OpenConnection();
      var sql = "SELECT COUNT(*) FROM test";

      // Act
      var result = connection.ExecuteScalar<TestEnum>(sql);

      // Assert
      result.ShouldBe(TestEnum.B);
    }

    [Fact]
    public void ExecuteScalar_ReturnsString()
    {
      // Arrange
      using var connection = PostgresConnectionFactory.OpenConnection();
      var sql = "SELECT \"Name\" FROM test LIMIT 1";

      // Act
      var result = connection.ExecuteScalar<string>(sql);

      // Assert
      result.ShouldBe("TestName");
    }

    [Fact]
    public void ExecuteScalar_ReturnsBool()
    {
      // Arrange
      using var connection = PostgresConnectionFactory.OpenConnection();
      var sql = "SELECT COUNT(*) > 0 FROM test";

      // Act
      var result = connection.ExecuteScalar<bool>(sql);

      // Assert
      result.ShouldBeTrue();
    }

    [Fact]
    public void ExecuteScalar_ReturnsShort()
    {
      // Arrange
      using var connection = PostgresConnectionFactory.OpenConnection();
      var sql = "SELECT COUNT(*) FROM test";

      // Act
      var result = connection.ExecuteScalar<short>(sql);

      // Assert
      result.ShouldBe((short)1);
    }

    [Fact]
    public void ExecuteScalar_ReturnsInt()
    {
      // Arrange
      using var connection = PostgresConnectionFactory.OpenConnection();
      var sql = "SELECT COUNT(*) FROM test";

      // Act
      var result = connection.ExecuteScalar<int>(sql);

      // Assert
      result.ShouldBe(1);
    }

    [Fact]
    public void ExecuteScalar_ReturnsLong()
    {
      // Arrange
      using var connection = PostgresConnectionFactory.OpenConnection();
      var sql = "SELECT COUNT(*) FROM test";

      // Act
      var result = connection.ExecuteScalar<long>(sql);

      // Assert
      result.ShouldBe((long)1);
    }
  }
}
