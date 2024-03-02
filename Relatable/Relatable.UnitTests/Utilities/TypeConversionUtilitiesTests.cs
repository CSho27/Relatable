using Relatable.Utilities;
using Shouldly;

namespace Relatable.UnitTests.Utilities
{
  public enum TestEnum { A, B, C }

  public class TypeConversionUtilitiesTests
  {
    [Fact]
    public void ConvertNonNullableValue_ConvertsToByte()
    {
      var x = new sbyte();
      var result = x.ConvertNonNullableValue<byte>();
      result.GetType().ShouldBe(typeof(byte));
    }

    [Fact]
    public void ConvertNonNullableValue_ConvertsToSByte()
    {
      var x = new byte();
      var result = x.ConvertNonNullableValue<sbyte>();
      result.GetType().ShouldBe(typeof(sbyte));
    }

    [Fact]
    public void ConvertNonNullableValue_ConvertsToBool()
    {
      var x = 1;
      var result = x.ConvertNonNullableValue<bool>();
      result.GetType().ShouldBe(typeof(bool));
    }

    [Fact]
    public void ConvertNonNullableValue_ConvertsToShort()
    {
      var x = 1;
      var result = x.ConvertNonNullableValue<short>();
      result.GetType().ShouldBe(typeof(short));
    }

    [Fact]
    public void ConvertNonNullableValue_ConvertsToUShort()
    {
      var x = 1;
      var result = x.ConvertNonNullableValue<ushort>();
      result.GetType().ShouldBe(typeof(ushort));
    }

    [Fact]
    public void ConvertNonNullableValue_ConvertsToInt()
    {
      var x = (long)1;
      var result = x.ConvertNonNullableValue<int>();
      result.GetType().ShouldBe(typeof(int));
    }

    [Fact]
    public void ConvertNonNullableValue_ConvertsToUInt()
    {
      var x = (long)1;
      var result = x.ConvertNonNullableValue<uint>();
      result.GetType().ShouldBe(typeof(uint));
    }

    [Fact]
    public void ConvertNonNullableValue_ConvertsToLong()
    {
      var x = 1;
      var result = x.ConvertNonNullableValue<long>();
      result.GetType().ShouldBe(typeof(long));
    }

    [Fact]
    public void ConvertNonNullableValue_ConvertsToULong()
    {
      var x = 1;
      var result = x.ConvertNonNullableValue<ulong>();
      result.GetType().ShouldBe(typeof(ulong));
    }

    [Fact]
    public void ConvertNonNullableValue_ConvertsToFloat()
    {
      var x = 1.1;
      var result = x.ConvertNonNullableValue<float>();
      result.GetType().ShouldBe(typeof(float));
    }

    [Fact]
    public void ConvertNonNullableValue_ConvertsToDouble()
    {
      var x = 1;
      var result = x.ConvertNonNullableValue<double>();
      result.GetType().ShouldBe(typeof(double));
    }

    [Fact]
    public void ConvertNonNullableValue_ConvertsToDecimal()
    {
      var x = 1;
      var result = x.ConvertNonNullableValue<decimal>();
      result.GetType().ShouldBe(typeof(decimal));
    }

    [Fact]
    public void ConvertNonNullableValue_ConvertsToEnum()
    {
      var x = 0;
      var result = x.ConvertNonNullableValue<TestEnum>();
      result.ShouldBe(TestEnum.A);
      result.GetType().ShouldBe(typeof(TestEnum));
    }
  }
}
