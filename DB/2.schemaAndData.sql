USE [master]
GO
/****** Object:  Database [HotelCabaniasObligatorioP3]    Script Date: 18/6/2023 01:09:46 a. m. ******/
CREATE DATABASE [HotelCabaniasObligatorioP3]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HotelCabaniasObligatorioP3', FILENAME = N'C:\Users\Snowly\HotelCabaniasObligatorioP3.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HotelCabaniasObligatorioP3_log', FILENAME = N'C:\Users\Snowly\HotelCabaniasObligatorioP3_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [HotelCabaniasObligatorioP3] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HotelCabaniasObligatorioP3].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HotelCabaniasObligatorioP3] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HotelCabaniasObligatorioP3] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HotelCabaniasObligatorioP3] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HotelCabaniasObligatorioP3] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HotelCabaniasObligatorioP3] SET ARITHABORT OFF 
GO
ALTER DATABASE [HotelCabaniasObligatorioP3] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [HotelCabaniasObligatorioP3] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HotelCabaniasObligatorioP3] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HotelCabaniasObligatorioP3] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HotelCabaniasObligatorioP3] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HotelCabaniasObligatorioP3] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HotelCabaniasObligatorioP3] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HotelCabaniasObligatorioP3] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HotelCabaniasObligatorioP3] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HotelCabaniasObligatorioP3] SET  ENABLE_BROKER 
GO
ALTER DATABASE [HotelCabaniasObligatorioP3] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HotelCabaniasObligatorioP3] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HotelCabaniasObligatorioP3] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HotelCabaniasObligatorioP3] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HotelCabaniasObligatorioP3] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HotelCabaniasObligatorioP3] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [HotelCabaniasObligatorioP3] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HotelCabaniasObligatorioP3] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HotelCabaniasObligatorioP3] SET  MULTI_USER 
GO
ALTER DATABASE [HotelCabaniasObligatorioP3] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HotelCabaniasObligatorioP3] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HotelCabaniasObligatorioP3] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HotelCabaniasObligatorioP3] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HotelCabaniasObligatorioP3] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HotelCabaniasObligatorioP3] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [HotelCabaniasObligatorioP3] SET QUERY_STORE = OFF
GO
USE [HotelCabaniasObligatorioP3]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 18/6/2023 01:09:46 a. m. ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cabanias]    Script Date: 18/6/2023 01:09:46 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cabanias](
	[IdCabania] [int] IDENTITY(1,1) NOT NULL,
	[IdTipoCabania] [nvarchar](450) NOT NULL,
	[Nombre] [nvarchar](450) NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[CantMaxPersonas] [int] NOT NULL,
	[HabilitadaParaReservas] [bit] NOT NULL,
	[TieneJacuzzi] [bit] NOT NULL,
	[Foto] [nvarchar](max) NULL,
 CONSTRAINT [PK_Cabanias] PRIMARY KEY CLUSTERED 
(
	[IdCabania] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Configuraciones]    Script Date: 18/6/2023 01:09:46 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Configuraciones](
	[NombreAtributo] [nvarchar](450) NOT NULL,
	[LimiteSuperior] [int] NOT NULL,
	[LimiteInferior] [int] NOT NULL,
 CONSTRAINT [PK_Configuraciones] PRIMARY KEY CLUSTERED 
(
	[NombreAtributo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mantenimientos]    Script Date: 18/6/2023 01:09:46 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mantenimientos](
	[IdMantenimiento] [int] IDENTITY(1,1) NOT NULL,
	[IdCabania] [int] NOT NULL,
	[NombreDelFunc] [nvarchar](max) NOT NULL,
	[Descripcion_Valor] [nvarchar](max) NOT NULL,
	[Costo_Valor] [float] NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Mantenimientos] PRIMARY KEY CLUSTERED 
(
	[IdMantenimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoDeCabania]    Script Date: 18/6/2023 01:09:46 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoDeCabania](
	[IdTipoCabania] [nvarchar](450) NOT NULL,
	[Descripcion_Valor] [nvarchar](max) NOT NULL,
	[Costo_Valor] [float] NOT NULL,
 CONSTRAINT [PK_TipoDeCabania] PRIMARY KEY CLUSTERED 
(
	[IdTipoCabania] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 18/6/2023 01:09:46 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Discriminator] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](450) NOT NULL,
	[Contrasenia] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230618034717_Init', N'7.0.5')
GO
SET IDENTITY_INSERT [dbo].[Cabanias] ON 

INSERT [dbo].[Cabanias] ([IdCabania], [IdTipoCabania], [Nombre], [Descripcion], [CantMaxPersonas], [HabilitadaParaReservas], [TieneJacuzzi], [Foto]) VALUES (1, N'A', N'Limon', N'Cómoda y funcional. Ubicada en Santa Isabel de La Pedrera, en un entorno de bosque y campo a pasos de mar. Cuenta con un equipamiento de diseño y primera calidad. Casa a estrenar, terminada 20/12/2022. La zona es muy tranquila y segura, nosotros vivimos en el predio y estamos disponibles para solucionar cualquier tipo de eventualidad o consulta que tengan. Equipada con cama Queen size, Tv Smart 58" , Home theather 5.1 Bluetooth, aire acondicionado, wifi, Directv.', 2, 1, 1, N'Limon_001.jpg')
INSERT [dbo].[Cabanias] ([IdCabania], [IdTipoCabania], [Nombre], [Descripcion], [CantMaxPersonas], [HabilitadaParaReservas], [TieneJacuzzi], [Foto]) VALUES (2, N'A', N'Melon', N'Experimenta la escapada definitiva en nuestra tranquila casa del árbol de alquiler vacacional, ubicada a solo 1,2 kilómetros de la playa de La Arenisca, rodeada de hermosos paisajes rurales y perfecta para los amantes de la naturaleza. Nuestra casa está diseñada para que sientas el entorno natural con grandes ventanales que dejan entrar mucha luz y te permiten disfrutar de unas vistas impresionantes de la naturaleza circundante. Ten en cuenta que la casa no tiene cortinas ni cortinas, por lo que', 2, 1, 1, N'Melon_001.jpg')
INSERT [dbo].[Cabanias] ([IdCabania], [IdTipoCabania], [Nombre], [Descripcion], [CantMaxPersonas], [HabilitadaParaReservas], [TieneJacuzzi], [Foto]) VALUES (3, N'B', N'Sandia', N'Es hora de un merecido descanso en el mejor lugar. “La Escondida” es su mejor opción, se encuentra oculta en la Sierras de Carapé rodeada de montes nativos debidamente protegidos y cursos de agua únicos. Estamos en medio de las sierras, el aislamiento es palpable y es inevitable el encuentro con uno mismo y con  sus seres queridos. La cabaña cuanta con todas las comodidades para hacer sus vacaciones únicas, además de estar solo a una hora de Punta del Este por rutas de fácil acceso.', 3, 0, 1, N'Sandia_001.jpg')
INSERT [dbo].[Cabanias] ([IdCabania], [IdTipoCabania], [Nombre], [Descripcion], [CantMaxPersonas], [HabilitadaParaReservas], [TieneJacuzzi], [Foto]) VALUES (4, N'C', N'Papaya', N'A solo pasos de la playa y el mar, conecta con la naturaleza en esta escapada inolvidable en un Domo Geodésico. Disfruta del del sonido del mar y del entorno único. A solo 10 minutos de Punta del Este.', 4, 1, 0, N'Papaya_001.jpg')
INSERT [dbo].[Cabanias] ([IdCabania], [IdTipoCabania], [Nombre], [Descripcion], [CantMaxPersonas], [HabilitadaParaReservas], [TieneJacuzzi], [Foto]) VALUES (5, N'D', N'Maracuya', N'Todo el confort de una casa moderna en 3.500mts de parque, a cuadras de una hermosa playa sobre el Río de la Plata. Yacuzzi, estufa a leña, aire acondicionado, bicicletas, fogón, wi.fi, smarttv y más. Una bella experiencia de descanso, tranquilidad y naturaleza.', 5, 1, 1, N'Maracuya_001.jpg')
INSERT [dbo].[Cabanias] ([IdCabania], [IdTipoCabania], [Nombre], [Descripcion], [CantMaxPersonas], [HabilitadaParaReservas], [TieneJacuzzi], [Foto]) VALUES (6, N'E', N'Pelon', N'Cabaña nueva en medio del bosque de El Ensueño y a 50m de la playa. Rodeada de árboles, construida con materiales cálidos y de diseño, aberturas doble vidrio con mosquiteros. Amplio espacio abierto living-cocina con todo para 4 huéspedes,  dormitorio en suite con salida al deck, 2do dormitorio con cama con carro (2 camas twin) y 2do baño. Pura luz y bosque a un paso del río. Espacio para estacionar dos autos, parrillero, proyector, hamaca y sillas de playa.', 6, 0, 1, N'Pelon_001.jpg')
INSERT [dbo].[Cabanias] ([IdCabania], [IdTipoCabania], [Nombre], [Descripcion], [CantMaxPersonas], [HabilitadaParaReservas], [TieneJacuzzi], [Foto]) VALUES (7, N'F', N'Durazno', N'Mini casa, hecha de barro, madera y mucho amor! Ubicada entre Santa Ana y Balneario Argentino. Ideal para una escapada única y muy tranquila. Entorno natural, cerquita de la playa, tiene patio con parrillero.  A una hora aprox. de Montevideo  Terreno cercado, para seguridad de niños y mascotas.', 7, 1, 1, N'Durazno_001.jpg')
INSERT [dbo].[Cabanias] ([IdCabania], [IdTipoCabania], [Nombre], [Descripcion], [CantMaxPersonas], [HabilitadaParaReservas], [TieneJacuzzi], [Foto]) VALUES (8, N'G', N'Naranja', N'Es un hermoso lugar donde podrás disfrutar de la piscina climatizada todo el año, pasar momentos de paz rodeado de vegetación autóctona, vistas a las sierras que rodean la zona, disfrutar de las estrellas, los animales silvestres además de las comodidades que presenta la casa, agua, luz, baño privado, cocina y hermosa iluminación natural. Estas características y muchísimas cosas más que irás descubriendo, harán de tu estadía un momento único e inolvidable en contacto directo con la naturaleza.', 8, 0, 0, N'Naranja_001.jpg')
INSERT [dbo].[Cabanias] ([IdCabania], [IdTipoCabania], [Nombre], [Descripcion], [CantMaxPersonas], [HabilitadaParaReservas], [TieneJacuzzi], [Foto]) VALUES (9, N'H', N'Frutilla', N'Chill Out José Ignacio, un lugar pensado para descansar, disfrutando de su excelente vista acompañado de la tranquilidad del campo. A tan solo 1 km de la casa se encuentra el arroyo Jose Ignacio, ( dejamos fotos en galería) donde podrá disfrutar de una piscina natural o un paseo diferente rodeado de naturaleza pura. A tan solo 15 minutos del balneario José Ignacio y a pocos km de pueblo Garzón.', 9, 0, 1, N'Frutilla_001.jpg')
INSERT [dbo].[Cabanias] ([IdCabania], [IdTipoCabania], [Nombre], [Descripcion], [CantMaxPersonas], [HabilitadaParaReservas], [TieneJacuzzi], [Foto]) VALUES (10, N'A', N'Kiwi', N'Emplazada en la zona alta de Villa Serrana conocida como "El Observatorio Alto", disfrutaras de hermosas vistas, amaneceres, atardeceres, tranquilidad y sentirás la energía que se concentra en ese lugar corriendote por las venas . El Observatorio es conocido por ser el lugar de encuentro de aficionados a la observación del cielo, siendo este un espectáculo único!!', 10, 0, 0, N'Kiwi_001.jpg')
SET IDENTITY_INSERT [dbo].[Cabanias] OFF
GO
INSERT [dbo].[Configuraciones] ([NombreAtributo], [LimiteSuperior], [LimiteInferior]) VALUES (N'CabaniaDescripcion', 500, 10)
INSERT [dbo].[Configuraciones] ([NombreAtributo], [LimiteSuperior], [LimiteInferior]) VALUES (N'MantenimientoDescripcion', 200, 10)
INSERT [dbo].[Configuraciones] ([NombreAtributo], [LimiteSuperior], [LimiteInferior]) VALUES (N'TipoCabaniaDescripcion', 200, 10)
GO
SET IDENTITY_INSERT [dbo].[Mantenimientos] ON 

INSERT [dbo].[Mantenimientos] ([IdMantenimiento], [IdCabania], [NombreDelFunc], [Descripcion_Valor], [Costo_Valor], [Fecha]) VALUES (1, 1, N'Lola', N'Arreglo de aire acondicionado.', 700, CAST(N'2023-05-07T14:25:00.0000000' AS DateTime2))
INSERT [dbo].[Mantenimientos] ([IdMantenimiento], [IdCabania], [NombreDelFunc], [Descripcion_Valor], [Costo_Valor], [Fecha]) VALUES (2, 1, N'Lolo', N'Arreglo luminaria cocina.', 600, CAST(N'2023-05-07T11:15:00.0000000' AS DateTime2))
INSERT [dbo].[Mantenimientos] ([IdMantenimiento], [IdCabania], [NombreDelFunc], [Descripcion_Valor], [Costo_Valor], [Fecha]) VALUES (3, 2, N'Lucas', N'Arreglo puerta principal.', 1200, CAST(N'2023-05-07T15:12:00.0000000' AS DateTime2))
INSERT [dbo].[Mantenimientos] ([IdMantenimiento], [IdCabania], [NombreDelFunc], [Descripcion_Valor], [Costo_Valor], [Fecha]) VALUES (4, 2, N'Lola', N'Cambio de bombita del baño.', 200, CAST(N'2023-05-02T11:15:00.0000000' AS DateTime2))
INSERT [dbo].[Mantenimientos] ([IdMantenimiento], [IdCabania], [NombreDelFunc], [Descripcion_Valor], [Costo_Valor], [Fecha]) VALUES (5, 3, N'Lolo', N'Arreglo enchufe exterior.', 700, CAST(N'2023-04-14T03:39:00.0000000' AS DateTime2))
INSERT [dbo].[Mantenimientos] ([IdMantenimiento], [IdCabania], [NombreDelFunc], [Descripcion_Valor], [Costo_Valor], [Fecha]) VALUES (6, 3, N'Lucas', N'Cambio cortina dormitorio.', 1300, CAST(N'2023-03-23T08:00:00.0000000' AS DateTime2))
INSERT [dbo].[Mantenimientos] ([IdMantenimiento], [IdCabania], [NombreDelFunc], [Descripcion_Valor], [Costo_Valor], [Fecha]) VALUES (7, 3, N'Lucas', N'Cambio cerradura puerta principal.', 1900, CAST(N'2023-02-03T11:46:00.0000000' AS DateTime2))
INSERT [dbo].[Mantenimientos] ([IdMantenimiento], [IdCabania], [NombreDelFunc], [Descripcion_Valor], [Costo_Valor], [Fecha]) VALUES (8, 4, N'Lolo', N'Arreglo ventana sala de estar.', 400, CAST(N'2023-05-07T14:25:00.0000000' AS DateTime2))
INSERT [dbo].[Mantenimientos] ([IdMantenimiento], [IdCabania], [NombreDelFunc], [Descripcion_Valor], [Costo_Valor], [Fecha]) VALUES (9, 5, N'Lucas', N'Cambio llave de luz dormitorio.', 600, CAST(N'2023-05-07T14:25:00.0000000' AS DateTime2))
INSERT [dbo].[Mantenimientos] ([IdMantenimiento], [IdCabania], [NombreDelFunc], [Descripcion_Valor], [Costo_Valor], [Fecha]) VALUES (10, 6, N'Lola', N'Arreglo ventilador sala de estar.', 400, CAST(N'2023-05-07T14:25:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Mantenimientos] OFF
GO
INSERT [dbo].[TipoDeCabania] ([IdTipoCabania], [Descripcion_Valor], [Costo_Valor]) VALUES (N'A', N'El tipo de cabaña "A" tiene un costo por huesped de $800.', 800)
INSERT [dbo].[TipoDeCabania] ([IdTipoCabania], [Descripcion_Valor], [Costo_Valor]) VALUES (N'B', N'El tipo de cabaña "B" tiene un costo por huesped de $700.', 700)
INSERT [dbo].[TipoDeCabania] ([IdTipoCabania], [Descripcion_Valor], [Costo_Valor]) VALUES (N'C', N'El tipo de cabaña "C" tiene un costo por huesped de $650.', 650)
INSERT [dbo].[TipoDeCabania] ([IdTipoCabania], [Descripcion_Valor], [Costo_Valor]) VALUES (N'D', N'El tipo de cabaña "D" tiene un costo por huesped de $500.', 500)
INSERT [dbo].[TipoDeCabania] ([IdTipoCabania], [Descripcion_Valor], [Costo_Valor]) VALUES (N'E', N'El tipo de cabaña "E" tiene un costo por huesped de $450.', 450)
INSERT [dbo].[TipoDeCabania] ([IdTipoCabania], [Descripcion_Valor], [Costo_Valor]) VALUES (N'F', N'El tipo de cabaña "F" tiene un costo por huesped de $400.', 400)
INSERT [dbo].[TipoDeCabania] ([IdTipoCabania], [Descripcion_Valor], [Costo_Valor]) VALUES (N'G', N'El tipo de cabaña "G" tiene un costo por huesped de $390.', 390)
INSERT [dbo].[TipoDeCabania] ([IdTipoCabania], [Descripcion_Valor], [Costo_Valor]) VALUES (N'H', N'El tipo de cabaña "H" tiene un costo por huesped de $300.', 300)
INSERT [dbo].[TipoDeCabania] ([IdTipoCabania], [Descripcion_Valor], [Costo_Valor]) VALUES (N'I', N'El tipo de cabaña "I" tiene un costo por huesped de $250.', 250)
INSERT [dbo].[TipoDeCabania] ([IdTipoCabania], [Descripcion_Valor], [Costo_Valor]) VALUES (N'J', N'El tipo de cabaña "J" tiene un costo por huesped de $150.', 150)
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([IdUsuario], [Discriminator], [Email], [Contrasenia]) VALUES (1, N'Funcionario', N'lola@email.com', N'Lola1234')
INSERT [dbo].[Usuarios] ([IdUsuario], [Discriminator], [Email], [Contrasenia]) VALUES (2, N'Funcionario', N'lolo@email.com', N'Lolo1234')
INSERT [dbo].[Usuarios] ([IdUsuario], [Discriminator], [Email], [Contrasenia]) VALUES (3, N'Funcionario', N'lucas@email.com', N'Lucas1234')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
/****** Object:  Index [IX_Cabanias_IdCabania]    Script Date: 18/6/2023 01:09:46 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Cabanias_IdCabania] ON [dbo].[Cabanias]
(
	[IdCabania] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Cabanias_IdTipoCabania]    Script Date: 18/6/2023 01:09:46 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_Cabanias_IdTipoCabania] ON [dbo].[Cabanias]
(
	[IdTipoCabania] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Cabanias_Nombre]    Script Date: 18/6/2023 01:09:46 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Cabanias_Nombre] ON [dbo].[Cabanias]
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Mantenimientos_IdCabania]    Script Date: 18/6/2023 01:09:46 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_Mantenimientos_IdCabania] ON [dbo].[Mantenimientos]
(
	[IdCabania] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TipoDeCabania_IdTipoCabania]    Script Date: 18/6/2023 01:09:46 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_TipoDeCabania_IdTipoCabania] ON [dbo].[TipoDeCabania]
(
	[IdTipoCabania] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Usuarios_Email]    Script Date: 18/6/2023 01:09:46 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Usuarios_Email] ON [dbo].[Usuarios]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cabanias]  WITH CHECK ADD  CONSTRAINT [FK_Cabanias_TipoDeCabania_IdTipoCabania] FOREIGN KEY([IdTipoCabania])
REFERENCES [dbo].[TipoDeCabania] ([IdTipoCabania])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cabanias] CHECK CONSTRAINT [FK_Cabanias_TipoDeCabania_IdTipoCabania]
GO
ALTER TABLE [dbo].[Mantenimientos]  WITH CHECK ADD  CONSTRAINT [FK_Mantenimientos_Cabanias_IdCabania] FOREIGN KEY([IdCabania])
REFERENCES [dbo].[Cabanias] ([IdCabania])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Mantenimientos] CHECK CONSTRAINT [FK_Mantenimientos_Cabanias_IdCabania]
GO
USE [master]
GO
ALTER DATABASE [HotelCabaniasObligatorioP3] SET  READ_WRITE 
GO
