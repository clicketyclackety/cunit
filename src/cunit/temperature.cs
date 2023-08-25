namespace cunits.files;

/// <summary>
/// Represents a temperature Unit.
/// </summary>
public readonly struct temperature : IEquatable<temperature>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a temperature
	public temperature(double value)
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
	public static implicit operator temperature(double value) => new temperature(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(temperature left, temperature right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(temperature left, temperature right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(temperature left, temperature right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(temperature left, temperature right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static temperature operator +(temperature val) => val;
	///<inheritdoc/>
	public static temperature operator -(temperature val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(temperature left, temperature right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(temperature left, temperature right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(temperature left, temperature right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(temperature left, temperature right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this temperature with another temperature for equality (no tolerance used)</summary>
	public static bool operator ==(temperature left, temperature right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this temperature with another temperature for inequality (no tolerance used)</summary>
	public static bool operator !=(temperature left, temperature right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is temperature unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(temperature unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} K";

	#endregion


	#endregion

}


