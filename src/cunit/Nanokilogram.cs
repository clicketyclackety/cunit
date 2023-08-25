namespace cunits.files;

/// <summary>
/// Represents a Nanokilogram Unit.
/// </summary>
public readonly struct Nanokilogram : IEquatable<Nanokilogram>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Nanokilogram
	public Nanokilogram(double value)
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
	public static implicit operator Nanokilogram(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Nanokilogram left, Nanokilogram right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Nanokilogram left, Nanokilogram right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Nanokilogram left, Nanokilogram right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Nanokilogram left, Nanokilogram right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Nanokilogram operator +(Nanokilogram val) => val;
	///<inheritdoc/>
	public static Nanokilogram operator -(Nanokilogram val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Nanokilogram left, Nanokilogram right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Nanokilogram left, Nanokilogram right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Nanokilogram left, Nanokilogram right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Nanokilogram left, Nanokilogram right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Nanokilogram with another Nanokilogram for equality (no tolerance used)</summary>
	public static bool operator ==(Nanokilogram left, Nanokilogram right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Nanokilogram with another Nanokilogram for inequality (no tolerance used)</summary>
	public static bool operator !=(Nanokilogram left, Nanokilogram right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Nanokilogram unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Nanokilogram unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} Kg";

	#endregion


	#endregion

}


