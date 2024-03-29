USE [master]
GO
/****** Object:  Database [HotelCabaniasObligatorioP3]    Script Date: 18/6/2023 01:01:45 a. m. ******/
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
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 18/6/2023 01:01:45 a. m. ******/
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
/****** Object:  Table [dbo].[Cabanias]    Script Date: 18/6/2023 01:01:45 a. m. ******/
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
/****** Object:  Table [dbo].[Configuraciones]    Script Date: 18/6/2023 01:01:45 a. m. ******/
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
/****** Object:  Table [dbo].[Mantenimientos]    Script Date: 18/6/2023 01:01:45 a. m. ******/
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
/****** Object:  Table [dbo].[TipoDeCabania]    Script Date: 18/6/2023 01:01:45 a. m. ******/
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
/****** Object:  Table [dbo].[Usuarios]    Script Date: 18/6/2023 01:01:45 a. m. ******/
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
/****** Object:  Index [IX_Cabanias_IdCabania]    Script Date: 18/6/2023 01:01:45 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Cabanias_IdCabania] ON [dbo].[Cabanias]
(
	[IdCabania] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Cabanias_IdTipoCabania]    Script Date: 18/6/2023 01:01:45 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_Cabanias_IdTipoCabania] ON [dbo].[Cabanias]
(
	[IdTipoCabania] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Cabanias_Nombre]    Script Date: 18/6/2023 01:01:45 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Cabanias_Nombre] ON [dbo].[Cabanias]
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Mantenimientos_IdCabania]    Script Date: 18/6/2023 01:01:45 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_Mantenimientos_IdCabania] ON [dbo].[Mantenimientos]
(
	[IdCabania] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TipoDeCabania_IdTipoCabania]    Script Date: 18/6/2023 01:01:45 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_TipoDeCabania_IdTipoCabania] ON [dbo].[TipoDeCabania]
(
	[IdTipoCabania] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Usuarios_Email]    Script Date: 18/6/2023 01:01:45 a. m. ******/
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
