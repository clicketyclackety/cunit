namespace cunits.files;

/// <summary>
/// Represents a Decitime Unit.
/// </summary>
public readonly struct Decitime : IEquatable<Decitime>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Decitime
	public Decitime(double value)
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
	public static implicit operator Decitime(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Decitime left, Decitime right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Decitime left, Decitime right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Decitime left, Decitime right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Decitime left, Decitime right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Decitime operator +(Decitime val) => val;
	///<inheritdoc/>
	public static Decitime operator -(Decitime val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Decitime left, Decitime right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Decitime left, Decitime right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Decitime left, Decitime right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Decitime left, Decitime right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Decitime with another Decitime for equality (no tolerance used)</summary>
	public static bool operator ==(Decitime left, Decitime right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Decitime with another Decitime for inequality (no tolerance used)</summary>
	public static bool operator !=(Decitime left, Decitime right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Decitime unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Decitime unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} s";

	#endregion


	#endregion

}


