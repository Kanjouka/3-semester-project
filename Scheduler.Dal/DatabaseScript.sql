USE [DMA-CSD-V221_10434635]
--DROP TABLE [hour_slip]
--DROP TABLE [employee]
--DROP TABLE [project]
--DROP TABLE [address]
--DROP TABLE [city]
--DROP TABLE [role]

CREATE TABLE [dbo].[role](
	[id] [int] NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[role_name] [nvarchar](50) NOT NULL
)

CREATE TABLE [dbo].[city](
	[zip] [nvarchar](20) NOT NULL PRIMARY KEY,
	[city_name] [nvarchar](100) NOT NULL
)

CREATE TABLE [dbo].[address](
	[id] [int] NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[street_name] [nvarchar](50) NOT NULL,
	[street_number] [nvarchar](10) NOT NULL,
	[zip] [nvarchar](20) NOT NULL FOREIGN KEY REFERENCES [city]([zip])
)
CREATE TABLE [dbo].[project](
	[id] [int] NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[name] [nvarchar](100) NOT NULL,
	[start_date] [date] NOT NULL,
	[end_date] [date] NOT NULL,
	[total_minutes] [int] NOT NULL DEFAULT 0,
	[address_id_fk] [int] FOREIGN KEY REFERENCES [address]([id])
)

CREATE TABLE [dbo].[employee](
	[id] [int] NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[first_name] [nvarchar](100) NOT NULL,
	[last_name] [nvarchar](100) NOT NULL,
	[phone_number] [varchar](15) NOT NULL,
	[email] [varchar](100) NOT NULL UNIQUE,
	[hashed_password] [nvarchar](500) NOT NULL,
	[address_id_fk] [int] FOREIGN KEY REFERENCES [address]([id]),
	[project_id_fk] [int] FOREIGN KEY REFERENCES [project]([id]),
	[role_id_fk] [int] NOT NULL FOREIGN KEY REFERENCES [role]([id])
)

CREATE TABLE [dbo].[hour_slip](
	[id] [int] NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[is_approved] [bit] NOT NULL DEFAULT 0,
	[date] [datetime] NOT NULL,
	[start_time] [datetime] NOT NULL,
	[end_time] [datetime] NOT NULL,
	[row_version] [timestamp] NOT NULL,
	[employee_id_fk] [int] NOT NULL FOREIGN KEY REFERENCES [employee]([id]),
	[project_id_fk] [int] FOREIGN KEY REFERENCES [project]([id])
)