using System;
using TopengineerPlugin.Utilities;

namespace TopengineerPlugin.Models
{
    /// <summary>
    /// Model representing a weld according to GOST standards
    /// </summary>
    public class Weld
    {
        /// <summary>
        /// Weld types
        /// </summary>
        public enum WeldType
        {
            FilletWeld,        // Угловой шов
            ButWeld,           // Стыковой шов
            PlugWeld,          // Пробочный шов
            SlotWeld           // Щелевой шов
        }

        /// <summary>
        /// Weld positions
        /// </summary>
        public enum WeldPosition
        {
            Flat,              // Нижнее положение
            Horizontal,        // Горизонтальное положение
            Vertical,          // Вертикальное положение
            Overhead           // Потолочное положение
        }

        /// <summary>
        /// Unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Weld type
        /// </summary>
        public WeldType Type { get; set; }

        /// <summary>
        /// Weld position
        /// </summary>
        public WeldPosition Position { get; set; }

        /// <summary>
        /// Leg size (катет) in millimeters for fillet welds
        /// </summary>
        public double LegSize { get; set; }

        /// <summary>
        /// Weld length in millimeters
        /// </summary>
        public double Length { get; set; }

        /// <summary>
        /// Material thickness in millimeters
        /// </summary>
        public double MaterialThickness { get; set; }

        /// <summary>
        /// GOST designation
        /// </summary>
        public string GOSTDesignation { get; set; }

        /// <summary>
        /// Welding method (e.g., ручная дуговая - manual arc)
        /// </summary>
        public string WeldingMethod { get; set; }

        /// <summary>
        /// Number of passes (слоев)
        /// </summary>
        public int NumberOfPasses { get; set; }

        /// <summary>
        /// Calculate recommended leg size based on material thickness
        /// </summary>
        public void CalculateRecommendedLegSize()
        {
            LegSize = Helper.CalculateWeldSize(MaterialThickness);
        }

        /// <summary>
        /// Calculate weld mass (approximate)
        /// </summary>
        public double CalculateWeldMass(double density = 7850)
        {
            // Approximate volume for fillet weld: V = (leg_size^2 / 2) * length
            double volumeMm3 = (LegSize * LegSize / 2) * Length * NumberOfPasses;
            double volumeM3 = volumeMm3 / 1e9;
            return Math.Round(volumeM3 * density, 3);
        }

        /// <summary>
        /// Get weld display name
        /// </summary>
        public string GetDisplayName()
        {
            return $"{Type} {LegSize}x{Length} ({GOSTDesignation})";
        }

        /// <summary>
        /// Validate weld parameters
        /// </summary>
        public bool IsValid()
        {
            if (LegSize <= 0 || Length <= 0 || MaterialThickness <= 0)
                return false;

            // Check leg size vs material thickness
            if (LegSize > MaterialThickness)
                return false;

            return true;
        }

        public override string ToString()
        {
            return GetDisplayName();
        }
    }
}
