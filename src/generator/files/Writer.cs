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
            File.WriteAllLines(unit.GetFilePath(), unit.Generate());

            var serializer = new GUnitSerializer(unit);
            File.WriteAllLines(serializer.GetFilePath(), serializer.Generate());
        }
        
    }
    
}