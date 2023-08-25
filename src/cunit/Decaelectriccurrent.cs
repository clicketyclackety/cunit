namespace cunits.files;

/// <summary>
/// Represents a Decaelectriccurrent Unit.
/// </summary>
public readonly struct Decaelectriccurrent : IEquatable<Decaelectriccurrent>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Decaelectriccurrent
	public Decaelectriccurrent(double value)
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
	public static implicit operator Decaelectriccurrent(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Decaelectriccurrent left, Decaelectriccurrent right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Decaelectriccurrent left, Decaelectriccurrent right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Decaelectriccurrent left, Decaelectriccurrent right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Decaelectriccurrent left, Decaelectriccurrent right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Decaelectriccurrent operator +(Decaelectriccurrent val) => val;
	///<inheritdoc/>
	public static Decaelectriccurrent operator -(Decaelectriccurrent val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Decaelectriccurrent left, Decaelectriccurrent right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Decaelectriccurrent left, Decaelectriccurrent right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Decaelectriccurrent left, Decaelectriccurrent right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Decaelectriccurrent left, Decaelectriccurrent right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Decaelectriccurrent with another Decaelectriccurrent for equality (no tolerance used)</summary>
	public static bool operator ==(Decaelectriccurrent left, Decaelectriccurrent right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Decaelectriccurrent with another Decaelectriccurrent for inequality (no tolerance used)</summary>
	public static bool operator !=(Decaelectriccurrent left, Decaelectriccurrent right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Decaelectriccurrent unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Decaelectriccurrent unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} Amp";

	#endregion


	#endregion

}


