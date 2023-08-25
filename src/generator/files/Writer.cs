using System.Reflection;
using generator.units;
using generator.units.constants;
using generator.units.si;
using generators.units;

namespace generators.files;

internal sealed partial class Writer
{
    
    private static Dictionary<UnitType, IUnit> _unitLookup { get; set; }
    internal static Dictionary<UnitType, IUnit> UnitLookup
    {
        get
        {
            if (_unitLookup is null)
            {
                Assembly assembly = typeof(Meter).Assembly;
                var definedUnits = assembly.ExportedTypes.Where(t => t.IsAssignableTo(typeof(GeneratableUnit))).Where(t => !t.IsAbstract);
                var unitInstances = definedUnits.Select(du => (GeneratableUnit)Activator.CreateInstance(du));

                _unitLookup = unitInstances.ToDictionary(ui => ui.Type, ui => ui as IUnit);
            }

            return _unitLookup;
        }
    }
    
    public void Theory()
    {
        // -- Process
        Assembly assembly = typeof(Meter).Assembly;
        var definedUnits = assembly.ExportedTypes.Where(t => t.IsAssignableTo(typeof(GeneratableUnit))).Where(t => !t.IsAbstract);
        var unitInstances = definedUnits.Select(du => (GeneratableUnit)Activator.CreateInstance(du));

        IGeneratableUnit[] units = unitInstances.ToArray();
        FieldInfo[] multipliers = GetConstants(typeof(BaseTenPrefixes)).ToArray();
        
        List<GeneratedUnit> SolvedUnitSet = new();
        
        foreach (var unit in units)
        {
            
            foreach(var multiplier in multipliers)
            {
                foreach (UnitType[] compatibleDimensionSet in unit.CompatibleDimensions)
                {
                    IUnit[] unitSet = compatibleDimensionSet.Select(c => UnitLookup[c]).ToArray();
                    GeneratedUnit generated = new GeneratedUnit(unit, multiplier, unitSet);

                    ClassGenerator generator = new ClassGenerator(generated);
                    generator.Generate();
                    var lines = generator.GetLines();
                    
                    File.WriteAllLines(generated.FilePath, lines);
                    
                    // SolvedUnitSet.Add(solved);
                }
            }
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