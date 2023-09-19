using generators.foundations;

namespace generator.units;

public static class Utils
{
    
    public static IEnumerable<UnitList.UnitDescription> GetRelatedUnits(UnitList.UnitDescription unit)
    {
        if (unit.BaseUnit is null)
            yield break;
        
        foreach (var relatedUnit in UnitList.GetUnits())
        {
            if (relatedUnit.BaseUnit is null)
                continue;

            if (relatedUnit.Name == unit.Name)
                continue;

            if (relatedUnit.BaseUnit != unit.BaseUnit)
                continue;
            
            yield return relatedUnit;
        }
    }

    public static IEnumerable<(string left, string right)> GetUnitPairs(UnitList.UnitDescription unit)
    {
        var unitsByMaxDimensions = UnitList.GetUnits().Where(u => u.Dimensions is not null)
            .Where(u => u.Dimensions.Contains(unit.Name))
            // .Where(u => u.Dimensions.Length >= 2)
            .Where(u => u != unit)
            .OrderBy(u => u.Dimensions.Length);

        foreach (var mUnit in unitsByMaxDimensions)
        {
            if (mUnit.Dimensions.Length == 2)
                yield return (mUnit.Dimensions[0], mUnit.Dimensions[1]);

            var possibles = unitsByMaxDimensions
                .Where(u => u.Dimensions.Length < mUnit.Dimensions.Length)
                // .Where(u => mUnit.Calculation.Contains(u.Calculation))
                .Where(u => u.Dimensions.Except(mUnit.Dimensions).Count() == 1);

            foreach (var possible in possibles)
            {
                yield return (mUnit.Name, possible.Name);
            }
            
        }
        
    }
    
}