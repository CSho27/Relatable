namespace Relatable.IntegrationTests.Postgres.Execution.DbConnectionExtensions
{
  public class TestEntity
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateOnly CreatedDate { get; set; }
    public TimeOnly CreatedTime { get; set; }
    public Guid TestUUID { get; set; }
  }
}
