USE master
GO
IF EXISTS(SELECT * FROM sys.databases WHERE name = 'Restaurant') DROP DATABASE [Restaurant]
GO
CREATE DATABASE [Restaurant];
GO
USE [Restaurant];
GO

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Chef')
CREATE TABLE [dbo].[Chef] (
    [Chef_Id]                           BIGINT              NOT NULL IDENTITY,
    [Chef_Name]                         VARCHAR(45)             NULL DEFAULT NULL,
    [Salary]                            FLOAT                   NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([Chef_Id])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Meal')
CREATE TABLE [dbo].[Meal] (
    [Meal_Id]                           BIGINT              NOT NULL IDENTITY,
    [Name]                              VARCHAR(45)             NULL DEFAULT NULL,
    [Price]                             FLOAT                   NULL DEFAULT NULL,
    [Chef_Id]                           BIGINT                  NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([Meal_Id])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Order')
CREATE TABLE [dbo].[Order] (
    [Order_Id]                          BIGINT              NOT NULL IDENTITY,
    [Customer_Id]                       BIGINT                  NULL DEFAULT NULL,
    [Meal_Id]                           BIGINT                  NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([Order_Id])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Supplier')
CREATE TABLE [dbo].[Supplier] (
    [Supplier_Id]                       BIGINT              NOT NULL IDENTITY,
    [Supplier_City]                     VARCHAR(45)             NULL DEFAULT NULL,
    [Supplier_Name]                     TEXT                    NULL DEFAULT NULL,
    [Phone]                             INT                     NULL DEFAULT NULL,
    [Chef_Id]                           BIGINT                  NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([Supplier_Id])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Waiter')
CREATE TABLE [dbo].[Waiter] (
    [Waiter_Id]                         BIGINT              NOT NULL IDENTITY,
    [Waiter_Name]                       VARCHAR(45)             NULL DEFAULT NULL,
    [Salary]                            FLOAT                   NULL DEFAULT NULL,
    [Phone]                             INT                     NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([Waiter_Id])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Customer')
CREATE TABLE [dbo].[Customer] (
    [Customer_Id]                       BIGINT              NOT NULL IDENTITY,
    [Customer_Name]                     VARCHAR(45)             NULL DEFAULT NULL,
    [Address]                           VARCHAR(45)             NULL DEFAULT NULL,
    [Phone]                             INT                     NULL DEFAULT NULL,
    [Waiter_Id]                         BIGINT                  NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([Customer_Id])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Ingredient')
CREATE TABLE [dbo].[Ingredient] (
    [Ingredient_Id]                     BIGINT              NOT NULL IDENTITY,
    [Ingredient_Name]                   VARCHAR(45)             NULL DEFAULT NULL,
    [Description]                       VARCHAR(45)             NULL DEFAULT NULL,
    [Meal_Id]                           BIGINT                  NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([Ingredient_Id])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Provider')
CREATE TABLE [dbo].[Provider] (
    [Provider_Id]                       BIGINT              NOT NULL IDENTITY,
    [Supplier_Id]                       BIGINT                  NULL DEFAULT NULL,
    [Ingredient_Id]                     BIGINT                  NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([Provider_Id])
);

-- ---------------------------- --
-- --------FOREIGN KEYS-------- --
-- ---------------------------- --

ALTER TABLE [Meal]
    ADD CONSTRAINT [Fk_Meal_Chef_Id]
        FOREIGN KEY ([Chef_Id])
        REFERENCES [Chef] ([Chef_Id])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Supplier]
    ADD CONSTRAINT [Fk_Supplier_Chef_Id]
        FOREIGN KEY ([Chef_Id])
        REFERENCES [Chef] ([Chef_Id])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Customer]
    ADD CONSTRAINT [Fk_Customer_Waiter_Id]
        FOREIGN KEY ([Waiter_Id])
        REFERENCES [Waiter] ([Waiter_Id])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Ingredient]
    ADD CONSTRAINT [Fk_Ingredient_Meal_Id]
        FOREIGN KEY ([Meal_Id])
        REFERENCES [Meal] ([Meal_Id])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Order]
    ADD CONSTRAINT [Fk_Order_Customer_Id]
        FOREIGN KEY ([Customer_Id])
        REFERENCES [Customer] ([Customer_Id])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [Fk_Order_Meal_Id]
        FOREIGN KEY ([Meal_Id])
        REFERENCES [Meal] ([Meal_Id])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Provider]
    ADD CONSTRAINT [Fk_Provider_Supplier_Id]
        FOREIGN KEY ([Supplier_Id])
        REFERENCES [Supplier] ([Supplier_Id])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [Fk_Provider_Ingredient_Id]
        FOREIGN KEY ([Ingredient_Id])
        REFERENCES [Ingredient] ([Ingredient_Id])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

