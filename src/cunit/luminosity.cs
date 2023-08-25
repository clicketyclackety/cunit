namespace cunits.files;

/// <summary>
/// Represents a luminosity Unit.
/// </summary>
public readonly struct luminosity : IEquatable<luminosity>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a luminosity
	public luminosity(double value)
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
	public static implicit operator luminosity(double value) => new luminosity(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(luminosity left, luminosity right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(luminosity left, luminosity right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(luminosity left, luminosity right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(luminosity left, luminosity right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static luminosity operator +(luminosity val) => val;
	///<inheritdoc/>
	public static luminosity operator -(luminosity val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(luminosity left, luminosity right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(luminosity left, luminosity right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(luminosity left, luminosity right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(luminosity left, luminosity right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this luminosity with another luminosity for equality (no tolerance used)</summary>
	public static bool operator ==(luminosity left, luminosity right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this luminosity with another luminosity for inequality (no tolerance used)</summary>
	public static bool operator !=(luminosity left, luminosity right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is luminosity unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(luminosity unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} cd";

	#endregion


	#endregion

}


