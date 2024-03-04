using Relatable.Abstractions.Querying.QueryModel;

namespace Relatable.Querying.QueryModel
{
  public class OrderBy : IOrderBy
  {
    public string OrderByValue { get; init; } = "";
    string IOrderBy.OrderBy => OrderByValue;
    public SortDirection SortDirection { get; init; }
  }
}
