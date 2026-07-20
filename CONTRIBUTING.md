# Contributing Guidelines

## Как помочь проекту

### Сообщение об ошибках

1. Проверьте, не была ли ошибка уже зарегистрирована
2. Создайте новый Issue с описанием:
   - Какая версия плагина
   - Какая версия Tekla Structures
   - Какие шаги привели к ошибке
   - Какой результат ожидается
   - Какой результат получен
   - Скриншоты если применимо

### Предложение улучшений

1. Откройте Discussion с идеей
2. Обсудите реализацию с командой
3. Если идея одобрена, создайте Issue для трекинга

### Отправка Pull Requests

1. **Форкните** репозиторий
2. **Создайте ветку** для вашей функции: `git checkout -b feature/my-feature`
3. **Коммитьте** измене��ия: `git commit -m 'Add my feature'`
4. **Отправьте** в ветку: `git push origin feature/my-feature`
5. **Создайте** Pull Request

### Требования к коду

- Следуйте соглашениям кодирования проекта
- Добавляйте XML-комментарии для публичных методов
- Включайте примеры использования
- Тестируйте код перед отправкой
- Обновляйте документацию если нужно
- Добавляйте запись в CHANGELOG.md

### Процесс разработки

1. Создать issue описывающий проблему или функцию
2. Обсудить подход в comments
3. Реализовать на отдельной ветке
4. Отправить PR с ссылкой на issue
5. Получить review от мейнтейнеров
6. Внести исправления если потребуются
7. Merge в main ветку

### Стандарты коммитов

```
[type] short description

Detailed explanation if needed.

Closes #issue_number
```

**Types:**
- feat: новая функция
- fix: исправление ошибки
- docs: изменения в документации
- style: форматирование кода
- refactor: переструктурирование без изменения функциональности
- perf: улучшение производительности
- test: добавление тестов

### Примеры:

```
feat: Add support for custom bolt catalogs

Implemented ability to import custom bolt definitions from CSV files.
Allows users to extend the default GOST bolt catalog.

Closes #123
```

```
fix: Correct weld size calculation for material thickness > 30mm

The formula for calculating recommended weld leg size was incorrect
for materials thicker than 30mm. Now correctly uses GOST 14776 standard.

Closes #456
```

## Процесс Release

1. Обновить версию в TODOs
2. Обновить CHANGELOG.md
3. Создать тег версии: `git tag -a v1.0.0 -m "Release version 1.0.0"`
4. Отправить тег: `git push origin v1.0.0`
5. Создать Release на GitHub с примечаниями

## Разработка локально

### Настройка

```bash
# Клонировать
git clone https://github.com/BOK-stack/Tekla-Structures-Plugin-Topengineer.git
cd Tekla-Structures-Plugin-Topengineer

# Откр��ть в Visual Studio
start TopengineerPlugin.sln
```

### Сборка

```bash
# Debug
msbuild TopengineerPlugin.sln /p:Configuration=Debug

# Release  
msbuild TopengineerPlugin.sln /p:Configuration=Release
```

### Тестирование

```bash
# Скопировать DLL в Tekla Extensions
copy bin\Release\TopengineerPlugin.dll "C:\ProgramData\Trimble\Tekla Structures\2024\Extensions\Applications\"

# Запустить Tekla Structures
```

## Контакты

- **Разработчик**: BOK-stack
- **Email**: bazarbaeomar@gmail.com
- **GitHub**: https://github.com/BOK-stack

---

Спасибо за интерес к проекту! 🙏
