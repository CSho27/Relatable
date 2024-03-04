using Relatable.Abstractions.Querying.QueryModel;
using Relatable.Configuration;
using System.Collections.Immutable;
using System.ComponentModel;

namespace Relatable.Querying.QueryModel
{
  public class QueryBuilder : IQueryModel
  {
    public string? FromClause { get; private set; }
    public List<string> SelectClauses { get; } = new List<string>();
    public List<IJoin> JoinClauses { get; } = new List<IJoin>();
    public List<string> WhereClauses { get; } = new List<string>();
    public List<IOrderBy> OrderByClauses { get; } = new List<IOrderBy>();
    public List<string> GroupByClauses { get; } = new List<string>();
    public Dictionary<string, string> Parameters { get; } = new Dictionary<string, string>();

    string? IQueryModel.From => FromClause;
    IEnumerable<string> IQueryModel.Selects => SelectClauses;
    IEnumerable<IJoin> IQueryModel.Joins => JoinClauses;
    IEnumerable<string> IQueryModel.WhereClauses => WhereClauses;
    IEnumerable<IOrderBy> IQueryModel.OrderByClauses => OrderByClauses;
    IEnumerable<string> IQueryModel.GroupByClauses => GroupByClauses;
    IImmutableDictionary<string, string> IQueryModel.Parameters => Parameters.ToImmutableDictionary();

    public QueryBuilder Select(params string[] selects)
    {
      SelectClauses.AddRange(selects);
      return this;
    }

    public QueryBuilder From(string from)
    {
      if (FromClause is not null)
        throw new InvalidOperationException("Query only can contain one from. Add fetch additional data, please use a join.");

      FromClause = from;
      return this;
    }

    public QueryBuilder InnerJoin(string table, string on) => Join(table, on, JoinType.Inner);
    public QueryBuilder LeftJoin(string table, string on) => Join(table, on, JoinType.Left);
    public QueryBuilder RightJoin(string table, string on) => Join(table, on, JoinType.Right);
    public QueryBuilder FullJoin(string table, string on) => Join(table, on, JoinType.Full);
    public QueryBuilder CrossJoin(string table, string on) => Join(table, on, JoinType.Cross);

    public QueryBuilder Join<TKey, TValue>(string table, string on, JoinType type, IDictionary<TKey, TValue> parameters)
    {
      var qm = AddParameters(parameters);
      return qm.Join(table, on, type);
    }

    public QueryBuilder Join(string table, string on, JoinType type, object parameters)
    {
      var qm = AddParameters(parameters);
      return qm.Join(table, on, type);
    }

    public QueryBuilder Join(string table, string on, JoinType type)
    {
      var join = new Join
      {
        Type = type,
        Table = table,
        On = on
      };
      JoinClauses.Add(join);
      return this;
    }

    public QueryBuilder Where(string where, object? parameters = null)
    {
      WhereClauses.Add(where);
      return parameters is not null
        ? AddParameters(parameters)
        : this;
    }

    public QueryBuilder Where<TKey, TValue>(string where, IDictionary<TKey, TValue>? parameters = null)
    {
      WhereClauses.Add(where);
      return parameters is not null
        ? AddParameters(parameters)
        : this;
    }

    public QueryBuilder OrderByDescending(string orderBy) => OrderBy(orderBy, ListSortDirection.Descending);
    public QueryBuilder OrderBy(string orderBy, ListSortDirection direction = ListSortDirection.Ascending)
    {
      OrderByClauses.Add(new OrderBy { OrderByValue = orderBy, SortDirection = direction });
      return this;
    }

    public QueryBuilder GroupBy(string groupBy)
    {
      GroupByClauses.Add(groupBy);
      return this;
    }

    public QueryBuilder AddParameters(object parameters)
    {
      foreach (var property in parameters.GetType().GetProperties())
        AddParameter(property.Name, property.GetValue(parameters));

      return this;
    }

    public QueryBuilder AddParameters<TKey, TValue>(IDictionary<TKey, TValue> parameters)
    {
      foreach (var parameter in parameters)
      {
        var key = parameter.Key?.ToString();
        if (key is null)
          throw new ArgumentException("Parameter key cannot resolve to null");

        AddParameter(key, parameter.Value);
      }

      return this;
    }

    public QueryBuilder AddParameter(string name, object? value)
    {
      Parameters.Add(ToParameterName(name), ToParameterValue(value));
      return this;
    }

    public override string ToString()
    {
      var interpreter = RelatableConfig.DefaultQueryInterpreter;
      if (interpreter is null)
        throw new Exception($"Could not find an interpreter to use. Please either configure one using {nameof(RelatableConfig)} or instantiate one to interpret this query");

      return interpreter.Interpret(this);
    }

    private string ToParameterName(string name)
    {
      return name.StartsWith("@")
        ? name
        : $"@{name}";
    }

    private string ToParameterValue(object? parameterValue)
    {
      if (parameterValue is null)
        return "NULL";
      if (parameterValue.GetType() == typeof(string))
        return $"'{parameterValue}'";

      return parameterValue.ToString()!;
    }
  }
}
