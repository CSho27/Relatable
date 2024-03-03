using Relatable.Abstractions.Querying.QueryModel;
using System.ComponentModel;

namespace Relatable.Querying.QueryModel
{
  public class OrderBy : IOrderBy
  {
    public string OrderByValue { get; init; } = "";
    string IOrderBy.OrderBy => OrderByValue;
    public ListSortDirection SortDirection { get; init; }
  }
}
