USE [WorkDb]
GO
/****** Object:  Table [dbo].[EmailAccountConfiguration]    Script Date: 20.02.2024 15:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmailAccountConfiguration](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServiceId] [int] NOT NULL,
	[SMTP] [nvarchar](max) NOT NULL,
	[Port] [int] NOT NULL,
	[Login] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_EmailAccountConfiguration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmailFooters]    Script Date: 20.02.2024 15:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmailFooters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmailSchemaId] [int] NOT NULL,
	[TextHtml] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_EmailFooters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmailSchemas]    Script Date: 20.02.2024 15:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmailSchemas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServiceId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Subject] [nvarchar](max) NOT NULL,
	[From] [nvarchar](max) NOT NULL,
	[DisplayName] [nvarchar](max) NOT NULL,
	[ReplyTo] [nvarchar](max) NOT NULL,
	[ReplyToDisplayName] [nvarchar](max) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_EmailSchemas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmailSchemaVariables]    Script Date: 20.02.2024 15:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmailSchemaVariables](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_EmailSchemaVariables] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ListUssers]    Script Date: 20.02.2024 15:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListUssers](
	[Id] [int] NOT NULL,
	[UserListId] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[EmailAdress] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ListUssers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logos]    Script Date: 20.02.2024 15:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmailFooterId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Type] [nvarchar](max) NOT NULL,
	[FileByteArray] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Logos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServicesPermisions]    Script Date: 20.02.2024 15:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServicesPermisions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServiceName] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_ServicesPermisions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ussers]    Script Date: 20.02.2024 15:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ussers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[ServiceId] [int] NOT NULL,
 CONSTRAINT [PK_Ussers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[EmailAccountConfiguration]  WITH CHECK ADD  CONSTRAINT [FK_EmailAccountConfiguration_ServicesPermisions_ServiceId] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[ServicesPermisions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmailAccountConfiguration] CHECK CONSTRAINT [FK_EmailAccountConfiguration_ServicesPermisions_ServiceId]
GO
ALTER TABLE [dbo].[EmailFooters]  WITH CHECK ADD  CONSTRAINT [FK_EmailFooters_EmailSchemas_EmailSchemaId] FOREIGN KEY([EmailSchemaId])
REFERENCES [dbo].[EmailSchemas] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmailFooters] CHECK CONSTRAINT [FK_EmailFooters_EmailSchemas_EmailSchemaId]
GO
ALTER TABLE [dbo].[EmailSchemas]  WITH CHECK ADD  CONSTRAINT [FK_EmailSchemas_ServicesPermisions_ServiceId] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[ServicesPermisions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmailSchemas] CHECK CONSTRAINT [FK_EmailSchemas_ServicesPermisions_ServiceId]
GO
ALTER TABLE [dbo].[EmailSchemaVariables]  WITH CHECK ADD  CONSTRAINT [FK_EmailSchemaVariables_EmailSchemas_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[EmailSchemas] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmailSchemaVariables] CHECK CONSTRAINT [FK_EmailSchemaVariables_EmailSchemas_Id]
GO
ALTER TABLE [dbo].[ListUssers]  WITH CHECK ADD  CONSTRAINT [FK_ListUssers_Ussers_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[Ussers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ListUssers] CHECK CONSTRAINT [FK_ListUssers_Ussers_Id]
GO
ALTER TABLE [dbo].[Logos]  WITH CHECK ADD  CONSTRAINT [FK_Logos_EmailFooters_EmailFooterId] FOREIGN KEY([EmailFooterId])
REFERENCES [dbo].[EmailFooters] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Logos] CHECK CONSTRAINT [FK_Logos_EmailFooters_EmailFooterId]
GO
ALTER TABLE [dbo].[Ussers]  WITH CHECK ADD  CONSTRAINT [FK_Ussers_ServicesPermisions_ServiceId] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[ServicesPermisions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ussers] CHECK CONSTRAINT [FK_Ussers_ServicesPermisions_ServiceId]
GO
