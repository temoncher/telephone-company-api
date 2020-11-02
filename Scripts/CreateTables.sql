-- Drop database if it is already present
IF EXISTS(
  SELECT
  *
FROM
  [sys].[databases]
WHERE
    [name] = 'telephone_company'
) BEGIN
  DROP DATABASE [telephone_company]
END

GO

-- Create new database
CREATE DATABASE [telephone_company]
GO

-- Create Organisations table
USE [telephone_company];

CREATE TABLE [organisations]
(
  [organisation_id] INT IDENTITY(1, 1) PRIMARY KEY,
  [name] NVARCHAR(50) NOT NULL,
);

GO

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

GO

-- Create Accounts table
CREATE TABLE [accounts]
(
  [account_id] INT IDENTITY(1, 1) PRIMARY KEY,
  [subscriber_id] INT NOT NULL,
  [balance] INT DEFAULT 0,
  FOREIGN KEY(subscriber_id) REFERENCES [subscribers](subscriber_id) ON DELETE CASCADE
);

GO

-- Create TransactionTypes table
CREATE TABLE [transaction_types]
(
  [transaction_type_id] INT IDENTITY(1, 1) PRIMARY KEY,
  [title] NVARCHAR(50) NOT NULL,
);

GO

-- Create Transactions table
CREATE TABLE [transactions]
(
  [transaction_id] INT IDENTITY(1, 1) PRIMARY KEY,
  [transaction_type_id] INT NOT NULL,
  [account_id] INT NOT NULL,
  [amount] INT NOT NULL,
  [timestamp] DATETIME DEFAULT CURRENT_TIMESTAMP,
  FOREIGN KEY(transaction_type_id) REFERENCES [transaction_types](transaction_type_id) ON DELETE CASCADE,
  FOREIGN KEY(account_id) REFERENCES [accounts](account_id) ON DELETE CASCADE
);

GO

-- Create Daytimes table
CREATE TABLE [daytimes]
(
  [daytime_id] INT IDENTITY(1, 1) PRIMARY KEY,
  [title] NVARCHAR(20) NOT NULL,
);

GO

-- Create Localities table
CREATE TABLE [localities]
(
  [locality_id] INT IDENTITY(1, 1) PRIMARY KEY,
  [name] NVARCHAR(50) NOT NULL,
);

GO