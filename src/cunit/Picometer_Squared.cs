namespace cunits.files;

/// <summary>
/// Represents a Picometer_Squared Unit.
/// </summary>
public readonly struct Picometer_Squared : IEquatable<Picometer_Squared>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Picometer_Squared
	public Picometer_Squared(double value)
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
	public static implicit operator Picometer_Squared(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Picometer_Squared left, Picometer_Squared right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Picometer_Squared left, Picometer_Squared right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Picometer_Squared left, Picometer_Squared right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Picometer_Squared left, Picometer_Squared right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Picometer_Squared operator +(Picometer_Squared val) => val;
	///<inheritdoc/>
	public static Picometer_Squared operator -(Picometer_Squared val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Picometer_Squared left, Picometer_Squared right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Picometer_Squared left, Picometer_Squared right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Picometer_Squared left, Picometer_Squared right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Picometer_Squared left, Picometer_Squared right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Picometer_Squared with another Picometer_Squared for equality (no tolerance used)</summary>
	public static bool operator ==(Picometer_Squared left, Picometer_Squared right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Picometer_Squared with another Picometer_Squared for inequality (no tolerance used)</summary>
	public static bool operator !=(Picometer_Squared left, Picometer_Squared right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Picometer_Squared unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Picometer_Squared unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} M";

	#endregion


	#endregion

}


