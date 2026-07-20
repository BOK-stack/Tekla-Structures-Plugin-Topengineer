using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TopengineerPlugin.Utilities
{
    /// <summary>
    /// Helper methods for common operations
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Round value to nearest mm according to GOST
        /// </summary>
        public static double RoundToMillimeter(double value)
        {
            return Math.Round(value, 0);
        }

        /// <summary>
        /// Convert millimeters to meters
        /// </summary>
        public static double MmToMeters(double mm)
        {
            return Math.Round(mm / 1000, 3);
        }

        /// <summary>
        /// Convert meters to millimeters
        /// </summary>
        public static double MetersToMm(double meters)
        {
            return meters * 1000;
        }

        /// <summary>
        /// Format number with Russian locale
        /// </summary>
        public static string FormatNumberRU(double value)
        {
            return value.ToString("F2").Replace(".", ",");
        }

        /// <summary>
        /// Get GOST profile name
        /// </summary>
        public static string ConvertToGOSTProfile(string profileName)
        {
            // ДВУТАВР25Б1 -> I25B1
            Dictionary<string, string> profileMap = new Dictionary<string, string>
            {
                { "ДВУТАВР", "I" },
                { "ШВЕЛЛЕР", "C" },
                { "УГОЛОК", "L" },
                { "ТРУБА", "Tube" }
            };

            foreach (var kvp in profileMap)
            {
                if (profileName.StartsWith(kvp.Key))
                {
                    return profileName.Replace(kvp.Key, kvp.Value);
                }
            }

            return profileName;
        }

        /// <summary>
        /// Convert bolt length to GOST standard
        /// </summary>
        public static int[] GetGOSTBoltLengths(double diameter)
        {
            // GOST 7798 standard bolt lengths
            Dictionary<double, int[]> boltLengths = new Dictionary<double, int[]>
            {
                { 6, new int[] { 12, 16, 20, 25, 30, 35, 40, 45, 50 } },
                { 8, new int[] { 16, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65 } },
                { 10, new int[] { 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80 } },
                { 12, new int[] { 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90 } },
                { 14, new int[] { 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100 } },
                { 16, new int[] { 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 100, 110 } }
            };

            if (boltLengths.ContainsKey(diameter))
            {
                return boltLengths[diameter];
            }

            return null;
        }

        /// <summary>
        /// Calculate weld size based on material thickness
        /// </summary>
        public static double CalculateWeldSize(double thickness)
        {
            // GOST 14776 standard weld sizes
            if (thickness <= 5)
                return 3;
            if (thickness <= 8)
                return 5;
            if (thickness <= 12)
                return 6;
            if (thickness <= 20)
                return 8;
            if (thickness <= 30)
                return 10;
            return 12;
        }

        /// <summary>
        /// Validate GOST designation format
        /// </summary>
        public static bool IsValidGOSTFormat(string designation)
        {
            if (string.IsNullOrWhiteSpace(designation))
                return false;

            // Check for Cyrillic characters (Russian)
            Regex russianPattern = new Regex(@"[а-яёА-ЯЁ]");
            return russianPattern.IsMatch(designation);
        }

        /// <summary>
        /// Calculate steel consumption
        /// </summary>
        public static double CalculateSteelConsumption(double volume, double density = 7850)
        {
            // Density in kg/m³
            return Math.Round((volume * density) / 1000, 2);
        }

        /// <summary>
        /// Get material density in kg/m³
        /// </summary>
        public static double GetMaterialDensity(string material)
        {
            Dictionary<string, double> densities = new Dictionary<string, double>
            {
                { "Сталь", 7850 },
                { "Алюминий", 2700 },
                { "Медь", 8960 },
                { "Титан", 4500 },
                { "Чугун", 7200 }
            };

            if (densities.ContainsKey(material))
            {
                return densities[material];
            }

            return 7850; // Default to steel
        }

        /// <summary>
        /// Truncate text to specified length
        /// </summary>
        public static string TruncateText(string text, int maxLength, string suffix = "...")
        {
            if (string.IsNullOrEmpty(text) || text.Length <= maxLength)
                return text;

            return text.Substring(0, maxLength - suffix.Length) + suffix;
        }

        /// <summary>
        /// Safe cast to int
        /// </summary>
        public static int SafeToInt(object value, int defaultValue = 0)
        {
            try
            {
                if (value == null)
                    return defaultValue;

                if (int.TryParse(value.ToString(), out int result))
                    return result;

                return defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Safe cast to double
        /// </summary>
        public static double SafeToDouble(object value, double defaultValue = 0)
        {
            try
            {
                if (value == null)
                    return defaultValue;

                if (double.TryParse(value.ToString(), out double result))
                    return result;

                return defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }
    }
}
