namespace cunits.files;

/// <summary>
/// Represents a Singularelectriccurrent Unit.
/// </summary>
public readonly struct Singularelectriccurrent : IEquatable<Singularelectriccurrent>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Singularelectriccurrent
	public Singularelectriccurrent(double value)
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
	public static implicit operator Singularelectriccurrent(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Singularelectriccurrent left, Singularelectriccurrent right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Singularelectriccurrent left, Singularelectriccurrent right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Singularelectriccurrent left, Singularelectriccurrent right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Singularelectriccurrent left, Singularelectriccurrent right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Singularelectriccurrent operator +(Singularelectriccurrent val) => val;
	///<inheritdoc/>
	public static Singularelectriccurrent operator -(Singularelectriccurrent val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Singularelectriccurrent left, Singularelectriccurrent right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Singularelectriccurrent left, Singularelectriccurrent right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Singularelectriccurrent left, Singularelectriccurrent right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Singularelectriccurrent left, Singularelectriccurrent right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Singularelectriccurrent with another Singularelectriccurrent for equality (no tolerance used)</summary>
	public static bool operator ==(Singularelectriccurrent left, Singularelectriccurrent right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Singularelectriccurrent with another Singularelectriccurrent for inequality (no tolerance used)</summary>
	public static bool operator !=(Singularelectriccurrent left, Singularelectriccurrent right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Singularelectriccurrent unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Singularelectriccurrent unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} Amp";

	#endregion


	#endregion

}


