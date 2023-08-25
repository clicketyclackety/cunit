namespace cunits.files;

/// <summary>
/// Represents a kilogram Unit.
/// </summary>
public readonly struct kilogram : IEquatable<kilogram>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a kilogram
	public kilogram(double value)
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
	public static implicit operator kilogram(double value) => new kilogram(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(kilogram left, kilogram right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(kilogram left, kilogram right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(kilogram left, kilogram right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(kilogram left, kilogram right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static kilogram operator +(kilogram val) => val;
	///<inheritdoc/>
	public static kilogram operator -(kilogram val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(kilogram left, kilogram right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(kilogram left, kilogram right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(kilogram left, kilogram right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(kilogram left, kilogram right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this kilogram with another kilogram for equality (no tolerance used)</summary>
	public static bool operator ==(kilogram left, kilogram right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this kilogram with another kilogram for inequality (no tolerance used)</summary>
	public static bool operator !=(kilogram left, kilogram right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is kilogram unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(kilogram unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} Kg";

	#endregion


	#endregion

}


