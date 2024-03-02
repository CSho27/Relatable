namespace Relatable.IntegrationTests.Utilities
{
  public static class FileSystemUtilities
  {
    public static string? GetProjectRootDirectory()
    {
      var workingDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());
      return GetProjectRoot(workingDirectory)?.FullName;
    }

    private static DirectoryInfo? GetProjectRoot(DirectoryInfo directory)
    {
      if (directory.GetFiles().Any(d => d.Name.EndsWith(".csproj")))
        return directory;
      if (directory.Parent is null)
        return null;

      return GetProjectRoot(directory.Parent);
    }
  }
}
