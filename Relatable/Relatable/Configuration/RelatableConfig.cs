using Relatable.Abstractions.Querying;

namespace Relatable.Configuration
{
  public static class RelatableConfig
  {
    public static IQueryInterpreter? DefaultQueryInterpreter { get; private set; }

    public static void Initialize(RelatableConfiguration config)
    {
      DefaultQueryInterpreter = config.DefaultQueryInterpreter;
    }

    public static void SetDefaultQueryInterpreter(IQueryInterpreter queryInterpreter)
    {
      DefaultQueryInterpreter = queryInterpreter;
    }


  }

  public class RelatableConfiguration
  {
    public IQueryInterpreter? DefaultQueryInterpreter { get; set; }
  }
}
