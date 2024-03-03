using Relatable.Utilities;
using System.Data;
using System.Data.Common;
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

    public static async Task<IEnumerable<T>> ReadAllRowsAsync<T>(this IDataReader reader)
    {
      var rows = await reader.ReadAllRowsAsync(typeof(T));
      return rows.Cast<T>();
    }

    public static async Task<IEnumerable<object>> ReadAllRowsAsync(this IDataReader reader, Type type)
    {
      var rows = new List<object>();
      var hasRow = true;
      while (hasRow)
      {
        (hasRow, var row) = await reader.TryReadRowAsync(type);
        if(hasRow)
          rows.Add(row!);
      }
      return rows;
    }

    public static bool TryReadRow<T>(this IDataReader reader, out T? row)
    {
      var result = reader.TryReadRow(typeof(T), out var readRow);
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

      row = reader.ConstructRow(returnType);
      return true;
    }

    public static async Task<(bool HasRow, T Row)> TryReadRowAsync<T>(this IDataReader reader)
    {
      var (hasRow, row) = await reader.TryReadRowAsync(typeof(T));
      return (hasRow, (T)row!);
    }

    public static async Task<(bool HasRow, object? Row)> TryReadRowAsync(this IDataReader reader, Type returnType)
    {
      if(reader is not DbDataReader asyncReader)
        throw new InvalidOperationException("Provided DataReader does not support reading async");

      var hasRow = await asyncReader.ReadAsync();
      if (!hasRow)
        return (false, default);

      return (true, asyncReader.ConstructRow(returnType));
    }

    public static T ConstructRow<T>(this IDataReader reader)
    {
      var returnType = typeof(T);
      return (T)reader.ConstructRow(returnType);
    }

    public static object ConstructRow(this IDataReader reader, Type returnType)
    {
      var returnObj = Activator.CreateInstance(returnType)!;
      if (returnObj is null)
        throw new Exception($"Failed to construct type {returnType}");

      for (var i = 0; i < reader.FieldCount; i++)
      {
        var fieldName = reader.GetName(i);
        var property = returnType.GetProperty(fieldName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        if (property is null)
          continue;

        property.SetValue(returnObj, reader[i].ConvertValue(property.PropertyType));
      }

      return returnObj;
    }
  }
}
