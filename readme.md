# Календарь мероприятий для спорта высших достижений

## Запуск

**email-proxy** - для запуска необходимо вставить папку RSAKeys в ./email-proxy/email-proxy и запустить командой "dotnet run", либо с помощью Visual Studio 2022

## !Необходимо проверить настройки подключения к локальному серверу PostgeSQL бд в файле appsetings.json 
**UserService** - миграция для базы данных выполняется автоматически. Сервис запускается командой "dotnet run", либо с помощью Visual Studio 2022

## !Необходимо проверить настройки подключения к локальному серверу PostgeSQL бд в файле appsetings.json 
**SportEvents** - необходимо открыть Visual Studio 2022, после запустить "Средства -> Диспетчер пакетов NuGet -> Консоль диспетчера пакетов" и выполнить в ней команду "Update-Database". После этих действий появится БД SportEvents. В ней необходимо выполнить скрипт из файл script.sql.

## Описание проекта
**Цель проекта** — создание интерактивной платформы для удобного отображения календаря спортивных мероприятий. 
Система позволяет фильтровать события по ключевым параметрам, что упрощает доступ спортсменов, тренеров и организаторов к актуальной информации.

Проект решает проблему неудобства работы с Единым календарным планом, публикуемым в формате PDF, предоставляя персонализированный и структурированный доступ к данным.

---

## Основные функции платформы

### Фильтрация мероприятий
Платформа позволяет отбирать события по следующим параметрам:
- Вид спорта (например, баскетбол, плавание и т.д.)
- Дисциплина (на доработке)
- Программа
- Место проведения
- Количество участников
- Пол и возрастная группа
- Сроки проведения
- Тип соревнования 

### Форматы отображения
События могут быть представлены в различных форматах:
- Мероприятия текущей недели
- Мероприятия следующего месяца
- Мероприятия 3 месяца
- Мероприятия полугодия

### Дополнительные возможности
- **Извещения о новых мероприятиях**  
  Уведомления о добавлении новых событий или изменении текущих.
- **Персонализированные уведомления и напоминания**  
  Информация о предстоящих мероприятиях на основе предпочтений пользователя.

---

## Решение

### Сбор данных
1. **Парсинг данных**  
   Автоматическая выгрузка информации с официального сайта Министерства спорта.
2. **Унификация**  
   Создание централизованной базы данных для работы с информацией.

### Сценарии использования
1. **Вывод информации по видам спорта**  
   Быстрая фильтрация событий по интересующему виду спорта.
2. **Подборка соревнований по дисциплинам**  
   Поиск мероприятий по заданным дисциплинам.
3. **Отображение мероприятий на заданный срок**  
   Просмотр соревнований на 1, 3 или 6 месяцев.
4. **Рассылка уведомлений**  
   Настраиваемые уведомления.
5. **Уведомления об изменениях**  
   Информирование пользователей о переносах или отменах событий.

---

## Проблематика
Единый календарный план, публикуемый Министерством спорта в формате PDF, не учитывает индивидуальные потребности пользователей.  
- Отсутствует возможность фильтрации по видам спорта и другим параметрам.  
- Значительное время затрачивается на поиск релевантной информации.  
- Усложнено планирование подготовки к соревнованиям.  

Проект решает эти проблемы, создавая удобный инструмент для просмотра, фильтрации и управления информацией о спортивных мероприятиях.

---

## Образ результата
1. **Интерактивный календарь**  
   Удобный интерфейс для просмотра событий с поддержкой фильтров.
2. **Сценарии работы**  
   Реализованы основные и дополнительные сценарии использования, описанные выше.

---

## Стек технологий
- **Frontend**: React, Vite, Material ui, Lucide, Npm, Mob. 
- **Backend**: ASP.Net 8, Docker Compose.
- **ORM**: EF 8, SQLKata.
- **Коммуникация**: REST API, с FastEndpoint, gRPC.  

---

## Развитие продукта
- Интеграция с дополнительными спортивными платформами: например, сплатформами для отслеживания тренировок и результатов.
- Поддержка многоканальных уведомлений (мобильные,email, sms, push)
