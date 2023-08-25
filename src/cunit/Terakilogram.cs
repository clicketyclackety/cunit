namespace cunits.files;

/// <summary>
/// Represents a Terakilogram Unit.
/// </summary>
public readonly struct Terakilogram : IEquatable<Terakilogram>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Terakilogram
	public Terakilogram(double value)
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
	public static implicit operator Terakilogram(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Terakilogram left, Terakilogram right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Terakilogram left, Terakilogram right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Terakilogram left, Terakilogram right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Terakilogram left, Terakilogram right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Terakilogram operator +(Terakilogram val) => val;
	///<inheritdoc/>
	public static Terakilogram operator -(Terakilogram val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Terakilogram left, Terakilogram right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Terakilogram left, Terakilogram right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Terakilogram left, Terakilogram right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Terakilogram left, Terakilogram right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Terakilogram with another Terakilogram for equality (no tolerance used)</summary>
	public static bool operator ==(Terakilogram left, Terakilogram right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Terakilogram with another Terakilogram for inequality (no tolerance used)</summary>
	public static bool operator !=(Terakilogram left, Terakilogram right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Terakilogram unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Terakilogram unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} Kg";

	#endregion


	#endregion

}


