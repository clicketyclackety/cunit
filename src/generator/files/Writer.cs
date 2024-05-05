using generator;
using generator.files;
using generator.units;

namespace generators.files;

internal sealed class Writer
{
    
    public void Write()
    {
        var csproj = new CsProj();
        WriteFile(csproj);
        
        var matrixUnits = UnitList.GetUnits();
        foreach(var unit in matrixUnits)
        {
            WriteFile(unit);
        }
        
        var serializer = new UniversalSerializer();
        WriteFile(serializer);

        var constants = new ConstantsFile();
        WriteFile(constants);

        var interfaceFile = new UnitInterfaceFile();
        WriteFile(interfaceFile);

        var unknownUnit = new UnknownUnit();
        WriteFile(unknownUnit);
    }

    private void WriteFile(IGenerateableFile generatable)
    {
        var directory = Path.GetDirectoryName(generatable.GetFilePath());
        if (!Directory.Exists(directory))
            Directory.CreateDirectory(directory);  
        
        File.WriteAllLines(generatable.GetFilePath(), generatable.Generate());
    }
    
}
