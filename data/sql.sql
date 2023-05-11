USE [LoginRazor]
GO

/****** Object:  Table [dbo].[personne]    Script Date: 11/05/2023 20:18:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[personne](
	[idPersonne] [int] IDENTITY(1,1) NOT NULL,
	[nomPersonne] [varchar](50) NOT NULL,
	[prenomPersonne] [varchar](50) NOT NULL,
	[mdp] [varbinary](64) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idPersonne] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

