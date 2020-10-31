using System.IO;

namespace SqlBackend.Utils
{
  public static class ScriptsUtils
  {
    public static string GetSqlScript(string scriptPath)
    {
      string filePath = System.IO.Path.GetFullPath($"Scripts\\{scriptPath}");
      FileInfo file = new FileInfo(filePath);
      string script = file.OpenText().ReadToEnd();

      return script;
    }
  }
}