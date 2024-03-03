using Relatable.Abstractions.Querying.QueryModel;
using Relatable.Querying.QueryModel;
using Shouldly;

namespace Relatable.UnitTests.Querying.QueryModel
{
  public class QueryBuilderTests
  {
    [Fact]
    public void Select_ShouldAddAllSelects()
    {
      // Arrange
      var queryBuilder = new QueryBuilder();

      // Act
      queryBuilder.Select("Id", "Name", "Description");

      // Assert
      queryBuilder.SelectClauses.Count.ShouldBe(3);
      queryBuilder.SelectClauses[0].ShouldBe("Id");
      queryBuilder.SelectClauses[1].ShouldBe("Name");
      queryBuilder.SelectClauses[2].ShouldBe("Description");
    }

    [Fact]
    public void From_ShouldSetFrom()
    {
      // Arrange
      var queryBuilder = new QueryBuilder();

      // Act
      queryBuilder.From("Entities");

      // Assert
      queryBuilder.FromClause.ShouldBe("Entities");
    }

    [Fact]
    public void From_ShouldThrow_WhenFromAlreadySet()
    {
      // Arrange
      var queryBuilder = new QueryBuilder();
      queryBuilder.From("Something");

      // Act/Assert
      Should.Throw<InvalidOperationException>(() => queryBuilder.From("Entities"));
    }

    [Fact]
    public void Join_ShouldAddJoin()
    {
      // Arrange
      var queryBuilder = new QueryBuilder();

      // Act
      queryBuilder.Join("LinkedEntities", "LinkedEntities.EntityId = Entity.Id", JoinType.Inner);

      // Assert
      queryBuilder.JoinClauses.Count.ShouldBe(1);
      var onlyJoin = queryBuilder.JoinClauses.Single();
      onlyJoin.Table.ShouldBe("LinkedEntities");
      onlyJoin.On.ShouldBe("LinkedEntities.EntityId = Entity.Id");
      onlyJoin.Type.ShouldBe(JoinType.Inner);
    }

    [Fact]
    public void Join_ShouldAddParameters_IfObjectParametersIncluded()
    {
      // Arrange
      var queryBuilder = new QueryBuilder();

      // Act
      queryBuilder.Join("LinkedEntities", "LinkedEntities.Id = @LinkedId", JoinType.Inner, new { LinkedId = 1 });

      // Assert
      queryBuilder.Parameters.Count.ShouldBe(1);
      var onlyParameter = queryBuilder.Parameters.Single();
      onlyParameter.Key.ShouldBe("@LinkedId");
      onlyParameter.Value.ShouldBe("1");
    }

    [Fact]
    public void Join_ShouldAddParameters_IfDictionaryParametersIncluded()
    {
      // Arrange
      var queryBuilder = new QueryBuilder();

      // Act
      queryBuilder.Join("LinkedEntities", "LinkedEntities.Id = @LinkedId", JoinType.Inner, new Dictionary<string, object> { { "LinkedId", 1 } });

      // Assert
      queryBuilder.Parameters.Count.ShouldBe(1);
      var onlyParameter = queryBuilder.Parameters.Single();
      onlyParameter.Key.ShouldBe("@LinkedId");
      onlyParameter.Value.ShouldBe("1");
    }

    [Fact]
    public void AddParamaters_ShouldAddParameters_ForObjectParameters()
    {
      // Arrange
      var queryBuilder = new QueryBuilder();

      // Act
      queryBuilder.AddParameters(new { LinkedId = 1 });

      // Assert
      queryBuilder.Parameters.Count.ShouldBe(1);
      var onlyParameter = queryBuilder.Parameters.Single();
      onlyParameter.Key.ShouldBe("@LinkedId");
      onlyParameter.Value.ShouldBe("1");
    }

    [Fact]
    public void AddParamaters_ShouldAddParameters_ForDictionaryParameters()
    {
      // Arrange
      var queryBuilder = new QueryBuilder();

      // Act
      queryBuilder.AddParameters(new Dictionary<string, object> { { "LinkedId", 1 } });

      // Assert
      queryBuilder.Parameters.Count.ShouldBe(1);
      var onlyParameter = queryBuilder.Parameters.Single();
      onlyParameter.Key.ShouldBe("@LinkedId");
      onlyParameter.Value.ShouldBe("1");
    }

    [Fact]
    public void AddParamaters_ShouldAddParameters_ForDictionaryParametersOfSpecificType()
    {
      // Arrange
      var queryBuilder = new QueryBuilder();

      // Act
      queryBuilder.AddParameters(new Dictionary<string, int> { { "LinkedId", 1 } });

      // Assert
      queryBuilder.Parameters.Count.ShouldBe(1);
      var onlyParameter = queryBuilder.Parameters.Single();
      onlyParameter.Key.ShouldBe("@LinkedId");
      onlyParameter.Value.ShouldBe("1");
    }
  }
}
