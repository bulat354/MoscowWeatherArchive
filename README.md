# MoscowWeatherArchive

## Запуск

### Front Angular

Открываете терминал в папке .\MoscowWeatherFront\moscow-weather и пишете ng serve. Готово

### Back Asp Net Core

Открываете терминал в папке .\MoscowWeather\MoscowWeather и пишете сначала docker run --name weather-forecast --env=POSTGRES_PASSWORD=Pa$$w0rd --env=POSTGRES_DB=moscow_weather -p 5432:5432 -d postgres для запуска контейнера с PostgreSQL в docker контейнере (можно запускать в принципе где угодно, главное пароль, юзер, название бд и адрес были как в файле appsettings.json. Далее необходимо запустить проект Asp Net Core и для этого пишем в терминале dotnet run.

## Пользуемся

Фронт открывается по адресу https://localhost:4200