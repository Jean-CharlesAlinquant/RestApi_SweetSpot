-- Check if the database exists, and create it if it doesn't
IF NOT EXISTS (SELECT * from sys.databases WHERE name = 'InstaPay')
BEGIN
    CREATE DATABASE InstaPay;
END
GO

-- Switch to the target database
USE InstaPay;
GO

-- Create the table
CREATE TABLE SepaMessages (
    TransactionId NVARCHAR(50) PRIMARY KEY,
    MessageContent NVARCHAR(MAX),
    CreatedDate DATETIME
);