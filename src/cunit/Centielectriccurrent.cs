namespace cunits.files;

/// <summary>
/// Represents a Centielectriccurrent Unit.
/// </summary>
public readonly struct Centielectriccurrent : IEquatable<Centielectriccurrent>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Centielectriccurrent
	public Centielectriccurrent(double value)
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
	public static implicit operator Centielectriccurrent(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Centielectriccurrent left, Centielectriccurrent right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Centielectriccurrent left, Centielectriccurrent right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Centielectriccurrent left, Centielectriccurrent right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Centielectriccurrent left, Centielectriccurrent right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Centielectriccurrent operator +(Centielectriccurrent val) => val;
	///<inheritdoc/>
	public static Centielectriccurrent operator -(Centielectriccurrent val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Centielectriccurrent left, Centielectriccurrent right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Centielectriccurrent left, Centielectriccurrent right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Centielectriccurrent left, Centielectriccurrent right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Centielectriccurrent left, Centielectriccurrent right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Centielectriccurrent with another Centielectriccurrent for equality (no tolerance used)</summary>
	public static bool operator ==(Centielectriccurrent left, Centielectriccurrent right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Centielectriccurrent with another Centielectriccurrent for inequality (no tolerance used)</summary>
	public static bool operator !=(Centielectriccurrent left, Centielectriccurrent right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Centielectriccurrent unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Centielectriccurrent unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} Amp";

	#endregion


	#endregion

}


