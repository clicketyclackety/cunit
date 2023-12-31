using System.Text.RegularExpressions;
using generators.foundations;

namespace generator.units;

public static class Calculations
{

    public static string GetFullCalculation(GUnit gUnit)
    {
        var result = gUnit.Calculation;
        result = result.Replace("<v>", "value");
        if (gUnit.Dimensions?.Length >= 1)
        {
            for (int i = 0; i < gUnit.Dimensions.Length; i++)
            {
                var positionalUnit = UnitList.GetUnit(gUnit.Dimensions[i]);
                var parameterName = Generics.GetParam(i);
                result = result.Replace($"<{i}>", positionalUnit.Name);
            }
        }

        return result;
    }

    public static string GetCalcuation(GUnit left, GUnit right)
    {
        return $"{FormatCalculation(left.Calculation)} / {FormatCalculation(right.Calculation)}";
    }
    
    public static string CombineCalcuationAndDimensions(GUnit gUnit)
    {
        if (gUnit.Dimensions is null)
            return gUnit.Formula;
        
        string upperCalc = gUnit.Formula.ToUpperInvariant();
        for (int i = 0; i < gUnit.Dimensions.Length; i++)
        {
            string upperGeneric = Generics.Names[i].ToUpperInvariant();
            string doubleGeneric = $"{upperGeneric}{upperGeneric}";
            upperCalc = upperCalc.Replace(doubleGeneric, gUnit.Dimensions[i]);
        }

        return upperCalc;
    }

    public static int[] GetCalucationIndicies(string formula)
    {
        var reg = new Regex(@"<([\d])>");
        var matches = reg.Matches(formula);
        return matches.Select(m => int.Parse(m.Groups[1].Value)).ToArray();
    }

    public static string InvertCalculation(string calculation)
    {
        return calculation
            .Replace("-", "NEG")
            .Replace("/", "DIV")
            .Replace("*", "/")
            .Replace("DIV", "*")
            .Replace("+", "-")
            .Replace("NEG", "+");
    }

    public static string FormatCalculation(string calcuation)
    {
        var calc = calcuation.Replace("<v>", "value")
            .Replace("<vV>", "value.Value");

        foreach (var generic in Generics.Names)
        {
            var g = generic.ToLowerInvariant();
            
            calc = calc.Replace($"<v{g}V>", $"value.{generic}Value.Value")
                .Replace($"<v{g}>", $"value.{generic}Value");
                // .Replace($"<v{g}C>", $"value.{generic}Value"); // TODO : Add casting support
        }

        return calc;
    }

}