namespace cunits.files;

/// <summary>
/// Represents a Millikilogram Unit.
/// </summary>
public readonly struct Millikilogram : IEquatable<Millikilogram>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Millikilogram
	public Millikilogram(double value)
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
	public static implicit operator Millikilogram(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Millikilogram left, Millikilogram right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Millikilogram left, Millikilogram right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Millikilogram left, Millikilogram right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Millikilogram left, Millikilogram right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Millikilogram operator +(Millikilogram val) => val;
	///<inheritdoc/>
	public static Millikilogram operator -(Millikilogram val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Millikilogram left, Millikilogram right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Millikilogram left, Millikilogram right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Millikilogram left, Millikilogram right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Millikilogram left, Millikilogram right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Millikilogram with another Millikilogram for equality (no tolerance used)</summary>
	public static bool operator ==(Millikilogram left, Millikilogram right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Millikilogram with another Millikilogram for inequality (no tolerance used)</summary>
	public static bool operator !=(Millikilogram left, Millikilogram right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Millikilogram unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Millikilogram unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} Kg";

	#endregion


	#endregion

}


