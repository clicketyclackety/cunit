using System.Text.RegularExpressions;
using generators.foundations;

namespace generator.units;

public static class Utils
{
    
    public static IEnumerable<GUnit> GetRelatedUnits(GUnit gUnit)
    {
        var units = UnitList.GetUnits();
        if (gUnit.BaseUnit is null)
        {
            units = units.Where(u => u.BaseUnit == gUnit);
        }
        else
        {
            yield return gUnit.BaseUnit;
        }
        
        foreach (var relatedUnit in units)
        {
            if (relatedUnit.BaseUnit is null)
                continue;

            if (relatedUnit == gUnit)
                continue;

            if (relatedUnit.BaseUnit != (gUnit.BaseUnit ?? gUnit))
                continue;
            
            yield return relatedUnit;
        }
    }

    public static IEnumerable<(string left, string right)> GetUnitPairsExhaustive(GUnit gUnit)
    {
        var unitsByMaxDimensions = UnitList.GetUnits().Where(u => u.Dimensions is not null)
            .Where(u => u.Dimensions.Contains(gUnit.Name))
            // .Where(u => u.Dimensions.Length >= 2)
            .Where(u => u != gUnit)
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

    public static IEnumerable<(GUnit left, GUnit right)> GetUnitPairs2(
        GUnit gUnit)
    {
        GUnit leftGUnit = null;
        GUnit rightGUnit = null;

        if (gUnit.Dimensions.Length == 2)
        {
            yield return (UnitList.GetUnit(gUnit.Dimensions[0]), UnitList.GetUnit(gUnit.Dimensions[1]));
            yield break;
        }
        
        foreach (var unitItem in UnitList.GetUnits())
        {
            var unitItemDims = gUnit.Dimensions ?? new [] { gUnit.Name };
            var except = gUnit.Dimensions.Except(unitItemDims).ToArray();
            if (except.Count() == 1)
                yield return (UnitList.GetUnit(except[0]), unitItem);
        }

        // yield return (leftUnit, rightUnit);
    }
    
    public static (GUnit left, GUnit right) ForceGetUnitPairs(
        GUnit gUnit)
    {
        GUnit leftGUnit = null;
        GUnit rightGUnit = null;

        while (leftGUnit is null && rightGUnit is null)
        {
            foreach (var unitItem in UnitList.GetUnits())
            {
                if (gUnit == unitItem)
                    continue;
                
                if (!gUnit.Formula.Contains(unitItem.Formula))
                    continue;

                var replaced = gUnit.Formula.Replace(unitItem.Formula, "");

                var reg = new Regex(@"<[\d]>");
                var matches = reg.Matches(replaced);
                
                // TODO : or 2?
                if (matches.Count() == 1)
                {
                    leftGUnit = unitItem;
                    var num = matches[0].Value.Replace("<", "").Replace(">", "");
                    int.TryParse(num, out int index);
                    rightGUnit = UnitList.GetUnit(gUnit.Dimensions[index]);
                    break;
                }
                else
                {
                    // TODO : This section needs work
                    leftGUnit = unitItem;
                }
            }
        }

        return (leftGUnit, rightGUnit);
    }

    public static IEnumerable<List<GUnit>> GetBuildPieces(GUnit gUnit)
    {
        if (gUnit.Dimensions is null)
        {
            yield return new List<GUnit> { gUnit };
            yield break;
        }

        if (gUnit.Dimensions.Length == 2)
        {
            yield return new List<GUnit>
            {
                UnitList.GetUnit(gUnit.Dimensions[0]),
                UnitList.GetUnit(gUnit.Dimensions[1]),
            };
            yield break;
        }

        // List<UnitList.UnitDescription> unitPieces = unit.Dimensions.Select(u => UnitList.GetUnit(u)).ToList();

        IEnumerable<GUnit> embeddedUnits = GetPotentialEmbeddedUnits(gUnit);
        foreach (var potential in embeddedUnits)
        {
            string replaced = gUnit.Formula.Replace(potential.Formula, "");
            int[] indicies = Calculations.GetCalucationIndicies(replaced);
            if (indicies.Length != 1)
                continue;

            yield return new List<GUnit> { potential, UnitList.GetUnit(gUnit.Dimensions.Last()) };
            yield break;
        }
        
    }

    public static IEnumerable<List<GUnit>> GetBuildingSets(GUnit gUnit)
    {
        var embedableUnits = GetPotentialEmbeddedableUnits(gUnit);
        foreach (var potential in embedableUnits)
        {
            if (potential.Dimensions is null)
                continue;
            
            if (!potential.Dimensions.Contains(gUnit.Name))
                continue;

            var pieces = GetBuildPieces(potential).FirstOrDefault();
            if (pieces is not null && pieces.Count > 1)
                yield return new List<GUnit>()
                {
                    potential,
                    pieces.First(),
                    pieces.Last(),
                };
        }
    }

    private static IEnumerable<GUnit> GetPotentialEmbeddedUnits(GUnit gUnit)
    {
        foreach (var unitItem in UnitList.GetUnits())
        {
            if (unitItem.Dimensions is null || unitItem.Dimensions.Length < 2)
                continue;

            // TODO : Improve this check
            if (gUnit.Formula.Contains(unitItem.Formula))
                yield return unitItem;
        }
    }

    private static IEnumerable<GUnit> GetPotentialEmbeddedableUnits(GUnit gUnit)
    {
        foreach (var unitItem in UnitList.GetUnits())
        {
            // TODO : Improve this check
            if (unitItem.Formula.Contains(gUnit.Formula))
                yield return unitItem;
        }
    }
    
}