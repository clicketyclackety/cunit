namespace cunits.files;

/// <summary>
/// Represents a Nanometer Unit.
/// </summary>
public readonly struct Nanometer : IEquatable<Nanometer>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Nanometer
	public Nanometer(double value)
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
	public static implicit operator Nanometer(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Nanometer left, Nanometer right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Nanometer left, Nanometer right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Nanometer left, Nanometer right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Nanometer left, Nanometer right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Nanometer operator +(Nanometer val) => val;
	///<inheritdoc/>
	public static Nanometer operator -(Nanometer val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Nanometer left, Nanometer right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Nanometer left, Nanometer right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Nanometer left, Nanometer right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Nanometer left, Nanometer right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Nanometer with another Nanometer for equality (no tolerance used)</summary>
	public static bool operator ==(Nanometer left, Nanometer right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Nanometer with another Nanometer for inequality (no tolerance used)</summary>
	public static bool operator !=(Nanometer left, Nanometer right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Nanometer unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Nanometer unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} M";

	#endregion


	#endregion

}


