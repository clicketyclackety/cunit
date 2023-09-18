using System.Reflection;
using generator.units;
using generators.units;

namespace generators.files;

internal sealed partial class Writer
{
    
    public void Theory()
    {
        // TODO : Sort out Matrix Unit Solver
        var matrixUnits = UnitList.GetUnits();
        foreach(var unit in matrixUnits)
        {
            ClassGenerator generator = new ClassGenerator(unit);
            generator.Generate();
            File.WriteAllLines(generator.GetFilePath(), generator.GetLines());
        }

        ;

        // A Unit is defined by it's
        // Unit Dimensions (which units is it made of?)
        // Multipliers

        // To Define
        // Unit
        // Multipliers
        // Alternative Units (which are a _kind_ of multiplier
        // Default = 1
        // 7 Standard Units

        // Dimensions ( x compatible)
        // How many dimensions are valid?
        // Multipliers
        // Cross

        // To Generate within each class
        // Operators
        // * / - + == != etc.
        // implicit conversion
        // convert to double
        // convert to tuples

        // Constructors
        // Defu
        // Get Hash
        // DocStrings
        // ToString
        // ToSI method (Make this an interface?)

        // Also! 
        // Define the central unit type, double/decimal etc.
    }
    
    public void Write()
    {
        Theory();
    }

    internal static List<FieldInfo> GetConstants(Type type)
    {
        FieldInfo[] fieldInfos = type.GetFields(BindingFlags.Public |
                                                BindingFlags.Static | BindingFlags.FlattenHierarchy);

        return fieldInfos.Where(fi => fi.IsLiteral && !fi.IsInitOnly).ToList();
    }
    
}