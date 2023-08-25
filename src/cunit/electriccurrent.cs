namespace cunits.files;

/// <summary>
/// Represents a electriccurrent Unit.
/// </summary>
public readonly struct electriccurrent : IEquatable<electriccurrent>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a electriccurrent
	public electriccurrent(double value)
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
	public static implicit operator electriccurrent(double value) => new electriccurrent(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(electriccurrent left, electriccurrent right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(electriccurrent left, electriccurrent right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(electriccurrent left, electriccurrent right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(electriccurrent left, electriccurrent right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static electriccurrent operator +(electriccurrent val) => val;
	///<inheritdoc/>
	public static electriccurrent operator -(electriccurrent val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(electriccurrent left, electriccurrent right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(electriccurrent left, electriccurrent right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(electriccurrent left, electriccurrent right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(electriccurrent left, electriccurrent right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this electriccurrent with another electriccurrent for equality (no tolerance used)</summary>
	public static bool operator ==(electriccurrent left, electriccurrent right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this electriccurrent with another electriccurrent for inequality (no tolerance used)</summary>
	public static bool operator !=(electriccurrent left, electriccurrent right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is electriccurrent unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(electriccurrent unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} Amp";

	#endregion


	#endregion

}


