using System;
using TopengineerPlugin.Utilities;

namespace TopengineerPlugin.Models
{
    /// <summary>
    /// Model representing a steel profile according to GOST standards
    /// </summary>
    public class Profile
    {
        /// <summary>
        /// Profile types
        /// </summary>
        public enum ProfileType
        {
            IBeam,      // Двутавр (I-beam)
            Channel,    // Швеллер (Channel)
            Angle,      // Уголок (Angle)
            Tube,       // Труба (Tube)
            Pipe,       // Круглая труба (Round pipe)
            ZProfile,   // Z-профиль
            CProfile    // C-профиль
        }

        /// <summary>
        /// Unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Profile type
        /// </summary>
        public ProfileType Type { get; set; }

        /// <summary>
        /// GOST designation (e.g., ДВУТАВР25Б1 -> I25B1)
        /// </summary>
        public string GOSTDesignation { get; set; }

        /// <summary>
        /// English/Latin designation
        /// </summary>
        public string EnglishDesignation { get; set; }

        /// <summary>
        /// Height in millimeters
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Width in millimeters
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Flange thickness in millimeters
        /// </summary>
        public double FlangeThickness { get; set; }

        /// <summary>
        /// Web thickness in millimeters
        /// </summary>
        public double WebThickness { get; set; }

        /// <summary>
        /// Mass per meter in kg
        /// </summary>
        public double MassPerMeter { get; set; }

        /// <summary>
        /// Is rolled profile (true) or welded (false)
        /// </summary>
        public bool IsRolled { get; set; }

        /// <summary>
        /// GOST standard reference
        /// </summary>
        public string GOSTStandard { get; set; }

        /// <summary>
        /// Convert profile to GOST notation
        /// </summary>
        public string ConvertToGOST()
        {
            return Helper.ConvertToGOSTProfile(EnglishDesignation);
        }

        /// <summary>
        /// Calculate mass for given length
        /// </summary>
        public double CalculateMass(double length)
        {
            return Math.Round((length * MassPerMeter) / 1000, 2);
        }

        /// <summary>
        /// Get profile display name
        /// </summary>
        public string GetDisplayName()
        {
            string profileType = Type.ToString();
            return $"{profileType} {GOSTDesignation} (ГОСТ {GOSTStandard})";
        }

        public override string ToString()
        {
            return GetDisplayName();
        }
    }
}
