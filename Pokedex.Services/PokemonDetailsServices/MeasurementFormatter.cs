using System.Globalization;

namespace Pokedex.Services
{
    /// <summary>
    /// Formats raw API measurements (expressed in tenths of a unit) into culture-invariant display strings.
    /// </summary>
    internal static class MeasurementFormatter
    {
        public static string Format(int rawValue, string unit)
        {
            var value = rawValue / 10f;
            return string.Concat(value.ToString(CultureInfo.InvariantCulture), " ", unit);
        }
    }
}
