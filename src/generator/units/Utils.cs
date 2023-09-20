using System.Text.RegularExpressions;
using generators.foundations;

namespace generator.units;

public static class Utils
{
    
    public static IEnumerable<UnitList.UnitDescription> GetRelatedUnits(UnitList.UnitDescription unit)
    {
        var units = UnitList.GetUnits();
        if (unit.BaseUnit is null)
        {
            units = units.Where(u => u.BaseUnit == unit);
        }
        else
        {
            yield return unit.BaseUnit;
        }
        
        foreach (var relatedUnit in units)
        {
            if (relatedUnit.BaseUnit is null)
                continue;

            if (relatedUnit == unit)
                continue;

            if (relatedUnit.BaseUnit != (unit.BaseUnit ?? unit))
                continue;
            
            yield return relatedUnit;
        }
    }

    public static IEnumerable<(string left, string right)> GetUnitPairsExhaustive(UnitList.UnitDescription unit)
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

    public static IEnumerable<(UnitList.UnitDescription left, UnitList.UnitDescription right)> GetUnitPairs2(
        UnitList.UnitDescription unit)
    {
        UnitList.UnitDescription leftUnit = null;
        UnitList.UnitDescription rightUnit = null;

        if (unit.Dimensions.Length == 2)
        {
            yield return (UnitList.GetUnit(unit.Dimensions[0]), UnitList.GetUnit(unit.Dimensions[1]));
            yield break;
        }
        
        foreach (var unitItem in UnitList.GetUnits())
        {
            var unitItemDims = unit.Dimensions ?? new [] { unit.Name };
            var except = unit.Dimensions.Except(unitItemDims).ToArray();
            if (except.Count() == 1)
                yield return (UnitList.GetUnit(except[0]), unitItem);
        }

        // yield return (leftUnit, rightUnit);
    }
    
    public static (UnitList.UnitDescription left, UnitList.UnitDescription right) ForceGetUnitPairs(
        UnitList.UnitDescription unit)
    {
        UnitList.UnitDescription leftUnit = null;
        UnitList.UnitDescription rightUnit = null;

        while (leftUnit is null && rightUnit is null)
        {
            foreach (var unitItem in UnitList.GetUnits())
            {
                if (unit == unitItem)
                    continue;
                
                if (!unit.Formula.Contains(unitItem.Formula))
                    continue;

                var replaced = unit.Formula.Replace(unitItem.Formula, "");

                var reg = new Regex(@"<[\d]>");
                var matches = reg.Matches(replaced);
                
                // TODO : or 2?
                if (matches.Count() == 1)
                {
                    leftUnit = unitItem;
                    var num = matches[0].Value.Replace("<", "").Replace(">", "");
                    int.TryParse(num, out int index);
                    rightUnit = UnitList.GetUnit(unit.Dimensions[index]);
                    break;
                }
                else
                {
                    // TODO : This section needs work
                    leftUnit = unitItem;
                }
            }
        }

        return (leftUnit, rightUnit);
    }

    public static IEnumerable<List<UnitList.UnitDescription>> GetBuildPieces(UnitList.UnitDescription unit)
    {
        if (unit.Dimensions is null)
        {
            yield return new List<UnitList.UnitDescription> { unit };
            yield break;
        }

        if (unit.Dimensions.Length == 2)
        {
            yield return new List<UnitList.UnitDescription>
            {
                UnitList.GetUnit(unit.Dimensions[0]),
                UnitList.GetUnit(unit.Dimensions[1]),
            };
            yield break;
        }

        // List<UnitList.UnitDescription> unitPieces = unit.Dimensions.Select(u => UnitList.GetUnit(u)).ToList();

        IEnumerable<UnitList.UnitDescription> embeddedUnits = GetPotentialEmbeddedUnits(unit);
        foreach (var potential in embeddedUnits)
        {
            string replaced = unit.Formula.Replace(potential.Formula, "");
            int[] indicies = Calculations.GetCalucationIndicies(replaced);
            if (indicies.Length != 1)
                continue;

            yield return new List<UnitList.UnitDescription> { potential, UnitList.GetUnit(unit.Dimensions.Last()) };
            yield break;
        }
        
    }

    public static IEnumerable<List<UnitList.UnitDescription>> GetBuildingSets(UnitList.UnitDescription unit)
    {
        var embedableUnits = GetPotentialEmbeddedableUnits(unit);
        foreach (var potential in embedableUnits)
        {
            if (potential.Dimensions is null)
                continue;
            
            if (!potential.Dimensions.Contains(unit.Name))
                continue;

            var pieces = GetBuildPieces(potential).FirstOrDefault();
            if (pieces is not null && pieces.Count > 1)
                yield return new List<UnitList.UnitDescription>()
                {
                    potential,
                    pieces.First(),
                    pieces.Last(),
                };
        }
    }

    private static IEnumerable<UnitList.UnitDescription> GetPotentialEmbeddedUnits(UnitList.UnitDescription unit)
    {
        foreach (var unitItem in UnitList.GetUnits())
        {
            if (unitItem.Dimensions is null || unitItem.Dimensions.Length < 2)
                continue;

            // TODO : Improve this check
            if (unit.Formula.Contains(unitItem.Formula))
                yield return unitItem;
        }
    }

    private static IEnumerable<UnitList.UnitDescription> GetPotentialEmbeddedableUnits(UnitList.UnitDescription unit)
    {
        foreach (var unitItem in UnitList.GetUnits())
        {
            // TODO : Improve this check
            if (unitItem.Formula.Contains(unit.Formula))
                yield return unitItem;
        }
    }
    
}