namespace cunits.files;

/// <summary>
/// Represents a Hectotime Unit.
/// </summary>
public readonly struct Hectotime : IEquatable<Hectotime>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Hectotime
	public Hectotime(double value)
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
	public static implicit operator Hectotime(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Hectotime left, Hectotime right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Hectotime left, Hectotime right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Hectotime left, Hectotime right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Hectotime left, Hectotime right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Hectotime operator +(Hectotime val) => val;
	///<inheritdoc/>
	public static Hectotime operator -(Hectotime val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Hectotime left, Hectotime right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Hectotime left, Hectotime right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Hectotime left, Hectotime right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Hectotime left, Hectotime right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Hectotime with another Hectotime for equality (no tolerance used)</summary>
	public static bool operator ==(Hectotime left, Hectotime right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Hectotime with another Hectotime for inequality (no tolerance used)</summary>
	public static bool operator !=(Hectotime left, Hectotime right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Hectotime unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Hectotime unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} s";

	#endregion


	#endregion

}


