/*
Nombre: Criptos.sql
Autor: Elias silva
Descripción: Archivo script para generación de tablas y llenado de datos de prueba
Nota: Crear la base de datos previamente (no se incluyó parte del script de creación de BD 
para evitar conflictos por la inexistencia del path de origen el el equipo destino).
*/
USE [Criptos]
GO
/****** Tabla [dbo].[Criptomoneda]  Prefijo: Crm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Criptomoneda](
	[CrmId] [int] IDENTITY(1,1) NOT NULL,
	[CrmNombre] [nvarchar](100) NOT NULL,
	[CrmSimbolo] [nvarchar](10) NOT NULL,
	[CrmWebOrigen] [nvarchar](200) NULL,
	[CrmDescripcion] [nvarchar](255) NULL,
	[CrmFechaLanzamiento] [date] NULL,
	[Fecha_Creacion] [date] NULL,
	[Fecha_Actualizacion] [date] NULL,
 CONSTRAINT [PK_Criptomoneda] PRIMARY KEY CLUSTERED 
(
	[CrmId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Tabla [dbo].[Moneda] Prefijo: Mon    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Moneda](
	[MonId] [int] IDENTITY(1,1) NOT NULL,
	[MonNombre] [nvarchar](100) NOT NULL,
	[MonSimbolo] [nvarchar](10) NOT NULL,
	[Fecha_Creacion] [date] NULL,
	[Fecha_Actualizacion] [date] NULL,
 CONSTRAINT [PK_Moneda] PRIMARY KEY CLUSTERED 
(
	[MonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Tabla [dbo].[PrecioCripto]   Prefijo: Prc ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrecioCripto](
	[PrcId] [int] IDENTITY(1,1) NOT NULL,
	[CrmId] [int] NOT NULL,
	[MonId] [int] NOT NULL,
	[PrcPrecio] [decimal](18, 2) NULL,
	[PrcPrecioFecha] [date] NULL,
	[Fecha_Creacion] [date] NULL,
	[Fecha_Actualizacion] [date] NULL,
 CONSTRAINT [PK_PrecioCripto] PRIMARY KEY CLUSTERED 
(
	[PrcId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Tabla [dbo].[Usuario]  Prefijo: Usr ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[UsrId] [int] IDENTITY(1,1) NOT NULL,
	[UsrNombre] [nvarchar](100) NOT NULL,
	[UsrCorreo] [nvarchar](50) NULL,
	[UsrUsuario] [nvarchar](10) NOT NULL,
	[UsrClave] [nvarchar](10) NOT NULL,
	[UsrRol] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[UsrId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
-- Datos 

SET IDENTITY_INSERT [dbo].[Criptomoneda] ON 
GO
INSERT [dbo].[Criptomoneda] ([CrmId], [CrmNombre], [CrmSimbolo], [CrmWebOrigen], [CrmDescripcion], [CrmFechaLanzamiento], [Fecha_Creacion], [Fecha_Actualizacion]) VALUES (1, N'Ethereum', N'ETH', NULL, NULL, NULL, CAST(N'2025-07-27' AS Date), NULL)
GO
INSERT [dbo].[Criptomoneda] ([CrmId], [CrmNombre], [CrmSimbolo], [CrmWebOrigen], [CrmDescripcion], [CrmFechaLanzamiento], [Fecha_Creacion], [Fecha_Actualizacion]) VALUES (2, N'Tether', N'USDT', NULL, NULL, NULL, CAST(N'2025-07-27' AS Date), NULL)
GO
INSERT [dbo].[Criptomoneda] ([CrmId], [CrmNombre], [CrmSimbolo], [CrmWebOrigen], [CrmDescripcion], [CrmFechaLanzamiento], [Fecha_Creacion], [Fecha_Actualizacion]) VALUES (3, N'Binance Coin', N'BNB', NULL, NULL, NULL, CAST(N'2025-07-27' AS Date), NULL)
GO
INSERT [dbo].[Criptomoneda] ([CrmId], [CrmNombre], [CrmSimbolo], [CrmWebOrigen], [CrmDescripcion], [CrmFechaLanzamiento], [Fecha_Creacion], [Fecha_Actualizacion]) VALUES (4, N'Bitcoin', N'BTC', NULL, NULL, NULL, CAST(N'2025-07-27' AS Date), NULL)
GO
SET IDENTITY_INSERT [dbo].[Criptomoneda] OFF
GO
SET IDENTITY_INSERT [dbo].[Moneda] ON 
GO
INSERT [dbo].[Moneda] ([MonId], [MonNombre], [MonSimbolo], [Fecha_Creacion], [Fecha_Actualizacion]) VALUES (1, N'Dolar', N'DL', CAST(N'2025-07-27' AS Date), NULL)
GO
INSERT [dbo].[Moneda] ([MonId], [MonNombre], [MonSimbolo], [Fecha_Creacion], [Fecha_Actualizacion]) VALUES (2, N'Bolivar', N'VES', CAST(N'2025-07-27' AS Date), NULL)
GO
INSERT [dbo].[Moneda] ([MonId], [MonNombre], [MonSimbolo], [Fecha_Creacion], [Fecha_Actualizacion]) VALUES (3, N'Euro', N'EUR', CAST(N'2025-07-27' AS Date), NULL)
GO
SET IDENTITY_INSERT [dbo].[Moneda] OFF
GO
SET IDENTITY_INSERT [dbo].[PrecioCripto] ON 
GO
INSERT [dbo].[PrecioCripto] ([PrcId], [CrmId], [MonId], [PrcPrecio], [PrcPrecioFecha], [Fecha_Creacion], [Fecha_Actualizacion]) VALUES (1, 1, 1, CAST(1.00 AS Decimal(18, 2)), CAST(N'2025-05-01' AS Date), CAST(N'2025-05-01' AS Date), NULL)
GO
INSERT [dbo].[PrecioCripto] ([PrcId], [CrmId], [MonId], [PrcPrecio], [PrcPrecioFecha], [Fecha_Creacion], [Fecha_Actualizacion]) VALUES (2, 1, 2, CAST(90.00 AS Decimal(18, 2)), CAST(N'2025-05-01' AS Date), CAST(N'2025-05-01' AS Date), NULL)
GO
INSERT [dbo].[PrecioCripto] ([PrcId], [CrmId], [MonId], [PrcPrecio], [PrcPrecioFecha], [Fecha_Creacion], [Fecha_Actualizacion]) VALUES (3, 2, 1, CAST(2.00 AS Decimal(18, 2)), CAST(N'2025-05-10' AS Date), CAST(N'2025-05-10' AS Date), NULL)
GO
INSERT [dbo].[PrecioCripto] ([PrcId], [CrmId], [MonId], [PrcPrecio], [PrcPrecioFecha], [Fecha_Creacion], [Fecha_Actualizacion]) VALUES (4, 2, 2, CAST(180.00 AS Decimal(18, 2)), CAST(N'2025-05-10' AS Date), CAST(N'2025-05-10' AS Date), NULL)
GO
INSERT [dbo].[PrecioCripto] ([PrcId], [CrmId], [MonId], [PrcPrecio], [PrcPrecioFecha], [Fecha_Creacion], [Fecha_Actualizacion]) VALUES (5, 1, 2, CAST(90.00 AS Decimal(18, 2)), CAST(N'2025-05-02' AS Date), CAST(N'2025-05-02' AS Date), NULL)
GO
INSERT [dbo].[PrecioCripto] ([PrcId], [CrmId], [MonId], [PrcPrecio], [PrcPrecioFecha], [Fecha_Creacion], [Fecha_Actualizacion]) VALUES (6, 1, 2, CAST(92.00 AS Decimal(18, 2)), CAST(N'2025-05-03' AS Date), CAST(N'2025-05-03' AS Date), NULL)
GO
SET IDENTITY_INSERT [dbo].[PrecioCripto] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 
GO
INSERT [dbo].[Usuario] ([UsrId], [UsrNombre], [UsrCorreo], [UsrUsuario], [UsrClave], [UsrRol]) VALUES (1, N'string', N'string', N'string', N'string', 0)
GO
INSERT [dbo].[Usuario] ([UsrId], [UsrNombre], [UsrCorreo], [UsrUsuario], [UsrClave], [UsrRol]) VALUES (3, N'Elias Silva', N'silvaelias@hotmail.com', N'elias', N'12345', 1)
GO
INSERT [dbo].[Usuario] ([UsrId], [UsrNombre], [UsrCorreo], [UsrUsuario], [UsrClave], [UsrRol]) VALUES (5, N'Test 2', N'user@example.com', N'test2', N'12345', 0)
GO
INSERT [dbo].[Usuario] ([UsrId], [UsrNombre], [UsrCorreo], [UsrUsuario], [UsrClave], [UsrRol]) VALUES (8, N'Prueba de PUT', N'user@example.com', N'string', N'string', 0)
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[PrecioCripto]  WITH CHECK ADD  CONSTRAINT [FK_PrecioCripto_Criptomoneda] FOREIGN KEY([CrmId])
REFERENCES [dbo].[Criptomoneda] ([CrmId])
GO
ALTER TABLE [dbo].[PrecioCripto] CHECK CONSTRAINT [FK_PrecioCripto_Criptomoneda]
GO
ALTER TABLE [dbo].[PrecioCripto]  WITH CHECK ADD  CONSTRAINT [FK_PrecioCripto_Moneda] FOREIGN KEY([MonId])
REFERENCES [dbo].[Moneda] ([MonId])
GO
ALTER TABLE [dbo].[PrecioCripto] CHECK CONSTRAINT [FK_PrecioCripto_Moneda]
GO
/****** StoredProcedure [dbo].[sp_ChequeaCriptoPrecio]   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ChequeaCriptoPrecio]
	-- Parametros
	@p_Cripto INT=0,
    @p_Moneda INT=0,
    @p_Precio DECIMAL=0,
    @p_PrecioFecha VARCHAR(25),
    @o_outMsg INT=0 OUT
AS
BEGIN
	IF EXISTS(SELECT P.PrcId, C.CrmId, C.CrmNombre, C.CrmSimbolo, M.MonId, M.MonSimbolo, M.MonNombre, P.PrcPrecio, P.PrcPrecioFecha
        FROM  PrecioCripto AS P INNER JOIN
            Criptomoneda AS C ON P.CrmId = C.CrmId INNER JOIN
            Moneda AS M ON P.MonId = M.MonId 
            WHERE C.CrmId=@p_Cripto AND M.MonId= @p_Moneda AND P.PrcPrecio= @p_Precio AND P.PrcPrecioFecha = CAST(@p_PrecioFecha AS date))
        BEGIN
            SELECT @o_outMsg=1
            RETURN 0
        END
    RETURN 0        
END
GO
USE [master]
GO
ALTER DATABASE [Criptos] SET  READ_WRITE 
GO
