# Руководство по установке

## Требования

- **Tekla Structures**: 2020 SP1 и выше (до 2025)
- **.NET Framework**: 4.7.2 и выше
- **Система**: Windows 7 или выше
- **Память**: минимум 2 ГБ свободной оперативной памяти

## Пошаговая установка

### 1. Загрузка плагина

```bash
git clone https://github.com/BOK-stack/Tekla-Structures-Plugin-Topengineer.git
cd Tekla-Structures-Plugin-Topengineer
```

### 2. Компиляция из исходного кода

1. Откройте `TopengineerPlugin.sln` в Visual Studio 2019+
2. Выберите конфигурацию `Release`
3. Нажмите `Build → Build Solution`
4. Скомпилированный файл `TopengineerPlugin.dll` будет в папке `bin/Release/`

### 3. Определение пути к Tekla Structures

Путь установки Tekla Structures по умолчанию:

```
C:\Program Files\Trimble\Tekla Structures\<версия>\
```

Для версии 2024:
```
C:\Program Files\Trimble\Tekla Structures\2024\
```

### 4. Копирование плагина

1. Перейдите в папку приложений:
   ```
   C:\ProgramData\Trimble\Tekla Structures\<версия>\Extensions\Applications
   ```

2. Скопируйте `TopengineerPlugin.dll` в эту папку

3. Создайте файл `TopengineerPlugin.xml` с описанием плагина:

```xml
<?xml version="1.0" encoding="utf-8"?>
<PluginData>
  <Name>Topengineer Plugin</Name>
  <Description>Комплексный плагин для автоматизации проектирования металлоконструкций</Description>
  <Version>1.0.0</Version>
  <Company>BOK-stack</Company>
  <AssemblyName>TopengineerPlugin.dll</AssemblyName>
  <ClassName>TopengineerPlugin.TopengineerPlugin</ClassName>
  <HelpFile></HelpFile>
  <Tooltip>Topengineer - автоматизация по ГОСТ</Tooltip>
</PluginData>
```

### 5. Проверка установки

1. Откройте Tekla Structures
2. Перезагрузите приложение
3. Перейдите в меню **Applications**
4. Должен появиться пункт **Topengineer**

## Возможные проблемы и решения

### Проблема: Плагин не отображается в меню

**Решение:**
1. Проверьте путь установки плагина
2. Убедитесь, что файл `TopengineerPlugin.dll` скопирован правильно
3. Проверьте наличие файла `TopengineerPlugin.xml`
4. Перезагрузите Tekla Structures
5. Проверьте логи в папке `%APPDATA%\Trimble\Tekla Structures\Logs\`

### Проблема: Ошибка "не удается найти сборку"

**Решение:**
1. Убедитесь, что установлена .NET Framework 4.7.2+
2. Перекомпилируйте плагин в Visual Studio
3. Проверьте наличие всех зависимостей

### Проблема: "System.IO.FileNotFound Exception"

**Решение:**
1. Проверьте права доступа на папку `Extensions\Applications`
2. Дайте полные права на папку текущему пользователю
3. Переместите плагин в правильную папку

## Удаление плагина

1. Откройте папку:
   ```
   C:\ProgramData\Trimble\Tekla Structures\<версия>\Extensions\Applications
   ```

2. Удалите файлы:
   - `TopengineerPlugin.dll`
   - `TopengineerPlugin.xml`

3. Перезагрузите Tekla Structures

## Обновление плагина

1. Скачайте новую версию
2. Откройте новый `TopengineerPlugin.sln` в Visual Studio
3. Скомпилируйте в `Release`
4. Замените старый `TopengineerPlugin.dll` на новый
5. Перезагрузите Tekla Structures

## Поддержка версий Tekla Structures

| Версия | Поддержка | Статус |
|--------|----------|--------|
| 2020 SP1+ | ✓ | Полная |
| 2021 | ✓ | Полная |
| 2022 | ✓ | Полная |
| 2023 | ✓ | Полная |
| 2024 | ✓ | Полная |
| 2025 | ✓ | Полная |

## Поддержка

Для помощи с установкой создавайте [Issues](https://github.com/BOK-stack/Tekla-Structures-Plugin-Topengineer/issues) на GitHub
