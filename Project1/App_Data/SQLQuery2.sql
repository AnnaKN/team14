﻿CREATE TABLE [dbo].[Ratings](
	[Worker] [varchar](50) NOT NULL,
	[JobID] [int] NOT NULL,
	[TimeManagement] [int] NULL,
	[Interpersonal] [int] NULL,
	[Quality] [int] NULL,
	[Profesionalism] [int] NULL,
	[QuickRating] [int] NULL,
	[Consistency] [int] NULL,
	[Comments] [varchar](max) NULL,
	[Pending] [varchar](50) NULL,
 CONSTRAINT [PK_Ratings_1] PRIMARY KEY CLUSTERED 
(
	[Worker] ASC,
	[JobID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]