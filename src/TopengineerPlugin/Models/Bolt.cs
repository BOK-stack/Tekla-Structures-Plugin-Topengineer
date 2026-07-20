using System;
using TopengineerPlugin.Utilities;

namespace TopengineerPlugin.Models
{
    /// <summary>
    /// Model representing a bolt according to GOST standards
    /// </summary>
    public class Bolt
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Bolt diameter in millimeters
        /// </summary>
        public double Diameter { get; set; }

        /// <summary>
        /// Bolt length in millimeters
        /// </summary>
        public double Length { get; set; }

        /// <summary>
        /// Bolt pitch (coarse or fine)
        /// </summary>
        public double Pitch { get; set; }

        /// <summary>
        /// GOST designation (e.g., ГОСТ 7798)
        /// </summary>
        public string GOSTDesignation { get; set; }

        /// <summary>
        /// Material grade (e.g., 5.8, 8.8, 10.9)
        /// </summary>
        public string Grade { get; set; }

        /// <summary>
        /// Is high-strength bolt
        /// </summary>
        public bool IsHighStrength { get; set; }

        /// <summary>
        /// Mass per piece in grams
        /// </summary>
        public double MassPerPiece { get; set; }

        /// <summary>
        /// Validate bolt length according to GOST
        /// </summary>
        public bool IsValidLength()
        {
            int[] validLengths = Helper.GetGOSTBoltLengths(Diameter);
            if (validLengths == null)
                return true; // Unknown diameter, assume valid

            foreach (int length in validLengths)
            {
                if (Math.Abs(Length - length) < 0.1)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Get nearest valid GOST length
        /// </summary>
        public double GetNearestValidLength()
        {
            int[] validLengths = Helper.GetGOSTBoltLengths(Diameter);
            if (validLengths == null)
                return Length;

            double nearest = validLengths[0];
            double minDiff = Math.Abs(Length - validLengths[0]);

            foreach (int length in validLengths)
            {
                double diff = Math.Abs(Length - length);
                if (diff < minDiff)
                {
                    minDiff = diff;
                    nearest = length;
                }
            }

            return nearest;
        }

        /// <summary>
        /// Get bolt display name
        /// </summary>
        public string GetDisplayName()
        {
            return $"{GOSTDesignation} {Diameter}x{Length} {Grade}";
        }

        public override string ToString()
        {
            return GetDisplayName();
        }
    }
}
