namespace cunits.files;

/// <summary>
/// Represents a Millitime Unit.
/// </summary>
public readonly struct Millitime : IEquatable<Millitime>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Millitime
	public Millitime(double value)
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
	public static implicit operator Millitime(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Millitime left, Millitime right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Millitime left, Millitime right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Millitime left, Millitime right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Millitime left, Millitime right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Millitime operator +(Millitime val) => val;
	///<inheritdoc/>
	public static Millitime operator -(Millitime val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Millitime left, Millitime right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Millitime left, Millitime right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Millitime left, Millitime right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Millitime left, Millitime right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Millitime with another Millitime for equality (no tolerance used)</summary>
	public static bool operator ==(Millitime left, Millitime right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Millitime with another Millitime for inequality (no tolerance used)</summary>
	public static bool operator !=(Millitime left, Millitime right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Millitime unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Millitime unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} s";

	#endregion


	#endregion

}


