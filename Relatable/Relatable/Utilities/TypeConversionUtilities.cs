namespace Relatable.Utilities
{
  public static class TypeConversionUtilities
  {
    public static T ConvertValue<T>(this object? value)
    {
      var type = typeof(T);
      var isTypeNullable = type.IsNullableValueType();
      if (value is null && !isTypeNullable)
        throw new ArgumentException("value was null but type T is not a nullable type");
      if (value is null)
        return default!;
      
      return ConvertNonNullableValue<T>(value);
    }

    public static T ConvertNonNullableValue<T>(this object value)
    {
      var type = typeof(T);
      if (type == typeof(sbyte))
        return (T)(object)Convert.ToSByte(value);
      if (type == typeof(byte))
        return (T)(object)Convert.ToByte(value);
      if (type == typeof(bool))
        return (T)(object)Convert.ToBoolean(value);
      if (type == typeof(short))
        return (T)(object)Convert.ToInt16(value);
      if (type == typeof(ushort))
        return (T)(object)Convert.ToUInt16(value);
      if (type == typeof(int))
        return (T)(object)Convert.ToInt32(value);
      if (type == typeof(uint))
        return (T)(object)Convert.ToUInt32(value);
      if (type == typeof(long))
        return (T)(object)Convert.ToInt64(value);
      if (type == typeof(ulong))
        return (T)(object)Convert.ToUInt64(value);
      if (type == typeof(float))
        return (T)(object)Convert.ToSingle(value);
      if (type == typeof(double))
        return (T)(object)Convert.ToDouble(value);
      if (type == typeof(decimal))
        return (T)(object)Convert.ToDecimal(value);
      if (type.IsEnum)
        return (T)value;

      throw new ArgumentException($"Unsupported type {type.Name}");
    }

  }
}
