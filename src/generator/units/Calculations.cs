using generators.foundations;

namespace generator.units;

public static class Calculations
{
    public static string GetCalcuation(UnitList.UnitDescription left, UnitList.UnitDescription right)
    {
        return
            $"{left.Calculation.Replace("value", "value.Value")} / {right.Calculation.Replace("value", "value.Value")}";
    }
    
    public static string CombineCalcuationAndDimensions(UnitList.UnitDescription unit)
    {
        if (unit.Dimensions is null)
            return unit.Calculation;
        
        string upperCalc = unit.Calculation.ToUpperInvariant();
        for (int i = 0; i < unit.Dimensions.Length; i++)
        {
            string upperGeneric = Generics.Names[i].ToUpperInvariant();
            string doubleGeneric = $"{upperGeneric}{upperGeneric}";
            upperCalc = upperCalc.Replace(doubleGeneric, unit.Dimensions[i]);
        }

        return upperCalc;
    }
}