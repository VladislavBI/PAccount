
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/02/2018 10:13:57
-- Generated from EDMX file: D:\Программирование\train project\PAccountant\PAccountant.Model\Entity\PAccountModelContext.edmx
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

IF OBJECT_ID(N'[dbo].[FK_debt_DebtOperations_Currencies]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[debt.DebtOperations] DROP CONSTRAINT [FK_debt_DebtOperations_Currencies];
GO
IF OBJECT_ID(N'[dbo].[FK_debt_DebtOperations_debt_DebtAgent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[debt.DebtOperations] DROP CONSTRAINT [FK_debt_DebtOperations_debt_DebtAgent];
GO
IF OBJECT_ID(N'[dbo].[FK_debt_DebtOperations_debt_DebtType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[debt.DebtOperations] DROP CONSTRAINT [FK_debt_DebtOperations_debt_DebtType];
GO
IF OBJECT_ID(N'[dbo].[FK_debt_DebtOperations_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[debt.DebtOperations] DROP CONSTRAINT [FK_debt_DebtOperations_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_debt_Transactions_debt_DebtOperations]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[debt.Transactions] DROP CONSTRAINT [FK_debt_Transactions_debt_DebtOperations];
GO
IF OBJECT_ID(N'[dbo].[FK_Operation_Currency]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Operations] DROP CONSTRAINT [FK_Operation_Currency];
GO
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
IF OBJECT_ID(N'[dbo].[FK_other_Projects_Currencies]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[other.Projects] DROP CONSTRAINT [FK_other_Projects_Currencies];
GO
IF OBJECT_ID(N'[dbo].[FK_other_Projects_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[other.Projects] DROP CONSTRAINT [FK_other_Projects_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_other_FreelancePayement_Currencies]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[other_FreelancePayement] DROP CONSTRAINT [FK_other_FreelancePayement_Currencies];
GO
IF OBJECT_ID(N'[dbo].[FK_other_FreelancePayement_other_Projects]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[other_FreelancePayement] DROP CONSTRAINT [FK_other_FreelancePayement_other_Projects];
GO
IF OBJECT_ID(N'[dbo].[FK_other_SpendHoursPerProject_other_Projects]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[other_SpendHoursPerProject] DROP CONSTRAINT [FK_other_SpendHoursPerProject_other_Projects];
GO
IF OBJECT_ID(N'[dbo].[FK_template_Operations_Operations]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[template.Operations] DROP CONSTRAINT [FK_template_Operations_Operations];
GO
IF OBJECT_ID(N'[dbo].[FK_template_FK_Operation_Currency]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Operations] DROP CONSTRAINT [FK_template_FK_Operation_Currency];
GO
IF OBJECT_ID(N'[dbo].[FK_template_FK_Operation_OperationCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Operations] DROP CONSTRAINT [FK_template_FK_Operation_OperationCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_template_FK_Operation_OperationSource]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Operations] DROP CONSTRAINT [FK_template_FK_Operation_OperationSource];
GO
IF OBJECT_ID(N'[dbo].[FK_template_FK_Operation_OperationType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Operations] DROP CONSTRAINT [FK_template_FK_Operation_OperationType];
GO
IF OBJECT_ID(N'[dbo].[FK_template_FK_Operation_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Operations] DROP CONSTRAINT [FK_template_FK_Operation_User];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Currencies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Currencies];
GO
IF OBJECT_ID(N'[dbo].[debt.DebtAgent]', 'U') IS NOT NULL
    DROP TABLE [dbo].[debt.DebtAgent];
GO
IF OBJECT_ID(N'[dbo].[debt.DebtOperations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[debt.DebtOperations];
GO
IF OBJECT_ID(N'[dbo].[debt.DebtType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[debt.DebtType];
GO
IF OBJECT_ID(N'[dbo].[debt.Transactions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[debt.Transactions];
GO
IF OBJECT_ID(N'[dbo].[OperationCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OperationCategories];
GO
IF OBJECT_ID(N'[dbo].[Operations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Operations];
GO
IF OBJECT_ID(N'[dbo].[OperationSources]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OperationSources];
GO
IF OBJECT_ID(N'[dbo].[OperationTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OperationTypes];
GO
IF OBJECT_ID(N'[dbo].[other.PlannedBuy]', 'U') IS NOT NULL
    DROP TABLE [dbo].[other.PlannedBuy];
GO
IF OBJECT_ID(N'[dbo].[other.Projects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[other.Projects];
GO
IF OBJECT_ID(N'[dbo].[other.sumStored]', 'U') IS NOT NULL
    DROP TABLE [dbo].[other.sumStored];
GO
IF OBJECT_ID(N'[dbo].[other_FreelancePayement]', 'U') IS NOT NULL
    DROP TABLE [dbo].[other_FreelancePayement];
GO
IF OBJECT_ID(N'[dbo].[other_SpendHoursPerProject]', 'U') IS NOT NULL
    DROP TABLE [dbo].[other_SpendHoursPerProject];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[template.Operations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[template.Operations];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
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

-- Creating table 'debt_DebtAgent'
CREATE TABLE [dbo].[debt_DebtAgent] (
    [Id] int  NOT NULL,
    [Name] varchar(50)  NOT NULL
);
GO

-- Creating table 'debt_Transactions'
CREATE TABLE [dbo].[debt_Transactions] (
    [Id] int  NOT NULL,
    [DebtOperationId] int  NOT NULL,
    [Sum] float  NOT NULL,
    [Date] datetime  NOT NULL
);
GO

-- Creating table 'debt_DebtOperations'
CREATE TABLE [dbo].[debt_DebtOperations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AgentId] int  NOT NULL,
    [UserId] int  NOT NULL,
    [DebtTypeId] int  NOT NULL,
    [StartSum] float  NOT NULL,
    [RewardSum] float  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] datetime  NOT NULL,
    [CurrencyId] int  NOT NULL,
    [Comment] varchar(max)  NULL,
    [IsInProgress] bit  NOT NULL
);
GO

-- Creating table 'debt_DebtType'
CREATE TABLE [dbo].[debt_DebtType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL
);
GO

-- Creating table 'template_Operations'
CREATE TABLE [dbo].[template_Operations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(100)  NOT NULL,
    [OperationId] int  NOT NULL
);
GO

-- Creating table 'other_PlannedBuy'
CREATE TABLE [dbo].[other_PlannedBuy] (
    [Id] int  NOT NULL,
    [Name] nvarchar(50)  NULL,
    [Sum] float  NULL,
    [UserId] int  NULL
);
GO

-- Creating table 'other_sumStored'
CREATE TABLE [dbo].[other_sumStored] (
    [Id] int  NOT NULL,
    [Sum] float  NULL,
    [UserId] int  NULL
);
GO

-- Creating table 'other_Projects'
CREATE TABLE [dbo].[other_Projects] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SumPerHour] float  NOT NULL,
    [TotalHours] float  NOT NULL,
    [UserId] int  NOT NULL,
    [CurrencyId] int  NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [IsEnded] bit  NOT NULL
);
GO

-- Creating table 'other_FreelancePayement'
CREATE TABLE [dbo].[other_FreelancePayement] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProjectId] int  NOT NULL,
    [HoursPayed] float  NOT NULL,
    [SumPayed] float  NOT NULL,
    [PayDate] datetime  NOT NULL,
    [CurrencyId] int  NOT NULL
);
GO

-- Creating table 'other_SpendHoursPerProject'
CREATE TABLE [dbo].[other_SpendHoursPerProject] (
    [Id] int  NOT NULL,
    [SpendHours] float  NOT NULL,
    [ProjectId] int  NOT NULL
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

-- Creating primary key on [Id] in table 'debt_DebtAgent'
ALTER TABLE [dbo].[debt_DebtAgent]
ADD CONSTRAINT [PK_debt_DebtAgent]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'debt_Transactions'
ALTER TABLE [dbo].[debt_Transactions]
ADD CONSTRAINT [PK_debt_Transactions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'debt_DebtOperations'
ALTER TABLE [dbo].[debt_DebtOperations]
ADD CONSTRAINT [PK_debt_DebtOperations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'debt_DebtType'
ALTER TABLE [dbo].[debt_DebtType]
ADD CONSTRAINT [PK_debt_DebtType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'template_Operations'
ALTER TABLE [dbo].[template_Operations]
ADD CONSTRAINT [PK_template_Operations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'other_PlannedBuy'
ALTER TABLE [dbo].[other_PlannedBuy]
ADD CONSTRAINT [PK_other_PlannedBuy]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'other_sumStored'
ALTER TABLE [dbo].[other_sumStored]
ADD CONSTRAINT [PK_other_sumStored]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'other_Projects'
ALTER TABLE [dbo].[other_Projects]
ADD CONSTRAINT [PK_other_Projects]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'other_FreelancePayement'
ALTER TABLE [dbo].[other_FreelancePayement]
ADD CONSTRAINT [PK_other_FreelancePayement]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'other_SpendHoursPerProject'
ALTER TABLE [dbo].[other_SpendHoursPerProject]
ADD CONSTRAINT [PK_other_SpendHoursPerProject]
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

-- Creating foreign key on [CurrencyId] in table 'debt_DebtOperations'
ALTER TABLE [dbo].[debt_DebtOperations]
ADD CONSTRAINT [FK_debt_DebtOperations_Currencies]
    FOREIGN KEY ([CurrencyId])
    REFERENCES [dbo].[Currencies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_debt_DebtOperations_Currencies'
CREATE INDEX [IX_FK_debt_DebtOperations_Currencies]
ON [dbo].[debt_DebtOperations]
    ([CurrencyId]);
GO

-- Creating foreign key on [AgentId] in table 'debt_DebtOperations'
ALTER TABLE [dbo].[debt_DebtOperations]
ADD CONSTRAINT [FK_debt_DebtOperations_debt_DebtAgent]
    FOREIGN KEY ([AgentId])
    REFERENCES [dbo].[debt_DebtAgent]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_debt_DebtOperations_debt_DebtAgent'
CREATE INDEX [IX_FK_debt_DebtOperations_debt_DebtAgent]
ON [dbo].[debt_DebtOperations]
    ([AgentId]);
GO

-- Creating foreign key on [DebtTypeId] in table 'debt_DebtOperations'
ALTER TABLE [dbo].[debt_DebtOperations]
ADD CONSTRAINT [FK_debt_DebtOperations_debt_DebtType]
    FOREIGN KEY ([DebtTypeId])
    REFERENCES [dbo].[debt_DebtType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_debt_DebtOperations_debt_DebtType'
CREATE INDEX [IX_FK_debt_DebtOperations_debt_DebtType]
ON [dbo].[debt_DebtOperations]
    ([DebtTypeId]);
GO

-- Creating foreign key on [UserId] in table 'debt_DebtOperations'
ALTER TABLE [dbo].[debt_DebtOperations]
ADD CONSTRAINT [FK_debt_DebtOperations_Users]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_debt_DebtOperations_Users'
CREATE INDEX [IX_FK_debt_DebtOperations_Users]
ON [dbo].[debt_DebtOperations]
    ([UserId]);
GO

-- Creating foreign key on [DebtOperationId] in table 'debt_Transactions'
ALTER TABLE [dbo].[debt_Transactions]
ADD CONSTRAINT [FK_debt_Transactions_debt_DebtOperations]
    FOREIGN KEY ([DebtOperationId])
    REFERENCES [dbo].[debt_DebtOperations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_debt_Transactions_debt_DebtOperations'
CREATE INDEX [IX_FK_debt_Transactions_debt_DebtOperations]
ON [dbo].[debt_Transactions]
    ([DebtOperationId]);
GO

-- Creating foreign key on [OperationId] in table 'template_Operations'
ALTER TABLE [dbo].[template_Operations]
ADD CONSTRAINT [FK_template_Operations_Operations]
    FOREIGN KEY ([OperationId])
    REFERENCES [dbo].[Operations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_template_Operations_Operations'
CREATE INDEX [IX_FK_template_Operations_Operations]
ON [dbo].[template_Operations]
    ([OperationId]);
GO

-- Creating foreign key on [CurrencyId] in table 'other_Projects'
ALTER TABLE [dbo].[other_Projects]
ADD CONSTRAINT [FK_other_Projects_Currencies]
    FOREIGN KEY ([CurrencyId])
    REFERENCES [dbo].[Currencies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_other_Projects_Currencies'
CREATE INDEX [IX_FK_other_Projects_Currencies]
ON [dbo].[other_Projects]
    ([CurrencyId]);
GO

-- Creating foreign key on [CurrencyId] in table 'other_FreelancePayement'
ALTER TABLE [dbo].[other_FreelancePayement]
ADD CONSTRAINT [FK_other_FreelancePayement_Currencies]
    FOREIGN KEY ([CurrencyId])
    REFERENCES [dbo].[Currencies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_other_FreelancePayement_Currencies'
CREATE INDEX [IX_FK_other_FreelancePayement_Currencies]
ON [dbo].[other_FreelancePayement]
    ([CurrencyId]);
GO

-- Creating foreign key on [UserId] in table 'other_Projects'
ALTER TABLE [dbo].[other_Projects]
ADD CONSTRAINT [FK_other_Projects_Users]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_other_Projects_Users'
CREATE INDEX [IX_FK_other_Projects_Users]
ON [dbo].[other_Projects]
    ([UserId]);
GO

-- Creating foreign key on [ProjectId] in table 'other_FreelancePayement'
ALTER TABLE [dbo].[other_FreelancePayement]
ADD CONSTRAINT [FK_other_FreelancePayement_other_Projects]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[other_Projects]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_other_FreelancePayement_other_Projects'
CREATE INDEX [IX_FK_other_FreelancePayement_other_Projects]
ON [dbo].[other_FreelancePayement]
    ([ProjectId]);
GO

-- Creating foreign key on [ProjectId] in table 'other_SpendHoursPerProject'
ALTER TABLE [dbo].[other_SpendHoursPerProject]
ADD CONSTRAINT [FK_other_SpendHoursPerProject_other_Projects]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[other_Projects]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_other_SpendHoursPerProject_other_Projects'
CREATE INDEX [IX_FK_other_SpendHoursPerProject_other_Projects]
ON [dbo].[other_SpendHoursPerProject]
    ([ProjectId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------