namespace cunits.files;

/// <summary>
/// Represents a Centikilogram Unit.
/// </summary>
public readonly struct Centikilogram : IEquatable<Centikilogram>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Centikilogram
	public Centikilogram(double value)
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
	public static implicit operator Centikilogram(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Centikilogram left, Centikilogram right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Centikilogram left, Centikilogram right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Centikilogram left, Centikilogram right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Centikilogram left, Centikilogram right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Centikilogram operator +(Centikilogram val) => val;
	///<inheritdoc/>
	public static Centikilogram operator -(Centikilogram val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Centikilogram left, Centikilogram right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Centikilogram left, Centikilogram right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Centikilogram left, Centikilogram right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Centikilogram left, Centikilogram right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Centikilogram with another Centikilogram for equality (no tolerance used)</summary>
	public static bool operator ==(Centikilogram left, Centikilogram right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Centikilogram with another Centikilogram for inequality (no tolerance used)</summary>
	public static bool operator !=(Centikilogram left, Centikilogram right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Centikilogram unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Centikilogram unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} Kg";

	#endregion


	#endregion

}


