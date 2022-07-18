SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permisos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreEmpleado] [varchar](100) NOT NULL,
	[ApellidoEmpleado] [varchar](100) NOT NULL,
	[TipoPermiso] [int] NOT NULL,
	[FechaPermiso] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoPermisos]    Script Date: 17/7/2022 20:35:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPermisos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](300) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Permisos] ON 
GO
INSERT [dbo].[Permisos] ([Id], [NombreEmpleado], [ApellidoEmpleado], [TipoPermiso], [FechaPermiso]) VALUES (4, N'ADRIAN', N'VERA', 1, CAST(N'2022-07-17T20:33:41.500' AS DateTime))
GO
INSERT [dbo].[Permisos] ([Id], [NombreEmpleado], [ApellidoEmpleado], [TipoPermiso], [FechaPermiso]) VALUES (5, N'ERNESTO', N'CABALLERO', 3, CAST(N'2022-07-17T11:46:34.347' AS DateTime))
GO
INSERT [dbo].[Permisos] ([Id], [NombreEmpleado], [ApellidoEmpleado], [TipoPermiso], [FechaPermiso]) VALUES (6, N'LUIS', N'DEL VALLE', 3, CAST(N'2022-07-17T11:46:34.347' AS DateTime))
GO
INSERT [dbo].[Permisos] ([Id], [NombreEmpleado], [ApellidoEmpleado], [TipoPermiso], [FechaPermiso]) VALUES (7, N'TULIO', N'VILLARES', 3, CAST(N'2022-07-17T11:46:34.347' AS DateTime))
GO
INSERT [dbo].[Permisos] ([Id], [NombreEmpleado], [ApellidoEmpleado], [TipoPermiso], [FechaPermiso]) VALUES (8, N'IVAN', N'JIMENEZ', 2, CAST(N'2022-07-17T11:46:34.347' AS DateTime))
GO
INSERT [dbo].[Permisos] ([Id], [NombreEmpleado], [ApellidoEmpleado], [TipoPermiso], [FechaPermiso]) VALUES (9, N'EDGAR', N'CLAVIJO', 2, CAST(N'2022-07-17T11:46:34.347' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Permisos] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoPermisos] ON 
GO
INSERT [dbo].[TipoPermisos] ([Id], [Descripcion]) VALUES (1, N'ADMINISTRADOR')
GO
INSERT [dbo].[TipoPermisos] ([Id], [Descripcion]) VALUES (2, N'SUPERVISOR')
GO
INSERT [dbo].[TipoPermisos] ([Id], [Descripcion]) VALUES (3, N'EMPLEADO')
GO
SET IDENTITY_INSERT [dbo].[TipoPermisos] OFF
GO
ALTER TABLE [dbo].[Permisos]  WITH CHECK ADD FOREIGN KEY([TipoPermiso])
REFERENCES [dbo].[TipoPermisos] ([Id])
GO
