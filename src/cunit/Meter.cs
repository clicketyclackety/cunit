namespace cunits.files;

/// <summary>
/// Represents a Meter Unit.
/// </summary>
public readonly struct Meter : IEquatable<Meter>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Meter
	public Meter(double value)
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
	public static implicit operator Meter(double value) => new Meter(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Meter left, Meter right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Meter left, Meter right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Meter left, Meter right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Meter left, Meter right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Meter operator +(Meter val) => val;
	///<inheritdoc/>
	public static Meter operator -(Meter val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Meter left, Meter right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Meter left, Meter right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Meter left, Meter right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Meter left, Meter right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Meter with another Meter for equality (no tolerance used)</summary>
	public static bool operator ==(Meter left, Meter right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Meter with another Meter for inequality (no tolerance used)</summary>
	public static bool operator !=(Meter left, Meter right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Meter unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Meter unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} M";

	#endregion


	#endregion

}


