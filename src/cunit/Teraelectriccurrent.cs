namespace cunits.files;

/// <summary>
/// Represents a Teraelectriccurrent Unit.
/// </summary>
public readonly struct Teraelectriccurrent : IEquatable<Teraelectriccurrent>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Teraelectriccurrent
	public Teraelectriccurrent(double value)
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
	public static implicit operator Teraelectriccurrent(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Teraelectriccurrent left, Teraelectriccurrent right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Teraelectriccurrent left, Teraelectriccurrent right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Teraelectriccurrent left, Teraelectriccurrent right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Teraelectriccurrent left, Teraelectriccurrent right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Teraelectriccurrent operator +(Teraelectriccurrent val) => val;
	///<inheritdoc/>
	public static Teraelectriccurrent operator -(Teraelectriccurrent val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Teraelectriccurrent left, Teraelectriccurrent right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Teraelectriccurrent left, Teraelectriccurrent right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Teraelectriccurrent left, Teraelectriccurrent right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Teraelectriccurrent left, Teraelectriccurrent right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Teraelectriccurrent with another Teraelectriccurrent for equality (no tolerance used)</summary>
	public static bool operator ==(Teraelectriccurrent left, Teraelectriccurrent right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Teraelectriccurrent with another Teraelectriccurrent for inequality (no tolerance used)</summary>
	public static bool operator !=(Teraelectriccurrent left, Teraelectriccurrent right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Teraelectriccurrent unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Teraelectriccurrent unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} Amp";

	#endregion


	#endregion

}


