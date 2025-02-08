create database wpflabs;

use wpflabs;
drop table [dbo].[Клиенты];
drop table [dbo].[Вклады];

CREATE TABLE [dbo].[Клиенты] (
    [ID] INT NOT NULL,
    [ФИО] NVARCHAR(MAX) NULL,
    [Гражданство] NVARCHAR(MAX) NULL,
    [Адрес] NVARCHAR(MAX) NULL,
    [Фото] NVARCHAR(MAX) NULL,
    CONSTRAINT [PK_Клиенты] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Вклады] (
    [ID] INT NOT NULL,
    [Код_клиента] INT NULL,
    [Номер_счёта] INT NULL,
    [Вид_вклада] NVARCHAR(MAX) NULL,
    [Сумма] NVARCHAR(MAX) NULL,
    [Дата] DATETIME NULL,
    CONSTRAINT [PK_Вклады] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Вклады_Клиенты] FOREIGN KEY ([Код_клиента]) REFERENCES [dbo].[Клиенты]([ID])
);