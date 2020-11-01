USE [telephone_company];

INSERT INTO
    [subscribers] (
        [organisation_id],
        [account_id],
        [inn],
        [first_name],
        [last_name],
        [patronymic],
        [adress]
    )
VALUES
    (
        @organisationId,
        @accountId,
        @inn,
        @firstName,
        @lastName,
        @patronymic,
        @adress
    );