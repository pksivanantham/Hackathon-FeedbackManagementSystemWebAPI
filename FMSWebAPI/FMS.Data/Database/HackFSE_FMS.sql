
USE master;
IF DB_ID(N'HackFSE_FMS') IS NOT NULL
DROP DATABASE HackFSE_FMS;
GO

CREATE DATABASE HackFSE_FMS;
GO

USE HackFSE_FMS

-- ****************** HAckFSE: Microsoft SQL Server ******************
-- ******************************************************************
--IF OBJECT_ID('[dbo].[EmployeeDetails]','U')  IS NOT NULL
--DROP TABLE   [dbo].[EmployeeDetails];
--GO


---- ************************************** [dbo].[EmployeeDetails]

--CREATE TABLE [dbo].[EmployeeDetails]
--(
-- [EmployeeID]            int NOT NULL ,
-- [EmployeeName]          varchar(100) NOT NULL ,
-- [BusinessUnit]          varchar(50) NULL ,
-- [EmployeeContactNumber] varchar(50) NULL ,

-- CONSTRAINT [PK_EmployeeDetails_EmployeeID] PRIMARY KEY CLUSTERED ([EmployeeID] ASC)
--);
GO

IF OBJECT_ID('[dbo].[OutreachEvent]','U')  IS NOT NULL
DROP TABLE [dbo].[OutreachEvent];
GO


-- ************************************** [dbo].[OutreachEvent]

CREATE TABLE [dbo].[OutreachEvent]
(
 [EventID]             varchar(12) NOT NULL ,
 [EventName]           varchar(500) NOT NULL ,
 [EventDescription]    varchar(500) NULL ,
 [EventDate]           datetime NOT NULL ,
 [BaseLocation]        varchar(100) NOT NULL ,
 [BeneficiaryName]     varchar(200) NOT NULL ,
 [BeneficiaryAddress]  varchar(500) NULL ,
 [CouncilName]         varchar(200) NULL ,
 [ProjectName]         varchar(100) NULL ,
 [Category]            varchar(100) NULL ,
 [LivesImpacted]       decimal(18,0) NOT NULL ,
 --[NumberOfVolunteer]   int NOT NULL ,
 --[TotalVolunteerHours] decimal(18,0) NOT NULL ,
 --[TotalTravelHours]    decimal(18,0) NOT NULL ,

 CONSTRAINT [PK_OutreachEvent_EventID] PRIMARY KEY CLUSTERED ([EventID] ASC)
);
GO

IF OBJECT_ID('[dbo].[ParticipationStatus]','U')  IS NOT NULL
DROP TABLE [dbo].[ParticipationStatus];
GO


-- ************************************** [ParticipationStatus]

CREATE TABLE [ParticipationStatus]
(
 [ParticipationStatusID] int NOT NULL ,
 [ParticipationStatus]   varchar(50) NOT NULL ,
 [Description]           varchar(100) NOT NULL ,

 CONSTRAINT [PK_ParticipationStatus_ParticipationStatusID] PRIMARY KEY CLUSTERED ([ParticipationStatusID] ASC)
);
GO


-- ****************** HackFSE: Microsoft SQL Server ******************
-- ******************************************************************
IF OBJECT_ID('[dbo].[EventPOCDetails]','U')  IS NOT NULL
DROP TABLE [dbo].[EventPOCDetails];
GO


-- ************************************** [EventPOCDetails]

CREATE TABLE [EventPOCDetails]
(
 [EventPOCDetailsID] int NOT NULL IDENTITY(1,1) ,
 [EventID]           varchar(12) NOT NULL ,
 [EmployeeID]        int NOT NULL ,
 [EmployeeName]          varchar(100) NOT NULL , 
 [EmployeeContactNumber] varchar(50) NULL ,

 CONSTRAINT [PK_EventPOCDetails_EventPOCDetailsID] PRIMARY KEY CLUSTERED ([EventPOCDetailsID] ASC),
 CONSTRAINT [FK_EventPOCDetails_OutreachEvent] FOREIGN KEY ([EventID])  REFERENCES [dbo].[OutreachEvent]([EventID]),
-- CONSTRAINT [FK_EventPOCDetails_EmployeeDetails] FOREIGN KEY ([EmployeeID])  REFERENCES [dbo].[EmployeeDetails]([EmployeeID])
);
GO


CREATE NONCLUSTERED INDEX [IX_EventPOCDetails_EventID] ON [EventPOCDetails] 
 (
  [EventID] ASC
 )

GO

--CREATE NONCLUSTERED INDEX [IX_EventPOCDetails_EmployeeID] ON [EventPOCDetails] 
-- (
--  [EmployeeID] ASC
-- )

--GO

IF OBJECT_ID('[dbo].[EventVolunteerDetails]','U')  IS NOT NULL
DROP TABLE [dbo].[EventVolunteerDetails];
GO


-- ************************************** [dbo].[EventVolunteerDetails]

CREATE TABLE [dbo].[EventVolunteerDetails]
(
 [EventVolunteerDetailsID] int NOT NULL IDENTITY(1,1) ,
 [EventID]                 varchar(12) NOT NULL , 
 [EmployeeID]        int NOT NULL ,
 [EmployeeName]          varchar(100) NULL , 
 [EmployeeContactNumber] varchar(50) NULL ,
 [BusinessUnit]          varchar(50) NULL,
 [VolunteerHours]          decimal(18,0) NULL ,
 [TravelHours]             decimal(18,0) NULL ,
 [Status]                  varchar(20) NULL ,
 [IsMailSend]              bit NOT NULL ,
 [MailSendCount]           int NOT NULL ,
 [ParticipationStatusID]   int NOT NULL ,

 CONSTRAINT [PK_EventEmployeeDetails_EventVolunteerDetailsID] PRIMARY KEY CLUSTERED ([EventVolunteerDetailsID] ASC),
 --CONSTRAINT [FK_EventEmployeeDetails_EmployeeDetails] FOREIGN KEY ([EmployeeID])  REFERENCES [dbo].[EmployeeDetails]([EmployeeID]),
 CONSTRAINT [FK_EventEmployeeDetails_OutreachEvent] FOREIGN KEY ([EventID])  REFERENCES [dbo].[OutreachEvent]([EventID]),
 CONSTRAINT [FK_EventEmployeeDetails_ParticipationStatus] FOREIGN KEY ([ParticipationStatusID])  REFERENCES [ParticipationStatus]([ParticipationStatusID])
);
GO


--CREATE NONCLUSTERED INDEX [IX_EventEmployeeDetails_EmployeeID] ON [dbo].[EventVolunteerDetails] 
-- (
--  [EmployeeID] ASC
-- )

--GO

CREATE NONCLUSTERED INDEX [IX_EventEmployeeDetails_EventID] ON [dbo].[EventVolunteerDetails] 
 (
  [EventID] ASC
 )

GO

CREATE NONCLUSTERED INDEX [IX_EventEmployeeDetails_ParticipationStatusID] ON [dbo].[EventVolunteerDetails] 
 (
  [ParticipationStatusID] ASC
 )

GO


Insert into [ParticipationStatus] ([ParticipationStatusID]  ,
 [ParticipationStatus]   ,
 [Description]           ) values (1,'Participated','Registered and participated')
 Insert into [ParticipationStatus] ([ParticipationStatusID]  ,
 [ParticipationStatus]   ,
 [Description]           ) values (2,'Did not participate','Registered and did not participate')
 Insert into [ParticipationStatus] ([ParticipationStatusID]  ,
 [ParticipationStatus]   ,
 [Description]           ) values (3,'Unregistered','Registered and did not attend')


