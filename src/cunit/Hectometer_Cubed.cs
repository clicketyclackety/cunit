namespace cunits.files;

/// <summary>
/// Represents a Hectometer_Cubed Unit.
/// </summary>
public readonly struct Hectometer_Cubed : IEquatable<Hectometer_Cubed>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Hectometer_Cubed
	public Hectometer_Cubed(double value)
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
	public static implicit operator Hectometer_Cubed(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Hectometer_Cubed left, Hectometer_Cubed right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Hectometer_Cubed left, Hectometer_Cubed right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Hectometer_Cubed left, Hectometer_Cubed right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Hectometer_Cubed left, Hectometer_Cubed right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Hectometer_Cubed operator +(Hectometer_Cubed val) => val;
	///<inheritdoc/>
	public static Hectometer_Cubed operator -(Hectometer_Cubed val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Hectometer_Cubed left, Hectometer_Cubed right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Hectometer_Cubed left, Hectometer_Cubed right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Hectometer_Cubed left, Hectometer_Cubed right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Hectometer_Cubed left, Hectometer_Cubed right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Hectometer_Cubed with another Hectometer_Cubed for equality (no tolerance used)</summary>
	public static bool operator ==(Hectometer_Cubed left, Hectometer_Cubed right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Hectometer_Cubed with another Hectometer_Cubed for inequality (no tolerance used)</summary>
	public static bool operator !=(Hectometer_Cubed left, Hectometer_Cubed right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Hectometer_Cubed unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Hectometer_Cubed unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} M";

	#endregion


	#endregion

}


