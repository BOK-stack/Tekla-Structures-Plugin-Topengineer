using System;
using System.Collections.Generic;
using TopengineerPlugin.Utilities;

namespace TopengineerPlugin.Config
{
    /// <summary>
    /// GOST settings and configuration for the plugin
    /// </summary>
    public class GOSTSettings
    {
        private Logger _logger;
        private Dictionary<string, object> _settings;

        public GOSTSettings()
        {
            _logger = new Logger("GOSTSettings");
            _settings = new Dictionary<string, object>();
            InitializeDefaultSettings();
        }

        private void InitializeDefaultSettings()
        {
            // Размеры и единицы измерения
            _settings["DefaultUnit"] = "mm"; // миллиметры
            _settings["MassUnit"] = "kg"; // килограммы
            _settings["LengthUnit"] = "m"; // метры

            // Стандарты
            _settings["BOLTStandard"] = "ГОСТ 7798-70"; // Болты
            _settings["ProfileStandard"] = "ГОСТ 8239-89"; // Двутавры
            _settings["ChannelStandard"] = "ГОСТ 8240-89"; // Швеллеры
            _settings["AngleStandard"] = "ГОСТ 8509-93"; // Уголки
            _settings["DrawingStandard"] = "ГОСТ 2.106-96"; // Спецификация
            _settings["WeldingStandard"] = "ГОСТ 2.312-72"; // Сварка

            // Цвета (RGB hex)
            _settings["HighStrengthBoltColor"] = "#FF0000"; // Красный
            _settings["StandardBoltColor"] = "#0000FF"; // Синий
            _settings["WeldColor"] = "#FFA500"; // Оранжевый

            // Параметры округления
            _settings["RoundDimensionsTo"] = 1; // 1 мм
            _settings["RoundMassDecimalPlaces"] = 2; // 2 знака

            // Параметры печати
            _settings["DefaultPaperSize"] = "A3";
            _settings["DefaultScale"] = "1:1";
            _settings["DefaultLineWeight"] = 0.7; // mm

            // Автоматизация
            _settings["AutoRoundDimensions"] = true;
            _settings["AutoGenerateTitleBlock"] = true;
            _settings["AutoPlaceWelds"] = false;
            _settings["AutoSelectWeldSize"] = true;

            // Форматирование текста
            _settings["UseRussianDesignations"] = true;
            _settings["DateFormat"] = "dd.MM.yyyy";
            _settings["DecimalSeparator"] = ","; // Запятая для России

            _logger.Log("Default GOST settings initialized");
        }

        /// <summary>
        /// Get setting value
        /// </summary>
        public object GetSetting(string key)
        {
            if (_settings.ContainsKey(key))
                return _settings[key];

            _logger.Warning($"Setting '{key}' not found");
            return null;
        }

        /// <summary>
        /// Set setting value
        /// </summary>
        public void SetSetting(string key, object value)
        {
            _settings[key] = value;
            _logger.Log($"Setting '{key}' set to '{value}'");
        }

        /// <summary>
        /// Get string setting
        /// </summary>
        public string GetStringSetting(string key, string defaultValue = "")
        {
            var value = GetSetting(key);
            return value?.ToString() ?? defaultValue;
        }

        /// <summary>
        /// Get boolean setting
        /// </summary>
        public bool GetBooleanSetting(string key, bool defaultValue = false)
        {
            var value = GetSetting(key);
            if (value is bool)
                return (bool)value;
            if (bool.TryParse(value?.ToString() ?? "", out bool result))
                return result;
            return defaultValue;
        }

        /// <summary>
        /// Get numeric setting
        /// </summary>
        public double GetNumericSetting(string key, double defaultValue = 0)
        {
            var value = GetSetting(key);
            if (value is double)
                return (double)value;
            if (double.TryParse(value?.ToString() ?? "", out double result))
                return result;
            return defaultValue;
        }

        /// <summary>
        /// Reset to default settings
        /// </summary>
        public void ResetToDefaults()
        {
            _settings.Clear();
            InitializeDefaultSettings();
            _logger.Log("Settings reset to defaults");
        }

        /// <summary>
        /// Get all settings
        /// </summary>
        public Dictionary<string, object> GetAllSettings()
        {
            return new Dictionary<string, object>(_settings);
        }

        /// <summary>
        /// Validate all settings
        /// </summary>
        public bool ValidateSettings()
        {
            try
            {
                _logger.Log("Validating GOST settings");

                // Check required standards
                string[] requiredStandards = {
                    "BOLTStandard", "ProfileStandard", "DrawingStandard", "WeldingStandard"
                };

                foreach (var standard in requiredStandards)
                {
                    if (!_settings.ContainsKey(standard))
                    {
                        _logger.Warning($"Missing required standard: {standard}");
                        return false;
                    }
                }

                _logger.Log("Settings validation passed");
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error validating settings: {ex.Message}");
                return false;
            }
        }
    }
}
