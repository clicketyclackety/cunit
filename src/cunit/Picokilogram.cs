namespace cunits.files;

/// <summary>
/// Represents a Picokilogram Unit.
/// </summary>
public readonly struct Picokilogram : IEquatable<Picokilogram>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Picokilogram
	public Picokilogram(double value)
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
	public static implicit operator Picokilogram(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Picokilogram left, Picokilogram right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Picokilogram left, Picokilogram right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Picokilogram left, Picokilogram right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Picokilogram left, Picokilogram right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Picokilogram operator +(Picokilogram val) => val;
	///<inheritdoc/>
	public static Picokilogram operator -(Picokilogram val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Picokilogram left, Picokilogram right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Picokilogram left, Picokilogram right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Picokilogram left, Picokilogram right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Picokilogram left, Picokilogram right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Picokilogram with another Picokilogram for equality (no tolerance used)</summary>
	public static bool operator ==(Picokilogram left, Picokilogram right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Picokilogram with another Picokilogram for inequality (no tolerance used)</summary>
	public static bool operator !=(Picokilogram left, Picokilogram right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Picokilogram unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Picokilogram unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} Kg";

	#endregion


	#endregion

}


