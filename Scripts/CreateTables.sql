-- Exit [telephone_company] db before drop
USE [master];

-- Drop database if it is already present
IF EXISTS(
  SELECT *
  FROM [sys].[databases]
  WHERE [name] = 'telephone_company'
) BEGIN
  DROP DATABASE [telephone_company]
END

-- Create new database
CREATE DATABASE [telephone_company];

USE [telephone_company];

-- Create Organisations table
CREATE TABLE [organisations]
(
  [organisation_id] INT IDENTITY(1, 1) PRIMARY KEY,
  [name] NVARCHAR(50) NOT NULL,
);

-- Create Subscribers table
CREATE TABLE [subscribers]
(
  [subscriber_id] INT IDENTITY(1, 1) PRIMARY KEY,
  [organisation_id] INT NOT NULL,
  [inn] INT NOT NULL,
  [first_name] NVARCHAR(30) NOT NULL,
  [last_name] NVARCHAR(30) NOT NULL,
  [patronymic] NVARCHAR(30),
  [adress] NVARCHAR(50),
  FOREIGN KEY(organisation_id) REFERENCES [organisations](organisation_id) ON DELETE CASCADE
);


-- Create Accounts table
CREATE TABLE [accounts]
(
  [account_id] INT IDENTITY(1, 1) PRIMARY KEY,
  [subscriber_id] INT NOT NULL,
  [balance] MONEY DEFAULT 0,
  FOREIGN KEY(subscriber_id) REFERENCES [subscribers](subscriber_id) ON DELETE CASCADE
);


-- Create TransactionTypes table
CREATE TABLE [transaction_types]
(
  [transaction_type_id] INT IDENTITY(1, 1) PRIMARY KEY,
  [title] NVARCHAR(50) NOT NULL,
);


-- Create Transactions table
CREATE TABLE [transactions]
(
  [transaction_id] INT IDENTITY(1, 1) PRIMARY KEY,
  [transaction_type_id] INT NOT NULL,
  [account_id] INT NOT NULL,
  [amount] SMALLMONEY NOT NULL,
  [timestamp] DATETIME DEFAULT CURRENT_TIMESTAMP,
  FOREIGN KEY(transaction_type_id) REFERENCES [transaction_types](transaction_type_id) ON DELETE CASCADE,
  FOREIGN KEY(account_id) REFERENCES [accounts](account_id) ON DELETE CASCADE
);


-- Create Daytimes table
CREATE TABLE [daytimes]
(
  [daytime_id] INT IDENTITY(1, 1) PRIMARY KEY,
  [title] NVARCHAR(20) NOT NULL,
);


-- Create Localities table
CREATE TABLE [localities]
(
  [locality_id] INT IDENTITY(1, 1) PRIMARY KEY,
  [name] NVARCHAR(50) NOT NULL,
);


-- Create Prices table
CREATE TABLE [prices]
(
  [price_id] INT IDENTITY(1, 1) PRIMARY KEY,
  [locality_id] INT NOT NULL,
  [title] NVARCHAR(50) NOT NULL,
  FOREIGN KEY(locality_id) REFERENCES [localities](locality_id) ON DELETE CASCADE
);


-- Create DaytimePrices table
CREATE TABLE [daytime_prices]
(
  [price_id] INT NOT NULL,
  [daytime_id] INT NOT NULL,
  [price_per_minute] SMALLMONEY NOT NULL,
  PRIMARY KEY(price_id, daytime_id),
  FOREIGN KEY(price_id) REFERENCES [prices](price_id) ON DELETE CASCADE,
  FOREIGN KEY(daytime_id) REFERENCES [daytimes](daytime_id) ON DELETE CASCADE
);


-- Create Calls table
CREATE TABLE [calls]
(
  [call_id] INT IDENTITY(1,1) PRIMARY KEY,
  [subscriber_id] INT,
  [daytime_id] INT,
  [locality_id] INT,
  [duration] INT NOT NULL,
  [timestamp] DATETIME DEFAULT CURRENT_TIMESTAMP,
  [deleted_at] DATETIME DEFAULT NULL,
  FOREIGN KEY(subscriber_id) REFERENCES [subscribers](subscriber_id) ON DELETE SET NULL,
  FOREIGN KEY(daytime_id) REFERENCES [daytimes](daytime_id) ON DELETE SET NULL,
  FOREIGN KEY(locality_id) REFERENCES [localities](locality_id) ON DELETE SET NULL,
);
