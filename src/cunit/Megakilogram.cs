namespace cunits.files;

/// <summary>
/// Represents a Megakilogram Unit.
/// </summary>
public readonly struct Megakilogram : IEquatable<Megakilogram>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Megakilogram
	public Megakilogram(double value)
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
	public static implicit operator Megakilogram(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Megakilogram left, Megakilogram right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Megakilogram left, Megakilogram right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Megakilogram left, Megakilogram right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Megakilogram left, Megakilogram right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Megakilogram operator +(Megakilogram val) => val;
	///<inheritdoc/>
	public static Megakilogram operator -(Megakilogram val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Megakilogram left, Megakilogram right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Megakilogram left, Megakilogram right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Megakilogram left, Megakilogram right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Megakilogram left, Megakilogram right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Megakilogram with another Megakilogram for equality (no tolerance used)</summary>
	public static bool operator ==(Megakilogram left, Megakilogram right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Megakilogram with another Megakilogram for inequality (no tolerance used)</summary>
	public static bool operator !=(Megakilogram left, Megakilogram right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Megakilogram unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Megakilogram unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} Kg";

	#endregion


	#endregion

}


