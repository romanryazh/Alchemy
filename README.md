# Alchemy Crafting Backend

![License](https://img.shields.io/badge/license-MIT-green.svg)
![.NET](https://img.shields.io/badge/.NET-9-blue)
![Status](https://img.shields.io/badge/status-Development-yellow)

## Описание

Проект реализует backend-логику для системы алхимического крафта.  
Основные доменные сущности включают:

- **Effect** — эффекты, которые могут иметь зелья и компоненты
- **Potion** — зелья с набором эффектов и рецептов
- **Location** — локации, где можно найти компоненты
- **Component** — компоненты для создания зелий
- **CraftStep** — шаги крафта, объединяющие компоненты и логику создания
- **Recipe** (не реализовано) - рецепты, которые включают необходимые шаги для крафта и зелье, получаемое на выходе.
- **Cauldron** (не реализовано) - котёл, который запускает процесс создания зелья.

CraftingProcess (не реализовано) - Value Object, процесс создания зелья.

Проект построен на платформе .NET с использованием Entity Framework Core, CQRS и паттернов DDD.

---

## Структура проекта

```
/AlchemyCraftingBackend
│
├── /Domain              # Доменные сущности и value objects
│   ├── Effect.cs
│   ├── Potion.cs
│   ├── Location.cs
│   ├── Component.cs
│   └── CraftStep.cs
│
├── /Application         # Логика приложения, CQRS, обработчики команд и запросов, контроллеры
│
├── /Infrastructure      # Конфигурация EF Core, репозитории, миграции
│
├── /API                 # Веб-слой
│
└── README.md            # Этот файл
```

---

## Технологии и зависимости

- .NET 9
- Entity Framework Core (EF Core)
- MediatR (CQRS)
- PostgreSQL (реляционная БД)
- AutoMapper (опционально, для маппинга DTO)
- FluentValidation (опционально, для валидации данных)
- Swagger (удобный способ взаимодействия с API)

---

## Установка и запуск

1. Клонируйте репозиторий:

```bash
git clone https://github.com/romanryazh/Alchemy.git
cd Alchemy
```

2. Настройте строку подключения к вашей базе данных в `appsettings.Development.json` (пример для PostgreSQL):

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=alchemy;Username=postgres;Password=yourpassword"
}
```

3. Миграции применяются автоматически! Однако при использовании api не в режиме develop примените вручную:

```bash
dotnet ef database update
```

4. Запустите проект:

```bash
dotnet run --project Alchemy.WebApi
```

---

## Основные сценарии использования

- Создание и управление эффектами (Effect)
- Создание зелий (Potion) с набором эффектов и рецептов
- Управление компонентами (Component) и их связью с локациями (Location) и эффектами (Effect)
- Определение шагов крафта (CraftStep), включающих компоненты

---

## Особенности архитектуры

- Использование DDD (Domain-Driven Design) для разделения логики
- CQRS с MediatR для обработки команд и запросов
- Value Objects для идентификаторов и других концептуальных сущностей
- Инкапсуляция коллекций через `IReadOnlyCollection<T>` и приватные поля
- Настройка EF Core с использованием Fluent API и конвертеров

---

## Планы на будущее

- Реализовать оставшиеся сущности с дополнительными эндпоинтами
- Реализовать аутентификацию и авторизацию
- Написать Unit и Integration тесты
- Доделать документацию API (Swagger)

---

## Контакты

- Автор: Роман Ряжских
- Email: romanryazh@yandex.ru
- GitHub: [https://github.com/romanryazh](https://github.com/romanryazh)

---

Спасибо за интерес к проекту!
