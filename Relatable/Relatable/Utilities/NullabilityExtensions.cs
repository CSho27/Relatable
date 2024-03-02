using System.Reflection;

namespace Relatable.Utilities
{
  public static class NullabilityExtensions
  {
    public static bool IsNullableValueType(this Type type)
    {
      if (type.IsValueType)
        return Nullable.GetUnderlyingType(type) != null;
      return false;
    }

    public static bool IsNullable(this PropertyInfo property)
    {
      if (property.PropertyType.IsNullableValueType())
        return true;
      var nullabilityInfo = new NullabilityInfoContext().Create(property);
      return nullabilityInfo.WriteState is NullabilityState.Nullable;
    }

    public static bool IsNullable(this FieldInfo field)
    {
      if (field.FieldType.IsNullableValueType())
        return true;
      var nullabilityInfo = new NullabilityInfoContext().Create(field);
      return nullabilityInfo.WriteState is NullabilityState.Nullable;
    }

    public static bool IsNullable(this ParameterInfo parameter)
    {
      if (parameter.ParameterType.IsNullableValueType())
        return true;
      var nullabilityInfo = new NullabilityInfoContext().Create(parameter);
      return nullabilityInfo.WriteState is NullabilityState.Nullable;
    }
  }
}
