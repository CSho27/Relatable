using Relatable.Utilities;
using Shouldly;

namespace Relatable.UnitTests.Extensions
{
  public enum TestEnum { One }
  public class TestClass
  {
    public int FieldInt;
    public bool FieldBool;
    public TestEnum FieldEnum;
    public string FieldString;
    public TestClass FieldObject;

    public int? NullableFieldInt;
    public bool? NullableFieldBool;
    public TestEnum? NullableFieldEnum;
    public string? NullableFieldString;
    public TestClass? NullableFieldObject;

    public int PropertyInt { get; set; }
    public bool PropertyBool { get; set; }
    public TestEnum PropertyEnum { get; set; }
    public string PropertyString { get; set; }
    public TestClass PropertyObject { get; set; }

    public int? NullablePropertyInt { get; set; }
    public bool? NullablePropertyBool { get; set; }
    public TestEnum? NullablePropertyEnum { get; set; }
    public string? NullablePropertyString { get; set; }
    public TestClass? NullablePropertyObject { get; set; }

    public void TestFunction(
        int testInt,
        bool testBool,
        TestEnum testEnum,
        string testString,
        TestClass testClass
    )
    { }

    public void NullableTestFunction(
        int? testInt,
        bool? testBool,
        TestEnum? testEnum,
        string? testString,
        TestClass? testClass
    )
    { }
  }

  public class NullabilityExtensionTests
  {
    // Field
    [Fact]
    public void IsNullable_ReturnsFalse_ForIntField()
    {
      var field = typeof(TestClass).GetField(nameof(TestClass.FieldInt))!;
      var result = field.IsNullable();
      result.ShouldBeFalse();
    }

    [Fact]
    public void IsNullable_ReturnsFalse_ForBooleanField()
    {
      var field = typeof(TestClass).GetField(nameof(TestClass.FieldBool))!;
      var result = field.IsNullable();
      result.ShouldBeFalse();
    }

    [Fact]
    public void IsNullable_ReturnsFalse_ForEnumField()
    {
      var field = typeof(TestClass).GetField(nameof(TestClass.FieldEnum))!;
      var result = field.IsNullable();
      result.ShouldBeFalse();
    }

    [Fact]
    public void IsNullable_ReturnsFalse_ForStringField()
    {
      var field = typeof(TestClass).GetField(nameof(TestClass.FieldString))!;
      var result = field.IsNullable();
      result.ShouldBeFalse();
    }

    [Fact]
    public void IsNullable_ReturnsFalse_ForObjectField()
    {
      var field = typeof(TestClass).GetField(nameof(TestClass.FieldObject))!;
      var result = field.IsNullable();
      result.ShouldBeFalse();
    }

    [Fact]
    public void IsNullable_ReturnsTrue_ForNullableIntField()
    {
      var field = typeof(TestClass).GetField(nameof(TestClass.NullableFieldInt))!;
      var result = field.IsNullable();
      result.ShouldBeTrue();
    }

    [Fact]
    public void IsNullable_ReturnsTrue_ForNullableBooleanField()
    {
      var field = typeof(TestClass).GetField(nameof(TestClass.NullableFieldBool))!;
      var result = field.IsNullable();
      result.ShouldBeTrue();
    }

    [Fact]
    public void IsNullable_ReturnsTrue_ForNullableEnumField()
    {
      var field = typeof(TestClass).GetField(nameof(TestClass.NullableFieldEnum))!;
      var result = field.IsNullable();
      result.ShouldBeTrue();
    }

    [Fact]
    public void IsNullable_ReturnsTrue_ForNullableStringField()
    {
      var field = typeof(TestClass).GetField(nameof(TestClass.NullableFieldString))!;
      var result = field.IsNullable();
      result.ShouldBeTrue();
    }

    [Fact]
    public void IsNullable_ReturnsTrue_ForNullableObjectField()
    {
      var field = typeof(TestClass).GetField(nameof(TestClass.NullableFieldObject))!;
      var result = field.IsNullable();
      result.ShouldBeTrue();
    }

    // Property
    [Fact]
    public void IsNullable_ReturnsFalse_ForIntProperty()
    {
      var property = typeof(TestClass).GetProperty(nameof(TestClass.PropertyInt))!;
      var result = property.IsNullable();
      result.ShouldBeFalse();
    }

    [Fact]
    public void IsNullable_ReturnsFalse_ForBooleanProperty()
    {
      var property = typeof(TestClass).GetProperty(nameof(TestClass.PropertyBool))!;
      var result = property.IsNullable();
      result.ShouldBeFalse();
    }

    [Fact]
    public void IsNullable_ReturnsFalse_ForEnumProperty()
    {
      var property = typeof(TestClass).GetProperty(nameof(TestClass.PropertyEnum))!;
      var result = property.IsNullable();
      result.ShouldBeFalse();
    }

    [Fact]
    public void IsNullable_ReturnsFalse_ForStringProperty()
    {
      var property = typeof(TestClass).GetProperty(nameof(TestClass.PropertyString))!;
      var result = property.IsNullable();
      result.ShouldBeFalse();
    }

    [Fact]
    public void IsNullable_ReturnsFalse_ForObjectProperty()
    {
      var property = typeof(TestClass).GetProperty(nameof(TestClass.PropertyObject))!;
      var result = property.IsNullable();
      result.ShouldBeFalse();
    }

    [Fact]
    public void IsNullable_ReturnsTrue_ForNullableIntProperty()
    {
      var property = typeof(TestClass).GetProperty(nameof(TestClass.NullablePropertyInt))!;
      var result = property.IsNullable();
      result.ShouldBeTrue();
    }

    [Fact]
    public void IsNullable_ReturnsTrue_ForNullableBooleanProperty()
    {
      var property = typeof(TestClass).GetProperty(nameof(TestClass.NullablePropertyBool))!;
      var result = property.IsNullable();
      result.ShouldBeTrue();
    }

    [Fact]
    public void IsNullable_ReturnsTrue_ForNullableEnumProperty()
    {
      var property = typeof(TestClass).GetProperty(nameof(TestClass.NullablePropertyEnum))!;
      var result = property.IsNullable();
      result.ShouldBeTrue();
    }

    [Fact]
    public void IsNullable_ReturnsTrue_ForNullableStringProperty()
    {
      var property = typeof(TestClass).GetProperty(nameof(TestClass.NullablePropertyString))!;
      var result = property.IsNullable();
      result.ShouldBeTrue();
    }

    [Fact]
    public void IsNullable_ReturnsTrue_ForNullableObjectProperty()
    {
      var property = typeof(TestClass).GetProperty(nameof(TestClass.NullablePropertyObject))!;
      var result = property.IsNullable();
      result.ShouldBeTrue();
    }

    // Parameter
    [Fact]
    public void IsNullable_ReturnsFalse_ForIntParameter()
    {
      var method = typeof(TestClass).GetMethod(nameof(TestClass.TestFunction))!;
      var parameter = method.GetParameters().Single(p => p.Name == "testInt")!;
      var result = parameter.IsNullable();
      result.ShouldBeFalse();
    }

    [Fact]
    public void IsNullable_ReturnsFalse_ForBoolParameter()
    {
      var method = typeof(TestClass).GetMethod(nameof(TestClass.TestFunction))!;
      var parameter = method.GetParameters().Single(p => p.Name == "testBool")!;
      var result = parameter.IsNullable();
      result.ShouldBeFalse();
    }

    [Fact]
    public void IsNullable_ReturnsFalse_ForEnumParameter()
    {
      var method = typeof(TestClass).GetMethod(nameof(TestClass.TestFunction))!;
      var parameter = method.GetParameters().Single(p => p.Name == "testEnum")!;
      var result = parameter.IsNullable();
      result.ShouldBeFalse();
    }

    [Fact]
    public void IsNullable_ReturnsFalse_ForStringParameter()
    {
      var method = typeof(TestClass).GetMethod(nameof(TestClass.TestFunction))!;
      var parameter = method.GetParameters().Single(p => p.Name == "testString")!;
      var result = parameter.IsNullable();
      result.ShouldBeFalse();
    }

    [Fact]
    public void IsNullable_ReturnsFalse_ForObjectParameter()
    {
      var method = typeof(TestClass).GetMethod(nameof(TestClass.TestFunction))!;
      var parameter = method.GetParameters().Single(p => p.Name == "testClass")!;
      var result = parameter.IsNullable();
      result.ShouldBeFalse();
    }

    [Fact]
    public void IsNullable_ReturnsTrue_ForNullableIntParameter()
    {
      var method = typeof(TestClass).GetMethod(nameof(TestClass.NullableTestFunction))!;
      var parameter = method.GetParameters().Single(p => p.Name == "testInt")!;
      var result = parameter.IsNullable();
      result.ShouldBeTrue();
    }

    [Fact]
    public void IsNullable_ReturnsTrue_ForNullableBoolParameter()
    {
      var method = typeof(TestClass).GetMethod(nameof(TestClass.NullableTestFunction))!;
      var parameter = method.GetParameters().Single(p => p.Name == "testBool")!;
      var result = parameter.IsNullable();
      result.ShouldBeTrue();
    }

    [Fact]
    public void IsNullable_ReturnsTrue_ForNullableEnumParameter()
    {
      var method = typeof(TestClass).GetMethod(nameof(TestClass.NullableTestFunction))!;
      var parameter = method.GetParameters().Single(p => p.Name == "testEnum")!;
      var result = parameter.IsNullable();
      result.ShouldBeTrue();
    }

    [Fact]
    public void IsNullable_ReturnsTrue_ForNullableStringParameter()
    {
      var method = typeof(TestClass).GetMethod(nameof(TestClass.NullableTestFunction))!;
      var parameter = method.GetParameters().Single(p => p.Name == "testString")!;
      var result = parameter.IsNullable();
      result.ShouldBeTrue();
    }

    [Fact]
    public void IsNullable_ReturnsTrue_ForNullableObjectParameter()
    {
      var method = typeof(TestClass).GetMethod(nameof(TestClass.NullableTestFunction))!;
      var parameter = method.GetParameters().Single(p => p.Name == "testClass")!;
      var result = parameter.IsNullable();
      result.ShouldBeTrue();
    }
  }
}