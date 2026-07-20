using System;
using System.Collections.Generic;
using System.Linq;
using TopengineerPlugin.Models;
using TopengineerPlugin.Utilities;

namespace TopengineerPlugin.Reports
{
    /// <summary>
    /// Generates technical reports according to GOST standards
    /// </summary>
    public class ReportGenerator
    {
        private Logger _logger;
        private List<Bolt> _bolts;
        private List<Profile> _profiles;
        private List<Material> _materials;
        private List<Weld> _welds;

        public ReportGenerator()
        {
            _logger = new Logger("ReportGenerator");
            _bolts = new List<Bolt>();
            _profiles = new List<Profile>();
            _materials = new List<Material>();
            _welds = new List<Weld>();
        }

        /// <summary>
        /// Generate technical specification (КМ - Конструктивные Металлоконструкции)
        /// </summary>
        public Dictionary<string, object> GenerateTechnicalSpecification()
        {
            try
            {
                _logger.Log("Generating technical specification (КМ)");

                var specification = new Dictionary<string, object>
                {
                    { "Title", "Техническая спецификация. Конструктивные металлоконструкции" },
                    { "Date", DateTime.Now.ToString("dd.MM.yyyy") },
                    { "TotalItems", _profiles.Count + _bolts.Count },
                    { "Profiles", GenerateProfilesTable() },
                    { "Bolts", GenerateBoltsTable() },
                    { "TotalMass", CalculateTotalMass() }
                };

                _logger.Log("Technical specification generated successfully");
                return specification;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error generating technical specification: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Generate steel consumption report (КЖ - Конструктивные Жесткие)
        /// </summary>
        public Dictionary<string, object> GenerateSteelConsumptionReport()
        {
            try
            {
                _logger.Log("Generating steel consumption report (КЖ)");

                double totalConsumption = 0;
                var materialBreakdown = new Dictionary<string, double>();

                foreach (var profile in _profiles)
                {
                    double mass = profile.MassPerMeter;
                    totalConsumption += mass;

                    string materialKey = "Сталь";
                    if (!materialBreakdown.ContainsKey(materialKey))
                        materialBreakdown[materialKey] = 0;
                    materialBreakdown[materialKey] += mass;
                }

                var report = new Dictionary<string, object>
                {
                    { "Title", "Ведомость расхода стали" },
                    { "Date", DateTime.Now.ToString("dd.MM.yyyy") },
                    { "TotalConsumption", Math.Round(totalConsumption, 2) },
                    { "MaterialBreakdown", materialBreakdown },
                    { "Unit", "кг" }
                };

                _logger.Log("Steel consumption report generated successfully");
                return report;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error generating steel consumption report: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Generate welding report
        /// </summary>
        public Dictionary<string, object> GenerateWeldingReport()
        {
            try
            {
                _logger.Log("Generating welding report");

                double totalWeldLength = 0;
                double totalWeldMass = 0;
                var weldsByType = new Dictionary<string, int>();

                foreach (var weld in _welds)
                {
                    totalWeldLength += weld.Length;
                    totalWeldMass += weld.CalculateWeldMass();

                    string weldType = weld.Type.ToString();
                    if (!weldsByType.ContainsKey(weldType))
                        weldsByType[weldType] = 0;
                    weldsByType[weldType]++;
                }

                var report = new Dictionary<string, object>
                {
                    { "Title", "Ведомость сварных швов" },
                    { "Date", DateTime.Now.ToString("dd.MM.yyyy") },
                    { "TotalWelds", _welds.Count },
                    { "TotalWeldLength", Math.Round(totalWeldLength, 2) },
                    { "TotalWeldMass", Math.Round(totalWeldMass, 3) },
                    { "WeldsByType", weldsByType }
                };

                _logger.Log("Welding report generated successfully");
                return report;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error generating welding report: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Generate cutting map for profiles
        /// </summary>
        public Dictionary<string, object> GenerateCuttingMap()
        {
            try
            {
                _logger.Log("Generating cutting map for profiles");

                var cuttingMap = new Dictionary<string, object>
                {
                    { "Title", "Карта раскроя проката" },
                    { "Date", DateTime.Now.ToString("dd.MM.yyyy") },
                    { "StockLength", 12000 }, // Standard 12m stock
                    { "Profiles", new List<Dictionary<string, object>>() }
                };

                var profiles = cuttingMap["Profiles"] as List<Dictionary<string, object>>;
                
                foreach (var profile in _profiles)
                {
                    profiles.Add(new Dictionary<string, object>
                    {
                        { "Designation", profile.GOSTDesignation },
                        { "MassPerMeter", profile.MassPerMeter },
                        { "Quantity", 1 },
                        { "TotalLength", profile.Height }
                    });
                }

                _logger.Log("Cutting map generated successfully");
                return cuttingMap;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error generating cutting map: {ex.Message}");
                return null;
            }
        }

        private List<Dictionary<string, object>> GenerateProfilesTable()
        {
            var table = new List<Dictionary<string, object>>();
            foreach (var profile in _profiles)
            {
                table.Add(new Dictionary<string, object>
                {
                    { "Designation", profile.GOSTDesignation },
                    { "Type", profile.Type.ToString() },
                    { "MassPerMeter", profile.MassPerMeter },
                    { "GOST", profile.GOSTStandard }
                });
            }
            return table;
        }

        private List<Dictionary<string, object>> GenerateBoltsTable()
        {
            var table = new List<Dictionary<string, object>>();
            foreach (var bolt in _bolts)
            {
                table.Add(new Dictionary<string, object>
                {
                    { "Diameter", bolt.Diameter },
                    { "Length", bolt.Length },
                    { "Grade", bolt.Grade },
                    { "Mass", bolt.MassPerPiece },
                    { "GOST", bolt.GOSTDesignation }
                });
            }
            return table;
        }

        private double CalculateTotalMass()
        {
            double totalMass = 0;
            foreach (var profile in _profiles)
            {
                totalMass += profile.MassPerMeter;
            }
            foreach (var bolt in _bolts)
            {
                totalMass += bolt.MassPerPiece;
            }
            return Math.Round(totalMass, 2);
        }

        public void AddProfile(Profile profile)
        {
            _profiles.Add(profile);
        }

        public void AddBolt(Bolt bolt)
        {
            _bolts.Add(bolt);
        }

        public void AddWeld(Weld weld)
        {
            _welds.Add(weld);
        }
    }
}
