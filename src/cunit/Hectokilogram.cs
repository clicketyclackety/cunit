namespace cunits.files;

/// <summary>
/// Represents a Hectokilogram Unit.
/// </summary>
public readonly struct Hectokilogram : IEquatable<Hectokilogram>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Hectokilogram
	public Hectokilogram(double value)
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
	public static implicit operator Hectokilogram(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Hectokilogram left, Hectokilogram right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Hectokilogram left, Hectokilogram right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Hectokilogram left, Hectokilogram right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Hectokilogram left, Hectokilogram right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Hectokilogram operator +(Hectokilogram val) => val;
	///<inheritdoc/>
	public static Hectokilogram operator -(Hectokilogram val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Hectokilogram left, Hectokilogram right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Hectokilogram left, Hectokilogram right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Hectokilogram left, Hectokilogram right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Hectokilogram left, Hectokilogram right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Hectokilogram with another Hectokilogram for equality (no tolerance used)</summary>
	public static bool operator ==(Hectokilogram left, Hectokilogram right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Hectokilogram with another Hectokilogram for inequality (no tolerance used)</summary>
	public static bool operator !=(Hectokilogram left, Hectokilogram right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Hectokilogram unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Hectokilogram unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} Kg";

	#endregion


	#endregion

}


