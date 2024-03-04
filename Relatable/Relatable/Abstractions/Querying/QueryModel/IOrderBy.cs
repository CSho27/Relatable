namespace Relatable.Abstractions.Querying.QueryModel
{
  public interface IOrderBy
  {
    public string OrderBy { get; }
    public SortDirection SortDirection { get; }
  }
}
