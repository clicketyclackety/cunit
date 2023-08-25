namespace cunits.files;

/// <summary>
/// Represents a Kilotime Unit.
/// </summary>
public readonly struct Kilotime : IEquatable<Kilotime>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Kilotime
	public Kilotime(double value)
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
	public static implicit operator Kilotime(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Kilotime left, Kilotime right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Kilotime left, Kilotime right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Kilotime left, Kilotime right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Kilotime left, Kilotime right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Kilotime operator +(Kilotime val) => val;
	///<inheritdoc/>
	public static Kilotime operator -(Kilotime val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Kilotime left, Kilotime right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Kilotime left, Kilotime right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Kilotime left, Kilotime right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Kilotime left, Kilotime right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Kilotime with another Kilotime for equality (no tolerance used)</summary>
	public static bool operator ==(Kilotime left, Kilotime right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Kilotime with another Kilotime for inequality (no tolerance used)</summary>
	public static bool operator !=(Kilotime left, Kilotime right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Kilotime unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Kilotime unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} s";

	#endregion


	#endregion

}


