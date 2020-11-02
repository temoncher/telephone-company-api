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

-- Create TransactionTypes table
CREATE TABLE [transaction_types] (
  [transaction_type_id] INT IDENTITY(1, 1) PRIMARY KEY,
  [title] NVARCHAR(50) NOT NULL,
);

GO
;

-- Create Transactions table
CREATE TABLE [transactions] (
  [transaction_id] INT IDENTITY(1, 1) PRIMARY KEY,
  [transaction_type_id] INT NOT NULL FOREIGN KEY REFERENCES [transaction_types](transaction_type_id),
  [account_id] INT NOT NULL FOREIGN KEY REFERENCES [accounts](account_id),
  [amount] INT NOT NULL,
  [timestamp] DATETIME DEFAULT CURRENT_TIMESTAMP,
);

GO
;