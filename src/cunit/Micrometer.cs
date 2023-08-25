namespace cunits.files;

/// <summary>
/// Represents a Micrometer Unit.
/// </summary>
public readonly struct Micrometer : IEquatable<Micrometer>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Micrometer
	public Micrometer(double value)
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
	public static implicit operator Micrometer(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Micrometer left, Micrometer right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Micrometer left, Micrometer right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Micrometer left, Micrometer right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Micrometer left, Micrometer right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Micrometer operator +(Micrometer val) => val;
	///<inheritdoc/>
	public static Micrometer operator -(Micrometer val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Micrometer left, Micrometer right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Micrometer left, Micrometer right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Micrometer left, Micrometer right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Micrometer left, Micrometer right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Micrometer with another Micrometer for equality (no tolerance used)</summary>
	public static bool operator ==(Micrometer left, Micrometer right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Micrometer with another Micrometer for inequality (no tolerance used)</summary>
	public static bool operator !=(Micrometer left, Micrometer right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Micrometer unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Micrometer unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} M";

	#endregion


	#endregion

}


