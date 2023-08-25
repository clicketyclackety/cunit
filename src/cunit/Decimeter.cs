namespace cunits.files;

/// <summary>
/// Represents a Decimeter Unit.
/// </summary>
public readonly struct Decimeter : IEquatable<Decimeter>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Decimeter
	public Decimeter(double value)
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
	public static implicit operator Decimeter(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Decimeter left, Decimeter right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Decimeter left, Decimeter right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Decimeter left, Decimeter right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Decimeter left, Decimeter right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Decimeter operator +(Decimeter val) => val;
	///<inheritdoc/>
	public static Decimeter operator -(Decimeter val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Decimeter left, Decimeter right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Decimeter left, Decimeter right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Decimeter left, Decimeter right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Decimeter left, Decimeter right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Decimeter with another Decimeter for equality (no tolerance used)</summary>
	public static bool operator ==(Decimeter left, Decimeter right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Decimeter with another Decimeter for inequality (no tolerance used)</summary>
	public static bool operator !=(Decimeter left, Decimeter right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Decimeter unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Decimeter unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} M";

	#endregion


	#endregion

}


