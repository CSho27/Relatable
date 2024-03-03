using Relatable.Abstractions.Querying.QueryModel;

namespace Relatable.Abstractions.Querying
{
    public interface IQueryInterpreter
    {
        string Interpret(IQueryModel query);
    }
}
