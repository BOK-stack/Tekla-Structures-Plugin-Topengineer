# Структура проекта

## 📁 Директории и файлы

```
Tekla-Structures-Plugin-Topengineer/
│
├── 📄 README.md                           # Главная документация проекта
├── 📄 CHANGELOG.md                        # История изменений и версий
├── 📄 LICENSE                             # MIT лицензия
├── 📄 .gitignore                          # Git конфигурация
├── 📄 TopengineerPlugin.xml               # Конфигурация плагина
│
├── 📁 src/                                # Исходный код
│   └── 📁 TopengineerPlugin/
│       ├── 📄 TopengineerPlugin.cs        # Главный класс плагина
│       ├── 📄 TopengineerPlugin.csproj    # Конфигурация проекта
│       │
│       ├── 📁 Core/                       # Основные модули
│       │   ├── 📄 CatalogManager.cs       # Управление каталогами
│       │   ├── 📄 WeldingAutomation.cs    # Автоматизация сварки
│       │   ├── 📄 AttributeManager.cs     # Управление атрибутами
│       │   └── 📄 DrawingAutomation.cs    # Автоматизация чертежей
│       │
│       ├── 📁 Models/                     # Модели данных
│       │   ├── 📄 Bolt.cs                 # Модель болта
│       │   ├── 📄 Profile.cs              # Модель профиля
│       │   ├── 📄 Material.cs             # Модель материала
│       │   └── 📄 Weld.cs                 # Модель сварки
│       │
│       ├── 📁 Reports/                    # Модули отчётности
│       │   ├── 📄 ReportGenerator.cs      # Генератор отчётов
│       │   ├── 📄 ExcelExporter.cs        # Экспорт в Excel/CSV
│       │   └── 📄 SpecificationGenerator.cs # Генератор спецификаций
│       │
│       ├── 📁 Config/                     # Конфигурация
│       │   └── 📄 GOSTSettings.cs         # Параметры ГОСТ
│       │
│       ├── 📁 Utilities/                  # Вспомогательные функции
│       │   ├── 📄 Logger.cs               # Система логирования
│       │   └── 📄 Helper.cs               # Утилиты и помощники
│       │
│       └── 📁 Properties/
│           └── 📄 AssemblyInfo.cs         # Информация о сборке
│
├── 📁 docs/                               # Документация
│   ├── 📄 INSTALLATION.md                 # Руководство установки
│   ├── 📄 USER_GUIDE.md                   # Руководство пользователя
│   ├── 📄 GOST_STANDARDS.md               # Справочник ГОСТ
│   └── ���� API_REFERENCE.md                # Справочник API
│
├── 📁 samples/                            # Примеры использования
│   └── 📄 UsageExamples.cs                # Примеры кода
│
└── 📁 tests/                              # Тесты (готовы для расширения)
    └── 📁 TopengineerPlugin.Tests/
        └── (Placeholder для юнит-тестов)
```

## 🏗️ Архитектура

### Слои приложения

```
┌─────────────────────────────────────────────────────────┐
│            Пользовательский интерфейс (UI)            │
│         (Tekla Structures Plugin Integration)          │
└─────────────────────────────────────────────────────────┘
                          ↓
┌─────────────────────────────────────────────────────────┐
│             Бизнес-логика (Business Logic)             │
│  ┌──────────────────────────────────────────────────┐   │
│  │ Core Modules:                                    │   │
│  │ • CatalogManager                                 │   │
│  │ • WeldingAutomation                              │   │
│  │ • AttributeManager                               │   │
│  │ • DrawingAutomation                              │   │
│  └──────────────────────────────────────────────────┘   │
│  ┌──────────────────────────────────────────────────┐   │
│  │ Reports:                                         │   │
│  │ • ReportGenerator                                │   │
│  │ • ExcelExporter                                  │   │
│  │ • SpecificationGenerator                         │   │
│  └──────────────────────────────────────────────────┘   │
└─────────────────────────────────────────────────────────┘
                          ↓
┌─────────────────────────────────────────────────────────┐
│                Модели данных (Models)                  │
│  • Bolt, Profile, Material, Weld                       │
└─────────────────────────────────────────────────────────┘
                          ↓
┌─────────────────────────────────────────────────────────┐
│         Вспомогательные слои (Utilities)               │
│  • Logger, Helper, GOSTSettings                        │
└─────────────────────────────────────────────────────────┘
```

## 📦 Зависимости

### Встроенные (Framework)
- System
- System.Collections.Generic
- System.IO
- System.Text
- System.Reflection
- System.Windows.Forms
- PresentationCore
- PresentationFramework

### Требуемые
- .NET Framework 4.7.2+
- Tekla Structures SDK (встроено в Tekla Structures)

### Опциональные (для расширения)
- EPPlus (для улучшенного экспорта в Excel)
- Dapper (для работы с БД)
- Newtonsoft.Json (для JSON сериализации)

## 🔄 Основные компоненты

### 1. CatalogManager
**Функции:**
- Управление каталогами болтов, профилей, материалов
- Поиск элементов по параметрам
- Добавление пользовательских элементов
- Валидация параметров по ГОСТ

### 2. WeldingAutomation
**Функции:**
- Автоматическая расстановка сварки
- Подбор размера катета шва
- Генерация отчётов по сварке
- Валидация параметров сварки

### 3. ReportGenerator
**Функции:**
- Генерация технических спецификаций (КМ)
- Ведомость расхода стали (КЖ)
- Ведомость сварных швов
- Карты р��скроя

### 4. ExcelExporter
**Функции:**
- Экспорт в Excel формат
- Экспорт в CSV
- Форматирование таблиц
- Автоматическое создание папок

### 5. DrawingAutomation
**Функции:**
- Генерация титульных листов
- Автоматическое размещение видов
- Округление размеров
- Преобразование отметок

### 6. AttributeManager
**Функции:**
- Управление атрибутами
- Управление префиксами
- Передача атрибутов
- Сравнение сборок

### 7. GOSTSettings
**Функции:**
- Управление параметрами ГОСТ
- Хранение пользовательских настроек
- Валидация конфигурации
- Загрузка/сохранение параметров

### 8. Logger
**Функции:**
- Логирование событий
- Сохранение в файлы
- Управление старыми логами
- Различные уровни логирования

## 📊 Поток данных

```
Пользователь
    ↓
[Tekla Structures Plugin Interface]
    ↓
[TopengineerPlugin Main Class]
    ↓
┌─────────────────────────────────┐
│   Выбор функции                 │
├─────────────────────────────────┤
│ 1. Каталоги      → CatalogManager│
│ 2. Сварка        → WeldingAutom │
│ 3. Отчёты        → ReportGenerat│
│ 4. Чертежи       → DrawingAutom │
│ 5. Атрибуты      → AttributeMan │
│ 6. Параметры     → GOSTSettings │
└─────────────────────────────────┘
    ↓
[Models Layer - Bolt, Profile, Material, Weld]
    ↓
[Utilities - Logger, Helper, Exports]
    ↓
Результат → [Файлы | Консоль | Excel]
```

## 🎯 Точки расширения

### 1. Добавление новых типов каталогов
```csharp
// В CatalogManager добавить:
public List<CustomItem> GetCustomItems() { ... }
public void AddCustomItem(CustomItem item) { ... }
```

### 2. Интеграция с Tekla Structures API
```csharp
// В WeldingAutomation.AutoPlaceWelds():
// Добавить вызовы Tekla.Structures API
```

### 3. Добавление новых форматов экспорта
```csharp
// В ExcelExporter добавить:
public bool ExportToXML(...) { ... }
public bool ExportToJSON(...) { ... }
```

### 4. Поддержка мультиязычности
```csharp
// Создать класс Localization
// Добавить ресурсные файлы .resx для разных языков
```

## 🔒 Обработка исключений

Все методы содержат try-catch блоки и логирование:

```csharp
try
{
    // Основная логика
}
catch (Exception ex)
{
    _logger.Error($"Error: {ex.Message}");
    // Обработка ошибки
}
```

## 📝 Соглашения кодирования

### Именование
- **Классы**: PascalCase (CatalogManager)
- **Методы**: PascalCase (GetBolt)
- **Переменные**: camelCase (boltDiameter)
- **Константы**: UPPER_CASE (MAX_BOLT_SIZE)

### Документация
- Все публичные классы и методы имеют XML-комментарии
- Примеры использования в комментариях
- Пояснения о параметрах и возвращаемых значениях

### Стиль кода
- Использование using statements для управления ресурсами
- Проверка null перед использованием
- Логирование важных операций
- Валидация входных данных

## 🚀 Развёртывание

### Разработка
1. Клонировать репозиторий
2. Открыть .sln в Visual Studio
3. Скомпилировать в режиме Debug
4. Скопировать DLL в папку Tekla Extensions

### Продакшн
1. Скомпилировать в режиме Release
2. Создать ZIP архив с файлами
3. Распространить через GitHub Releases
4. Обновить версию в CHANGELOG.md

## 🔧 Инструменты и технологии

- **Язык**: C# 8.0+
- **Framework**: .NET Framework 4.7.2
- **IDE**: Visual Studio 2019+
- **Версионирование**: Git
- **Тестирование**: NUnit (готово для интеграции)
- **Документация**: Markdown

## 📞 Поддержка

Для вопросов и сообщений об ошибках:
- GitHub Issues: https://github.com/BOK-stack/Tekla-Structures-Plugin-Topengineer/issues
- Обсуждения: https://github.com/BOK-stack/Tekla-Structures-Plugin-Topengineer/discussions

## 📄 Лицензия

МИТ лицензия - см. файл LICENSE
