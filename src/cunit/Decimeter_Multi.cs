namespace cunits.files;

/// <summary>
/// Represents a Decimeter_Multi Unit.
/// </summary>
public readonly struct Decimeter_Multi : IEquatable<Decimeter_Multi>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Decimeter_Multi
	public Decimeter_Multi(double value)
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
	public static implicit operator Decimeter_Multi(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Decimeter_Multi left, Decimeter_Multi right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Decimeter_Multi left, Decimeter_Multi right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Decimeter_Multi left, Decimeter_Multi right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Decimeter_Multi left, Decimeter_Multi right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Decimeter_Multi operator +(Decimeter_Multi val) => val;
	///<inheritdoc/>
	public static Decimeter_Multi operator -(Decimeter_Multi val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Decimeter_Multi left, Decimeter_Multi right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Decimeter_Multi left, Decimeter_Multi right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Decimeter_Multi left, Decimeter_Multi right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Decimeter_Multi left, Decimeter_Multi right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Decimeter_Multi with another Decimeter_Multi for equality (no tolerance used)</summary>
	public static bool operator ==(Decimeter_Multi left, Decimeter_Multi right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Decimeter_Multi with another Decimeter_Multi for inequality (no tolerance used)</summary>
	public static bool operator !=(Decimeter_Multi left, Decimeter_Multi right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Decimeter_Multi unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Decimeter_Multi unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} M";

	#endregion


	#endregion

}


