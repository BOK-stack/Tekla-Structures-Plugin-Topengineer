# Руководство пользователя

## Основные возможности

### 1. Управление каталогами (Catalogs)

#### Работа с болтами

```csharp
var plugin = new TopengineerPlugin();
var catalogManager = plugin.CatalogManager;

// Получить болт по диаметру и длине
var bolt = catalogManager.GetBolt(diameter: 10, length: 30);

// Получить все болты
var allBolts = catalogManager.GetAllBolts();

// Добавить пользовательский болт
var customBolt = new Bolt
{
    Diameter = 14,
    Length = 45,
    Grade = "10.9",
    GOSTDesignation = "ГОСТ 7798"
};
catalogManager.AddCustomBolt(customBolt);
```

#### Работа с профилями

```csharp
// Получить профиль по обозначению
var profile = catalogManager.GetProfile("I25B1");

// Поиск профилей по типу
var ibeams = catalogManager.SearchProfiles(Profile.ProfileType.IBeam);

// Добавить пользовательский профиль
var customProfile = new Profile
{
    Type = Profile.ProfileType.IBeam,
    GOSTDesignation = "I30B2",
    EnglishDesignation = "I30B2",
    Height = 300,
    Width = 110,
    FlangeThickness = 11,
    WebThickness = 7,
    MassPerMeter = 42.2,
    GOSTStandard = "8239-89"
};
catalogManager.AddCustomProfile(customProfile);
```

#### Работа с материалами

```csharp
// Получить материал по обозначению
var material = catalogManager.GetMaterial("Сталь 3");

// Получить все материалы
var allMaterials = catalogManager.GetAllMaterials();

// Расчет массы по объему
var mass = material.CalculateMass(volumeM3: 0.5);
```

### 2. Генерация отчетов (Reports)

#### Техническая спецификация

```csharp
var reportGenerator = plugin.ReportGenerator;

// Генерировать техническую спецификацию (КМ)
var specification = reportGenerator.GenerateTechnicalSpecification();

// Вывести результат
Console.WriteLine($"Заголовок: {specification["Title"]}");
Console.WriteLine($"Всего позиций: {specification["TotalItems"]}");
Console.WriteLine($"Общая масса: {specification["TotalMass"]} кг");
```

#### Ведомость расхода стали

```csharp
// Генерировать ведомость расхода стали (КЖ)
var steelReport = reportGenerator.GenerateSteelConsumptionReport();

Console.WriteLine($"Название: {steelReport["Title"]}");
Console.WriteLine($"Общий расход: {steelReport["TotalConsumption"]} кг");
```

#### Ведомость сварных швов

```csharp
// Генерировать ведомость сварных швов
var weldReport = reportGenerator.GenerateWeldingReport();

Console.WriteLine($"Всего швов: {weldReport["TotalWelds"]}");
Console.WriteLine($"Общая длина: {weldReport["TotalWeldLength"]} мм");
Console.WriteLine($"Общая масса: {weldReport["TotalWeldMass"]} кг");
```

#### Карта раскроя

```csharp
// Генерировать карту раскроя
var cuttingMap = reportGenerator.GenerateCuttingMap();
```

### 3. Управление сваркой (Welding)

```csharp
var weldingAutomation = plugin.WeldingAutomation;

// Автоматически расставить швы
weldingAutomation.AutoPlaceWelds();

// Автоматически подобрать размер катета шва
weldingAutomation.AutoSelectWeldSize();

// Получить отчет по сварке
var weldReport = weldingAutomation.GenerateWeldReport();
```

### 4. Управление атрибутами (Attributes)

```csharp
var attributeManager = plugin.AttributeManager;

// Установить префикс
attributeManager.SetPrefix("KM", "Конструктивные Металлоконструкции");

// Получить префикс
var prefix = attributeManager.GetPrefix("KM");

// Установить атрибут
attributeManager.SetAttribute("ProjectName", "Цех №1");

// Получить атрибут
var projectName = attributeManager.GetAttribute("ProjectName");

// Перенести атрибут из одного поля в другое
attributeManager.TransferAttribute("SourceField", "TargetField");

// Сравнить сборки
var differences = attributeManager.CompareAssemblies();
```

### 5. Работа с чертежами (Drawing)

```csharp
var drawingAutomation = plugin.DrawingAutomation;

// Генерировать титульный лист
drawingAutomation.GenerateTitleBlock(
    projectName: "Жилой комплекс",
    drawingNumber: "СБ-001",
    engineer: "И.И. Иванов",
    date: DateTime.Now
);

// Автоматич��ские размеры
drawingAutomation.AutomaticallyDimension();

// Округлить все размеры до 1 мм
drawingAutomation.RoundAllDimensions();

// Конвертировать отметки высот из мм в метры
drawingAutomation.ConvertHeightMarksToMeters();

// Добавить ГОСТ-совместимые линии разрыва
drawingAutomation.AddGOSTBreakLines();

// Сгенерировать план здания на сборочном чертеже
drawingAutomation.GenerateBuildingLayoutOnAssemblyDrawing();
```

### 6. Экспорт в Excel

```csharp
var excelExporter = plugin.ExcelExporter;

// Экспортировать отчет в Excel
var reportData = reportGenerator.GenerateTechnicalSpecification();
string filePath = excelExporter.GetDefaultExcelPath("Specification.xlsx");
excelExporter.ExportToExcel(reportData, filePath);

// Экспортировать данные в CSV
excelExporter.ExportToCSV(reportData, @"C:\Reports\data.csv");
```

## Примеры использования

### Пример 1: Полный цикл создания спецификации

```csharp
// Инициализировать плагин
var plugin = new TopengineerPlugin();

// Работа с каталогом
var profile = plugin.CatalogManager.GetProfile("I25B1");
var bolt = plugin.CatalogManager.GetBolt(10, 30);

// Генерировать отчеты
var kmReport = plugin.ReportGenerator.GenerateTechnicalSpecification();
var kjReport = plugin.ReportGenerator.GenerateSteelConsumptionReport();
var weldReport = plugin.ReportGenerator.GenerateWeldingReport();

// Экспортировать
var exporter = plugin.ExcelExporter;
exporter.ExportToExcel(kmReport, exporter.GetDefaultExcelPath("КМ.xlsx"));
exporter.ExportToExcel(kjReport, exporter.GetDefaultExcelPath("КЖ.xlsx"));
exporter.ExportToExcel(weldReport, exporter.GetDefaultExcelPath("Сварка.xlsx"));
```

### Пример 2: Автоматизация сварки

```csharp
var plugin = new TopengineerPlugin();
var welding = plugin.WeldingAutomation;

// Добавить швы
var weld1 = new Weld
{
    Type = Weld.WeldType.FilletWeld,
    Position = Weld.WeldPosition.Flat,
    MaterialThickness = 8,
    Length = 500
};

weld1.CalculateRecommendedLegSize(); // Рассчитать размер катета
welding.AddWeld(weld1);

// Сгенерировать отчет
var report = welding.GenerateWeldReport();
Console.WriteLine($"Всего швов: {report["TotalWelds"]}");
Console.WriteLine($"Общая длина: {report["TotalWeldLength"]} мм");
```

### Пример 3: Работа с атрибутами

```csharp
var plugin = new TopengineerPlugin();
var attributes = plugin.AttributeManager;

// Установить параметры проекта
attributes.SetAttribute("ProjectName", "Производственный комплекс");
attributes.SetAttribute("ProjectNumber", "ПР-2026-001");
attributes.SetAttribute("Designer", "А.В. Петров");
attributes.SetAttribute("Date", DateTime.Now.ToString("dd.MM.yyyy"));

// Получить все атрибуты
var allAttrs = attributes.GetAllAttributes();
foreach (var attr in allAttrs)
{
    Console.WriteLine($"{attr.Key}: {attr.Value}");
}
```

## Настройка параметров

Все параметры хранятся в классе `GOSTSettings`:

```csharp
var settings = new GOSTSettings();

// Установить пользовательские параметры
settings.SetSetting("DefaultPaperSize", "A1");
settings.SetSetting("AutoRoundDimensions", true);
settings.SetSetting("UseRussianDesignations", true);

// Получить параметр
var paperSize = settings.GetStringSetting("DefaultPaperSize");
var autoRound = settings.GetBooleanSetting("AutoRoundDimensions");

// Сбросить на значения по умолчанию
settings.ResetToDefaults();
```

## Логирование

Лог-файлы сохраняются в:
```
%APPDATA%\Topengineer\Logs\TopengineerPlugin_YYYY-MM-DD.log
```

Для просмотра логов:
```csharp
var logger = new Logger("MyModule");
logger.Log("Информационное сообщение");
logger.Warning("Предупреждение");
logger.Error("Ошибка");
logger.Debug("Отладка");

// Получить путь к лог-файлу
string logPath = logger.GetLogFilePath();

// Очистить старые логи (старше 30 дней)
logger.CleanOldLogs(30);
```

## Горячие клавиши

| Действие | Клавиша |
|----------|----------|
| Открыть главное окно плагина | Alt+T |
| Генерировать спецификацию | Ctrl+Shift+K |
| Экспортировать в Excel | Ctrl+Shift+E |
| Автоматизировать сварку | Ctrl+Shift+W |
| Округлить размеры | Ctrl+Shift+R |

## Поддержка

Для помощи смотрите [Issues](https://github.com/BOK-stack/Tekla-Structures-Plugin-Topengineer/issues)
