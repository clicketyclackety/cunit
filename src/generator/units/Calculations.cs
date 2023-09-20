using System.Text.RegularExpressions;
using generators.foundations;

namespace generator.units;

public static class Calculations
{

    public static string GetFullCalculation(UnitList.UnitDescription unit)
    {
        var result = unit.Calculation;
        result = result.Replace("<v>", "value");
        if (unit.Dimensions?.Length >= 1)
        {
            for (int i = 0; i < unit.Dimensions.Length; i++)
            {
                var positionalUnit = UnitList.GetUnit(unit.Dimensions[i]);
                var parameterName = Generics.GetParam(i);
                result = result.Replace($"<{i}>", positionalUnit.Name);
            }
        }

        return result;
    }

    public static string GetCalcuation(UnitList.UnitDescription left, UnitList.UnitDescription right)
    {
        return
            $"{left.Calculation.Replace("<v>", "value.Value")} / {right.Calculation.Replace("<v>", "value.Value")}";
    }
    
    public static string CombineCalcuationAndDimensions(UnitList.UnitDescription unit)
    {
        if (unit.Dimensions is null)
            return unit.Formula;
        
        string upperCalc = unit.Formula.ToUpperInvariant();
        for (int i = 0; i < unit.Dimensions.Length; i++)
        {
            string upperGeneric = Generics.Names[i].ToUpperInvariant();
            string doubleGeneric = $"{upperGeneric}{upperGeneric}";
            upperCalc = upperCalc.Replace(doubleGeneric, unit.Dimensions[i]);
        }

        return upperCalc;
    }

    public static int[] GetCalucationIndicies(string formula)
    {
        var reg = new Regex(@"<([\d])>");
        var matches = reg.Matches(formula);
        return matches.Select(m => int.Parse(m.Groups[1].Value)).ToArray();
    }
    
}