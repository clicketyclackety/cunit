namespace generators;

public interface IOperator
{
    
}

public struct ImplicitOperator : IOperator
{
    public readonly string ReturnValueType;
    public readonly string InputValueType;
    public readonly string DifferenceValue;

    public ImplicitOperator(string returnValueType,
        string inputValueType,
        string differenceValue)
    {
        ReturnValueType = returnValueType;
        InputValueType = inputValueType;
        DifferenceValue = differenceValue;
    }
}

public struct Operator : IOperator
{
    public readonly string Calculator;
    public readonly string ReturnType;
    public readonly string LeftType;
    public readonly string RightType;
}

public static class OperatorType
{
    public const string DIVIDE = "/";
}