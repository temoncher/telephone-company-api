USE [telephone_company];

INSERT INTO
  [calls]
  ([subscriber_id], [locality_id], [duration])
VALUES
  (@subscriberId, @localityId, @duration);