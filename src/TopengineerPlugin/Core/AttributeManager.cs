using System;
using System.Collections.Generic;
using TopengineerPlugin.Utilities;

namespace TopengineerPlugin.Core
{
    /// <summary>
    /// Manages attributes and prefixes in the model
    /// </summary>
    public class AttributeManager
    {
        private Logger _logger;
        private Dictionary<string, object> _prefixes;
        private Dictionary<string, object> _attributes;

        public AttributeManager()
        {
            _logger = new Logger("AttributeManager");
            _prefixes = new Dictionary<string, object>();
            _attributes = new Dictionary<string, object>();
            InitializeDefaultPrefixes();
        }

        private void InitializeDefaultPrefixes()
        {
            _prefixes["KM"] = "Конструктивные Металлоконструкции";
            _prefixes["KMD"] = "Конструктивные Металлоконструкции Детали";
            _prefixes["KZh"] = "Конструктивные Жесткие";
            _prefixes["AR"] = "Архитектурные";
            _logger.Log("Default prefixes initialized");
        }

        /// <summary>
        /// Set prefix value
        /// </summary>
        public void SetPrefix(string prefixName, object value)
        {
            _prefixes[prefixName] = value;
            _logger.Log($"Prefix '{prefixName}' set to '{value}'");
        }

        /// <summary>
        /// Get prefix value
        /// </summary>
        public object GetPrefix(string prefixName)
        {
            if (_prefixes.ContainsKey(prefixName))
                return _prefixes[prefixName];
            return null;
        }

        /// <summary>
        /// Set attribute
        /// </summary>
        public void SetAttribute(string attributeName, object value)
        {
            _attributes[attributeName] = value;
            _logger.Log($"Attribute '{attributeName}' set");
        }

        /// <summary>
        /// Get attribute
        /// </summary>
        public object GetAttribute(string attributeName)
        {
            if (_attributes.ContainsKey(attributeName))
                return _attributes[attributeName];
            return null;
        }

        /// <summary>
        /// Transfer attribute from one field to another
        /// </summary>
        public void TransferAttribute(string sourceAttribute, string targetAttribute)
        {
            try
            {
                if (_attributes.ContainsKey(sourceAttribute))
                {
                    var value = _attributes[sourceAttribute];
                    _attributes[targetAttribute] = value;
                    _logger.Log($"Attribute transferred from '{sourceAttribute}' to '{targetAttribute}'");
                }
                else
                {
                    _logger.Warning($"Source attribute '{sourceAttribute}' not found");
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Error transferring attribute: {ex.Message}");
            }
        }

        /// <summary>
        /// Compare two assemblies
        /// </summary>
        public Dictionary<string, object> CompareAssemblies(Dictionary<string, object> assembly1, Dictionary<string, object> assembly2)
        {
            try
            {
                var differences = new Dictionary<string, object>();
                _logger.Log("Comparing assemblies");

                // Compare keys and values
                var allKeys = new HashSet<string>();
                foreach (var key in assembly1.Keys) allKeys.Add(key);
                foreach (var key in assembly2.Keys) allKeys.Add(key);

                foreach (var key in allKeys)
                {
                    bool in1 = assembly1.ContainsKey(key);
                    bool in2 = assembly2.ContainsKey(key);

                    if (!in1)
                        differences[$"{key}_Missing_In_Assembly1"] = assembly2[key];
                    else if (!in2)
                        differences[$"{key}_Missing_In_Assembly2"] = assembly1[key];
                    else if (!assembly1[key].Equals(assembly2[key]))
                        differences[$"{key}_Different"] = new object[] { assembly1[key], assembly2[key] };
                }

                _logger.Log($"Assembly comparison completed: {differences.Count} differences found");
                return differences;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error comparing assemblies: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Compare current model assemblies
        /// </summary>
        public void CompareAssemblies()
        {
            try
            {
                _logger.Log("Starting assembly comparison");
                // TODO: Implement Tekla Structures API integration
                _logger.Log("Assembly comparison completed");
            }
            catch (Exception ex)
            {
                _logger.Error($"Error in assembly comparison: {ex.Message}");
            }
        }

        /// <summary>
        /// Get all prefixes
        /// </summary>
        public Dictionary<string, object> GetAllPrefixes()
        {
            return new Dictionary<string, object>(_prefixes);
        }

        /// <summary>
        /// Get all attributes
        /// </summary>
        public Dictionary<string, object> GetAllAttributes()
        {
            return new Dictionary<string, object>(_attributes);
        }
    }
}
