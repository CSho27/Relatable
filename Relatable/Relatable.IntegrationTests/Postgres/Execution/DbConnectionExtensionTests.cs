﻿using Relatable.Execution;
using Shouldly;

namespace Relatable.IntegrationTests.Postgres.Execution
{
  public enum TestEnum { A, B, TestName }

  public class DbConnectionExtensionTests
  {
    // ExecuteScalar
    [Fact]
    public void ExecuteScalar_ReturnsEnum()
    {
      // Arrange
      using var connection = PostgresConnectionFactory.OpenConnection();
      var sql = "SELECT \"Id\" FROM test LIMIT 1";

      // Act
      var result = connection.ExecuteScalar<TestEnum>(sql);

      // Assert
      result.ShouldBe(TestEnum.B);
    }

    [Fact]
    public void ExecuteScalar_ReturnsStringEnum()
    {
      // Arrange
      using var connection = PostgresConnectionFactory.OpenConnection();
      var sql = "SELECT \"Name\" FROM test LIMIT 1";

      // Act
      var result = connection.ExecuteScalar<TestEnum>(sql);

      // Assert
      result.ShouldBe(TestEnum.TestName);
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
      var sql = "SELECT \"Id\" FROM test LIMIT 1";

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
      var sql = "SELECT \"Id\" FROM test LIMIT 1";

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
      var sql = "SELECT \"Id\" FROM test LIMIT 1";

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
      var sql = "SELECT \"Id\" FROM test LIMIT 1";

      // Act
      var result = connection.ExecuteScalar<long>(sql);

      // Assert
      result.ShouldBe((long)1);
    }

    [Fact]
    public void ExecuteScalar_ReturnsDateTime()
    {
      // Arrange
      using var connection = PostgresConnectionFactory.OpenConnection();
      var sql = "SELECT CreatedOn FROM test LIMIT 1";

      // Act
      var result = connection.ExecuteScalar<DateTime>(sql);

      // Assert
      result.GetType().ShouldBe(typeof(DateTime));
    }

    [Fact]
    public void ExecuteScalar_ReturnsDateOnlyForDate()
    {
      // Arrange
      using var connection = PostgresConnectionFactory.OpenConnection();
      var sql = "SELECT CreatedDate FROM test LIMIT 1";

      // Act
      var result = connection.ExecuteScalar<DateOnly>(sql);

      // Assert
      result.GetType().ShouldBe(typeof(DateOnly));
    }

    [Fact]
    public void ExecuteScalar_ReturnsDateOnlyForDateTime()
    {
      // Arrange
      using var connection = PostgresConnectionFactory.OpenConnection();
      var sql = "SELECT CreatedOn FROM test LIMIT 1";

      // Act
      var result = connection.ExecuteScalar<DateOnly>(sql);

      // Assert
      result.GetType().ShouldBe(typeof(DateOnly));
    }

    [Fact]
    public void ExecuteScalar_ReturnsTimeSpanForTime()
    {
      // Arrange
      using var connection = PostgresConnectionFactory.OpenConnection();
      var sql = "SELECT CreatedTime FROM test LIMIT 1";

      // Act
      var result = connection.ExecuteScalar<TimeSpan>(sql);

      // Assert
      result.GetType().ShouldBe(typeof(TimeSpan));
    }

    [Fact]
    public void ExecuteScalar_ReturnsTimeSpanForDateTime()
    {
      // Arrange
      using var connection = PostgresConnectionFactory.OpenConnection();
      var sql = "SELECT CreatedOn FROM test LIMIT 1";

      // Act
      var result = connection.ExecuteScalar<TimeSpan>(sql);

      // Assert
      result.GetType().ShouldBe(typeof(TimeSpan));
    }

    [Fact]
    public void ExecuteScalar_ReturnsTimeOnlyForTime()
    {
      // Arrange
      using var connection = PostgresConnectionFactory.OpenConnection();
      var sql = "SELECT CreatedTime FROM test LIMIT 1";

      // Act
      var result = connection.ExecuteScalar<TimeOnly>(sql);

      // Assert
      result.GetType().ShouldBe(typeof(TimeOnly));
    }

    [Fact]
    public void ExecuteScalar_ReturnsTimeOnlyForDateTime()
    {
      // Arrange
      using var connection = PostgresConnectionFactory.OpenConnection();
      var sql = "SELECT CreatedOn FROM test LIMIT 1";

      // Act
      var result = connection.ExecuteScalar<TimeOnly>(sql);

      // Assert
      result.GetType().ShouldBe(typeof(TimeOnly));
    }

    [Fact]
    public void ExecuteScalar_ReturnsUUID()
    {
      // Arrange
      using var connection = PostgresConnectionFactory.OpenConnection();
      var sql = "SELECT TestUUID FROM test LIMIT 1";

      // Act
      var result = connection.ExecuteScalar<Guid>(sql);

      // Assert
      result.GetType().ShouldBe(typeof(Guid));
    }



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
      result.ShouldBe((long)1);
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
