namespace cunits.files;

/// <summary>
/// Represents a Singulartime Unit.
/// </summary>
public readonly struct Singulartime : IEquatable<Singulartime>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Singulartime
	public Singulartime(double value)
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
	public static implicit operator Singulartime(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Singulartime left, Singulartime right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Singulartime left, Singulartime right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Singulartime left, Singulartime right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Singulartime left, Singulartime right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Singulartime operator +(Singulartime val) => val;
	///<inheritdoc/>
	public static Singulartime operator -(Singulartime val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Singulartime left, Singulartime right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Singulartime left, Singulartime right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Singulartime left, Singulartime right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Singulartime left, Singulartime right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Singulartime with another Singulartime for equality (no tolerance used)</summary>
	public static bool operator ==(Singulartime left, Singulartime right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Singulartime with another Singulartime for inequality (no tolerance used)</summary>
	public static bool operator !=(Singulartime left, Singulartime right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Singulartime unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Singulartime unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} s";

	#endregion


	#endregion

}


