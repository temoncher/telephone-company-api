USE [telephone_company];

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
    (
        @organisationId,
        @inn,
        @firstName,
        @lastName,
        @patronymic,
        @adress
    );