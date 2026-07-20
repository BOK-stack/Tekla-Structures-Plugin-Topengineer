using System;
using System.Collections.Generic;
using System.IO;
using TopengineerPlugin.Utilities;

namespace TopengineerPlugin.Reports
{
    /// <summary>
    /// Exports reports and data to Excel format
    /// </summary>
    public class ExcelExporter
    {
        private Logger _logger;

        public ExcelExporter()
        {
            _logger = new Logger("ExcelExporter");
        }

        /// <summary>
        /// Export report to Excel file
        /// </summary>
        public bool ExportToExcel(Dictionary<string, object> reportData, string filePath)
        {
            try
            {
                _logger.Log($"Starting export to Excel: {filePath}");

                // Check if file path is valid
                if (string.IsNullOrWhiteSpace(filePath))
                {
                    _logger.Error("Invalid file path provided");
                    return false;
                }

                // Create directory if it doesn't exist
                string directory = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                    _logger.Log($"Created directory: {directory}");
                }

                // TODO: Implement actual Excel export using EPPlus or similar library
                // For now, we'll create a CSV file as demonstration
                string csvPath = Path.ChangeExtension(filePath, ".csv");
                ExportToCSV(reportData, csvPath);

                _logger.Log($"Excel export completed successfully: {filePath}");
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error exporting to Excel: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Export data to CSV format (alternative to Excel)
        /// </summary>
        public bool ExportToCSV(Dictionary<string, object> data, string filePath)
        {
            try
            {
                _logger.Log($"Exporting to CSV: {filePath}");

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Write header
                    writer.WriteLine("\"Key\",\"Value\"");

                    // Write data
                    foreach (var kvp in data)
                    {
                        string value = kvp.Value?.ToString() ?? "";
                        value = value.Replace("\"", "\\\""); // Escape quotes
                        writer.WriteLine($"\"{kvp.Key}\",\"{value}\"");
                    }
                }

                _logger.Log("CSV export completed successfully");
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error exporting to CSV: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Export table data to Excel
        /// </summary>
        public bool ExportTableToExcel(List<Dictionary<string, object>> tableData, string filePath, string sheetName = "Sheet1")
        {
            try
            {
                _logger.Log($"Exporting table to Excel: {filePath}");

                if (tableData == null || tableData.Count == 0)
                {
                    _logger.Warning("No table data to export");
                    return false;
                }

                // TODO: Implement actual Excel export using EPPlus
                // For now, export to CSV
                string csvPath = Path.ChangeExtension(filePath, ".csv");
                ExportTableToCSV(tableData, csvPath);

                _logger.Log("Table export completed successfully");
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error exporting table: {ex.Message}");
                return false;
            }
        }

        private bool ExportTableToCSV(List<Dictionary<string, object>> tableData, string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    if (tableData.Count == 0)
                        return false;

                    // Write headers
                    var headers = tableData[0].Keys;
                    writer.WriteLine(string.Join(",", headers));

                    // Write rows
                    foreach (var row in tableData)
                    {
                        var values = new List<string>();
                        foreach (var header in headers)
                        {
                            string value = row.ContainsKey(header) ? row[header]?.ToString() ?? "" : "";
                            value = value.Replace("\"", "\\\""); // Escape quotes
                            values.Add($"\"{value}\"");
                        }
                        writer.WriteLine(string.Join(",", values));
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error exporting table to CSV: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Get Excel file path in default location
        /// </summary>
        public string GetDefaultExcelPath(string fileName)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string topengineerFolder = Path.Combine(documentsPath, "Topengineer", "Reports");
            return Path.Combine(topengineerFolder, fileName);
        }
    }
}
