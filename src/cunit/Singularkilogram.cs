namespace cunits.files;

/// <summary>
/// Represents a Singularkilogram Unit.
/// </summary>
public readonly struct Singularkilogram : IEquatable<Singularkilogram>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Singularkilogram
	public Singularkilogram(double value)
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
	public static implicit operator Singularkilogram(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Singularkilogram left, Singularkilogram right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Singularkilogram left, Singularkilogram right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Singularkilogram left, Singularkilogram right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Singularkilogram left, Singularkilogram right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Singularkilogram operator +(Singularkilogram val) => val;
	///<inheritdoc/>
	public static Singularkilogram operator -(Singularkilogram val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Singularkilogram left, Singularkilogram right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Singularkilogram left, Singularkilogram right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Singularkilogram left, Singularkilogram right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Singularkilogram left, Singularkilogram right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Singularkilogram with another Singularkilogram for equality (no tolerance used)</summary>
	public static bool operator ==(Singularkilogram left, Singularkilogram right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Singularkilogram with another Singularkilogram for inequality (no tolerance used)</summary>
	public static bool operator !=(Singularkilogram left, Singularkilogram right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Singularkilogram unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Singularkilogram unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} Kg";

	#endregion


	#endregion

}


