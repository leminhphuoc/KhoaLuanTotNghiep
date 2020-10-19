USE [master]
GO
/****** Object:  Database [mon60410_FonNature]    Script Date: 19-10-2020 8:48:12 AM ******/
CREATE DATABASE [mon60410_FonNature]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'mon60410_FonNature', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\mon60410_FonNature.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'mon60410_FonNature_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\mon60410_FonNature_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [mon60410_FonNature] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [mon60410_FonNature].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [mon60410_FonNature] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [mon60410_FonNature] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [mon60410_FonNature] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [mon60410_FonNature] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [mon60410_FonNature] SET ARITHABORT OFF 
GO
ALTER DATABASE [mon60410_FonNature] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [mon60410_FonNature] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [mon60410_FonNature] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [mon60410_FonNature] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [mon60410_FonNature] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [mon60410_FonNature] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [mon60410_FonNature] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [mon60410_FonNature] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [mon60410_FonNature] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [mon60410_FonNature] SET  ENABLE_BROKER 
GO
ALTER DATABASE [mon60410_FonNature] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [mon60410_FonNature] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [mon60410_FonNature] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [mon60410_FonNature] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [mon60410_FonNature] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [mon60410_FonNature] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [mon60410_FonNature] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [mon60410_FonNature] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [mon60410_FonNature] SET  MULTI_USER 
GO
ALTER DATABASE [mon60410_FonNature] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [mon60410_FonNature] SET DB_CHAINING OFF 
GO
ALTER DATABASE [mon60410_FonNature] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [mon60410_FonNature] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [mon60410_FonNature] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'mon60410_FonNature', N'ON'
GO
ALTER DATABASE [mon60410_FonNature] SET QUERY_STORE = OFF
GO
USE [mon60410_FonNature]
GO
/****** Object:  Schema [mon60410_phuoc]    Script Date: 19-10-2020 8:48:12 AM ******/
CREATE SCHEMA [mon60410_phuoc]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 19-10-2020 8:48:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[About]    Script Date: 19-10-2020 8:48:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[About](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](250) NULL,
	[description] [ntext] NULL,
	[image] [nvarchar](250) NULL,
	[Category] [int] NOT NULL,
	[Author] [nvarchar](250) NULL,
	[Role] [nvarchar](250) NULL,
	[Sign] [nvarchar](250) NULL,
 CONSTRAINT [PK_dbo.About] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountAdmin]    Script Date: 19-10-2020 8:48:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountAdmin](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[userName] [nvarchar](100) NOT NULL,
	[passWord] [nvarchar](100) NOT NULL,
	[type] [bit] NULL,
	[STATUS] [bit] NULL,
 CONSTRAINT [PK_dbo.AccountAdmin] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Banner]    Script Date: 19-10-2020 8:48:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banner](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Location] [int] NOT NULL,
	[Image] [nvarchar](500) NULL,
 CONSTRAINT [PK_dbo.Banner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Benefit]    Script Date: 19-10-2020 8:48:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Benefit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Description] [nvarchar](250) NULL,
	[Image] [nvarchar](500) NULL,
 CONSTRAINT [PK_dbo.Benefit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 19-10-2020 8:48:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](250) NULL,
	[MobilePhone] [nvarchar](250) NULL,
	[Email] [nvarchar](250) NULL,
	[LinkFaceBook] [nvarchar](250) NULL,
	[LinkInstagram] [nvarchar](250) NULL,
	[LogoHeader] [nvarchar](250) NULL,
	[LogoFooter] [nvarchar](250) NULL,
	[FacebookPagePlugin] [nvarchar](1000) NULL,
 CONSTRAINT [PK_dbo.Contact] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Content]    Script Date: 19-10-2020 8:48:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Content](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](250) NULL,
	[metatitle] [nvarchar](100) NULL,
	[description] [nvarchar](500) NULL,
	[image] [nvarchar](250) NULL,
	[categoryID] [bigint] NULL,
	[detail] [ntext] NULL,
	[createdDate] [date] NULL,
	[modifiedDate] [date] NULL,
	[topHot] [date] NULL,
	[viewCount] [int] NULL,
	[status] [bit] NULL,
	[MetaKeyWord] [nvarchar](500) NULL,
	[MetaDescription] [nvarchar](500) NULL,
	[IsDisplayInHomePage] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Content] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContentCategory]    Script Date: 19-10-2020 8:48:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContentCategory](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](250) NULL,
	[metatitle] [nvarchar](250) NULL,
	[parentID] [int] NULL,
	[displayOrder] [int] NULL,
	[createdDate] [date] NULL,
	[modifiedDate] [date] NULL,
	[status] [bit] NULL,
	[showOnHome] [bit] NULL,
 CONSTRAINT [PK_dbo.ContentCategory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 19-10-2020 8:48:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](100) NOT NULL,
	[phone] [varchar](20) NOT NULL,
	[address] [nvarchar](100) NOT NULL,
	[token] [nvarchar](100) NULL,
	[createdDate] [date] NULL,
	[modifiedDate] [date] NULL,
	[status] [bit] NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_dbo.Customer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerAccount]    Script Date: 19-10-2020 8:48:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerAccount](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[userName] [nvarchar](100) NOT NULL,
	[passWord] [nvarchar](100) NOT NULL,
	[type] [bit] NULL,
	[STATUS] [bit] NULL,
	[IdCustomer] [bigint] NULL,
 CONSTRAINT [PK_dbo.CustomerAccount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dictionary]    Script Date: 19-10-2020 8:48:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dictionary](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Key] [nvarchar](250) NULL,
	[Value] [nvarchar](250) NULL,
 CONSTRAINT [PK_dbo.Dictionary] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Footer]    Script Date: 19-10-2020 8:48:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Footer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[text] [nvarchar](50) NULL,
	[link] [nvarchar](100) NULL,
	[displayOrder] [int] NULL,
	[typeId] [int] NULL,
	[status] [bit] NULL,
	[Icon] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Footer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FooterCategory]    Script Date: 19-10-2020 8:48:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FooterCategory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
 CONSTRAINT [PK_dbo.FooterCategory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IPAddress]    Script Date: 19-10-2020 8:48:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IPAddress](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IP] [nvarchar](max) NULL,
	[date] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.IPAddress] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 19-10-2020 8:48:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[text] [nvarchar](50) NULL,
	[link] [nvarchar](100) NULL,
	[displayOrder] [int] NULL,
	[typeId] [int] NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_dbo.Menu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuType]    Script Date: 19-10-2020 8:48:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.MenuType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 19-10-2020 8:48:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdCustomer] [bigint] NOT NULL,
	[createdDate] [datetime] NULL,
	[IdStatus] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderInformation]    Script Date: 19-10-2020 8:48:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderInformation](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdProduct] [bigint] NOT NULL,
	[IdOrder] [bigint] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_dbo.OrderInformation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderStatus]    Script Date: 19-10-2020 8:48:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.OrderStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Page]    Script Date: 19-10-2020 8:48:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Page](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Url] [nvarchar](100) NULL,
	[Body] [ntext] NULL,
	[MetaTitle] [nvarchar](250) NULL,
	[MetaDescription] [nvarchar](1000) NULL,
	[MetaKeywords] [nvarchar](1000) NULL,
 CONSTRAINT [PK_dbo.Page] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 19-10-2020 8:48:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](250) NOT NULL,
	[metaTitle] [nvarchar](250) NULL,
	[description] [nvarchar](999) NULL,
	[image] [nvarchar](max) NULL,
	[moreImages] [xml] NULL,
	[price] [decimal](18, 0) NULL,
	[promotionPrice] [decimal](18, 0) NULL,
	[idCategory] [int] NOT NULL,
	[detail] [ntext] NULL,
	[createdDate] [date] NULL,
	[modifiDate] [date] NULL,
	[status] [bit] NULL,
	[topHot] [date] NULL,
	[MetaKeyword] [nvarchar](250) NULL,
	[MetaDescription] [nvarchar](250) NULL,
	[AmountSold] [int] NOT NULL,
	[isDisplayHomePage] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 19-10-2020 8:48:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](250) NULL,
	[metatitle] [nvarchar](250) NULL,
	[parentID] [int] NULL,
	[displayOrder] [int] NULL,
	[createdDate] [date] NULL,
	[modifiedDate] [date] NULL,
	[status] [bit] NULL,
	[showOnHome] [bit] NULL,
 CONSTRAINT [PK_dbo.ProductCategory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SEO]    Script Date: 19-10-2020 8:48:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SEO](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[MetaTitle] [nvarchar](500) NULL,
	[MetaKeyWord] [nvarchar](500) NULL,
	[MetaDescription] [nvarchar](500) NULL,
	[TypeId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.SEO] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 19-10-2020 8:48:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[MetaTitle] [nvarchar](250) NULL,
	[MetaKeyword] [nvarchar](250) NULL,
	[MetaDescription] [nvarchar](250) NULL,
	[Description] [nvarchar](999) NULL,
	[Image] [nvarchar](max) NULL,
	[MoreImages] [xml] NULL,
	[Price] [decimal](18, 2) NULL,
	[PromotionPrice] [decimal](18, 2) NULL,
	[IdCategory] [int] NOT NULL,
	[Detail] [ntext] NULL,
	[CreatedDate] [date] NULL,
	[ModifiDate] [date] NULL,
	[Status] [bit] NULL,
	[TopHot] [date] NULL,
	[IsDisplayHomePage] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Service] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceCategory]    Script Date: 19-10-2020 8:48:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Metatitle] [nvarchar](250) NULL,
	[ParentID] [int] NULL,
	[DisplayOrder] [int] NULL,
	[CreatedDate] [date] NULL,
	[ModifiedDate] [date] NULL,
	[Status] [bit] NULL,
	[ShowOnHome] [bit] NULL,
 CONSTRAINT [PK_dbo.ServiceCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Slide]    Script Date: 19-10-2020 8:48:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slide](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[image] [nvarchar](max) NULL,
	[displayOrder] [int] NULL,
	[link] [nvarchar](max) NULL,
	[createdDate] [datetime] NULL,
	[modifiedDate] [datetime] NULL,
	[status] [bit] NULL,
	[title] [nvarchar](max) NULL,
	[subtitle] [nvarchar](max) NULL,
	[TextButton] [nvarchar](max) NULL,
	[YellowTitle] [nvarchar](max) NULL,
	[SlideType] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Slide] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 19-10-2020 8:48:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[Phone] [nvarchar](20) NULL,
	[Address] [nvarchar](100) NULL,
	[createdDate] [date] NULL,
	[modifiedDate] [date] NULL,
	[status] [bit] NULL,
	[IdAccount] [bigint] NOT NULL,
	[Position] [nvarchar](100) NULL,
	[ShowOnHome] [bit] NULL,
	[image] [nvarchar](250) NULL,
 CONSTRAINT [PK_dbo.Staff] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsefulInformation]    Script Date: 19-10-2020 8:48:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsefulInformation](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Value] [int] NULL,
 CONSTRAINT [PK_dbo.UsefulInformation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VisitorByTime]    Script Date: 19-10-2020 8:48:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VisitorByTime](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Time] [datetime] NOT NULL,
	[Count] [bigint] NOT NULL,
 CONSTRAINT [PK_dbo.VisitorByTime] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[About] ADD  DEFAULT ((0)) FOR [Category]
GO
ALTER TABLE [dbo].[Content] ADD  DEFAULT ((0)) FOR [IsDisplayInHomePage]
GO
ALTER TABLE [dbo].[IPAddress] ADD  DEFAULT ('1900-01-01T00:00:00.000') FOR [date]
GO
ALTER TABLE [dbo].[Product] ADD  DEFAULT ((0)) FOR [AmountSold]
GO
ALTER TABLE [dbo].[Product] ADD  DEFAULT ((0)) FOR [isDisplayHomePage]
GO
ALTER TABLE [dbo].[SEO] ADD  DEFAULT ((0)) FOR [TypeId]
GO
ALTER TABLE [dbo].[Slide] ADD  DEFAULT ((0)) FOR [SlideType]
GO
ALTER TABLE [dbo].[CustomerAccount]  WITH CHECK ADD  CONSTRAINT [FK_CustomerAccount_Customer] FOREIGN KEY([IdCustomer])
REFERENCES [dbo].[Customer] ([id])
GO
ALTER TABLE [dbo].[CustomerAccount] CHECK CONSTRAINT [FK_CustomerAccount_Customer]
GO
ALTER TABLE [dbo].[Menu]  WITH CHECK ADD  CONSTRAINT [FK_Menu_MenuType] FOREIGN KEY([typeId])
REFERENCES [dbo].[MenuType] ([id])
GO
ALTER TABLE [dbo].[Menu] CHECK CONSTRAINT [FK_Menu_MenuType]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductCategory] FOREIGN KEY([idCategory])
REFERENCES [dbo].[ProductCategory] ([id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductCategory]
GO
USE [master]
GO
ALTER DATABASE [mon60410_FonNature] SET  READ_WRITE 
GO
