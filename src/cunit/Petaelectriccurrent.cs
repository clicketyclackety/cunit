namespace cunits.files;

/// <summary>
/// Represents a Petaelectriccurrent Unit.
/// </summary>
public readonly struct Petaelectriccurrent : IEquatable<Petaelectriccurrent>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Petaelectriccurrent
	public Petaelectriccurrent(double value)
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
	public static implicit operator Petaelectriccurrent(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Petaelectriccurrent left, Petaelectriccurrent right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Petaelectriccurrent left, Petaelectriccurrent right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Petaelectriccurrent left, Petaelectriccurrent right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Petaelectriccurrent left, Petaelectriccurrent right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Petaelectriccurrent operator +(Petaelectriccurrent val) => val;
	///<inheritdoc/>
	public static Petaelectriccurrent operator -(Petaelectriccurrent val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Petaelectriccurrent left, Petaelectriccurrent right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Petaelectriccurrent left, Petaelectriccurrent right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Petaelectriccurrent left, Petaelectriccurrent right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Petaelectriccurrent left, Petaelectriccurrent right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Petaelectriccurrent with another Petaelectriccurrent for equality (no tolerance used)</summary>
	public static bool operator ==(Petaelectriccurrent left, Petaelectriccurrent right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Petaelectriccurrent with another Petaelectriccurrent for inequality (no tolerance used)</summary>
	public static bool operator !=(Petaelectriccurrent left, Petaelectriccurrent right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Petaelectriccurrent unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Petaelectriccurrent unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} Amp";

	#endregion


	#endregion

}


