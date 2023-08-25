namespace cunits.files;

/// <summary>
/// Represents a Millimeter Unit.
/// </summary>
public readonly struct Millimeter : IEquatable<Millimeter>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Millimeter
	public Millimeter(double value)
	{
		Value = value;
	}

	#region Methods

	/// <summary>Converts a unit to SI</summary>
	public Meter ToSI() => (Meter)this;

	#endregion

	#region Operators

	#region Casting

	/// <summary>Converts a double into this Unit.</summary>
	public static implicit operator Millimeter(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Millimeter left, Millimeter right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Millimeter left, Millimeter right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Millimeter left, Millimeter right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Millimeter left, Millimeter right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Millimeter operator +(Millimeter val) => val;
	///<inheritdoc/>
	public static Millimeter operator -(Millimeter val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Millimeter left, Millimeter right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Millimeter left, Millimeter right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Millimeter left, Millimeter right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Millimeter left, Millimeter right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Millimeter with another Millimeter for equality (no tolerance used)</summary>
	public static bool operator ==(Millimeter left, Millimeter right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Millimeter with another Millimeter for inequality (no tolerance used)</summary>
	public static bool operator !=(Millimeter left, Millimeter right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Millimeter unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Millimeter unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} M";

	#endregion


	#endregion

}


