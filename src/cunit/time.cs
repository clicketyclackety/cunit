namespace cunits.files;

/// <summary>
/// Represents a time Unit.
/// </summary>
public readonly struct time : IEquatable<time>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a time
	public time(double value)
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
	public static implicit operator time(double value) => new time(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(time left, time right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(time left, time right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(time left, time right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(time left, time right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static time operator +(time val) => val;
	///<inheritdoc/>
	public static time operator -(time val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(time left, time right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(time left, time right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(time left, time right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(time left, time right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this time with another time for equality (no tolerance used)</summary>
	public static bool operator ==(time left, time right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this time with another time for inequality (no tolerance used)</summary>
	public static bool operator !=(time left, time right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is time unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(time unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} s";

	#endregion


	#endregion

}


