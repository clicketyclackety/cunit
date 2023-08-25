namespace cunits.files;

/// <summary>
/// Represents a Gigameter Unit.
/// </summary>
public readonly struct Gigameter : IEquatable<Gigameter>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Gigameter
	public Gigameter(double value)
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
	public static implicit operator Gigameter(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Gigameter left, Gigameter right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Gigameter left, Gigameter right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Gigameter left, Gigameter right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Gigameter left, Gigameter right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Gigameter operator +(Gigameter val) => val;
	///<inheritdoc/>
	public static Gigameter operator -(Gigameter val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Gigameter left, Gigameter right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Gigameter left, Gigameter right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Gigameter left, Gigameter right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Gigameter left, Gigameter right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Gigameter with another Gigameter for equality (no tolerance used)</summary>
	public static bool operator ==(Gigameter left, Gigameter right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Gigameter with another Gigameter for inequality (no tolerance used)</summary>
	public static bool operator !=(Gigameter left, Gigameter right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Gigameter unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Gigameter unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} M";

	#endregion


	#endregion

}


