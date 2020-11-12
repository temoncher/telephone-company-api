USE [telephone_company]

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

-- Seed TransactionTypes table
INSERT INTO
  [transaction_types]
    ([title])
VALUES
  ('INCOME'),
  ('LOSS');

-- Seed Daytimes table
INSERT INTO
  [daytimes]
    ([title])
VALUES
  (N'Утро'),
  (N'День'),
  (N'Вечер'),
  (N'Ночь');

-- Seed Localities table
INSERT INTO
  [localities]
    ([name])
VALUES
  (N'Ярославль'),
  (N'Москва'),
  ('Brooklyn'),
  ('Disney Land');

-- Seed Subscribers table
INSERT INTO
  [subscribers]
    (
      [organisation_id],
      [locality_id],
      [inn],
      [first_name],
      [last_name],
      [patronymic],
      [adress]
    )
VALUES
  (3, 1, 111, 'John', 'Doe', NULL, 'Brooklyn'),
  (
    1,
    2,
    112,
    N'Артем',
    N'Баранов',
    N'Сергеевич',
    N'Ярославль'
  ),
  (3, 2, 113, N'Мини', N'Маус', NULL, 'Disney Land'),
  (3, 1, 114, N'Стивен', N'Джобс', NULL, NULL),
  (4, NULL, 115, 'Bill', 'Gates', NULL, NULL),
  (
    3,
    NULL,
    116,
    N'Микки',
    N'Маус',
    NULL,
    'Disney Land'
  );


-- No need to seed Accounts because they will be generated on trigger


-- Seed Transactions table
INSERT INTO
  [transactions]
    (
      [transaction_type_id],
      [account_id],
      [amount],
      [created_at]
    )
VALUES
  (1, 1, 100, '2020-04-20 13:10:02.047'),
  (1, 1, 100, '2020-05-22 12:11:02.047'),
  (1, 1, 200, '2020-04-23 23:00:02.047'),
  (1, 1, 100, '2020-05-23 23:40:02.047'),
  (1, 3, 100, '2020-05-13 23:40:02.047'),
  (1, 3, 400, '2020-05-13 23:43:02.047'),
  (1, 4, 1500, '2019-11-25 15:10:02.047'),
  (1, 2, 10, '2019-08-21 02:11:02.047'),
  (1, 2, 300, '2019-06-25 20:00:02.047'),
  (1, 2, 500, '2019-05-21 23:10:02.047'),
  (1, 2, 815, '2018-04-23 23:10:02.047');

-- Seed Prices table
INSERT INTO
  [prices]
    ([locality_id], [title])
VALUES
  (1, 'Best price'),
  (1, N'Прайс Надежный'),
  (2, N'Москва не ждет'),
  (3, 'Brooklyn Night'),
  (4, 'Disney Land');


-- Seed DaytimePrices table
INSERT INTO
  [daytime_prices]
    (
      [price_id],
      [daytime_id],
      [price_per_minute]
    )
VALUES
  (1, 1, 60),
  (1, 2, 30),
  (1, 3, 30),
  (1, 4, 10),
  (2, 1, 100),
  (2, 2, 80),
  (2, 3, 40),
  (2, 4, 30),
  (3, 1, 10),
  (3, 2, 20),
  (3, 3, 30),
  (3, 4, 40),
  (4, 1, 20),
  (4, 2, 20),
  (4, 3, 20),
  (4, 4, 20);

-- Seed Calls table
INSERT INTO
  [calls]
    (
      [subscriber_id],
      [locality_id],
      [duration],
      [daytime_id],
      [created_at]
    )
VALUES
  (1, 1, 60, 1, '2020-04-30 13:10:02.047'),
  (1, 1, 33, 2, '2020-04-30 12:11:02.047'),
  (1, 1, 245, 1, '2020-04-23 23:00:02.047'),
  (1, 2, 123, 3, '2020-05-23 23:40:02.047'),
  (1, 1, 22, 4, '2020-05-13 23:40:02.047'),
  (1, 1, 12, 1, '2020-05-13 23:43:02.047'),
  (2, 2, 11, 1, '2019-11-30 15:10:02.047'),
  (2, 2, 123, 2, '2019-08-30 02:11:02.047'),
  (2, 2, 54, 3, '2019-06-23 20:00:02.047'),
  (2, 2, 64, 4, '2019-06-23 23:10:02.047'),
  (2, 2, 23, 1, '2019-06-13 23:30:02.047'),
  (2, 2, 12, 2, '2019-06-13 22:43:02.047'),
  (3, 2, 11, 4, '2018-12-30 14:15:02.047'),
  (3, 2, 123, 4, '2018-11-30 01:31:02.047'),
  (3, 2, 54, 2, '2018-11-23 21:21:02.047'),
  (3, 2, 64, 3, '2018-11-23 23:10:02.047');
