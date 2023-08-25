namespace cunits.files;

/// <summary>
/// Represents a Microkilogram Unit.
/// </summary>
public readonly struct Microkilogram : IEquatable<Microkilogram>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Microkilogram
	public Microkilogram(double value)
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
	public static implicit operator Microkilogram(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Microkilogram left, Microkilogram right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Microkilogram left, Microkilogram right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Microkilogram left, Microkilogram right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Microkilogram left, Microkilogram right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Microkilogram operator +(Microkilogram val) => val;
	///<inheritdoc/>
	public static Microkilogram operator -(Microkilogram val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Microkilogram left, Microkilogram right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Microkilogram left, Microkilogram right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Microkilogram left, Microkilogram right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Microkilogram left, Microkilogram right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Microkilogram with another Microkilogram for equality (no tolerance used)</summary>
	public static bool operator ==(Microkilogram left, Microkilogram right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Microkilogram with another Microkilogram for inequality (no tolerance used)</summary>
	public static bool operator !=(Microkilogram left, Microkilogram right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Microkilogram unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Microkilogram unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} Kg";

	#endregion


	#endregion

}


