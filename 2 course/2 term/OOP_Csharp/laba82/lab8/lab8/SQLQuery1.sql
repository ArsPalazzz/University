create database wpflabs;

use wpflabs;
drop table [dbo].[�������];
drop table [dbo].[������];

CREATE TABLE [dbo].[�������] (
    [ID] INT NOT NULL,
    [���] NVARCHAR(MAX) NULL,
    [�����������] NVARCHAR(MAX) NULL,
    [�����] NVARCHAR(MAX) NULL,
    [����] NVARCHAR(MAX) NULL,
    CONSTRAINT [PK_�������] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[������] (
    [ID] INT NOT NULL,
    [���_�������] INT NULL,
    [�����_�����] INT NULL,
    [���_������] NVARCHAR(MAX) NULL,
    [�����] NVARCHAR(MAX) NULL,
    [����] DATETIME NULL,
    CONSTRAINT [PK_������] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_������_�������] FOREIGN KEY ([���_�������]) REFERENCES [dbo].[�������]([ID])
);