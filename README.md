# Криптобиржа на .NET Framework Windows Forms

Данное приложение является криптобиржей, которая позволяет пользователям торговать криптовалютами на бирже. Она разработана на платформе .NET Framework с использованием Windows Forms.

## 📖 Функциональность

Моя программа обладает следующей функциональностью:

- Регистрация и авторизация пользователей.
- Покупка и продажа криптовалют.
- Просмотр актуальной информации о курсах криптовалют в режиме (почти)реального времени.
- Просмотр истории транзакций и баланса счета.
- Интерфейс для просмотра текущих и исторических данных о курсах криптовалют.

## 🛠️ Требования к системе

Для корректной работы программы необходимы следующие компоненты:

- Windows 7, 8, 10 или 11.
-  .NET Framework 4.5 или выше.
- 2 Гб оперативной памяти.
- 1 Гб свободного места на жестком диске.

## ⚙️ Установка и запуск

Чтобы установить приложение на компьютер, выполните следующие действия:

1. Склонируйте репозиторий на локальный компьютер.
2. Откройте проект в Visual Studio.
3. Из NuGet package manager установите пакеты:

| Пакет              | Описание                                    |
| ------------------ | -------------------------------------------- |
| MongoDB.Driver     | Официальный драйвер для MongoDB              |
| NBitcoin           | Библиотека для работы с биткоином            |
| NBitcoin.Altcoins  | Расширение NBitcoin для работы с альткоинами |
| Nethereum.Util     | Библиотека утилит для работы с Ethereum      |
| Nethereum.Signer   | Библиотека для создания подписей в Ethereum  |


в файле `App.config` вставьте следующий код:
```xml
<appSettings>
    <add key="MyPass" value="your_mongodb_password_here" />
</appSettings>
```
Замените `"your_mongodb_password_here"` на ваш настоящий пароль для MongoDB.

4.  Соберите проект.
5. Запустите программу.

## 👨‍💻 Разработчик

Данное приложение разработано в качестве курсового проекта студентом Асылбековым Даниялом, студентом колледжа ЦАТЭК.

## 🔒 Лицензия

Данное приложение распространяется под лицензией MIT. Подробная информация о лицензии содержится в файле `LICENSE`.
