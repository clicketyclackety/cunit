namespace cunits.files;

/// <summary>
/// Represents a Megameter Unit.
/// </summary>
public readonly struct Megameter : IEquatable<Megameter>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Megameter
	public Megameter(double value)
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
	public static implicit operator Megameter(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Megameter left, Megameter right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Megameter left, Megameter right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Megameter left, Megameter right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Megameter left, Megameter right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Megameter operator +(Megameter val) => val;
	///<inheritdoc/>
	public static Megameter operator -(Megameter val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Megameter left, Megameter right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Megameter left, Megameter right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Megameter left, Megameter right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Megameter left, Megameter right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Megameter with another Megameter for equality (no tolerance used)</summary>
	public static bool operator ==(Megameter left, Megameter right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Megameter with another Megameter for inequality (no tolerance used)</summary>
	public static bool operator !=(Megameter left, Megameter right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Megameter unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Megameter unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} M";

	#endregion


	#endregion

}


