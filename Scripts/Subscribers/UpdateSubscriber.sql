USE TelephoneCompany;

UPDATE subscribers
SET organisation_id = @organisationId,
    account_id = @accountId,
    inn = @inn,
    adress = @adress,
    first_name = @firstName,
    last_name = @lastName,
    patronymic = @patronymic
WHERE subscriber_id = @subscriberId