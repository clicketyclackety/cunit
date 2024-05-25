using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace cunit.tests
{

    public class Operations
    {

        [Theory]
        [TestCaseSource(nameof(Units))]
        public void PlusPlus(dynamic unit)
        {
            var value = unit.Value + 1;
            var result = unit++;
            Assert.That(result.Value, Is.EqualTo(value - 1));
        }

        [Theory]
        [TestCaseSource(nameof(Units))]
        public void MinusMinus(dynamic unit)
        {
            var value = unit.Value + 1;
            var result = unit--;
            Assert.That(result.Value, Is.EqualTo(value - 1));
        }

        [Theory]
        [TestCaseSource(nameof(Units))]
        public void Modulo(dynamic unit)
        {
            var result = unit % 2;
            var value = unit.Value % 2;
            Assert.That(result.Value, Is.EqualTo(value));
        }

        public static IEnumerable Units
        {
            get
            {
                yield return new Meter(100);
                yield return new Inch(60);
                yield return new Millimeter(75.45);
                // yield return new InchSquared(2, 5);
                // yield return new MeterCubed(65, 76, 90);
                yield return new Ampere(254.653);
                yield return new Week(254.653);
            }
        }

    }

}