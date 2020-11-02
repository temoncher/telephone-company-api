USE [telephone_company]
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