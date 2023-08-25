namespace cunits.files;

/// <summary>
/// Represents a Teratime Unit.
/// </summary>
public readonly struct Teratime : IEquatable<Teratime>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Teratime
	public Teratime(double value)
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
	public static implicit operator Teratime(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Teratime left, Teratime right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Teratime left, Teratime right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Teratime left, Teratime right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Teratime left, Teratime right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Teratime operator +(Teratime val) => val;
	///<inheritdoc/>
	public static Teratime operator -(Teratime val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Teratime left, Teratime right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Teratime left, Teratime right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Teratime left, Teratime right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Teratime left, Teratime right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Teratime with another Teratime for equality (no tolerance used)</summary>
	public static bool operator ==(Teratime left, Teratime right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Teratime with another Teratime for inequality (no tolerance used)</summary>
	public static bool operator !=(Teratime left, Teratime right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Teratime unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Teratime unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} s";

	#endregion


	#endregion

}


