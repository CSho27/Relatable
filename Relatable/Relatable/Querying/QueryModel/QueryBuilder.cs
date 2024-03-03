using Relatable.Abstractions.Querying.QueryModel;
using Relatable.Configuration;
using System.Collections.Immutable;
using System.ComponentModel;

namespace Relatable.Querying.QueryModel
{
  public class QueryBuilder : IQueryModel
  {
    private string? _from { get; set; }
    private List<string> _selects = new List<string>();
    private List<IJoin> _joins = new List<IJoin>();
    private List<string> _whereClauses = new List<string>();
    private List<IOrderBy> _orderByClauses = new List<IOrderBy>();
    private List<string> _groupByClauses = new List<string>();
    private Dictionary<string, string> _parameters = new Dictionary<string, string>();

    string? IQueryModel.From => _from;
    IEnumerable<string> IQueryModel.Selects => _selects;
    IEnumerable<IJoin> IQueryModel.Joins => _joins;
    IEnumerable<string> IQueryModel.WhereClauses => _whereClauses;
    IEnumerable<IOrderBy> IQueryModel.OrderByClauses => _orderByClauses;
    IEnumerable<string> IQueryModel.GroupByClauses => _groupByClauses;
    IImmutableDictionary<string, string> IQueryModel.Parameters => _parameters.ToImmutableDictionary();

    public QueryBuilder Select(params string[] selects)
    {
      _selects.AddRange(selects);
      return this;
    }

    public QueryBuilder From(string from)
    {
      _from = from;
      return this;
    }


    public QueryBuilder InnerJoin(string table, string on) => Join(table, on, JoinType.Inner);
    public QueryBuilder LeftJoin(string table, string on) => Join(table, on, JoinType.Left);
    public QueryBuilder RightJoin(string table, string on) => Join(table, on, JoinType.Right);
    public QueryBuilder FullJoin(string table, string on) => Join(table, on, JoinType.Full);
    public QueryBuilder CrossJoin(string table, string on) => Join(table, on, JoinType.Cross);

    public QueryBuilder Join(string table, string on, JoinType type, IDictionary<string, object> parameters)
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
      _joins.Add(join);
      return this;
    }

    public QueryBuilder Where(string where, object? parameters = null)
    {
      _whereClauses.Add(where);
      return parameters is not null
        ? AddParameters(parameters)
        : this;
    }

    public QueryBuilder Where(string where, IDictionary<string, object>? parameters = null)
    {
      _whereClauses.Add(where);
      return parameters is not null
        ? AddParameters(parameters)
        : this;
    }

    public QueryBuilder OrderByDescending(string orderBy) => OrderBy(orderBy, ListSortDirection.Descending);
    public QueryBuilder OrderBy(string orderBy, ListSortDirection direction = ListSortDirection.Ascending)
    {
      _orderByClauses.Add(new OrderBy { OrderByValue = orderBy, SortDirection = direction });
      return this;
    }

    public QueryBuilder GroupBy(string groupBy)
    {
      _groupByClauses.Add(groupBy);
      return this;
    }

    public QueryBuilder AddParameters(object parameters)
    {
      foreach (var property in parameters.GetType().GetProperties())
        _parameters.Add(ToParameterName(property.Name), ToParameterString(property.GetValue(parameters)));

      return this;
    }

    public QueryBuilder AddParameters(IDictionary<string, object> parameters)
    {
      foreach (var parameter in parameters)
        _parameters.Add(ToParameterName(parameter.Key), ToParameterString(parameter.Value));

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

    private string ToParameterString(object? parameterValue)
    {
      if (parameterValue is null)
        return "NULL";
      if (parameterValue.GetType() == typeof(string))
        return $"'{parameterValue}'";

      return parameterValue.ToString()!;
    }
  }
}
