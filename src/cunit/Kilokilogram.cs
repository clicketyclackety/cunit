namespace cunits.files;

/// <summary>
/// Represents a Kilokilogram Unit.
/// </summary>
public readonly struct Kilokilogram : IEquatable<Kilokilogram>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Kilokilogram
	public Kilokilogram(double value)
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
	public static implicit operator Kilokilogram(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Kilokilogram left, Kilokilogram right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Kilokilogram left, Kilokilogram right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Kilokilogram left, Kilokilogram right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Kilokilogram left, Kilokilogram right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Kilokilogram operator +(Kilokilogram val) => val;
	///<inheritdoc/>
	public static Kilokilogram operator -(Kilokilogram val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Kilokilogram left, Kilokilogram right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Kilokilogram left, Kilokilogram right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Kilokilogram left, Kilokilogram right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Kilokilogram left, Kilokilogram right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Kilokilogram with another Kilokilogram for equality (no tolerance used)</summary>
	public static bool operator ==(Kilokilogram left, Kilokilogram right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Kilokilogram with another Kilokilogram for inequality (no tolerance used)</summary>
	public static bool operator !=(Kilokilogram left, Kilokilogram right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Kilokilogram unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Kilokilogram unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} Kg";

	#endregion


	#endregion

}


