USE [telephone_company]
GO

-- Seed Organisations table
INSERT INTO
  [organisations]
  ([name])
VALUES
  (N'ЯрГУ им. П.Г. Демидова'),
  (N'Тензор'),
  (N'McDonalds'),
  (N'KFC'),
  (N'Аквелон');

GO

-- Seed Subscribers table
INSERT INTO
  [subscribers]
  (
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

GO

-- No need to seed Accounts because they will be generated on trigger
-- Seed TransactionTypes table
INSERT INTO
  [transaction_types]
  ([title])
VALUES
  ('INCOME'),
  ('LOSS');

GO

-- Seed Transactions table
INSERT INTO
  [transactions]
  (
  [transaction_type_id],
  [account_id],
  [amount]
  )
VALUES
  (1, 1, 100),
  (1, 1, 100),
  (1, 1, 200),
  (2, 1, 100),
  (2, 3, 100),
  (2, 3, 400),
  (1, 4, 1500),
  (1, 2, 10),
  (2, 2, 300),
  (2, 2, 500),
  (1, 2, 815);

GO

-- Seed Daytimes table
INSERT INTO
  [daytimes]
  ([title])
VALUES
  (N'Утро'),
  (N'День'),
  (N'Вечер'),
  (N'Ночь');

GO

-- Seed Localities table
INSERT INTO
  [localities]
  ([name])
VALUES
  (N'Ярославль'),
  (N'Москва'),
  (N'Brooklyn'),
  (N'Disney Land');

GO