USE [master]
GO
/****** Object:  Database [alimentos]    Script Date: 14/12/2022 01:28:42 p. m. ******/
CREATE DATABASE [alimentos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'alimentos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\alimentos.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'alimentos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\alimentos_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [alimentos] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [alimentos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [alimentos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [alimentos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [alimentos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [alimentos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [alimentos] SET ARITHABORT OFF 
GO
ALTER DATABASE [alimentos] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [alimentos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [alimentos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [alimentos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [alimentos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [alimentos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [alimentos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [alimentos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [alimentos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [alimentos] SET  DISABLE_BROKER 
GO
ALTER DATABASE [alimentos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [alimentos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [alimentos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [alimentos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [alimentos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [alimentos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [alimentos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [alimentos] SET RECOVERY FULL 
GO
ALTER DATABASE [alimentos] SET  MULTI_USER 
GO
ALTER DATABASE [alimentos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [alimentos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [alimentos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [alimentos] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [alimentos] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [alimentos] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'alimentos', N'ON'
GO
ALTER DATABASE [alimentos] SET QUERY_STORE = OFF
GO
USE [alimentos]
GO
/****** Object:  UserDefinedDataType [dbo].[alimento]    Script Date: 14/12/2022 01:28:42 p. m. ******/
CREATE TYPE [dbo].[alimento] FROM [int] NOT NULL
GO
/****** Object:  UserDefinedDataType [dbo].[ingrediente]    Script Date: 14/12/2022 01:28:42 p. m. ******/
CREATE TYPE [dbo].[ingrediente] FROM [int] NOT NULL
GO
/****** Object:  Table [dbo].[Alimento]    Script Date: 14/12/2022 01:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alimento](
	[idAlimento] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[costo] [numeric](10, 2) NOT NULL,
	[fechaRegistro] [datetime] NOT NULL,
	[fechaActualizacion] [datetime] NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK_alimento] PRIMARY KEY CLUSTERED 
(
	[idAlimento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingrediente]    Script Date: 14/12/2022 01:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingrediente](
	[idIngrediente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
 CONSTRAINT [pk_idIngrediente] PRIMARY KEY CLUSTERED 
(
	[idIngrediente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IngredienteAlimento]    Script Date: 14/12/2022 01:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IngredienteAlimento](
	[idAlimento] [int] NOT NULL,
	[idIngrediente] [int] NOT NULL,
 CONSTRAINT [PK_IngredienteAlimento] PRIMARY KEY CLUSTERED 
(
	[idAlimento] ASC,
	[idIngrediente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[IngredienteAlimento]  WITH CHECK ADD  CONSTRAINT [FK_IngredienteAlimento_Alimento] FOREIGN KEY([idAlimento])
REFERENCES [dbo].[Alimento] ([idAlimento])
GO
ALTER TABLE [dbo].[IngredienteAlimento] CHECK CONSTRAINT [FK_IngredienteAlimento_Alimento]
GO
ALTER TABLE [dbo].[IngredienteAlimento]  WITH CHECK ADD  CONSTRAINT [FK_IngredienteAlimento_Ingrediente] FOREIGN KEY([idIngrediente])
REFERENCES [dbo].[Ingrediente] ([idIngrediente])
GO
ALTER TABLE [dbo].[IngredienteAlimento] CHECK CONSTRAINT [FK_IngredienteAlimento_Ingrediente]
GO
USE [master]
GO
ALTER DATABASE [alimentos] SET  READ_WRITE 
GO
