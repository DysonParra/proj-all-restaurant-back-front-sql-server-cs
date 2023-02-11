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
    [ChefId]                            BIGINT              NOT NULL IDENTITY,
    [ChefName]                          VARCHAR(45)             NULL DEFAULT NULL,
    [Salary]                            FLOAT                   NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([ChefId])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Meal')
CREATE TABLE [dbo].[Meal] (
    [MealId]                            BIGINT              NOT NULL IDENTITY,
    [Name]                              VARCHAR(45)             NULL DEFAULT NULL,
    [Price]                             FLOAT                   NULL DEFAULT NULL,
    [ChefId]                            BIGINT                  NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([MealId])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Order')
CREATE TABLE [dbo].[Order] (
    [OrderId]                           BIGINT              NOT NULL IDENTITY,
    [CustomerId]                        BIGINT                  NULL DEFAULT NULL,
    [MealId]                            BIGINT                  NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([OrderId])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Supplier')
CREATE TABLE [dbo].[Supplier] (
    [SupplierId]                        BIGINT              NOT NULL IDENTITY,
    [SupplierCity]                      VARCHAR(45)             NULL DEFAULT NULL,
    [SupplierName]                      TEXT                    NULL DEFAULT NULL,
    [Phone]                             INT                     NULL DEFAULT NULL,
    [ChefId]                            BIGINT                  NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([SupplierId])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Waiter')
CREATE TABLE [dbo].[Waiter] (
    [WaiterId]                          BIGINT              NOT NULL IDENTITY,
    [WaiterName]                        VARCHAR(45)             NULL DEFAULT NULL,
    [Salary]                            FLOAT                   NULL DEFAULT NULL,
    [Phone]                             INT                     NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([WaiterId])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Customer')
CREATE TABLE [dbo].[Customer] (
    [CustomerId]                        BIGINT              NOT NULL IDENTITY,
    [CustomerName]                      VARCHAR(45)             NULL DEFAULT NULL,
    [Address]                           VARCHAR(45)             NULL DEFAULT NULL,
    [Phone]                             INT                     NULL DEFAULT NULL,
    [WaiterId]                          BIGINT                  NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([CustomerId])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Ingredient')
CREATE TABLE [dbo].[Ingredient] (
    [IngredientId]                      BIGINT              NOT NULL IDENTITY,
    [IngredientName]                    VARCHAR(45)             NULL DEFAULT NULL,
    [Description]                       VARCHAR(45)             NULL DEFAULT NULL,
    [MealId]                            BIGINT                  NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([IngredientId])
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Provider')
CREATE TABLE [dbo].[Provider] (
    [ProviderId]                        BIGINT              NOT NULL IDENTITY,
    [SupplierId]                        BIGINT                  NULL DEFAULT NULL,
    [IngredientId]                      BIGINT                  NULL DEFAULT NULL,
    PRIMARY KEY CLUSTERED ([ProviderId])
);

-- ---------------------------- --
-- --------FOREIGN KEYS-------- --
-- ---------------------------- --

ALTER TABLE [Meal]
    ADD CONSTRAINT [FkMealChefId]
        FOREIGN KEY ([ChefId])
        REFERENCES [Chef] ([ChefId])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Supplier]
    ADD CONSTRAINT [FkSupplierChefId]
        FOREIGN KEY ([ChefId])
        REFERENCES [Chef] ([ChefId])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Customer]
    ADD CONSTRAINT [FkCustomerWaiterId]
        FOREIGN KEY ([WaiterId])
        REFERENCES [Waiter] ([WaiterId])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Ingredient]
    ADD CONSTRAINT [FkIngredientMealId]
        FOREIGN KEY ([MealId])
        REFERENCES [Meal] ([MealId])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Order]
    ADD CONSTRAINT [FkOrderCustomerId]
        FOREIGN KEY ([CustomerId])
        REFERENCES [Customer] ([CustomerId])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [FkOrderMealId]
        FOREIGN KEY ([MealId])
        REFERENCES [Meal] ([MealId])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Provider]
    ADD CONSTRAINT [FkProviderSupplierId]
        FOREIGN KEY ([SupplierId])
        REFERENCES [Supplier] ([SupplierId])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    CONSTRAINT [FkProviderIngredientId]
        FOREIGN KEY ([IngredientId])
        REFERENCES [Ingredient] ([IngredientId])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

