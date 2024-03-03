using NSubstitute;
using Relatable.Execution;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

  public class DataReaderExtensionTests
  {
    [Fact]
    public void ConstructRow_CorrectlyConstructsEntity()
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
      mockDataReader.GetName(0).Returns("Id");

      mockDataReader[1].Returns("Test");
      mockDataReader.GetName(1).Returns("Name");

      mockDataReader[2].Returns("Test description");
      mockDataReader.GetName(2).Returns("Description");

      mockDataReader[3].Returns(dateTime);
      mockDataReader.GetName(3).Returns("CreatedOn");

      mockDataReader[4].Returns(dateOnly);
      mockDataReader.GetName(4).Returns("CreatedDate");

      mockDataReader[5].Returns(timeOnly);
      mockDataReader.GetName(5).Returns("CreatedTime");

      mockDataReader[6].Returns(guid);
      mockDataReader.GetName(6).Returns("TestGuid");

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
  }
}
