USE TelephoneCompany;

CREATE TABLE subscribers
(
  subscriber_id INT PRIMARY KEY,
  organisation_id INT,
  account_id INT,
  inn INT,
  adress VARCHAR(50),
  first_name VARCHAR(30),
  last_name VARCHAR(30),
  patronymic VARCHAR(30)
);