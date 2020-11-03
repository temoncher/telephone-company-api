-- Add account for each new subscriber
CREATE TRIGGER [TR_subscribers_AfterInsert] ON [subscribers]
AFTER
INSERT
  AS BEGIN
  SET NOCOUNT ON

  INSERT INTO
  [accounts]
    ([subscriber_id])
  SELECT
    [subscriber_id]
  FROM
    [INSERTED]
END;