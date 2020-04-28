
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/24/2020 20:50:49
-- Generated from EDMX file: C:\Users\Dawei\source\repos\HealthGrove\Models\HealthyGrove_Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [HealthyGrove_DB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_InvasiveSavedInvasive]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SavedInvasiveSet] DROP CONSTRAINT [FK_InvasiveSavedInvasive];
GO
IF OBJECT_ID(N'[dbo].[FK_NonInvasiveSavedNonInvasive]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SavedNonInvasiveSet] DROP CONSTRAINT [FK_NonInvasiveSavedNonInvasive];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[InvasiveSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvasiveSet];
GO
IF OBJECT_ID(N'[dbo].[NonInvasiveSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NonInvasiveSet];
GO
IF OBJECT_ID(N'[dbo].[SavedInvasiveSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SavedInvasiveSet];
GO
IF OBJECT_ID(N'[dbo].[SavedNonInvasiveSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SavedNonInvasiveSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'InvasiveSet'
CREATE TABLE [dbo].[InvasiveSet] (
    [InvasiveId] int IDENTITY(1,1) NOT NULL,
    [ScientificName] nvarchar(max)  NOT NULL,
    [CommonName] nvarchar(max)  NOT NULL,
    [PlantType] nvarchar(max)  NOT NULL,
    [WeedStatus] nvarchar(max)  NOT NULL,
    [VictorianStatus] nvarchar(max)  NOT NULL,
    [Area_of_potential_distribution_remaining] nvarchar(max)  NOT NULL,
    [Potential_for_invasion] nvarchar(max)  NOT NULL,
    [RiskRating] nvarchar(max)  NOT NULL,
    [Family] nvarchar(max)  NOT NULL,
    [VictorianBiomes] nvarchar(max)  NOT NULL,
    [Impact_on_natural_systems] nvarchar(max)  NOT NULL,
    [Native] nvarchar(max)  NOT NULL,
    [Rate_of_dispersal] nvarchar(max)  NOT NULL,
    [HeightRanges] nvarchar(max)  NOT NULL,
    [SpreadRanges] nvarchar(max)  NOT NULL,
    [FlowerColour] nvarchar(max)  NOT NULL,
    [LeafColour] nvarchar(max)  NOT NULL,
    [ClimateZones] nvarchar(max)  NOT NULL,
    [Abcission] nvarchar(max)  NOT NULL,
    [SoilType] nvarchar(max)  NOT NULL,
    [LightNeeds] nvarchar(max)  NOT NULL,
    [Impact_score] int  NULL,
    [Potential_distribution_score] int  NULL,
    [Residual_risk_score] int  NULL,
    [Invasiveness_score] int  NULL,
    [Rate_of_dispersal_score] int  NULL,
    [Urgency_score] int  NULL,
    [Risk_ranking_score] float  NULL,
    [Image] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'NonInvasiveSet'
CREATE TABLE [dbo].[NonInvasiveSet] (
    [NonInvasiveId] int IDENTITY(1,1) NOT NULL,
    [ScientificName] nvarchar(max)  NOT NULL,
    [CommonName] nvarchar(max)  NOT NULL,
    [PlantType] nvarchar(max)  NOT NULL,
    [Maintenance] nvarchar(max)  NOT NULL,
    [FlowerColour] nvarchar(max)  NOT NULL,
    [FoliageColour] nvarchar(max)  NOT NULL,
    [HeightRanges] nvarchar(max)  NOT NULL,
    [Native] nvarchar(max)  NOT NULL,
    [SpreadRanges] nvarchar(max)  NOT NULL,
    [ClimateZones] nvarchar(max)  NOT NULL,
    [WaterNeeds] nvarchar(max)  NOT NULL,
    [LightNeeds] nvarchar(max)  NOT NULL,
    [SoilType] nvarchar(max)  NOT NULL,
    [FrostTolerance] nvarchar(max)  NOT NULL,
    [Abcission] nvarchar(max)  NOT NULL,
    [Image] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SavedInvasiveSet'
CREATE TABLE [dbo].[SavedInvasiveSet] (
    [SavedInvasiveId] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(max)  NOT NULL,
    [InvasiveId] int  NOT NULL
);
GO

-- Creating table 'SavedNonInvasiveSet'
CREATE TABLE [dbo].[SavedNonInvasiveSet] (
    [SavedNonInvasiveId] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(max)  NOT NULL,
    [NonInvasiveId] int  NOT NULL
);
GO

-- Creating table 'NurserySet'
CREATE TABLE [dbo].[NurserySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NurseryName] nvarchar(max)  NOT NULL,
    [Suburb] nvarchar(max)  NOT NULL,
    [Postcode] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [InvasiveId] in table 'InvasiveSet'
ALTER TABLE [dbo].[InvasiveSet]
ADD CONSTRAINT [PK_InvasiveSet]
    PRIMARY KEY CLUSTERED ([InvasiveId] ASC);
GO

-- Creating primary key on [NonInvasiveId] in table 'NonInvasiveSet'
ALTER TABLE [dbo].[NonInvasiveSet]
ADD CONSTRAINT [PK_NonInvasiveSet]
    PRIMARY KEY CLUSTERED ([NonInvasiveId] ASC);
GO

-- Creating primary key on [SavedInvasiveId] in table 'SavedInvasiveSet'
ALTER TABLE [dbo].[SavedInvasiveSet]
ADD CONSTRAINT [PK_SavedInvasiveSet]
    PRIMARY KEY CLUSTERED ([SavedInvasiveId] ASC);
GO

-- Creating primary key on [SavedNonInvasiveId] in table 'SavedNonInvasiveSet'
ALTER TABLE [dbo].[SavedNonInvasiveSet]
ADD CONSTRAINT [PK_SavedNonInvasiveSet]
    PRIMARY KEY CLUSTERED ([SavedNonInvasiveId] ASC);
GO

-- Creating primary key on [Id] in table 'NurserySet'
ALTER TABLE [dbo].[NurserySet]
ADD CONSTRAINT [PK_NurserySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [InvasiveId] in table 'SavedInvasiveSet'
ALTER TABLE [dbo].[SavedInvasiveSet]
ADD CONSTRAINT [FK_InvasiveSavedInvasive]
    FOREIGN KEY ([InvasiveId])
    REFERENCES [dbo].[InvasiveSet]
        ([InvasiveId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_InvasiveSavedInvasive'
CREATE INDEX [IX_FK_InvasiveSavedInvasive]
ON [dbo].[SavedInvasiveSet]
    ([InvasiveId]);
GO

-- Creating foreign key on [NonInvasiveId] in table 'SavedNonInvasiveSet'
ALTER TABLE [dbo].[SavedNonInvasiveSet]
ADD CONSTRAINT [FK_NonInvasiveSavedNonInvasive]
    FOREIGN KEY ([NonInvasiveId])
    REFERENCES [dbo].[NonInvasiveSet]
        ([NonInvasiveId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NonInvasiveSavedNonInvasive'
CREATE INDEX [IX_FK_NonInvasiveSavedNonInvasive]
ON [dbo].[SavedNonInvasiveSet]
    ([NonInvasiveId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------