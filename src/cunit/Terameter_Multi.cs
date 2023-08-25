namespace cunits.files;

/// <summary>
/// Represents a Terameter_Multi Unit.
/// </summary>
public readonly struct Terameter_Multi : IEquatable<Terameter_Multi>
{

	/// <summary>The double value of this unit</summary>
	internal readonly double Value;

	/// <summary>Creates a new instance of a Terameter_Multi
	public Terameter_Multi(double value)
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
	public static implicit operator Terameter_Multi(double value) => new(value);

	#endregion

	#region Mathmatic Operators

	///<inheritdoc/>
	public static double operator +(Terameter_Multi left, Terameter_Multi right)=> left.Value + right.Value;
	///<inheritdoc/>
	public static double operator -(Terameter_Multi left, Terameter_Multi right)=> left.Value - right.Value;
	///<inheritdoc/>
	public static double operator /(Terameter_Multi left, Terameter_Multi right)=> left.Value / right.Value;
	///<inheritdoc/>
	public static double operator *(Terameter_Multi left, Terameter_Multi right)=> left.Value * right.Value;

	#endregion

	#region Positive / Negative Operators

	///<inheritdoc/>
	public static Terameter_Multi operator +(Terameter_Multi val) => val;
	///<inheritdoc/>
	public static Terameter_Multi operator -(Terameter_Multi val) => new (-val.Value);

	#endregion

	#region Greater/Less

	///<inheritdoc/>
	public static bool operator <(Terameter_Multi left, Terameter_Multi right) => left.GetHashCode() < right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >(Terameter_Multi left, Terameter_Multi right) => left.GetHashCode() > right.GetHashCode();
	///<inheritdoc/>
	public static bool operator <=(Terameter_Multi left, Terameter_Multi right) => left.GetHashCode() <= right.GetHashCode();
	///<inheritdoc/>
	public static bool operator >=(Terameter_Multi left, Terameter_Multi right) => left.GetHashCode() >= right.GetHashCode();

	#endregion

	#region Equality

	/// <summary>Compares this Terameter_Multi with another Terameter_Multi for equality (no tolerance used)</summary>
	public static bool operator ==(Terameter_Multi left, Terameter_Multi right)=> left.GetHashCode() == right.GetHashCode();
	/// <summary>Compares this Terameter_Multi with another Terameter_Multi for inequality (no tolerance used)</summary>
	public static bool operator !=(Terameter_Multi left, Terameter_Multi right) => !(left == right);

	///<inheritdoc/>
	public override int GetHashCode() => HashCode.Combine(this.Value);
	///<inheritdoc/>
	public override bool Equals(object? obj) => obj is Terameter_Multi unit && Equals(unit);
	///<inheritdoc/>
	public bool Equals(Terameter_Multi unit) => this.GetHashCode() == unit.GetHashCode();
	///<inheritdoc/>
	public override string ToString() => $"{Value:0.000} M";

	#endregion


	#endregion

}


