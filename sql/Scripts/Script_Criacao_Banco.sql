USE [MinhaAplicacao]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 14/06/2021 12:35:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemPedidos]    Script Date: 14/06/2021 12:35:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemPedidos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](80) NOT NULL,
	[PrecoUnitario] [decimal](10, 2) NOT NULL,
	[Quantidade] [int] NOT NULL,
	[PedidoId] [int] NOT NULL,
	[DataHoraCadastro] [datetime] NOT NULL,
	[DataHoraModificado] [datetime] NULL,
 CONSTRAINT [PK_ItemPedidos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedidos]    Script Date: 14/06/2021 12:35:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedidos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Numero] [varchar](80) NOT NULL,
	[DataHoraCadastro] [datetime] NOT NULL,
	[DataHoraModificado] [datetime] NULL,
 CONSTRAINT [PK_Pedidos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ItemPedidos]  WITH CHECK ADD  CONSTRAINT [FK_ItemPedidos_Pedidos_PedidoId] FOREIGN KEY([PedidoId])
REFERENCES [dbo].[Pedidos] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ItemPedidos] CHECK CONSTRAINT [FK_ItemPedidos_Pedidos_PedidoId]
GO
