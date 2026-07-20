using System;
using System.Collections.Generic;
using TopengineerPlugin.Utilities;

namespace TopengineerPlugin.Reports
{
    /// <summary>
    /// Generates technical specifications according to GOST standards
    /// </summary>
    public class SpecificationGenerator
    {
        private Logger _logger;

        public SpecificationGenerator()
        {
            _logger = new Logger("SpecificationGenerator");
        }

        /// <summary>
        /// Generate specification header (ГОСТ 2.106-96)
        /// </summary>
        public Dictionary<string, object> GenerateSpecificationHeader()
        {
            try
            {
                _logger.Log("Generating specification header");

                var header = new Dictionary<string, object>
                {
                    { "GOST", "ГОСТ 2.106-96" },
                    { "Title", "Спецификация" },
                    { "Format", "A4" },
                    { "Date", DateTime.Now.ToString("dd.MM.yyyy") },
                    { "Sections", new List<string>
                        {
                            "Документы",
                            "Сборочные единицы",
                            "Детали",
                            "Стандартные изделия",
                            "Прочие изделия",
                            "Материалы"
                        }
                    }
                };

                _logger.Log("Specification header generated successfully");
                return header;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error generating specification header: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Generate fastener specification section
        /// </summary>
        public List<Dictionary<string, object>> GenerateFastenerSpecification(List<Dictionary<string, object>> fasteners)
        {
            try
            {
                _logger.Log("Generating fastener specification");

                var specification = new List<Dictionary<string, object>>();

                foreach (var fastener in fasteners)
                {
                    specification.Add(new Dictionary<string, object>
                    {
                        { "Position", fastener["Position"] ?? "" },
                        { "Designation", fastener["Designation"] ?? "" },
                        { "Grade", fastener["Grade"] ?? "" },
                        { "Quantity", fastener["Quantity"] ?? 0 },
                        { "Unit", "шт" },
                        { "Remark", fastener["Remark"] ?? "" }
                    });
                }

                _logger.Log($"Fastener specification generated for {specification.Count} items");
                return specification;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error generating fastener specification: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Generate material specification section
        /// </summary>
        public List<Dictionary<string, object>> GenerateMaterialSpecification(List<Dictionary<string, object>> materials)
        {
            try
            {
                _logger.Log("Generating material specification");

                var specification = new List<Dictionary<string, object>>();

                foreach (var material in materials)
                {
                    specification.Add(new Dictionary<string, object>
                    {
                        { "Position", material["Position"] ?? "" },
                        { "Material", material["Material"] ?? "" },
                        { "Grade", material["Grade"] ?? "" },
                        { "Mass", material["Mass"] ?? 0 },
                        { "Unit", "кг" },
                        { "Remark", material["Remark"] ?? "" }
                    });
                }

                _logger.Log($"Material specification generated for {specification.Count} items");
                return specification;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error generating material specification: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Validate specification structure (ГОСТ 2.106-96)
        /// </summary>
        public bool ValidateSpecification(Dictionary<string, object> specification)
        {
            try
            {
                _logger.Log("Validating specification structure");

                var requiredFields = new[] { "Title", "Date", "Sections" };

                foreach (var field in requiredFields)
                {
                    if (!specification.ContainsKey(field))
                    {
                        _logger.Warning($"Missing required field: {field}");
                        return false;
                    }
                }

                _logger.Log("Specification validation passed");
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error validating specification: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Round mass values according to GOST requirements
        /// </summary>
        public double RoundMassAccordingToGOST(double mass)
        {
            if (mass < 10)
                return Math.Round(mass, 1);
            if (mass < 100)
                return Math.Round(mass, 0);
            if (mass < 1000)
                return Math.Round(mass / 5) * 5;
            return Math.Round(mass / 10) * 10;
        }
    }
}
