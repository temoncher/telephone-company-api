-- Drop database if it is already present
IF EXISTS(
  SELECT
    *
  FROM
    [sys].[databases]
  WHERE
    [name] = 'telephone_company'
) BEGIN;

DROP DATABASE [telephone_company]
END;

GO
;

-- Create new database
CREATE DATABASE [telephone_company]
GO
;

-- Create Organisations table
USE [telephone_company];

CREATE TABLE [organisations] (
  [organisation_id] INT IDENTITY(1, 1) PRIMARY KEY,
  [name] NVARCHAR(50) NOT NULL,
);

GO
;

-- Create Subscribers table
CREATE TABLE [subscribers] (
  [subscriber_id] INT IDENTITY(1, 1) PRIMARY KEY,
  [organisation_id] INT NOT NULL FOREIGN KEY REFERENCES [organisations](organisation_id),
  [inn] INT NOT NULL,
  [first_name] NVARCHAR(30) NOT NULL,
  [last_name] NVARCHAR(30) NOT NULL,
  [patronymic] NVARCHAR(30),
  [adress] NVARCHAR(50)
);

GO
;

-- Create Accounts table
CREATE TABLE [accounts] (
  [account_id] INT IDENTITY(1, 1) PRIMARY KEY,
  [subscriber_id] INT NOT NULL FOREIGN KEY REFERENCES [subscribers](subscriber_id),
  [balance] INT DEFAULT 0,
);

GO
;

-- Create trigger to add account for each new subscriber
CREATE TRIGGER [TR_subscribers_InsteadOfInsert] ON [subscribers]
AFTER
INSERT
  AS BEGIN
INSERT INTO
  [accounts] ([subscriber_id])
SELECT
  [subscriber_id]
FROM
  inserted
END;

GO
;

-- Create TransactionTypes table
CREATE TABLE [transaction_types] (
  [transaction_type_id] INT IDENTITY(1, 1) PRIMARY KEY,
  [title] NVARCHAR(50) NOT NULL,
);

GO
;

-- Seed Organisations table
INSERT INTO
  [organisations] ([name])
VALUES
  (N'ЯрГУ им. П.Г. Демидова'),
  (N'Тензор'),
  (N'McDonalds'),
  (N'KFC'),
  (N'Аквелон');

GO
;

-- Seed Subscribers table
INSERT INTO
  [subscribers] (
    [organisation_id],
    [inn],
    [first_name],
    [last_name],
    [patronymic],
    [adress]
  )
VALUES
  (3, 111, 'John', 'Doe', NULL, 'Brooklyn'),
  (
    1,
    112,
    N'Артем',
    N'Баранов',
    N'Сергеевич',
    N'Ярославль'
  ),
  (3, 113, N'Мини', N'Маус', NULL, 'Disney Land'),
  (3, 114, N'Стивен', N'Джобс', NULL, NULL),
  (4, 115, 'Bill', 'Gates', NULL, NULL),
  (
    3,
    116,
    N'Микки',
    N'Маус',
    NULL,
    'Disney Land'
  );

-- No need to seed Accounts because they will be generated on trigger
-- Seed TransactionTypes table
INSERT INTO
  [transaction_types] ([title])
VALUES
  (N'Утро'),
  (N'День'),
  (N'Ночь');

GO
;