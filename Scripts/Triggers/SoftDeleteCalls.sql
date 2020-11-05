-- Soft delete call
CREATE TRIGGER [TR_calls_InsteadOfDelete] ON [calls]
INSTEAD OF DELETE
AS BEGIN
  SET NOCOUNT ON;

  UPDATE
    [calls]
  SET
    [deleted_at] = CURRENT_TIMESTAMP
  WHERE
    [call_id] IN (
      SELECT [call_id]
      FROM [DELETED]
    );
END