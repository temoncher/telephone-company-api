USE [telephone_company];

CREATE ROLE [dbAdminRole];

GRANT SELECT, UPDATE, INSERT, DELETE, EXECUTE TO [dbAdminRole];
GRANT VIEW DEFINITION TO [dbAdminRole];

CREATE USER [User_baranov4] FROM LOGIN [User_baranov4];

ALTER ROLE [dbAdminRole] ADD MEMBER [User_baranov4];

CREATE ROLE [dbManagerRole];

GRANT SELECT, UPDATE, INSERT, DELETE ON [daytimes] TO [dbManagerRole];
GRANT SELECT, UPDATE, INSERT, DELETE ON [prices] TO [dbManagerRole];
GRANT SELECT, UPDATE, INSERT, DELETE ON [localities] TO [dbManagerRole];
GRANT SELECT, UPDATE, INSERT, DELETE ON [daytime_prices] TO [dbManagerRole];

CREATE USER [User1_baranov4] FROM LOGIN [User1_baranov4];

ALTER ROLE [dbManagerRole] ADD MEMBER [User1_baranov4];