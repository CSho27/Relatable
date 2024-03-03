using System.ComponentModel;

namespace Relatable.Abstractions.Querying.QueryModel
{
  public interface IOrderBy
  {
    public string OrderBy { get; }
    public ListSortDirection SortDirection { get; }
  }
}
