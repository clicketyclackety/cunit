namespace cunits.files;

/// <summary>
/// Represents a Millimeter_Cubed Unit.
/// </summary>
public readonly struct Millimeter_Cubed : IEquatable<Millimeter_Cubed>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Millimeter_Cubed
	public Millimeter_Cubed(double value)
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
	public static implicit operator Millimeter_Cubed(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Millimeter_Cubed left, Millimeter_Cubed right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Millimeter_Cubed left, Millimeter_Cubed right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Millimeter_Cubed left, Millimeter_Cubed right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Millimeter_Cubed left, Millimeter_Cubed right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Millimeter_Cubed operator +(Millimeter_Cubed val) => val;
	///<inheritdoc/>
	public static Millimeter_Cubed operator -(Millimeter_Cubed val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Millimeter_Cubed left, Millimeter_Cubed right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Millimeter_Cubed left, Millimeter_Cubed right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Millimeter_Cubed left, Millimeter_Cubed right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Millimeter_Cubed left, Millimeter_Cubed right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Millimeter_Cubed with another Millimeter_Cubed for equality (no tolerance used)</summary>
	public static bool operator ==(Millimeter_Cubed left, Millimeter_Cubed right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Millimeter_Cubed with another Millimeter_Cubed for inequality (no tolerance used)</summary>
	public static bool operator !=(Millimeter_Cubed left, Millimeter_Cubed right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Millimeter_Cubed unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Millimeter_Cubed unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} M";

	#endregion


	#endregion

}


