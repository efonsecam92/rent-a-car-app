USE [RentaCar]
GO
/****** Object:  Table [dbo].[Tbl_Cliente]    Script Date: 20/12/2019 13:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Cliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Fecha_Registro] [date] NOT NULL,
	[Cant_Reservas] [int] NULL,
	[IdPersona] [int] NOT NULL,
	[Estado] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Empleado]    Script Date: 20/12/2019 13:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Empleado](
	[IdEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[Cargo] [varchar](max) NOT NULL,
	[Jefe_Inmediato] [varchar](max) NOT NULL,
	[Departamento] [varchar](max) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Estado] [int] NOT NULL,
 CONSTRAINT [PK__Tbl_Empl__CE6D8B9E4913D1C5] PRIMARY KEY CLUSTERED 
(
	[IdEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Imagen]    Script Date: 20/12/2019 13:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Imagen](
	[IdImagen] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](max) NOT NULL,
	[Ruta] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Tbl_Imagen] PRIMARY KEY CLUSTERED 
(
	[IdImagen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Persona]    Script Date: 20/12/2019 13:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Persona](
	[IdPersona] [int] IDENTITY(1,1) NOT NULL,
	[Identificacion] [bigint] NOT NULL,
	[Nombre] [varchar](max) NOT NULL,
	[Apellido1] [varchar](max) NOT NULL,
	[Apellido2] [varchar](max) NULL,
	[Direccion] [varchar](max) NULL,
	[Telefono] [varchar](max) NOT NULL,
	[Email_Per] [varchar](max) NOT NULL,
	[Estado] [int] NOT NULL,
 CONSTRAINT [PK_Tbl_Persona] PRIMARY KEY CLUSTERED 
(
	[IdPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Reserva]    Script Date: 20/12/2019 13:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Reserva](
	[IdReserva] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](max) NOT NULL,
	[TipoPago] [varchar](max) NOT NULL,
	[FechaEntrega] [datetime] NOT NULL,
	[FechaDevolucion] [datetime] NOT NULL,
	[Ciudad] [varchar](max) NULL,
	[Monto] [decimal](18, 0) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdEmpleado] [int] NOT NULL,
	[IdVehiculo] [int] NOT NULL,
 CONSTRAINT [PK_Tbl_Reserva] PRIMARY KEY CLUSTERED 
(
	[IdReserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Usuario]    Script Date: 20/12/2019 13:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Email_Comp] [varchar](max) NOT NULL,
	[Contrasenia] [varchar](max) NOT NULL,
	[IdPersona] [int] NOT NULL,
	[Estado] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Vehiculo]    Script Date: 20/12/2019 13:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Vehiculo](
	[IdVehiculo] [int] IDENTITY(1,1) NOT NULL,
	[Placa] [varchar](max) NOT NULL,
	[Modelo] [varchar](max) NULL,
	[Marca] [varchar](max) NOT NULL,
	[Kilometraje] [varchar](max) NULL,
	[Color] [varchar](max) NULL,
	[Tipo_Vehiculo] [varchar](max) NULL,
	[Tipo_Combustible] [varchar](max) NULL,
	[IdImagen] [int] NULL,
	[Estado] [int] NOT NULL,
 CONSTRAINT [PK_Tbl_Vehiculo] PRIMARY KEY CLUSTERED 
(
	[IdVehiculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tbl_Cliente] ON 

INSERT [dbo].[Tbl_Cliente] ([IdCliente], [Fecha_Registro], [Cant_Reservas], [IdPersona], [Estado]) VALUES (1, CAST(N'2019-12-19' AS Date), NULL, 1, 1)
INSERT [dbo].[Tbl_Cliente] ([IdCliente], [Fecha_Registro], [Cant_Reservas], [IdPersona], [Estado]) VALUES (3, CAST(N'2019-12-19' AS Date), NULL, 2, 1)
INSERT [dbo].[Tbl_Cliente] ([IdCliente], [Fecha_Registro], [Cant_Reservas], [IdPersona], [Estado]) VALUES (7, CAST(N'2019-12-20' AS Date), 1, 10, 1)
SET IDENTITY_INSERT [dbo].[Tbl_Cliente] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Empleado] ON 

INSERT [dbo].[Tbl_Empleado] ([IdEmpleado], [Cargo], [Jefe_Inmediato], [Departamento], [IdUsuario], [Estado]) VALUES (1, N'Vendedor', N'Marco Castro', N'Ventas', 1, 1)
INSERT [dbo].[Tbl_Empleado] ([IdEmpleado], [Cargo], [Jefe_Inmediato], [Departamento], [IdUsuario], [Estado]) VALUES (2, N'Cajero', N'Pedro Perez', N'Reservas', 2, 1)
INSERT [dbo].[Tbl_Empleado] ([IdEmpleado], [Cargo], [Jefe_Inmediato], [Departamento], [IdUsuario], [Estado]) VALUES (3, N'vendedor', N'marco', N'Madio', 1, 1)
SET IDENTITY_INSERT [dbo].[Tbl_Empleado] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Imagen] ON 

INSERT [dbo].[Tbl_Imagen] ([IdImagen], [Titulo], [Ruta]) VALUES (6, N'corollaazul', N'~/Content/Resources/img/Azul-yaris-2018_0193554757.png')
INSERT [dbo].[Tbl_Imagen] ([IdImagen], [Titulo], [Ruta]) VALUES (9, N'corollanegro', N'~/Content/Resources/img/Corolla_Negro193844148.png')
INSERT [dbo].[Tbl_Imagen] ([IdImagen], [Titulo], [Ruta]) VALUES (11, N'corollagris', N'~/Content/Resources/img/37021-6-toyota-transparent194045468.png')
INSERT [dbo].[Tbl_Imagen] ([IdImagen], [Titulo], [Ruta]) VALUES (12, N'yaris', N'~/Content/Resources/img/Azul-yaris-2018_0194128578.png')
INSERT [dbo].[Tbl_Imagen] ([IdImagen], [Titulo], [Ruta]) VALUES (13, N'spark', N'~/Content/Resources/img/2014-chevrolet-spark192310775.jpg')
INSERT [dbo].[Tbl_Imagen] ([IdImagen], [Titulo], [Ruta]) VALUES (14, N'echoazul', N'~/Content/Resources/img/Yaris-SD_Dark-Blue-Mica-Metallic-8W7-1192324102.png')
INSERT [dbo].[Tbl_Imagen] ([IdImagen], [Titulo], [Ruta]) VALUES (15, N'hiace', N'~/Content/Resources/img/hiace192335216.png')
SET IDENTITY_INSERT [dbo].[Tbl_Imagen] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Persona] ON 

INSERT [dbo].[Tbl_Persona] ([IdPersona], [Identificacion], [Nombre], [Apellido1], [Apellido2], [Direccion], [Telefono], [Email_Per], [Estado]) VALUES (1, 123456789, N'Mario', N'López', N'Román', N'Alajuela, 124', N'72038256', N'mario@gmail.com', 1)
INSERT [dbo].[Tbl_Persona] ([IdPersona], [Identificacion], [Nombre], [Apellido1], [Apellido2], [Direccion], [Telefono], [Email_Per], [Estado]) VALUES (2, 207840912, N'Marco', N'Castro', N'Guzmán', N'Alajuela, 123', N'72038256', N'marco@gmail.com', 1)
INSERT [dbo].[Tbl_Persona] ([IdPersona], [Identificacion], [Nombre], [Apellido1], [Apellido2], [Direccion], [Telefono], [Email_Per], [Estado]) VALUES (10, 123456789, N'Ana', N'Rojas', N'Castillo', N'San Jóse, 123', N'72038256', N'ana@gmail.com', 1)
SET IDENTITY_INSERT [dbo].[Tbl_Persona] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Usuario] ON 

INSERT [dbo].[Tbl_Usuario] ([IdUsuario], [Email_Comp], [Contrasenia], [IdPersona], [Estado]) VALUES (1, N'mario@gmail.com', N'123', 1, 1)
INSERT [dbo].[Tbl_Usuario] ([IdUsuario], [Email_Comp], [Contrasenia], [IdPersona], [Estado]) VALUES (2, N'marioelr1998@gmail.com', N'123', 2, 1)
INSERT [dbo].[Tbl_Usuario] ([IdUsuario], [Email_Comp], [Contrasenia], [IdPersona], [Estado]) VALUES (3, N'nelson@gmail.com', N'123', 1, 1)
SET IDENTITY_INSERT [dbo].[Tbl_Usuario] OFF
SET IDENTITY_INSERT [dbo].[Tbl_Vehiculo] ON 

INSERT [dbo].[Tbl_Vehiculo] ([IdVehiculo], [Placa], [Modelo], [Marca], [Kilometraje], [Color], [Tipo_Vehiculo], [Tipo_Combustible], [IdImagen], [Estado]) VALUES (1, N'ABC123', N'Yaris', N'Toyota', N'100000KM', N'Azul', N'SEDAN', N'GASOLINA', 6, 1)
INSERT [dbo].[Tbl_Vehiculo] ([IdVehiculo], [Placa], [Modelo], [Marca], [Kilometraje], [Color], [Tipo_Vehiculo], [Tipo_Combustible], [IdImagen], [Estado]) VALUES (2, N'345678', N'Corolla', N'Toyota', N'10000KM', N'Gris', N'SEDAN', N'GASOLINA', 11, 1)
INSERT [dbo].[Tbl_Vehiculo] ([IdVehiculo], [Placa], [Modelo], [Marca], [Kilometraje], [Color], [Tipo_Vehiculo], [Tipo_Combustible], [IdImagen], [Estado]) VALUES (3, N'890767', N'Corolla', N'Toyota', N'20000KM', N'Negro', N'SEDAN', N'GASOLINA', 9, 1)
INSERT [dbo].[Tbl_Vehiculo] ([IdVehiculo], [Placa], [Modelo], [Marca], [Kilometraje], [Color], [Tipo_Vehiculo], [Tipo_Combustible], [IdImagen], [Estado]) VALUES (4, N'123546', N'Echo', N'Toyota', N'50000KM', N'Azul', N'SEDAN', N'GASOLINA', 14, 1)
INSERT [dbo].[Tbl_Vehiculo] ([IdVehiculo], [Placa], [Modelo], [Marca], [Kilometraje], [Color], [Tipo_Vehiculo], [Tipo_Combustible], [IdImagen], [Estado]) VALUES (5, N'568978', N'Spark', N'Chevrolet', N'60000KM', N'Amarillo', N'SEDAN', N'GASOLINA', 13, 1)
INSERT [dbo].[Tbl_Vehiculo] ([IdVehiculo], [Placa], [Modelo], [Marca], [Kilometraje], [Color], [Tipo_Vehiculo], [Tipo_Combustible], [IdImagen], [Estado]) VALUES (7, N'123546', N'Hiace', N'Toyota', N'100000KM', N'Gris', N'MICROBUS', N'DIESEL', 15, 1)
SET IDENTITY_INSERT [dbo].[Tbl_Vehiculo] OFF
ALTER TABLE [dbo].[Tbl_Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Cli_Per] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[Tbl_Persona] ([IdPersona])
GO
ALTER TABLE [dbo].[Tbl_Cliente] CHECK CONSTRAINT [FK_Tbl_Cli_Per]
GO
ALTER TABLE [dbo].[Tbl_Empleado]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Usuario_Emp] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Tbl_Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Tbl_Empleado] CHECK CONSTRAINT [FK_Tbl_Usuario_Emp]
GO
ALTER TABLE [dbo].[Tbl_Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Res_Cli] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Tbl_Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Tbl_Reserva] CHECK CONSTRAINT [FK_Tbl_Res_Cli]
GO
ALTER TABLE [dbo].[Tbl_Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Res_Emp] FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[Tbl_Empleado] ([IdEmpleado])
GO
ALTER TABLE [dbo].[Tbl_Reserva] CHECK CONSTRAINT [FK_Tbl_Res_Emp]
GO
ALTER TABLE [dbo].[Tbl_Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Res_Veh] FOREIGN KEY([IdVehiculo])
REFERENCES [dbo].[Tbl_Vehiculo] ([IdVehiculo])
GO
ALTER TABLE [dbo].[Tbl_Reserva] CHECK CONSTRAINT [FK_Tbl_Res_Veh]
GO
ALTER TABLE [dbo].[Tbl_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Usuario] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[Tbl_Persona] ([IdPersona])
GO
ALTER TABLE [dbo].[Tbl_Usuario] CHECK CONSTRAINT [FK_Tbl_Usuario]
GO
ALTER TABLE [dbo].[Tbl_Vehiculo]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Imagen] FOREIGN KEY([IdImagen])
REFERENCES [dbo].[Tbl_Imagen] ([IdImagen])
GO
ALTER TABLE [dbo].[Tbl_Vehiculo] CHECK CONSTRAINT [FK_Tbl_Imagen]
GO
