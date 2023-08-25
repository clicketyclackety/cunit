namespace cunits.files;

/// <summary>
/// Represents a amount Unit.
/// </summary>
public readonly struct amount : IEquatable<amount>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a amount
	public amount(double value)
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
	public static implicit operator amount(double value) => new amount(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(amount left, amount right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(amount left, amount right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(amount left, amount right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(amount left, amount right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static amount operator +(amount val) => val;
	///<inheritdoc/>
	public static amount operator -(amount val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(amount left, amount right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(amount left, amount right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(amount left, amount right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(amount left, amount right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this amount with another amount for equality (no tolerance used)</summary>
	public static bool operator ==(amount left, amount right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this amount with another amount for inequality (no tolerance used)</summary>
	public static bool operator !=(amount left, amount right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is amount unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(amount unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} Mole";

	#endregion


	#endregion

}


