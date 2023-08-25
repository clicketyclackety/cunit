namespace cunits.files;

/// <summary>
/// Represents a Microtime Unit.
/// </summary>
public readonly struct Microtime : IEquatable<Microtime>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Microtime
	public Microtime(double value)
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
	public static implicit operator Microtime(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Microtime left, Microtime right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Microtime left, Microtime right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Microtime left, Microtime right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Microtime left, Microtime right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Microtime operator +(Microtime val) => val;
	///<inheritdoc/>
	public static Microtime operator -(Microtime val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Microtime left, Microtime right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Microtime left, Microtime right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Microtime left, Microtime right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Microtime left, Microtime right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Microtime with another Microtime for equality (no tolerance used)</summary>
	public static bool operator ==(Microtime left, Microtime right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Microtime with another Microtime for inequality (no tolerance used)</summary>
	public static bool operator !=(Microtime left, Microtime right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Microtime unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Microtime unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} s";

	#endregion


	#endregion

}


