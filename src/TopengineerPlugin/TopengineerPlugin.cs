using System;
using System.Collections.Generic;
using TopengineerPlugin.Core;
using TopengineerPlugin.Reports;
using TopengineerPlugin.Utilities;

namespace TopengineerPlugin
{
    /// <summary>
    /// Main plugin class for Tekla Structures
    /// Provides automation for metal structure design according to GOST standards
    /// </summary>
    public class TopengineerPlugin
    {
        private static Logger _logger;
        
        public CatalogManager CatalogManager { get; private set; }
        public WeldingAutomation WeldingAutomation { get; private set; }
        public AttributeManager AttributeManager { get; private set; }
        public DrawingAutomation DrawingAutomation { get; private set; }
        public ReportGenerator ReportGenerator { get; private set; }
        public ExcelExporter ExcelExporter { get; private set; }

        /// <summary>
        /// Initialize the plugin
        /// </summary>
        public TopengineerPlugin()
        {
            _logger = new Logger("TopengineerPlugin");
            
            try
            {
                _logger.Log("Initializing Topengineer Plugin...");
                
                // Initialize all modules
                CatalogManager = new CatalogManager();
                WeldingAutomation = new WeldingAutomation();
                AttributeManager = new AttributeManager();
                DrawingAutomation = new DrawingAutomation();
                ReportGenerator = new ReportGenerator();
                ExcelExporter = new ExcelExporter();

                _logger.Log("Topengineer Plugin initialized successfully");
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed to initialize plugin: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Show main plugin dialog
        /// </summary>
        public void ShowMainDialog()
        {
            try
            {
                _logger.Log("Opening main dialog");
                // TODO: Implement main dialog window
                _logger.Log("Main dialog opened");
            }
            catch (Exception ex)
            {
                _logger.Error($"Error showing main dialog: {ex.Message}");
            }
        }

        /// <summary>
        /// Run automatic assembly comparison
        /// </summary>
        public void CompareAssemblies()
        {
            try
            {
                _logger.Log("Starting assembly comparison");
                AttributeManager.CompareAssemblies();
                _logger.Log("Assembly comparison completed");
            }
            catch (Exception ex)
            {
                _logger.Error($"Error comparing assemblies: {ex.Message}");
            }
        }

        /// <summary>
        /// Generate all reports for current model
        /// </summary>
        public void GenerateAllReports()
        {
            try
            {
                _logger.Log("Generating all reports");
                ReportGenerator.GenerateTechnicalSpecification();
                ReportGenerator.GenerateSteelConsumptionReport();
                ReportGenerator.GenerateWeldingReport();
                ReportGenerator.GenerateCuttingMap();
                _logger.Log("All reports generated successfully");
            }
            catch (Exception ex)
            {
                _logger.Error($"Error generating reports: {ex.Message}");
            }
        }

        /// <summary>
        /// Apply automatic welding to model
        /// </summary>
        public void ApplyAutomaticWelding()
        {
            try
            {
                _logger.Log("Applying automatic welding");
                WeldingAutomation.AutoPlaceWelds();
                WeldingAutomation.AutoSelectWeldSize();
                _logger.Log("Automatic welding applied");
            }
            catch (Exception ex)
            {
                _logger.Error($"Error applying welding: {ex.Message}");
            }
        }

        /// <summary>
        /// Get plugin version
        /// </summary>
        public string GetVersion()
        {
            return "1.0.0";
        }

        /// <summary>
        /// Get plugin name
        /// </summary>
        public string GetPluginName()
        {
            return "Topengineer Plugin for Tekla Structures";
        }
    }
}
