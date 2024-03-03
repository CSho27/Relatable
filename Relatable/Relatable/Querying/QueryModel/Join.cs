using Relatable.Abstractions.Querying.QueryModel;

namespace Relatable.Querying.QueryModel
{
  public class Join : IJoin
  {
    public JoinType Type { get; init; }
    public string Table { get; init; } = "";
    public string On { get; init; } = "";
  }
}
