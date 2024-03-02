
namespace Relatable.Utilities
{
  public static class TypeConversionUtilities
  {
    public static T ConvertValue<T>(this object? value)
    {
      return value is null
        ? default!
        : (T)ConvertValueType(value, typeof(T));
    }

    private static object ConvertValueType(object value, Type type)
    {
      var isNullable = type.IsNullableValueType();
      var underlyingType = isNullable
        ? Nullable.GetUnderlyingType(type)!
        : type;


      if(underlyingType.IsEnum)
      {
        var values = Enum.GetValues(underlyingType).Cast<object>();
        return values.Single(v => (int)v == value.ConvertValue<int>());
      }

      if (underlyingType == typeof(DateOnly) && value.GetType() == typeof(DateTime))
      {
        var dateTime = (DateTime)value;
        return DateOnly.FromDateTime(dateTime);
      }

      if (underlyingType == typeof(TimeOnly) && value.GetType() == typeof(DateTime))
      {
        var dateTime = (DateTime)value;
        return TimeOnly.FromDateTime(dateTime);
      }
      if(underlyingType == typeof(TimeOnly) && value.GetType() == typeof(TimeSpan))
      {
        var dateTime = (TimeSpan)value;
        return TimeOnly.FromTimeSpan(dateTime);
      }

      if (underlyingType == typeof(TimeSpan) && value.GetType() == typeof(DateTime))
      {
        var dateTime = (DateTime)value;
        return dateTime.TimeOfDay;
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
      else return value;
    }
  }
}
