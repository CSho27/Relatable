using Relatable.Execution;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relatable.IntegrationTests.Postgres.Execution
{
  public class DbConnectionExtensionTests
  {
    [Fact]
    public void ExecuteScalar_ReturnsInt()
    {
      // Arrange
      using var connection = PostgresConnectionFactory.OpenConnection();
      var selectInt = "SELECT COUNT(*) FROM test";

      // Act
      var result = connection.ExecuteScalar<int>(selectInt);

      // Assert
      result.ShouldBe(1);
    }
  }
}
