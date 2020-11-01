USE [telephone_company];

UPDATE
  [subscribers]
SET
  [organisation_id] = @organisationId,
  [inn] = @inn,
  [adress] = @adress,
  [first_name] = @firstName,
  [last_name] = @lastName,
  [patronymic] = @patronymic
WHERE
  [subscriber_id] = @subscriberId