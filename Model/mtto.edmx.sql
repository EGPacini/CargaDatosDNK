
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/04/2021 12:49:01
-- Generated from EDMX file: C:\Users\DNK Water\source\repos\WindowsFormsApp1\Model\mtto.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ContratoMantenimiento];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[BehaviorHidraulic]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BehaviorHidraulic];
GO
IF OBJECT_ID(N'[dbo].[BehaviorInstrumentation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BehaviorInstrumentation];
GO
IF OBJECT_ID(N'[dbo].[SitesMtto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SitesMtto];
GO
IF OBJECT_ID(N'[dbo].[TaskSuppliesUsed]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TaskSuppliesUsed];
GO
IF OBJECT_ID(N'[dbo].[TechnicalServices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TechnicalServices];
GO
IF OBJECT_ID(N'[dbo].[Tickets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tickets];
GO
IF OBJECT_ID(N'[dbo].[TareasPreventivas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TareasPreventivas];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BehaviorHidraulic'
CREATE TABLE [dbo].[BehaviorHidraulic] (
    [id] int IDENTITY(1,1) NOT NULL,
    [siteIDDatagate] nvarchar(255)  NULL,
    [datetime] datetime  NULL,
    [ch1Value] float  NULL,
    [ch2Value] float  NULL,
    [ch3Value] float  NULL
);
GO

-- Creating table 'BehaviorInstrumentation'
CREATE TABLE [dbo].[BehaviorInstrumentation] (
    [id] int IDENTITY(1,1) NOT NULL,
    [siteIDDatagate] nvarchar(255)  NULL,
    [datetime] datetime  NULL,
    [csq] int  NULL,
    [battery] float  NULL,
    [lastCallIn] datetime  NULL
);
GO

-- Creating table 'SitesMtto'
CREATE TABLE [dbo].[SitesMtto] (
    [id] int IDENTITY(1,1) NOT NULL,
    [siteIDDatagate] nvarchar(255)  NULL,
    [idFieldBeat] nvarchar(255)  NULL,
    [addressDatagate] nvarchar(255)  NULL,
    [createDateDatagate] datetime  NULL,
    [typeDevice] nvarchar(255)  NULL,
    [latitudeSite] float  NULL,
    [longitudeSite] float  NULL,
    [MeasuresDevice] varchar(40)  NULL
);
GO

-- Creating table 'TaskSuppliesUsed'
CREATE TABLE [dbo].[TaskSuppliesUsed] (
    [id] int IDENTITY(1,1) NOT NULL,
    [idFieldbeat] nvarchar(255)  NULL,
    [idTaskFieldbeat] nvarchar(255)  NULL,
    [datetimeTask] datetime  NULL,
    [suppliesUsed] nvarchar(255)  NULL,
    [quantity] int  NULL,
    [TaskType] varchar(25)  NULL,
    [currentStatus] varchar(30)  NULL
);
GO

-- Creating table 'TechnicalServices'
CREATE TABLE [dbo].[TechnicalServices] (
    [id] int IDENTITY(1,1) NOT NULL,
    [datetimeIn] datetime  NULL,
    [datetimeOut] datetime  NULL,
    [serviceReference] nvarchar(255)  NULL,
    [suppliesUsed] nvarchar(255)  NULL,
    [diagnosticDevice] nvarchar(255)  NULL,
    [idFieldBeat] nvarchar(255)  NULL
);
GO

-- Creating table 'Tickets'
CREATE TABLE [dbo].[Tickets] (
    [id] int IDENTITY(1,1) NOT NULL,
    [ticketNumber] int  NULL,
    [createDate] datetime  NULL,
    [siteIDDatagate] nvarchar(255)  NULL,
    [currentStatus] nvarchar(255)  NULL,
    [teamAssigned] nvarchar(255)  NULL,
    [closedDateDG] datetime  NULL,
    [lastUpdated] datetime  NULL,
    [SLAPlan] varchar(25)  NULL,
    [Overdue] varchar(5)  NULL,
    [tipoEvento] varchar(25)  NULL
);
GO

-- Creating table 'TareasPreventivas'
CREATE TABLE [dbo].[TareasPreventivas] (
    [id] int IDENTITY(1,1) NOT NULL,
    [cliente] varchar(30)  NULL,
    [sucursal] varchar(30)  NULL,
    [tasktype] varchar(30)  NULL,
    [createdate] datetime  NULL,
    [currentstatus] varchar(30)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'BehaviorHidraulic'
ALTER TABLE [dbo].[BehaviorHidraulic]
ADD CONSTRAINT [PK_BehaviorHidraulic]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'BehaviorInstrumentation'
ALTER TABLE [dbo].[BehaviorInstrumentation]
ADD CONSTRAINT [PK_BehaviorInstrumentation]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'SitesMtto'
ALTER TABLE [dbo].[SitesMtto]
ADD CONSTRAINT [PK_SitesMtto]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'TaskSuppliesUsed'
ALTER TABLE [dbo].[TaskSuppliesUsed]
ADD CONSTRAINT [PK_TaskSuppliesUsed]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'TechnicalServices'
ALTER TABLE [dbo].[TechnicalServices]
ADD CONSTRAINT [PK_TechnicalServices]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [PK_Tickets]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'TareasPreventivas'
ALTER TABLE [dbo].[TareasPreventivas]
ADD CONSTRAINT [PK_TareasPreventivas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------