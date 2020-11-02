USE [telephone_company]
GO
;

-- Create trigger to add account for each new subscriber
CREATE TRIGGER [TR_subscribers_InsteadOfInsert] ON [subscribers]
AFTER
INSERT
  AS BEGIN
INSERT INTO
  [accounts] ([subscriber_id])
SELECT
  [subscriber_id]
FROM
  inserted
END;

GO
;