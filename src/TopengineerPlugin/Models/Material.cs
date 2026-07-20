using System;
using TopengineerPlugin.Utilities;

namespace TopengineerPlugin.Models
{
    /// <summary>
    /// Model representing a material according to GOST standards
    /// </summary>
    public class Material
    {
        /// <summary>
        /// Material types
        /// </summary>
        public enum MaterialType
        {
            Steel,
            Aluminum,
            Copper,
            Titanium,
            CastIron,
            Other
        }

        /// <summary>
        /// Unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Material type
        /// </summary>
        public MaterialType Type { get; set; }

        /// <summary>
        /// GOST designation in Russian (e.g., Сталь 3, Сталь 09Г2С)
        /// </summary>
        public string GOSTDesignation { get; set; }

        /// <summary>
        /// English designation
        /// </summary>
        public string EnglishDesignation { get; set; }

        /// <summary>
        /// GOST standard (e.g., ГОСТ 535-88)
        /// </summary>
        public string GOSTStandard { get; set; }

        /// <summary>
        /// Material density in kg/m³
        /// </summary>
        public double Density { get; set; }

        /// <summary>
        /// Yield strength in MPa
        /// </summary>
        public double YieldStrength { get; set; }

        /// <summary>
        /// Tensile strength in MPa
        /// </summary>
        public double TensileStrength { get; set; }

        /// <summary>
        /// Elasticity modulus in GPa
        /// </summary>
        public double ElasticityModulus { get; set; }

        /// <summary>
        /// Color code for visualization
        /// </summary>
        public string ColorCode { get; set; }

        /// <summary>
        /// Calculate mass for given volume
        /// </summary>
        public double CalculateMass(double volumeM3)
        {
            return Math.Round(volumeM3 * Density, 2);
        }

        /// <summary>
        /// Round mass according to GOST requirements
        /// </summary>
        public double RoundMassToGOST(double mass)
        {
            if (mass < 10)
                return Math.Round(mass, 1);
            if (mass < 100)
                return Math.Round(mass, 0);
            if (mass < 1000)
                return Math.Round(mass / 5) * 5;
            return Math.Round(mass / 10) * 10;
        }

        /// <summary>
        /// Get material display name
        /// </summary>
        public string GetDisplayName()
        {
            return $"{GOSTDesignation} (ГОСТ {GOSTStandard})";
        }

        public override string ToString()
        {
            return GetDisplayName();
        }
    }
}
