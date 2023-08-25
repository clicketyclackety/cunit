namespace cunits.files;

/// <summary>
/// Represents a Decameter_Cubed Unit.
/// </summary>
public readonly struct Decameter_Cubed : IEquatable<Decameter_Cubed>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Decameter_Cubed
	public Decameter_Cubed(double value)
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
	public static implicit operator Decameter_Cubed(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Decameter_Cubed left, Decameter_Cubed right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Decameter_Cubed left, Decameter_Cubed right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Decameter_Cubed left, Decameter_Cubed right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Decameter_Cubed left, Decameter_Cubed right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Decameter_Cubed operator +(Decameter_Cubed val) => val;
	///<inheritdoc/>
	public static Decameter_Cubed operator -(Decameter_Cubed val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Decameter_Cubed left, Decameter_Cubed right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Decameter_Cubed left, Decameter_Cubed right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Decameter_Cubed left, Decameter_Cubed right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Decameter_Cubed left, Decameter_Cubed right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Decameter_Cubed with another Decameter_Cubed for equality (no tolerance used)</summary>
	public static bool operator ==(Decameter_Cubed left, Decameter_Cubed right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Decameter_Cubed with another Decameter_Cubed for inequality (no tolerance used)</summary>
	public static bool operator !=(Decameter_Cubed left, Decameter_Cubed right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Decameter_Cubed unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Decameter_Cubed unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} M";

	#endregion


	#endregion

}


