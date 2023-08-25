namespace cunits.files;

/// <summary>
/// Represents a Gigakilogram Unit.
/// </summary>
public readonly struct Gigakilogram : IEquatable<Gigakilogram>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Gigakilogram
	public Gigakilogram(double value)
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
	public static implicit operator Gigakilogram(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Gigakilogram left, Gigakilogram right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Gigakilogram left, Gigakilogram right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Gigakilogram left, Gigakilogram right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Gigakilogram left, Gigakilogram right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Gigakilogram operator +(Gigakilogram val) => val;
	///<inheritdoc/>
	public static Gigakilogram operator -(Gigakilogram val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Gigakilogram left, Gigakilogram right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Gigakilogram left, Gigakilogram right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Gigakilogram left, Gigakilogram right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Gigakilogram left, Gigakilogram right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Gigakilogram with another Gigakilogram for equality (no tolerance used)</summary>
	public static bool operator ==(Gigakilogram left, Gigakilogram right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Gigakilogram with another Gigakilogram for inequality (no tolerance used)</summary>
	public static bool operator !=(Gigakilogram left, Gigakilogram right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Gigakilogram unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Gigakilogram unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} Kg";

	#endregion


	#endregion

}


