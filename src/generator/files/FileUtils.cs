using System.Reflection;
using generator.units;

namespace generator.files;

public class FileUtils
{
    public static string GetCunitBaseDirectory()
    {
        Assembly assembly = typeof(GUnit).Assembly;

        var dotnetDir = Path.GetDirectoryName(assembly.Location);
        var configurationDir = Path.GetDirectoryName(dotnetDir);
        var binDir = Path.GetDirectoryName(configurationDir);
        var generatorDir = Path.GetDirectoryName(binDir);
        var srcDir = Path.GetDirectoryName(generatorDir);

        return Path.Combine(srcDir, "cunit");
    }
}