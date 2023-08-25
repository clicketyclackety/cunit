namespace cunits.files;

/// <summary>
/// Represents a Hectometer Unit.
/// </summary>
public readonly struct Hectometer : IEquatable<Hectometer>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Hectometer
	public Hectometer(double value)
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
	public static implicit operator Hectometer(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Hectometer left, Hectometer right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Hectometer left, Hectometer right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Hectometer left, Hectometer right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Hectometer left, Hectometer right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Hectometer operator +(Hectometer val) => val;
	///<inheritdoc/>
	public static Hectometer operator -(Hectometer val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Hectometer left, Hectometer right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Hectometer left, Hectometer right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Hectometer left, Hectometer right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Hectometer left, Hectometer right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Hectometer with another Hectometer for equality (no tolerance used)</summary>
	public static bool operator ==(Hectometer left, Hectometer right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Hectometer with another Hectometer for inequality (no tolerance used)</summary>
	public static bool operator !=(Hectometer left, Hectometer right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Hectometer unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Hectometer unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} M";

	#endregion


	#endregion

}


