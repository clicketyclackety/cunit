namespace cunits.files;

/// <summary>
/// Represents a Petakilogram Unit.
/// </summary>
public readonly struct Petakilogram : IEquatable<Petakilogram>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Petakilogram
	public Petakilogram(double value)
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
	public static implicit operator Petakilogram(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Petakilogram left, Petakilogram right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Petakilogram left, Petakilogram right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Petakilogram left, Petakilogram right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Petakilogram left, Petakilogram right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Petakilogram operator +(Petakilogram val) => val;
	///<inheritdoc/>
	public static Petakilogram operator -(Petakilogram val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Petakilogram left, Petakilogram right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Petakilogram left, Petakilogram right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Petakilogram left, Petakilogram right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Petakilogram left, Petakilogram right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Petakilogram with another Petakilogram for equality (no tolerance used)</summary>
	public static bool operator ==(Petakilogram left, Petakilogram right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Petakilogram with another Petakilogram for inequality (no tolerance used)</summary>
	public static bool operator !=(Petakilogram left, Petakilogram right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Petakilogram unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Petakilogram unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} Kg";

	#endregion


	#endregion

}


