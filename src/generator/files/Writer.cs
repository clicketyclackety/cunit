using generator.units;

namespace generators.files;

internal sealed class Writer
{
    
    public void Write()
    {
        // TODO : Sort out Matrix Unit Solver
        var matrixUnits = UnitList.GetUnits();
        foreach(var unit in matrixUnits)
        {
            ClassGenerator generator = new ClassGenerator(unit);
            generator.Generate();
            File.WriteAllLines(generator.GetFilePath(), generator.GetLines());
        }
        
    }
    
}