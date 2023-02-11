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
    [IntChefId]                         BIGINT              NOT NULL IDENTITY,
    [StrChefName]                       VARCHAR(45)             NULL DEFAULT NULL,
    [FltSalary]                         FLOAT                   NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([IntChefId])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Meal')
CREATE TABLE [dbo].[Meal] (
    [IntMealId]                         BIGINT              NOT NULL IDENTITY,
    [StrName]                           VARCHAR(45)             NULL DEFAULT NULL,
    [FltPrice]                          FLOAT                   NULL DEFAULT NULL,
    [IntChefId]                         BIGINT                  NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([IntMealId])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Order')
CREATE TABLE [dbo].[Order] (
    [IntOrderId]                        BIGINT              NOT NULL IDENTITY,
    [IntCustomerId]                     BIGINT                  NULL DEFAULT NULL,
    [IntMealId]                         BIGINT                  NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([IntOrderId])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Supplier')
CREATE TABLE [dbo].[Supplier] (
    [IntSupplierId]                     BIGINT              NOT NULL IDENTITY,
    [StrSupplierCity]                   VARCHAR(45)             NULL DEFAULT NULL,
    [TxtSupplierName]                   TEXT                    NULL DEFAULT NULL,
    [IntPhone]                          INT                     NULL DEFAULT NULL,
    [IntChefId]                         BIGINT                  NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([IntSupplierId])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Waiter')
CREATE TABLE [dbo].[Waiter] (
    [IntWaiterId]                       BIGINT              NOT NULL IDENTITY,
    [StrWaiterName]                     VARCHAR(45)             NULL DEFAULT NULL,
    [FltSalary]                         FLOAT                   NULL DEFAULT NULL,
    [IntPhone]                          INT                     NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([IntWaiterId])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Customer')
CREATE TABLE [dbo].[Customer] (
    [IntCustomerId]                     BIGINT              NOT NULL IDENTITY,
    [StrCustomerName]                   VARCHAR(45)             NULL DEFAULT NULL,
    [StrAddress]                        VARCHAR(45)             NULL DEFAULT NULL,
    [IntPhone]                          INT                     NULL DEFAULT NULL,
    [IntWaiterId]                       BIGINT                  NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([IntCustomerId])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Ingredient')
CREATE TABLE [dbo].[Ingredient] (
    [IntIngredientId]                   BIGINT              NOT NULL IDENTITY,
    [StrIngredientName]                 VARCHAR(45)             NULL DEFAULT NULL,
    [StrDescription]                    VARCHAR(45)             NULL DEFAULT NULL,
    [IntMealId]                         BIGINT                  NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([IntIngredientId])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Provider')
CREATE TABLE [dbo].[Provider] (
    [IntProviderId]                     BIGINT              NOT NULL IDENTITY,
    [IntSupplierId]                     BIGINT                  NULL DEFAULT NULL,
    [IntIngredientId]                   BIGINT                  NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([IntProviderId])
);

-- ---------------------------- --
-- --------FOREIGN KEYS-------- --
-- ---------------------------- --

ALTER TABLE [Meal]
    ADD CONSTRAINT [FkMealChefId]
        FOREIGN KEY ([IntChefId])
        REFERENCES [Chef] ([IntChefId])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Supplier]
    ADD CONSTRAINT [FkSupplierChefId]
        FOREIGN KEY ([IntChefId])
        REFERENCES [Chef] ([IntChefId])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Customer]
    ADD CONSTRAINT [FkCustomerWaiterId]
        FOREIGN KEY ([IntWaiterId])
        REFERENCES [Waiter] ([IntWaiterId])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Ingredient]
    ADD CONSTRAINT [FkIngredientMealId]
        FOREIGN KEY ([IntMealId])
        REFERENCES [Meal] ([IntMealId])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Order]
    ADD CONSTRAINT [FkOrderCustomerId]
        FOREIGN KEY ([IntCustomerId])
        REFERENCES [Customer] ([IntCustomerId])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [FkOrderMealId]
        FOREIGN KEY ([IntMealId])
        REFERENCES [Meal] ([IntMealId])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Provider]
    ADD CONSTRAINT [FkProviderSupplierId]
        FOREIGN KEY ([IntSupplierId])
        REFERENCES [Supplier] ([IntSupplierId])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [FkProviderIngredientId]
        FOREIGN KEY ([IntIngredientId])
        REFERENCES [Ingredient] ([IntIngredientId])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

