namespace cunits.files;

/// <summary>
/// Represents a Kilometer Unit.
/// </summary>
public readonly struct Kilometer : IEquatable<Kilometer>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Kilometer
	public Kilometer(double value)
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
	public static implicit operator Kilometer(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Kilometer left, Kilometer right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Kilometer left, Kilometer right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Kilometer left, Kilometer right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Kilometer left, Kilometer right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Kilometer operator +(Kilometer val) => val;
	///<inheritdoc/>
	public static Kilometer operator -(Kilometer val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Kilometer left, Kilometer right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Kilometer left, Kilometer right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Kilometer left, Kilometer right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Kilometer left, Kilometer right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Kilometer with another Kilometer for equality (no tolerance used)</summary>
	public static bool operator ==(Kilometer left, Kilometer right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Kilometer with another Kilometer for inequality (no tolerance used)</summary>
	public static bool operator !=(Kilometer left, Kilometer right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Kilometer unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Kilometer unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} M";

	#endregion


	#endregion

}


