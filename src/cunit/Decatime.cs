namespace cunits.files;

/// <summary>
/// Represents a Decatime Unit.
/// </summary>
public readonly struct Decatime : IEquatable<Decatime>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Decatime
	public Decatime(double value)
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
	public static implicit operator Decatime(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Decatime left, Decatime right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Decatime left, Decatime right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Decatime left, Decatime right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Decatime left, Decatime right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Decatime operator +(Decatime val) => val;
	///<inheritdoc/>
	public static Decatime operator -(Decatime val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Decatime left, Decatime right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Decatime left, Decatime right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Decatime left, Decatime right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Decatime left, Decatime right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Decatime with another Decatime for equality (no tolerance used)</summary>
	public static bool operator ==(Decatime left, Decatime right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Decatime with another Decatime for inequality (no tolerance used)</summary>
	public static bool operator !=(Decatime left, Decatime right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Decatime unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Decatime unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} s";

	#endregion


	#endregion

}


