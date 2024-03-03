namespace Relatable.Abstractions.Querying.QueryModel
{
  public interface IJoin
  {
    JoinType Type { get; }
    string Table { get; }
    string On { get; }
  }
}
