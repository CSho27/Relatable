﻿using Relatable.Utilities;
using Shouldly;

namespace Relatable.UnitTests.Utilities
{
  public enum TestEnum { A, B, C }

  public class TypeConversionUtilitiesTests
  {
    // ConvertValue

    [Fact]
    public void ConvertValue_WhenNullAndTIsValueType_ReturnsDefault()
    {
      int? x = null;
      var result = x.ConvertValue<int>();
      result.ShouldBe(0);
    }

    [Fact]
    public void ConvertValue_WhenNullAndTIsNullableType_ReturnsNull()
    {
      int? x = null;
      var result = x.ConvertValue<int?>();
      result.ShouldBeNull();
    }

    [Fact]
    public void ConvertValue_ConvertsIntToEnum()
    {
      var x = 0;
      var result = x.ConvertValue<TestEnum>();
      result.ShouldBe(TestEnum.A);
      result.GetType().ShouldBe(typeof(TestEnum));
    }

    [Fact]
    public void ConvertValue_ConvertsIntToNullableEnum()
    {
      var x = 0;
      var result = x.ConvertValue<TestEnum?>();
      result.ShouldNotBeNull();
      result.ShouldBe(TestEnum.A);
      result.GetType().ShouldBe(typeof(TestEnum));
    }

    [Fact]
    public void ConvertValue_ConvertsNullToNullableEnum()
    {
      int? x = null;
      var result = x.ConvertValue<TestEnum?>();
      result.ShouldBeNull();
    }

    [Fact]
    public void ConvertValue_ConvertsStringToEnum()
    {
      var x = "C";
      var result = x.ConvertValue<TestEnum>();
      result.ShouldBe(TestEnum.C);
      result.GetType().ShouldBe(typeof(TestEnum));
    }

    [Fact]
    public void ConvertValue_ConvertsToDateTime()
    {
      var x = DateTime.Now;
      var result = x.ConvertValue<DateTime>();
      result.ShouldBe(x);
      result.GetType().ShouldBe(typeof(DateTime));
    }

    [Fact]
    public void ConvertValue_ConvertsToNullableDateTime()
    {
      var x = DateTime.Now;
      var result = x.ConvertValue<DateTime?>();
      result.ShouldNotBeNull();
      result.GetType().ShouldBe(typeof(DateTime));
    }

    [Fact]
    public void ConvertValue_ConvertsToDateOnly()
    {
      var x = DateTime.Now;
      var result = x.ConvertValue<DateOnly>();
      result.GetType().ShouldBe(typeof(DateOnly));
      result.ShouldBe(DateOnly.FromDateTime(x));
    }

    [Fact]
    public void ConvertValue_ConvertsToNullableDateOnly()
    {
      DateTime? x = DateTime.Now;
      var result = x.ConvertValue<DateOnly?>();
      result.ShouldNotBeNull();
      result.GetType().ShouldBe(typeof(DateOnly));
    }

    [Fact]
    public void ConvertValue_ConvertsDateTimeToTimeOnly()
    {
      var x = DateTime.Now;
      var result = x.ConvertValue<TimeOnly>();
      result.GetType().ShouldBe(typeof(TimeOnly));
      result.ShouldBe(TimeOnly.FromDateTime(x));
    }

    [Fact]
    public void ConvertValue_ConvertsDateTimeToNullableTimeOnly()
    {
      DateTime? x = DateTime.Now;
      var result = x.ConvertValue<TimeOnly?>();
      result.ShouldNotBeNull();
      result.GetType().ShouldBe(typeof(TimeOnly));
    }

    [Fact]
    public void ConvertValue_ConvertsTimeSpanToTimeOnly()
    {
      var x = DateTime.Now.TimeOfDay;
      var result = x.ConvertValue<TimeOnly>();
      result.GetType().ShouldBe(typeof(TimeOnly));
      result.ShouldBe(TimeOnly.FromTimeSpan(x));
    }

    [Fact]
    public void ConvertValue_ConvertsTimeSpanToNullableTimeOnly()
    {
      TimeSpan? x = DateTime.Now.TimeOfDay;
      var result = x.ConvertValue<TimeOnly?>();
      result.ShouldNotBeNull();
      result.GetType().ShouldBe(typeof(TimeOnly));
    }

    [Fact]
    public void ConvertValue_ConvertsToTimeSpan()
    {
      var x = DateTime.Now;
      var result = x.ConvertValue<TimeSpan>();
      result.GetType().ShouldBe(typeof(TimeSpan));
      result.ShouldBe(x.TimeOfDay);
    }

    [Fact]
    public void ConvertValue_ConvertsToNullableTimeSpan()
    {
      DateTime? x = DateTime.Now;
      var result = x.ConvertValue<TimeSpan?>();
      result.ShouldNotBeNull();
      result.GetType().ShouldBe(typeof(TimeSpan));
    }


    [Fact]
    public void ConvertValue_ConvertsToByte()
    {
      var x = new sbyte();
      var result = x.ConvertValue<byte>();
      result.GetType().ShouldBe(typeof(byte));
    }

    [Fact]
    public void ConvertValue_ConvertsToNullableByte()
    {
      var x = new sbyte();
      var result = x.ConvertValue<byte?>();
      result.ShouldNotBeNull();
      result.GetType().ShouldBe(typeof(byte));
    }

    [Fact]
    public void ConvertValue_ConvertsToSByte()
    {
      var x = new byte();
      var result = x.ConvertValue<sbyte>();
      result.GetType().ShouldBe(typeof(sbyte));
    }

    [Fact]
    public void ConvertValue_ConvertsToNullableSByte()
    {
      var x = new byte();
      var result = x.ConvertValue<sbyte?>();
      result.ShouldNotBeNull();
      result.GetType().ShouldBe(typeof(sbyte));
    }

    [Fact]
    public void ConvertValue_ConvertsToBool()
    {
      var x = 1;
      var result = x.ConvertValue<bool>();
      result.GetType().ShouldBe(typeof(bool));
    }

    [Fact]
    public void ConvertValue_ConvertsToNullableBool()
    {
      var x = 1;
      var result = x.ConvertValue<bool?>();
      result.ShouldNotBeNull();
      result.GetType().ShouldBe(typeof(bool));
    }

    [Fact]
    public void ConvertValue_ConvertsToShort()
    {
      var x = 1;
      var result = x.ConvertValue<short>();
      result.GetType().ShouldBe(typeof(short));
    }

    [Fact]
    public void ConvertValue_ConvertsToNullableShort()
    {
      var x = 1;
      var result = x.ConvertValue<short?>();
      result.ShouldNotBeNull();
      result.GetType().ShouldBe(typeof(short));
    }

    [Fact]
    public void ConvertValue_ConvertsToUShort()
    {
      var x = 1;
      var result = x.ConvertValue<ushort>();
      result.GetType().ShouldBe(typeof(ushort));
    }

    [Fact]
    public void ConvertValue_ConvertsToNullableUShort()
    {
      var x = 1;
      var result = x.ConvertValue<ushort?>();
      result.ShouldNotBeNull();
      result.GetType().ShouldBe(typeof(ushort));
    }

    [Fact]
    public void ConvertValue_ConvertsToInt()
    {
      var x = (long)1;
      var result = x.ConvertValue<int>();
      result.GetType().ShouldBe(typeof(int));
    }

    [Fact]
    public void ConvertValue_ConvertsToNullableInt()
    {
      var x = (long)1;
      var result = x.ConvertValue<int?>();
      result.ShouldNotBeNull();
      result.GetType().ShouldBe(typeof(int));
    }

    [Fact]
    public void ConvertValue_ConvertsToUInt()
    {
      var x = (long)1;
      var result = x.ConvertValue<uint>();
      result.GetType().ShouldBe(typeof(uint));
    }

    [Fact]
    public void ConvertValue_ConvertsToNullableUInt()
    {
      var x = (long)1;
      var result = x.ConvertValue<uint?>();
      result.ShouldNotBeNull();
      result.GetType().ShouldBe(typeof(uint));
    }

    [Fact]
    public void ConvertValue_ConvertsToLong()
    {
      var x = 1;
      var result = x.ConvertValue<long>();
      result.GetType().ShouldBe(typeof(long));
    }

    [Fact]
    public void ConvertValue_ConvertsToNullableLong()
    {
      var x = 1;
      var result = x.ConvertValue<long?>();
      result.ShouldNotBeNull();
      result.GetType().ShouldBe(typeof(long));
    }

    [Fact]
    public void ConvertValue_ConvertsToULong()
    {
      var x = 1;
      var result = x.ConvertValue<ulong>();
      result.GetType().ShouldBe(typeof(ulong));
    }

    [Fact]
    public void ConvertValue_ConvertsToNullableULong()
    {
      var x = 1;
      var result = x.ConvertValue<ulong?>();
      result.ShouldNotBeNull();
      result.GetType().ShouldBe(typeof(ulong));
    }

    [Fact]
    public void ConvertValue_ConvertsToFloat()
    {
      var x = 1.1;
      var result = x.ConvertValue<float>();
      result.GetType().ShouldBe(typeof(float));
    }

    [Fact]
    public void ConvertValue_ConvertsToNullableFloat()
    {
      var x = 1;
      var result = x.ConvertValue<float?>();
      result.ShouldNotBeNull();
      result.GetType().ShouldBe(typeof(float));
    }

    [Fact]
    public void ConvertValue_ConvertsToDouble()
    {
      var x = 1;
      var result = x.ConvertValue<double>();
      result.GetType().ShouldBe(typeof(double));
    }

    [Fact]
    public void ConvertValue_ConvertsToNullableDouble()
    {
      var x = 1;
      var result = x.ConvertValue<double?>();
      result.ShouldNotBeNull();
      result.GetType().ShouldBe(typeof(double));
    }

    [Fact]
    public void ConvertValue_ConvertsToDecimal()
    {
      var x = 1;
      var result = x.ConvertValue<decimal>();
      result.GetType().ShouldBe(typeof(decimal));
    }

    [Fact]
    public void ConvertValue_ConvertsToNullableDecimal()
    {
      var x = 1;
      var result = x.ConvertValue<decimal?>();
      result.ShouldNotBeNull();
      result.GetType().ShouldBe(typeof(decimal));
    }
  }
}
