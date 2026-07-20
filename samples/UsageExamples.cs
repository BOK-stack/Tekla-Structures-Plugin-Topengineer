using System;
using System.Collections.Generic;
using TopengineerPlugin;
using TopengineerPlugin.Models;

namespace TopengineerPlugin.Examples
{
    /// <summary>
    /// Примеры использования плагина Topengineer
    /// </summary>
    public class UsageExamples
    {
        /// <summary>
        /// Пример 1: Работа с каталогом болтов
        /// </summary>
        public static void Example1_WorkingWithBolts()
        {
            Console.WriteLine("=== Пример 1: Работа с болтами ===");

            var plugin = new TopengineerPlugin();
            var catalogManager = plugin.CatalogManager;

            // Получить болт
            var bolt = catalogManager.GetBolt(10, 30);
            if (bolt != null)
            {
                Console.WriteLine($"Найден болт: {bolt.GetDisplayName()}");
                Console.WriteLine($"  Диаметр: {bolt.Diameter} мм");
                Console.WriteLine($"  Длина: {bolt.Length} мм");
                Console.WriteLine($"  Класс прочности: {bolt.Grade}");
                Console.WriteLine($"  Масса: {bolt.MassPerPiece} г");
            }

            // Добавить пользовательский болт
            var customBolt = new Bolt
            {
                Diameter = 14,
                Length = 50,
                Pitch = 2.0,
                GOSTDesignation = "ГОСТ 7798",
                Grade = "10.9",
                IsHighStrength = true,
                MassPerPiece = 52.5
            };
            catalogManager.AddCustomBolt(customBolt);
            Console.WriteLine($"\nДобавлен пользовательский болт: {customBolt.GetDisplayName()}");

            // Получить все болты
            var allBolts = catalogManager.GetAllBolts();
            Console.WriteLine($"\nВсего болтов в каталоге: {allBolts.Count}");
        }

        /// <summary>
        /// Пример 2: Работа с профилями
        /// </summary>
        public static void Example2_WorkingWithProfiles()
        {
            Console.WriteLine("\n=== Пример 2: Работа с профилями ===");

            var plugin = new TopengineerPlugin();
            var catalogManager = plugin.CatalogManager;

            // Получить профиль
            var profile = catalogManager.GetProfile("I25B1");
            if (profile != null)
            {
                Console.WriteLine($"Найден профиль: {profile.GetDisplayName()}");
                Console.WriteLine($"  Высота: {profile.Height} мм");
                Console.WriteLine($"  Ширина полки: {profile.Width} мм");
                Console.WriteLine($"  Масса/м: {profile.MassPerMeter} кг");
                Console.WriteLine($"  Стандарт: {profile.GOSTStandard}");
            }

            // Рассчитать массу профиля
            double length = 5000; // 5 метров
            var mass = profile.CalculateMass(length);
            Console.WriteLine($"\nМасса профиля длиной {length} мм: {mass} кг");

            // Поиск профилей по типу
            var ibeams = catalogManager.SearchProfiles(Profile.ProfileType.IBeam);
            Console.WriteLine($"\nДвутавров в каталоге: {ibeams.Count}");
            foreach (var beam in ibeams)
            {
                Console.WriteLine($"  - {beam.GOSTDesignation}");
            }
        }

        /// <summary>
        /// Пример 3: Работа с материалами
        /// </summary>
        public static void Example3_WorkingWithMaterials()
        {
            Console.WriteLine("\n=== Пример 3: Работа с материалами ===");

            var plugin = new TopengineerPlugin();
            var catalogManager = plugin.CatalogManager;

            // Получить материал
            var material = catalogManager.GetMaterial("Сталь 3");
            if (material != null)
            {
                Console.WriteLine($"Найден материал: {material.GetDisplayName()}");
                Console.WriteLine($"  Плотность: {material.Density} кг/м³");
                Console.WriteLine($"  Предел текучести: {material.YieldStrength} МПа");
                Console.WriteLine($"  Предел прочности: {material.TensileStrength} МПа");
            }

            // Рассчитать массу
            double volumeM3 = 0.5; // 0.5 м³
            var mass = material.CalculateMass(volumeM3);
            Console.WriteLine($"\nМасса {volumeM3} м³ стали: {mass} кг");

            // Получить все материалы
            var allMaterials = catalogManager.GetAllMaterials();
            Console.WriteLine($"\nВсего материалов в каталоге: {allMaterials.Count}");
        }

        /// <summary>
        /// Пример 4: Генерация отчётов
        /// </summary>
        public static void Example4_GeneratingReports()
        {
            Console.WriteLine("\n=== Пример 4: Генерация отчётов ===");

            var plugin = new TopengineerPlugin();
            var reportGenerator = plugin.ReportGenerator;

            // Сгенерировать техническую спецификацию (КМ)
            var kmReport = reportGenerator.GenerateTechnicalSpecification();
            Console.WriteLine($"Техническая специфика��ия (КМ):");
            Console.WriteLine($"  Название: {kmReport["Title"]}");
            Console.WriteLine($"  Дата: {kmReport["Date"]}");
            Console.WriteLine($"  Всего позиций: {kmReport["TotalItems"]}");

            // Сгенерировать ведомость расхода стали (КЖ)
            var kjReport = reportGenerator.GenerateSteelConsumptionReport();
            Console.WriteLine($"\nВедомость расхода стали (КЖ):");
            Console.WriteLine($"  Название: {kjReport["Title"]}");
            Console.WriteLine($"  Всего расхода: {kjReport["TotalConsumption"]} кг");

            // Сгенерировать ведомость сварных швов
            var weldReport = reportGenerator.GenerateWeldingReport();
            Console.WriteLine($"\nВедомость сварных швов:");
            Console.WriteLine($"  Название: {weldReport["Title"]}");
            Console.WriteLine($"  Всего швов: {weldReport["TotalWelds"]}");

            // Сгенерировать карту раскроя
            var cuttingMap = reportGenerator.GenerateCuttingMap();
            Console.WriteLine($"\nКарта раскроя:");
            Console.WriteLine($"  Название: {cuttingMap["Title"]}");
        }

        /// <summary>
        /// Пример 5: Работа со сваркой
        /// </summary>
        public static void Example5_WorkingWithWelding()
        {
            Console.WriteLine("\n=== Пример 5: Работа со сваркой ===");

            var plugin = new TopengineerPlugin();
            var weldingAutomation = plugin.WeldingAutomation;

            // Создать сварной шов
            var weld = new Weld
            {
                Type = Weld.WeldType.FilletWeld,
                Position = Weld.WeldPosition.Flat,
                MaterialThickness = 8,
                Length = 500,
                GOSTDesignation = "ГОСТ 2.312-72",
                WeldingMethod = "ручная дуговая",
                NumberOfPasses = 1
            };

            // Автоматически рассчитать размер катета
            weld.CalculateRecommendedLegSize();
            Console.WriteLine($"Сварной шов:");
            Console.WriteLine($"  Тип: {weld.Type}");
            Console.WriteLine($"  Толщина материала: {weld.MaterialThickness} мм");
            Console.WriteLine($"  Размер катета: {weld.LegSize} мм (рекомендуемый)");
            Console.WriteLine($"  Длина: {weld.Length} мм");

            // Добавить шов в модель
            weldingAutomation.AddWeld(weld);

            // Рассчитать массу сварки
            var weldMass = weld.CalculateWeldMass();
            Console.WriteLine($"  Масса сварки: {weldMass} кг");

            // Сгенерировать отчёт по сварке
            var report = weldingAutomation.GenerateWeldReport();
            Console.WriteLine($"\nОтчёт по сварке:");
            Console.WriteLine($"  Всего швов: {report["TotalWelds"]}");
            Console.WriteLine($"  Общая длина: {report["TotalWeldLength"]} мм");
            Console.WriteLine($"  Общая масса: {report["TotalWeldMass"]} кг");
        }

        /// <summary>
        /// Пример 6: Управление атрибутами
        /// </summary>
        public static void Example6_ManagingAttributes()
        {
            Console.WriteLine("\n=== Пример 6: Управление атрибутами ===");

            var plugin = new TopengineerPlugin();
            var attributeManager = plugin.AttributeManager;

            // Установить атрибуты проекта
            attributeManager.SetAttribute("ProjectName", "Производственный комплекс");
            attributeManager.SetAttribute("ProjectNumber", "ПР-2026-001");
            attributeManager.SetAttribute("Designer", "А.В. Петров");
            attributeManager.SetAttribute("Date", DateTime.Now.ToString("dd.MM.yyyy"));

            Console.WriteLine("Установленные атрибуты:");
            var allAttrs = attributeManager.GetAllAttributes();
            foreach (var attr in allAttrs)
            {
                Console.WriteLine($"  {attr.Key}: {attr.Value}");
            }

            // Установить префиксы
            Console.WriteLine("\nПрефиксы:");
            var allPrefixes = attributeManager.GetAllPrefixes();
            foreach (var prefix in allPrefixes)
            {
                Console.WriteLine($"  {prefix.Key}: {prefix.Value}");
            }
        }

        /// <summary>
        /// Пример 7: Экспорт в Excel
        /// </summary>
        public static void Example7_ExportToExcel()
        {
            Console.WriteLine("\n=== Пример 7: Экспорт в Excel ===");

            var plugin = new TopengineerPlugin();
            var reportGenerator = plugin.ReportGenerator;
            var excelExporter = plugin.ExcelExporter;

            // Сгенерировать отчёт
            var kmReport = reportGenerator.GenerateTechnicalSpecification();

            // Экспортировать в Excel
            string filePath = excelExporter.GetDefaultExcelPath("КМ.xlsx");
            bool success = excelExporter.ExportToExcel(kmReport, filePath);

            if (success)
            {
                Console.WriteLine($"Отчёт успешно экспортирован в: {filePath}");
            }
            else
            {
                Console.WriteLine("Ошибка при экспорте отчёта");
            }
        }

        /// <summary>
        /// Пример 8: Работа с чертежами
        /// </summary>
        public static void Example8_WorkingWithDrawings()
        {
            Console.WriteLine("\n=== Пример 8: Работа с чертежами ===");

            var plugin = new TopengineerPlugin();
            var drawingAutomation = plugin.DrawingAutomation;

            // Установить параметры чертежа
            drawingAutomation.SetDrawingSetting("DefaultPaperSize", "A1");
            drawingAutomation.SetDrawingSetting("DefaultScale", "1:50");
            drawingAutomation.SetDrawingSetting("AutoRoundDimensions", true);

            Console.WriteLine("Параметры чертежа:");
            var settings = drawingAutomation.GetAllDrawingSettings();
            foreach (var setting in settings)
            {
                Console.WriteLine($"  {setting.Key}: {setting.Value}");
            }

            // Сгенерировать титульный лист
            drawingAutomation.GenerateTitleBlock(
                projectName: "Жилой комплекс",
                drawingNumber: "СБ-001",
                engineer: "И.И. Иванов",
                date: DateTime.Now
            );
            Console.WriteLine("\nТитульный лист сгенерирован");
        }

        /// <summary>
        /// Главная программа для запуска примеров
        /// </summary>
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║  Topengineer Plugin - Примеры использования                 ║");
            Console.WriteLine("║  Version 1.0.0                                             ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝\n");

            try
            {
                Example1_WorkingWithBolts();
                Example2_WorkingWithProfiles();
                Example3_WorkingWithMaterials();
                Example4_GeneratingReports();
                Example5_WorkingWithWelding();
                Example6_ManagingAttributes();
                Example7_ExportToExcel();
                Example8_WorkingWithDrawings();

                Console.WriteLine("\n\n✓ Все примеры выполнены успешно!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n✗ Ошибка: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
