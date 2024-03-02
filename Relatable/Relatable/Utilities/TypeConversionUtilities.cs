
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
        return Convert.ToSByte(value);
      if (underlyingType == typeof(byte))
        return Convert.ToByte(value);
      if (underlyingType == typeof(bool))
        return Convert.ToBoolean(value);
      if (underlyingType == typeof(short))
        return Convert.ToInt16(value);
      if (underlyingType == typeof(ushort))
        return Convert.ToUInt16(value);
      if (underlyingType == typeof(int))
        return Convert.ToInt32(value);
      if (underlyingType == typeof(uint))
        return Convert.ToUInt32(value);
      if (underlyingType == typeof(long))
        return Convert.ToInt64(value);
      if (underlyingType == typeof(ulong))
        return Convert.ToUInt64(value);
      if (underlyingType == typeof(float))
        return Convert.ToSingle(value);
      if (underlyingType == typeof(double))
        return Convert.ToDouble(value);
      if (underlyingType == typeof(decimal))
        return Convert.ToDecimal(value);

      throw new ArgumentException($"Unsupported type {underlyingType.Name}");
    }
  }
}
