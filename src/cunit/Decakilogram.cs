namespace cunits.files;

/// <summary>
/// Represents a Decakilogram Unit.
/// </summary>
public readonly struct Decakilogram : IEquatable<Decakilogram>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Decakilogram
	public Decakilogram(double value)
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
	public static implicit operator Decakilogram(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Decakilogram left, Decakilogram right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Decakilogram left, Decakilogram right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Decakilogram left, Decakilogram right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Decakilogram left, Decakilogram right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Decakilogram operator +(Decakilogram val) => val;
	///<inheritdoc/>
	public static Decakilogram operator -(Decakilogram val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Decakilogram left, Decakilogram right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Decakilogram left, Decakilogram right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Decakilogram left, Decakilogram right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Decakilogram left, Decakilogram right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Decakilogram with another Decakilogram for equality (no tolerance used)</summary>
	public static bool operator ==(Decakilogram left, Decakilogram right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Decakilogram with another Decakilogram for inequality (no tolerance used)</summary>
	public static bool operator !=(Decakilogram left, Decakilogram right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Decakilogram unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Decakilogram unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} Kg";

	#endregion


	#endregion

}


