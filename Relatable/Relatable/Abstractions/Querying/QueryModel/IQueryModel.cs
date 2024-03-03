using System.Collections.Immutable;

namespace Relatable.Abstractions.Querying.QueryModel
{
  public interface IQueryModel
  {
    IEnumerable<string> Selects { get; }
    string? From { get; }
    IEnumerable<IJoin> Joins { get; }
    IEnumerable<string> WhereClauses { get; }
    IEnumerable<IOrderBy> OrderByClauses { get; }
    IEnumerable<string> GroupByClauses { get; }
    IImmutableDictionary<string, string> Parameters { get; }
  }
}
