using NSubstitute;
using Relatable.Execution;
using Shouldly;
using System.Data;

namespace Relatable.UnitTests.Execution
{
  public class TestEntity
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateOnly CreatedDate { get; set; }
    public TimeOnly CreatedTime { get; set; }
    public Guid TestGuid { get; set; }
  }

  public class TestVisibility
  {
    public bool Public { get; set; }
    public bool Internal { get; internal set; }
    public bool Protected { get; protected set; }
    public bool ProtectedInternal { get; protected internal set; }
    public bool Private { get; private set; }
  }

    public class TestNoCtor
    {
      public int Id { get; }

      public TestNoCtor(int id)
      {
        Id = id;
      }
    }

    public class DataReaderExtensionTests
  {
    [Fact]
    public void ConstructRow_WithMatchingFieldOrder_CorrectlyConstructsEntity()
    {
      // Arrange
      var dateTime = DateTime.Now;
      var dateOnly = DateOnly.FromDateTime(dateTime);
      var timeOnly = TimeOnly.FromDateTime(dateTime);
      var guid = new Guid();

      var mockDataReader = Substitute.For<IDataReader>();
      mockDataReader.Read().Returns(true);
      mockDataReader.FieldCount.Returns(7);
      mockDataReader[0].Returns(1);
      mockDataReader.GetName(0).Returns(nameof(TestEntity.Id));

      mockDataReader[1].Returns("Test");
      mockDataReader.GetName(1).Returns(nameof(TestEntity.Name));

      mockDataReader[2].Returns("Test description");
      mockDataReader.GetName(2).Returns(nameof(TestEntity.Description));

      mockDataReader[3].Returns(dateTime);
      mockDataReader.GetName(3).Returns(nameof(TestEntity.CreatedOn));

      mockDataReader[4].Returns(dateOnly);
      mockDataReader.GetName(4).Returns(nameof(TestEntity.CreatedDate));

      mockDataReader[5].Returns(timeOnly);
      mockDataReader.GetName(5).Returns(nameof(TestEntity.CreatedTime));

      mockDataReader[6].Returns(guid);
      mockDataReader.GetName(6).Returns(nameof(TestEntity.TestGuid));

      // Act
      var row = mockDataReader.ConstructRow<TestEntity>();

      // Assert
      row.Id.ShouldBe(1);
      row.Name.ShouldBe("Test");
      row.Description.ShouldBe("Test description");
      row.CreatedOn.ShouldBe(dateTime);
      row.CreatedDate.ShouldBe(dateOnly);
      row.CreatedTime.ShouldBe(timeOnly);
      row.TestGuid.ShouldBe(guid);
    }

    [Fact]
    public void ConstructRow_WithArbitraryFieldOrder_ConstructsEntity()
    {
      // Arrange
      var dateTime = DateTime.Now;
      var dateOnly = DateOnly.FromDateTime(dateTime);
      var timeOnly = TimeOnly.FromDateTime(dateTime);
      var guid = new Guid();

      var mockDataReader = Substitute.For<IDataReader>();
      mockDataReader.Read().Returns(true);
      mockDataReader.FieldCount.Returns(7);

      mockDataReader[0].Returns("Test description");
      mockDataReader.GetName(0).Returns(nameof(TestEntity.Description));

      mockDataReader[1].Returns("Test");
      mockDataReader.GetName(1).Returns(nameof(TestEntity.Name));

      mockDataReader[2].Returns(1);
      mockDataReader.GetName(2).Returns(nameof(TestEntity.Id));

      mockDataReader[3].Returns(guid);
      mockDataReader.GetName(3).Returns(nameof(TestEntity.TestGuid));

      mockDataReader[4].Returns(timeOnly);
      mockDataReader.GetName(4).Returns(nameof(TestEntity.CreatedTime));

      mockDataReader[5].Returns(dateOnly);
      mockDataReader.GetName(5).Returns(nameof(TestEntity.CreatedDate));

      mockDataReader[6].Returns(dateTime);
      mockDataReader.GetName(6).Returns(nameof(TestEntity.CreatedOn));

      // Act
      var row = mockDataReader.ConstructRow<TestEntity>();

      // Assert
      row.Id.ShouldBe(1);
      row.Name.ShouldBe("Test");
      row.Description.ShouldBe("Test description");
      row.CreatedOn.ShouldBe(dateTime);
      row.CreatedDate.ShouldBe(dateOnly);
      row.CreatedTime.ShouldBe(timeOnly);
      row.TestGuid.ShouldBe(guid);
    }

    [Fact]
    public void ConstructRow_PopulatesAllPublicAndInternalSetters()
    {
      // Arrange
      var mockDataReader = Substitute.For<IDataReader>();
      mockDataReader.Read().Returns(true);
      mockDataReader.FieldCount.Returns(5);

      mockDataReader[0].Returns(true);
      mockDataReader.GetName(0).Returns(nameof(TestVisibility.Public));

      mockDataReader[1].Returns(true);
      mockDataReader.GetName(1).Returns(nameof(TestVisibility.Internal));

      mockDataReader[2].Returns(true);
      mockDataReader.GetName(2).Returns(nameof(TestVisibility.Protected));

      mockDataReader[3].Returns(true);
      mockDataReader.GetName(3).Returns(nameof(TestVisibility.ProtectedInternal));

      mockDataReader[4].Returns(true);
      mockDataReader.GetName(4).Returns(nameof(TestVisibility.Private));

      // Act
      var row = mockDataReader.ConstructRow<TestVisibility>();

      // Assert
      row.Public.ShouldBeTrue();
      row.Internal.ShouldBeTrue();
      row.Protected.ShouldBeTrue();
      row.ProtectedInternal.ShouldBeTrue();
      row.Private.ShouldBeTrue();
    }

    [Fact]
    public void ConstructRow_WhenTypeHasNoConstructor_Throws()
    {
      // Arrange
      var mockDataReader = Substitute.For<IDataReader>();
      mockDataReader.Read().Returns(true);
      mockDataReader.FieldCount.Returns(5);

      // Act/Assert
      Should.Throw<Exception>(mockDataReader.ConstructRow<TestNoCtor>);
    }
  }
}
