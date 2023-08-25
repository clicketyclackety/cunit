namespace cunits.files;

/// <summary>
/// Represents a Picometer Unit.
/// </summary>
public readonly struct Picometer : IEquatable<Picometer>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Picometer
	public Picometer(double value)
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
	public static implicit operator Picometer(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Picometer left, Picometer right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Picometer left, Picometer right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Picometer left, Picometer right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Picometer left, Picometer right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Picometer operator +(Picometer val) => val;
	///<inheritdoc/>
	public static Picometer operator -(Picometer val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Picometer left, Picometer right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Picometer left, Picometer right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Picometer left, Picometer right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Picometer left, Picometer right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Picometer with another Picometer for equality (no tolerance used)</summary>
	public static bool operator ==(Picometer left, Picometer right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Picometer with another Picometer for inequality (no tolerance used)</summary>
	public static bool operator !=(Picometer left, Picometer right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Picometer unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Picometer unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} M";

	#endregion


	#endregion

}


