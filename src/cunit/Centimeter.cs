namespace cunits.files;

/// <summary>
/// Represents a Centimeter Unit.
/// </summary>
public readonly struct Centimeter : IEquatable<Centimeter>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Centimeter
	public Centimeter(double value)
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
	public static implicit operator Centimeter(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Centimeter left, Centimeter right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Centimeter left, Centimeter right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Centimeter left, Centimeter right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Centimeter left, Centimeter right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Centimeter operator +(Centimeter val) => val;
	///<inheritdoc/>
	public static Centimeter operator -(Centimeter val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Centimeter left, Centimeter right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Centimeter left, Centimeter right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Centimeter left, Centimeter right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Centimeter left, Centimeter right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Centimeter with another Centimeter for equality (no tolerance used)</summary>
	public static bool operator ==(Centimeter left, Centimeter right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Centimeter with another Centimeter for inequality (no tolerance used)</summary>
	public static bool operator !=(Centimeter left, Centimeter right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Centimeter unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Centimeter unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} M";

	#endregion


	#endregion

}


