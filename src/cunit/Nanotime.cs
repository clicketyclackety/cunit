namespace cunits.files;

/// <summary>
/// Represents a Nanotime Unit.
/// </summary>
public readonly struct Nanotime : IEquatable<Nanotime>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Nanotime
	public Nanotime(double value)
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
	public static implicit operator Nanotime(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Nanotime left, Nanotime right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Nanotime left, Nanotime right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Nanotime left, Nanotime right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Nanotime left, Nanotime right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Nanotime operator +(Nanotime val) => val;
	///<inheritdoc/>
	public static Nanotime operator -(Nanotime val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Nanotime left, Nanotime right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Nanotime left, Nanotime right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Nanotime left, Nanotime right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Nanotime left, Nanotime right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Nanotime with another Nanotime for equality (no tolerance used)</summary>
	public static bool operator ==(Nanotime left, Nanotime right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Nanotime with another Nanotime for inequality (no tolerance used)</summary>
	public static bool operator !=(Nanotime left, Nanotime right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Nanotime unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Nanotime unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} s";

	#endregion


	#endregion

}


