# Лабораторная работа 3. ASP.NET Core Web API и PostgreSQL

## Описание

Проект реализует простое ASP.NET Core Web API приложение для мини-библиотеки. API выполняет CRUD-операции с авторами, книгами и жанрами, использует Entity Framework Core и PostgreSQL.

## Таблицы

- `Authors` - авторы книг.
- `Books` - книги.
- `Genres` - жанры книг.
- `BookGenres` - промежуточная таблица для связи книг и жанров.

## Связи

- `Author` 1:N `Book` - один автор может иметь много книг.
- `Book` M:N `Genre` через `BookGenre` - одна книга может иметь много жанров, один жанр может относиться ко многим книгам.

## Запуск PostgreSQL

```bash
docker compose up -d
```

## Применение миграций

```bash
dotnet ef database update --project LibraryApi
```

## Запуск API

```bash
dotnet run --project LibraryApi
```

Также можно указать файл проекта явно:

```bash
dotnet run --project LibraryApi/LibraryApi.csproj
```

Файл `LibraryApi.sln` запускать через `dotnet run --project` нельзя: solution нужен для сборки и тестов, а не для запуска приложения.

Swagger доступен по адресу:

```text
/swagger
```

## Запуск тестов

```bash
dotnet test
```

Тесты написаны на NUnit. Для интеграционных тестов используется реальный PostgreSQL, который запускается через Testcontainers.

## Основные endpoints

### Authors

- `GET /api/authors`
- `GET /api/authors/{id}`
- `POST /api/authors`
- `PUT /api/authors/{id}`
- `DELETE /api/authors/{id}`

### Books

- `GET /api/books`
- `GET /api/books/{id}`
- `POST /api/books`
- `PUT /api/books/{id}`
- `DELETE /api/books/{id}`
- `POST /api/books/{bookId}/genres/{genreId}`
- `DELETE /api/books/{bookId}/genres/{genreId}`
- `GET /api/books/{bookId}/genres`

### Genres

- `GET /api/genres`
- `GET /api/genres/{id}`
- `POST /api/genres`
- `PUT /api/genres/{id}`
- `DELETE /api/genres/{id}`
