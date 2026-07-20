# API Reference

## Пространства имен

### TopengineerPlugin
Главное пространство имен плагина

### TopengineerPlugin.Core
Основные функциональные модули

### TopengineerPlugin.Models
Модели данных

### TopengineerPlugin.Reports
Модули отчетности

### TopengineerPlugin.Config
Конфигурация и настройки

### TopengineerPlugin.Utilities
Вспомогательные функции

---

## Класс TopengineerPlugin

### Свойства

```csharp
public CatalogManager CatalogManager { get; }
public WeldingAutomation WeldingAutomation { get; }
public AttributeManager AttributeManager { get; }
public DrawingAutomation DrawingAutomation { get; }
public ReportGenerator ReportGenerator { get; }
public ExcelExporter ExcelExporter { get; }
```

### Методы

```csharp
public void ShowMainDialog()
public void CompareAssemblies()
public void GenerateAllReports()
public void ApplyAutomaticWelding()
public string GetVersion()
public string GetPluginName()
```

---

## Класс CatalogManager

### Методы

```csharp
// Болты
public Bolt GetBolt(double diameter, double length)
public double FindValidBoltLength(double diameter, double requestedLength)
public void AddCustomBolt(Bolt bolt)
public List<Bolt> GetAllBolts()

// Профили
public Profile GetProfile(string designation)
public List<Profile> SearchProfiles(Profile.ProfileType type)
public void AddCustomProfile(Profile profile)
public List<Profile> GetAllProfiles()

// Материалы
public Material GetMaterial(string designation)
public List<Material> GetAllMaterials()
```

---

## Класс Bolt

### Свойства

```csharp
public int Id { get; set; }
public double Diameter { get; set; }
public double Length { get; set; }
public double Pitch { get; set; }
public string GOSTDesignation { get; set; }
public string Grade { get; set; }
public bool IsHighStrength { get; set; }
public double MassPerPiece { get; set; }
```

### Методы

```csharp
public bool IsValidLength()
public double GetNearestValidLength()
public string GetDisplayName()
```

---

## Класс Profile

### Свойства

```csharp
public int Id { get; set; }
public ProfileType Type { get; set; }
public string GOSTDesignation { get; set; }
public string EnglishDesignation { get; set; }
public double Height { get; set; }
public double Width { get; set; }
public double FlangeThickness { get; set; }
public double WebThickness { get; set; }
public double MassPerMeter { get; set; }
public bool IsRolled { get; set; }
public string GOSTStandard { get; set; }
```

### Методы

```csharp
public string ConvertToGOST()
public double CalculateMass(double length)
public string GetDisplayName()
```

---

## Класс Weld

### Свойства

```csharp
public int Id { get; set; }
public WeldType Type { get; set; }
public WeldPosition Position { get; set; }
public double LegSize { get; set; }
public double Length { get; set; }
public double MaterialThickness { get; set; }
public string GOSTDesignation { get; set; }
public string WeldingMethod { get; set; }
public int NumberOfPasses { get; set; }
```

### Методы

```csharp
public void CalculateRecommendedLegSize()
public double CalculateWeldMass(double density = 7850)
public string GetDisplayName()
public bool IsValid()
```

---

## Класс WeldingAutomation

### Методы

```csharp
public void AutoPlaceWelds()
public void AutoSelectWeldSize()
public void AddWeld(Weld weld)
public Dictionary<string, object> GenerateWeldReport()
public List<Weld> GetAllWelds()
public void ClearWelds()
public bool ValidateWeldDisplayOnDrawing(Weld weld)
```

---

## Класс AttributeManager

### Методы

```csharp
public void SetPrefix(string prefixName, object value)
public object GetPrefix(string prefixName)
public void SetAttribute(string attributeName, object value)
public object GetAttribute(string attributeName)
public void TransferAttribute(string sourceAttribute, string targetAttribute)
public Dictionary<string, object> CompareAssemblies(Dictionary<string, object> assembly1, Dictionary<string, object> assembly2)
public void CompareAssemblies()
public Dictionary<string, object> GetAllPrefixes()
public Dictionary<string, object> GetAllAttributes()
```

---

## Класс DrawingAutomation

### Методы

```csharp
public void SetDrawingSetting(string key, object value)
public object GetDrawingSetting(string key)
public void GenerateTitleBlock(string projectName, string drawingNumber, string engineer, DateTime date)
public void AutoPlaceDetailViews(List<string> detailIds)
public void AutomaticallyDimension()
public void ConvertSectionMarksToNumbers()
public void RoundAllDimensions()
public void ConvertHeightMarksToMeters()
public void AddGOSTBreakLines()
public void GenerateBuildingLayoutOnAssemblyDrawing()
public Dictionary<string, object> GetAllDrawingSettings()
```

---

## Класс ReportGenerator

### Методы

```csharp
public Dictionary<string, object> GenerateTechnicalSpecification()
public Dictionary<string, object> GenerateSteelConsumptionReport()
public Dictionary<string, object> GenerateWeldingReport()
public Dictionary<string, object> GenerateCuttingMap()
public void AddReportData(Dictionary<string, object> data)
```

---

## Класс ExcelExporter

### Методы

```csharp
public bool ExportToExcel(Dictionary<string, object> reportData, string filePath)
public bool ExportToCSV(Dictionary<string, object> data, string filePath)
public bool ExportTableToExcel(List<Dictionary<string, object>> tableData, string filePath, string sheetName = "Sheet1")
public string GetDefaultExcelPath(string fileName)
```

---

## Класс SpecificationGenerator

### Методы

```csharp
public Dictionary<string, object> GenerateSpecificationHeader()
public List<Dictionary<string, object>> GenerateFastenerSpecification(List<Dictionary<string, object>> fasteners)
public List<Dictionary<string, object>> GenerateMaterialSpecification(List<Dictionary<string, object>> materials)
public bool ValidateSpecification(Dictionary<string, object> specification)
public double RoundMassAccordingToGOST(double mass)
```

---

## Класс GOSTSettings

### Методы

```csharp
public object GetSetting(string key)
public void SetSetting(string key, object value)
public string GetStringSetting(string key, string defaultValue = "")
public bool GetBooleanSetting(string key, bool defaultValue = false)
public double GetNumericSetting(string key, double defaultValue = 0)
public void ResetToDefaults()
public Dictionary<string, object> GetAllSettings()
public bool ValidateSettings()
```

---

## Класс Logger

### Методы

```csharp
public void Log(string message)
public void Warning(string message)
public void Error(string message)
public void Debug(string message)
public string GetLogFilePath()
public void CleanOldLogs(int daysToKeep = 30)
```

---

## Класс Helper

### Статические методы

```csharp
public static double RoundToMillimeter(double value)
public static double MmToMeters(double mm)
public static double MetersToMm(double meters)
public static string FormatNumberRU(double value)
public static string ConvertToGOSTProfile(string profileName)
public static int[] GetGOSTBoltLengths(double diameter)
public static double CalculateWeldSize(double thickness)
public static bool IsValidGOSTFormat(string designation)
public static double CalculateSteelConsumption(double volume, double density = 7850)
public static double GetMaterialDensity(string material)
public static string TruncateText(string text, int maxLength, string suffix = "...")
public static int SafeToInt(object value, int defaultValue = 0)
public static double SafeToDouble(object value, double defaultValue = 0)
```
