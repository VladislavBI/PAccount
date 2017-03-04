
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/18/2017 16:19:38
-- Generated from EDMX file: D:\VSProjects\Projects\PAccountant\PAccountant.Model\Entity\PAccountModelContext.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PAccountant];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Operation_OperationCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Operations] DROP CONSTRAINT [FK_Operation_OperationCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_Operation_OperationSource]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Operations] DROP CONSTRAINT [FK_Operation_OperationSource];
GO
IF OBJECT_ID(N'[dbo].[FK_Operation_OperationType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Operations] DROP CONSTRAINT [FK_Operation_OperationType];
GO
IF OBJECT_ID(N'[dbo].[FK_Operation_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Operations] DROP CONSTRAINT [FK_Operation_User];
GO
IF OBJECT_ID(N'[dbo].[FK_OperationCategory_OperationType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OperationCategories] DROP CONSTRAINT [FK_OperationCategory_OperationType];
GO
IF OBJECT_ID(N'[dbo].[FK_Operation_Currency]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Operations] DROP CONSTRAINT [FK_Operation_Currency];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Operations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Operations];
GO
IF OBJECT_ID(N'[dbo].[OperationCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OperationCategories];
GO
IF OBJECT_ID(N'[dbo].[OperationSources]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OperationSources];
GO
IF OBJECT_ID(N'[dbo].[OperationTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OperationTypes];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Currencies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Currencies];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Operations'
CREATE TABLE [dbo].[Operations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [Summ] decimal(19,4)  NOT NULL,
    [Commentary] varchar(max)  NULL,
    [UserId] int  NOT NULL,
    [SourceId] int  NOT NULL,
    [CategoryId] int  NOT NULL,
    [CurrencyId] int  NOT NULL,
    [OperationTypeId] int  NOT NULL
);
GO

-- Creating table 'OperationCategories'
CREATE TABLE [dbo].[OperationCategories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [OperationTypeId] int  NOT NULL
);
GO

-- Creating table 'OperationSources'
CREATE TABLE [dbo].[OperationSources] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'OperationTypes'
CREATE TABLE [dbo].[OperationTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Password] varbinary(50)  NOT NULL
);
GO

-- Creating table 'Currencies'
CREATE TABLE [dbo].[Currencies] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Sale_Rate] float  NOT NULL,
    [Buy_Rate] float  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Operations'
ALTER TABLE [dbo].[Operations]
ADD CONSTRAINT [PK_Operations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OperationCategories'
ALTER TABLE [dbo].[OperationCategories]
ADD CONSTRAINT [PK_OperationCategories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OperationSources'
ALTER TABLE [dbo].[OperationSources]
ADD CONSTRAINT [PK_OperationSources]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OperationTypes'
ALTER TABLE [dbo].[OperationTypes]
ADD CONSTRAINT [PK_OperationTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Currencies'
ALTER TABLE [dbo].[Currencies]
ADD CONSTRAINT [PK_Currencies]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CategoryId] in table 'Operations'
ALTER TABLE [dbo].[Operations]
ADD CONSTRAINT [FK_Operation_OperationCategory]
    FOREIGN KEY ([CategoryId])
    REFERENCES [dbo].[OperationCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Operation_OperationCategory'
CREATE INDEX [IX_FK_Operation_OperationCategory]
ON [dbo].[Operations]
    ([CategoryId]);
GO

-- Creating foreign key on [SourceId] in table 'Operations'
ALTER TABLE [dbo].[Operations]
ADD CONSTRAINT [FK_Operation_OperationSource]
    FOREIGN KEY ([SourceId])
    REFERENCES [dbo].[OperationSources]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Operation_OperationSource'
CREATE INDEX [IX_FK_Operation_OperationSource]
ON [dbo].[Operations]
    ([SourceId]);
GO

-- Creating foreign key on [OperationTypeId] in table 'Operations'
ALTER TABLE [dbo].[Operations]
ADD CONSTRAINT [FK_Operation_OperationType]
    FOREIGN KEY ([OperationTypeId])
    REFERENCES [dbo].[OperationTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Operation_OperationType'
CREATE INDEX [IX_FK_Operation_OperationType]
ON [dbo].[Operations]
    ([OperationTypeId]);
GO

-- Creating foreign key on [UserId] in table 'Operations'
ALTER TABLE [dbo].[Operations]
ADD CONSTRAINT [FK_Operation_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Operation_User'
CREATE INDEX [IX_FK_Operation_User]
ON [dbo].[Operations]
    ([UserId]);
GO

-- Creating foreign key on [OperationTypeId] in table 'OperationCategories'
ALTER TABLE [dbo].[OperationCategories]
ADD CONSTRAINT [FK_OperationCategory_OperationType]
    FOREIGN KEY ([OperationTypeId])
    REFERENCES [dbo].[OperationTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OperationCategory_OperationType'
CREATE INDEX [IX_FK_OperationCategory_OperationType]
ON [dbo].[OperationCategories]
    ([OperationTypeId]);
GO

-- Creating foreign key on [CurrencyId] in table 'Operations'
ALTER TABLE [dbo].[Operations]
ADD CONSTRAINT [FK_Operation_Currency]
    FOREIGN KEY ([CurrencyId])
    REFERENCES [dbo].[Currencies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Operation_Currency'
CREATE INDEX [IX_FK_Operation_Currency]
ON [dbo].[Operations]
    ([CurrencyId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------