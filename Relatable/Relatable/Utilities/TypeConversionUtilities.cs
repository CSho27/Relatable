
namespace Relatable.Utilities
{
  public static class TypeConversionUtilities
  {
    public static T ConvertValue<T>(this object? value)
    {

      return value is null
        ? default!
        : (T)ConvertValueType(value, typeof(T))!;
    }

    private static object? ConvertValueType(object? value, Type type)
    {
      var isNullable = type.IsNullableValueType();
      var underlyingType = isNullable
        ? Nullable.GetUnderlyingType(type)!
        : type;


      if(underlyingType.IsEnum)
      {
        var values = Enum.GetValues(underlyingType).Cast<object>();
        return values.Single(v => (int)v == (int)value!);
      }
      if (underlyingType == typeof(sbyte))
      {
        var convertedValue = Convert.ToSByte(value);
        return isNullable
          ? new sbyte?(convertedValue)
          : convertedValue;
      }
      if (underlyingType == typeof(byte))
      {
        var convertedValue = Convert.ToByte(value);
        return isNullable
          ? new byte?(convertedValue)
          : convertedValue;
      }
      if (underlyingType == typeof(bool))
      {
        var convertedValue = Convert.ToBoolean(value);
        return isNullable
          ? new bool?(convertedValue)
          : convertedValue;
      }
      if (underlyingType == typeof(short))
      {
        var convertedValue = Convert.ToInt16(value);
        return isNullable
          ? new short?(convertedValue)
          : convertedValue;
      }
      if (underlyingType == typeof(ushort))
      {
        var convertedValue = Convert.ToUInt16(value);
        return isNullable
          ? new ushort?(convertedValue)
          : convertedValue;
      }
      if (underlyingType == typeof(int))
      {
        var convertedValue = Convert.ToInt32(value);
        return isNullable
          ? new int?(convertedValue)
          : convertedValue;
      }
      if (underlyingType == typeof(uint))
      {
        var convertedValue = Convert.ToUInt32(value);
        return isNullable
          ? new uint?(convertedValue)
          : convertedValue;
      }
      if (underlyingType == typeof(long))
      {
        var convertedValue = Convert.ToInt64(value);
        return isNullable
          ? new long?(convertedValue)
          : convertedValue;
      }
      if (underlyingType == typeof(ulong))
      {
        var convertedValue = Convert.ToUInt64(value);
        return isNullable
          ? new ulong?(convertedValue)
          : convertedValue;
      }
      if (underlyingType == typeof(float))
      {
        var convertedValue = Convert.ToSingle(value);
        return isNullable
          ? new float?(convertedValue)
          : convertedValue;
      }
      if (underlyingType == typeof(double))
      {
        var convertedValue = Convert.ToDouble(value);
        return isNullable
          ? new double?(convertedValue)
          : convertedValue;
      }
      if (underlyingType == typeof(decimal))
      {
        var convertedValue = Convert.ToDecimal(value);
        return isNullable
          ? new decimal?(convertedValue)
          : convertedValue;
      }

      throw new ArgumentException($"Unsupported type {underlyingType.Name}");
    }
  }
}
