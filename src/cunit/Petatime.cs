namespace cunits.files;

/// <summary>
/// Represents a Petatime Unit.
/// </summary>
public readonly struct Petatime : IEquatable<Petatime>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Petatime
	public Petatime(double value)
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
	public static implicit operator Petatime(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Petatime left, Petatime right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Petatime left, Petatime right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Petatime left, Petatime right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Petatime left, Petatime right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Petatime operator +(Petatime val) => val;
	///<inheritdoc/>
	public static Petatime operator -(Petatime val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Petatime left, Petatime right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Petatime left, Petatime right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Petatime left, Petatime right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Petatime left, Petatime right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Petatime with another Petatime for equality (no tolerance used)</summary>
	public static bool operator ==(Petatime left, Petatime right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Petatime with another Petatime for inequality (no tolerance used)</summary>
	public static bool operator !=(Petatime left, Petatime right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Petatime unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Petatime unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} s";

	#endregion


	#endregion

}


