CREATE DATABASE [WorkDb]
GO
USE [WorkDb]
GO
/****** Object:  Table [dbo].[EmailAccountConfiguration]    Script Date: 29.02.2024 18:04:34 ******/
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
/****** Object:  Table [dbo].[EmailFooters]    Script Date: 29.02.2024 18:04:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmailFooters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmailSchemaId] [int] NOT NULL,
	[LogoId] [int] NOT NULL,
	[TextHtml] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_EmailFooters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmailListRecipients]    Script Date: 29.02.2024 18:04:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmailListRecipients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RecipientListId] [int] NOT NULL,
	[RecipientId] [int] NOT NULL,
 CONSTRAINT [PK_EmailListRecipients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmailLogos]    Script Date: 29.02.2024 18:04:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmailLogos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Type] [nvarchar](max) NOT NULL,
	[FileByteArray] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_EmailLogos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmailRecipients]    Script Date: 29.02.2024 18:04:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmailRecipients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[EmailAdress] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_EmailRecipients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmailRecipientsLists]    Script Date: 29.02.2024 18:04:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmailRecipientsLists](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[ServiceId] [int] NOT NULL,
 CONSTRAINT [PK_EmailRecipientsLists] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmailSchemas]    Script Date: 29.02.2024 18:04:34 ******/
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
/****** Object:  Table [dbo].[EmailSchemaVariables]    Script Date: 29.02.2024 18:04:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmailSchemaVariables](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmailSchemaId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_EmailSchemaVariables] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServicesPermisions]    Script Date: 29.02.2024 18:04:34 ******/
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
ALTER TABLE [dbo].[EmailAccountConfiguration]  WITH CHECK ADD  CONSTRAINT [FK_EmailAccountConfiguration_ServicesPermisions_ServiceId] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[ServicesPermisions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmailAccountConfiguration] CHECK CONSTRAINT [FK_EmailAccountConfiguration_ServicesPermisions_ServiceId]
GO
ALTER TABLE [dbo].[EmailFooters]  WITH CHECK ADD  CONSTRAINT [FK_EmailFooters_EmailLogos_LogoId] FOREIGN KEY([LogoId])
REFERENCES [dbo].[EmailLogos] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmailFooters] CHECK CONSTRAINT [FK_EmailFooters_EmailLogos_LogoId]
GO
ALTER TABLE [dbo].[EmailFooters]  WITH CHECK ADD  CONSTRAINT [FK_EmailFooters_EmailSchemas_EmailSchemaId] FOREIGN KEY([EmailSchemaId])
REFERENCES [dbo].[EmailSchemas] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmailFooters] CHECK CONSTRAINT [FK_EmailFooters_EmailSchemas_EmailSchemaId]
GO
ALTER TABLE [dbo].[EmailListRecipients]  WITH CHECK ADD  CONSTRAINT [FK_EmailListRecipients_EmailRecipients_RecipientId] FOREIGN KEY([RecipientId])
REFERENCES [dbo].[EmailRecipients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmailListRecipients] CHECK CONSTRAINT [FK_EmailListRecipients_EmailRecipients_RecipientId]
GO
ALTER TABLE [dbo].[EmailListRecipients]  WITH CHECK ADD  CONSTRAINT [FK_EmailListRecipients_EmailRecipientsLists_RecipientListId] FOREIGN KEY([RecipientListId])
REFERENCES [dbo].[EmailRecipientsLists] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmailListRecipients] CHECK CONSTRAINT [FK_EmailListRecipients_EmailRecipientsLists_RecipientListId]
GO
ALTER TABLE [dbo].[EmailRecipientsLists]  WITH CHECK ADD  CONSTRAINT [FK_EmailRecipientsLists_ServicesPermisions_ServiceId] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[ServicesPermisions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmailRecipientsLists] CHECK CONSTRAINT [FK_EmailRecipientsLists_ServicesPermisions_ServiceId]
GO
ALTER TABLE [dbo].[EmailSchemas]  WITH CHECK ADD  CONSTRAINT [FK_EmailSchemas_ServicesPermisions_ServiceId] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[ServicesPermisions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmailSchemas] CHECK CONSTRAINT [FK_EmailSchemas_ServicesPermisions_ServiceId]
GO
ALTER TABLE [dbo].[EmailSchemaVariables]  WITH CHECK ADD  CONSTRAINT [FK_EmailSchemaVariables_EmailSchemas_EmailSchemaId] FOREIGN KEY([EmailSchemaId])
REFERENCES [dbo].[EmailSchemas] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmailSchemaVariables] CHECK CONSTRAINT [FK_EmailSchemaVariables_EmailSchemas_EmailSchemaId]
GO
