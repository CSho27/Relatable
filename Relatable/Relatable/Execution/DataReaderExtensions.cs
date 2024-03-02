using System.Data;
using System.Reflection;

namespace Relatable.Execution
{
  public static class DataReaderExtensions
  {
    public static IEnumerable<T> ReadAllRows<T>(this IDataReader reader)
    {
      return reader.ReadAllRows(typeof(T)).Cast<T>();
    }

    public static IEnumerable<object> ReadAllRows(this IDataReader reader, Type type)
    {
      var rows = new List<object>();
      while (reader.TryReadRow(type, out var row))
        rows.Add(row!);
      return rows;
    }

    public static bool TryReadRow<T>(this IDataReader reader, out T? row)
    {
      var result = TryReadRow(reader, typeof(T), out var readRow);
      row = (T?)readRow;
      return result;
    }

    public static bool TryReadRow(this IDataReader reader, Type returnType, out object? row)
    {
      var hasRow = reader.Read();
      if (!hasRow)
      {
        row = default;
        return false;
      }

      row = reader.ReadRow(returnType);
      return true;
    }

    public static T ReadRow<T>(this IDataReader reader)
    {
      var returnType = typeof(T);
      return (T)ReadRow(reader, returnType);
    }

    public static object ReadRow(this IDataReader reader, Type returnType)
    {
      var constructor = returnType.GetConstructor([]);
      // NOTE: It would be kind of nice if it didn't have to, but we'd have to figure out how to construct all the parameters by name
      if (constructor is null)
        throw new Exception("Return type must have a parameterless constructor");
      var returnObj = constructor.Invoke([]);
      for (var i = 0; i < reader.FieldCount; i++)
      {
        var fieldName = reader.GetName(i);
        var property = returnType.GetProperty(fieldName, BindingFlags.IgnoreCase);
        if (property is null)
          continue;

        property.SetValue(returnObj, reader[i]);
      }

      return returnObj;
    }
  }
}
