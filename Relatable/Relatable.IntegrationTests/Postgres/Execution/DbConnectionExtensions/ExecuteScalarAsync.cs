using Relatable.Execution;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relatable.IntegrationTests.Postgres.Execution.DbConnectionExtensions
{
  public class ExecuteScalarAsync
  {
    // ExecuteScalarAsync
    [Fact]
    public async Task ExecuteScalarAsync_ReturnsEnum()
    {
      // Arrange
      using var connection = PostgresConnectionFactory.OpenConnection();
      var sql = "SELECT \"Id\" FROM test LIMIT 1";

      // Act
      var result = await connection.ExecuteScalarAsync<TestEnum>(sql);

      // Assert
      result.ShouldBe(TestEnum.B);
    }

    [Fact]
    public async Task ExecuteScalarAsync_ReturnsStringEnum()
    {
      // Arrange
      using var connection = PostgresConnectionFactory.OpenConnection();
      var sql = "SELECT \"Name\" FROM test LIMIT 1";

      // Act
      var result = await connection.ExecuteScalarAsync<TestEnum>(sql);

      // Assert
      result.ShouldBe(TestEnum.TestName);
    }

    [Fact]
    public async Task ExecuteScalarAsync_ReturnsString()
    {
      // Arrange
      using var connection = PostgresConnectionFactory.OpenConnection();
      var sql = "SELECT \"Name\" FROM test LIMIT 1";

      // Act
      var result = await connection.ExecuteScalarAsync<string>(sql);

      // Assert
      result.ShouldBe("TestName");
    }

    [Fact]
    public async Task ExecuteScalarAsync_ReturnsBool()
    {
      // Arrange
      using var connection = PostgresConnectionFactory.OpenConnection();
      var sql = "SELECT \"Id\" FROM test LIMIT 1";

      // Act
      var result = await connection.ExecuteScalarAsync<bool>(sql);

      // Assert
      result.ShouldBeTrue();
    }

    [Fact]
    public async Task ExecuteScalarAsync_ReturnsShort()
    {
      // Arrange
      using var connection = PostgresConnectionFactory.OpenConnection();
      var sql = "SELECT \"Id\" FROM test LIMIT 1";

      // Act
      var result = await connection.ExecuteScalarAsync<short>(sql);

      // Assert
      result.ShouldBe((short)1);
    }

    [Fact]
    public async Task ExecuteScalarAsync_ReturnsInt()
    {
      // Arrange
      using var connection = PostgresConnectionFactory.OpenConnection();
      var sql = "SELECT \"Id\" FROM test LIMIT 1";

      // Act
      var result = await connection.ExecuteScalarAsync<int>(sql);

      // Assert
      result.ShouldBe(1);
    }

    [Fact]
    public async Task ExecuteScalarAsync_ReturnsLong()
    {
      // Arrange
      using var connection = PostgresConnectionFactory.OpenConnection();
      var sql = "SELECT \"Id\" FROM test LIMIT 1";

      // Act
      var result = await connection.ExecuteScalarAsync<long>(sql);

      // Assert
      result.ShouldBe(1);
    }

    [Fact]
    public async Task ExecuteScalarAsync_ReturnsDateTime()
    {
      // Arrange
      using var connection = PostgresConnectionFactory.OpenConnection();
      var sql = "SELECT CreatedOn FROM test LIMIT 1";

      // Act
      var result = await connection.ExecuteScalarAsync<DateTime>(sql);

      // Assert
      result.GetType().ShouldBe(typeof(DateTime));
    }

    [Fact]
    public async Task ExecuteScalarAsync_ReturnsDateOnlyForDate()
    {
      // Arrange
      using var connection = PostgresConnectionFactory.OpenConnection();
      var sql = "SELECT CreatedDate FROM test LIMIT 1";

      // Act
      var result = await connection.ExecuteScalarAsync<DateOnly>(sql);

      // Assert
      result.GetType().ShouldBe(typeof(DateOnly));
    }

    [Fact]
    public async Task ExecuteScalarAsync_ReturnsDateOnlyForDateTime()
    {
      // Arrange
      using var connection = PostgresConnectionFactory.OpenConnection();
      var sql = "SELECT CreatedOn FROM test LIMIT 1";

      // Act
      var result = await connection.ExecuteScalarAsync<DateOnly>(sql);

      // Assert
      result.GetType().ShouldBe(typeof(DateOnly));
    }

    [Fact]
    public async Task ExecuteScalarAsync_ReturnsTimeSpanForTime()
    {
      // Arrange
      using var connection = PostgresConnectionFactory.OpenConnection();
      var sql = "SELECT CreatedTime FROM test LIMIT 1";

      // Act
      var result = await connection.ExecuteScalarAsync<TimeSpan>(sql);

      // Assert
      result.GetType().ShouldBe(typeof(TimeSpan));
    }

    [Fact]
    public async Task ExecuteScalarAsync_ReturnsTimeSpanForDateTime()
    {
      // Arrange
      using var connection = PostgresConnectionFactory.OpenConnection();
      var sql = "SELECT CreatedOn FROM test LIMIT 1";

      // Act
      var result = await connection.ExecuteScalarAsync<TimeSpan>(sql);

      // Assert
      result.GetType().ShouldBe(typeof(TimeSpan));
    }

    [Fact]
    public async Task ExecuteScalarAsync_ReturnsTimeOnlyForTime()
    {
      // Arrange
      using var connection = PostgresConnectionFactory.OpenConnection();
      var sql = "SELECT CreatedTime FROM test LIMIT 1";

      // Act
      var result = await connection.ExecuteScalarAsync<TimeOnly>(sql);

      // Assert
      result.GetType().ShouldBe(typeof(TimeOnly));
    }

    [Fact]
    public async Task ExecuteScalarAsync_ReturnsTimeOnlyForDateTime()
    {
      // Arrange
      using var connection = PostgresConnectionFactory.OpenConnection();
      var sql = "SELECT CreatedOn FROM test LIMIT 1";

      // Act
      var result = await connection.ExecuteScalarAsync<TimeOnly>(sql);

      // Assert
      result.GetType().ShouldBe(typeof(TimeOnly));
    }

    [Fact]
    public async Task ExecuteScalarAsync_ReturnsUUID()
    {
      // Arrange
      using var connection = PostgresConnectionFactory.OpenConnection();
      var sql = "SELECT TestUUID FROM test LIMIT 1";

      // Act
      var result = await connection.ExecuteScalarAsync<Guid>(sql);

      // Assert
      result.GetType().ShouldBe(typeof(Guid));
    }
  }
}
