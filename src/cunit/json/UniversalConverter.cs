using System.Text.Json;
using System.Text.Json.Serialization;


namespace cunit.Json
{
	public sealed class UniversalConverter : JsonConverter<IUnit>
	{

		public override bool CanConvert(Type typeToConvert) => typeToConvert.GetInterface(nameof(IUnit)) is not null;

		public override IUnit Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			try
			{
				var value = reader.GetString();
				var parts = value?.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries) ?? Array.Empty<string>();
				var symbol = parts.Last();
				var dimensions = parts.Take(parts.Count() -1);

				List<double> dimensionValues = new (dimensions.Count());
				foreach(var doubleString in dimensions)
				{
					if (string.IsNullOrEmpty(doubleString))
					{
						dimensionValues.Add(0);
						continue;
					}

					if (!double.TryParse(doubleString, out var doubleValue))
					{
						dimensionValues.Add(0);
						continue;
					}

					dimensionValues.Add(doubleValue);
				}

				dynamic foundUnit = symbol switch
				{
					Radian.Symbol => new Radian(dimensionValues[0]),
					Degree.Symbol => new Degree(dimensionValues[0]),
					Meter.Symbol => new Meter(dimensionValues[0]),
					MeterSquared.Symbol => new MeterSquared(dimensionValues[0], dimensionValues[1]),
					MeterCubed.Symbol => new MeterCubed(dimensionValues[0], dimensionValues[1], dimensionValues[2]),
					Kilometer.Symbol => new Kilometer(dimensionValues[0]),
					KilometerSquared.Symbol => new KilometerSquared(dimensionValues[0], dimensionValues[1]),
					KilometerCubed.Symbol => new KilometerCubed(dimensionValues[0], dimensionValues[1], dimensionValues[2]),
					Centimeter.Symbol => new Centimeter(dimensionValues[0]),
					CentimeterSquared.Symbol => new CentimeterSquared(dimensionValues[0], dimensionValues[1]),
					CentimeterCubed.Symbol => new CentimeterCubed(dimensionValues[0], dimensionValues[1], dimensionValues[2]),
					Millimeter.Symbol => new Millimeter(dimensionValues[0]),
					MillimeterSquared.Symbol => new MillimeterSquared(dimensionValues[0], dimensionValues[1]),
					MillimeterCubed.Symbol => new MillimeterCubed(dimensionValues[0], dimensionValues[1], dimensionValues[2]),
					Inch.Symbol => new Inch(dimensionValues[0]),
					InchSquared.Symbol => new InchSquared(dimensionValues[0], dimensionValues[1]),
					InchCubed.Symbol => new InchCubed(dimensionValues[0], dimensionValues[1], dimensionValues[2]),
					Foot.Symbol => new Foot(dimensionValues[0]),
					FootSquared.Symbol => new FootSquared(dimensionValues[0], dimensionValues[1]),
					FootCubed.Symbol => new FootCubed(dimensionValues[0], dimensionValues[1], dimensionValues[2]),
					Second.Symbol => new Second(dimensionValues[0]),
					MilliSecond.Symbol => new MilliSecond(dimensionValues[0]),
					Minute.Symbol => new Minute(dimensionValues[0]),
					Hour.Symbol => new Hour(dimensionValues[0]),
					Day.Symbol => new Day(dimensionValues[0]),
					Week.Symbol => new Week(dimensionValues[0]),
					Kelvin.Symbol => new Kelvin(dimensionValues[0]),
					Celsius.Symbol => new Celsius(dimensionValues[0]),
					Fahrenheit.Symbol => new Fahrenheit(dimensionValues[0]),
					Kilogram.Symbol => new Kilogram(dimensionValues[0]),
					Milligram.Symbol => new Milligram(dimensionValues[0]),
					Gram.Symbol => new Gram(dimensionValues[0]),
					Tonne.Symbol => new Tonne(dimensionValues[0]),
					Ounce.Symbol => new Ounce(dimensionValues[0]),
					Pound.Symbol => new Pound(dimensionValues[0]),
					Candela.Symbol => new Candela(dimensionValues[0]),
					Ampere.Symbol => new Ampere(dimensionValues[0]),
					Mole.Symbol => new Mole(dimensionValues[0]),
					Byte.Symbol => new Byte(dimensionValues[0]),
					Bit.Symbol => new Bit(dimensionValues[0]),
					Kilobyte.Symbol => new Kilobyte(dimensionValues[0]),
					Megabyte.Symbol => new Megabyte(dimensionValues[0]),
					Gigabyte.Symbol => new Gigabyte(dimensionValues[0]),
					_ => UnknownUnit.Err
				};

				return typeToConvert.Name switch
				{
					nameof(Radian) => (Radian)foundUnit,
					nameof(Degree) => (Degree)foundUnit,
					nameof(Meter) => (Meter)foundUnit,
					nameof(MeterSquared) => (MeterSquared)foundUnit,
					nameof(MeterCubed) => (MeterCubed)foundUnit,
					nameof(Kilometer) => (Kilometer)foundUnit,
					nameof(KilometerSquared) => (KilometerSquared)foundUnit,
					nameof(KilometerCubed) => (KilometerCubed)foundUnit,
					nameof(Centimeter) => (Centimeter)foundUnit,
					nameof(CentimeterSquared) => (CentimeterSquared)foundUnit,
					nameof(CentimeterCubed) => (CentimeterCubed)foundUnit,
					nameof(Millimeter) => (Millimeter)foundUnit,
					nameof(MillimeterSquared) => (MillimeterSquared)foundUnit,
					nameof(MillimeterCubed) => (MillimeterCubed)foundUnit,
					nameof(Inch) => (Inch)foundUnit,
					nameof(InchSquared) => (InchSquared)foundUnit,
					nameof(InchCubed) => (InchCubed)foundUnit,
					nameof(Foot) => (Foot)foundUnit,
					nameof(FootSquared) => (FootSquared)foundUnit,
					nameof(FootCubed) => (FootCubed)foundUnit,
					nameof(Second) => (Second)foundUnit,
					nameof(MilliSecond) => (MilliSecond)foundUnit,
					nameof(Minute) => (Minute)foundUnit,
					nameof(Hour) => (Hour)foundUnit,
					nameof(Day) => (Day)foundUnit,
					nameof(Week) => (Week)foundUnit,
					nameof(Kelvin) => (Kelvin)foundUnit,
					nameof(Celsius) => (Celsius)foundUnit,
					nameof(Fahrenheit) => (Fahrenheit)foundUnit,
					nameof(Kilogram) => (Kilogram)foundUnit,
					nameof(Milligram) => (Milligram)foundUnit,
					nameof(Gram) => (Gram)foundUnit,
					nameof(Tonne) => (Tonne)foundUnit,
					nameof(Ounce) => (Ounce)foundUnit,
					nameof(Pound) => (Pound)foundUnit,
					nameof(Candela) => (Candela)foundUnit,
					nameof(Ampere) => (Ampere)foundUnit,
					nameof(Mole) => (Mole)foundUnit,
					nameof(Byte) => (Byte)foundUnit,
					nameof(Bit) => (Bit)foundUnit,
					nameof(Kilobyte) => (Kilobyte)foundUnit,
					nameof(Megabyte) => (Megabyte)foundUnit,
					nameof(Gigabyte) => (Gigabyte)foundUnit,
					_ => UnknownUnit.Err
				};

			}
			catch
			{
				return UnknownUnit.Err;
			}
		}

		public override void Write(
			Utf8JsonWriter writer,
			IUnit unit,
			JsonSerializerOptions options)
		{
			string symbol = unit switch
			{
				Radian => Radian.Symbol,
				Degree => Degree.Symbol,
				Meter => Meter.Symbol,
				MeterSquared => MeterSquared.Symbol,
				MeterCubed => MeterCubed.Symbol,
				Kilometer => Kilometer.Symbol,
				KilometerSquared => KilometerSquared.Symbol,
				KilometerCubed => KilometerCubed.Symbol,
				Centimeter => Centimeter.Symbol,
				CentimeterSquared => CentimeterSquared.Symbol,
				CentimeterCubed => CentimeterCubed.Symbol,
				Millimeter => Millimeter.Symbol,
				MillimeterSquared => MillimeterSquared.Symbol,
				MillimeterCubed => MillimeterCubed.Symbol,
				Inch => Inch.Symbol,
				InchSquared => InchSquared.Symbol,
				InchCubed => InchCubed.Symbol,
				Foot => Foot.Symbol,
				FootSquared => FootSquared.Symbol,
				FootCubed => FootCubed.Symbol,
				Second => Second.Symbol,
				MilliSecond => MilliSecond.Symbol,
				Minute => Minute.Symbol,
				Hour => Hour.Symbol,
				Day => Day.Symbol,
				Week => Week.Symbol,
				Kelvin => Kelvin.Symbol,
				Celsius => Celsius.Symbol,
				Fahrenheit => Fahrenheit.Symbol,
				Kilogram => Kilogram.Symbol,
				Milligram => Milligram.Symbol,
				Gram => Gram.Symbol,
				Tonne => Tonne.Symbol,
				Ounce => Ounce.Symbol,
				Pound => Pound.Symbol,
				Candela => Candela.Symbol,
				Ampere => Ampere.Symbol,
				Mole => Mole.Symbol,
				Byte => Byte.Symbol,
				Bit => Bit.Symbol,
				Kilobyte => Kilobyte.Symbol,
				Megabyte => Megabyte.Symbol,
				Gigabyte => Gigabyte.Symbol,
				_ => UnknownUnit.Symbol
			};

			var json = "";

			dynamic dynamicUnit = unit;

			if (unit is IUnit2D)
			{
				json += $" {dynamicUnit.XValue.Value}";
				json += $" {dynamicUnit.YValue.Value}";
			}
			else if (unit is IUnit3D)
			{
				json += $" {dynamicUnit.XValue.Value}";
				json += $" {dynamicUnit.YValue.Value}";
				json += $" {dynamicUnit.ZValue.Value}";
			}
			else if (unit is IUnit4D)
			{
				json += $" {dynamicUnit.XValue.Value}";
				json += $" {dynamicUnit.YValue.Value}";
				json += $" {dynamicUnit.ZValue.Value}";
				json += $" {dynamicUnit.TValue.Value}";
			}
			else if (unit is IUnit5D)
			{
				json += $" {dynamicUnit.XValue.Value}";
				json += $" {dynamicUnit.YValue.Value}";
				json += $" {dynamicUnit.ZValue.Value}";
				json += $" {dynamicUnit.TValue.Value}";
				json += $" {dynamicUnit.UValue.Value}";
			}
			else if (unit is IUnit6D)
			{
				json += $" {dynamicUnit.XValue.Value}";
				json += $" {dynamicUnit.YValue.Value}";
				json += $" {dynamicUnit.ZValue.Value}";
				json += $" {dynamicUnit.TValue.Value}";
				json += $" {dynamicUnit.UValue.Value}";
				json += $" {dynamicUnit.VValue.Value}";
			}
			else
				json = $"{unit.Value}";

			json += $" {symbol}";

			writer.WriteStringValue(json);

		}

	}

}
