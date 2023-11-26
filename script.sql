USE [master]
GO
/****** Object:  Database [HealthHere]    Script Date: 26.11.2023 23:29:56 ******/
CREATE DATABASE [HealthHere]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HealthHere', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\HealthHere.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HealthHere_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\HealthHere_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [HealthHere] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HealthHere].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HealthHere] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HealthHere] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HealthHere] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HealthHere] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HealthHere] SET ARITHABORT OFF 
GO
ALTER DATABASE [HealthHere] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HealthHere] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HealthHere] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HealthHere] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HealthHere] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HealthHere] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HealthHere] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HealthHere] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HealthHere] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HealthHere] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HealthHere] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HealthHere] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HealthHere] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HealthHere] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HealthHere] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HealthHere] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HealthHere] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HealthHere] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HealthHere] SET  MULTI_USER 
GO
ALTER DATABASE [HealthHere] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HealthHere] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HealthHere] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HealthHere] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HealthHere] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HealthHere] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [HealthHere] SET QUERY_STORE = ON
GO
ALTER DATABASE [HealthHere] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [HealthHere]
GO
/****** Object:  Table [dbo].[order]    Script Date: 26.11.2023 23:29:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order](
	[order_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[status] [bit] NULL,
	[date] [date] NULL,
	[finall_price] [money] NULL,
	[pharmacy_id] [int] NULL,
 CONSTRAINT [PK_order] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order_sctructure]    Script Date: 26.11.2023 23:29:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order_sctructure](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NOT NULL,
	[product_id] [int] NOT NULL,
	[count] [int] NOT NULL,
 CONSTRAINT [PK_order_sctructure] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pharmacy]    Script Date: 26.11.2023 23:29:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pharmacy](
	[pharmacy_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](30) NULL,
	[address] [varchar](30) NULL,
	[work_time] [varchar](50) NULL,
	[is_available] [bit] NULL,
 CONSTRAINT [PK_pharmacy] PRIMARY KEY CLUSTERED 
(
	[pharmacy_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product]    Script Date: 26.11.2023 23:29:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product](
	[product_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](30) NOT NULL,
	[price] [money] NOT NULL,
	[description] [varchar](max) NULL,
	[count] [int] NULL,
	[image] [varbinary](50) NULL,
	[caterogy_id] [int] NULL,
 CONSTRAINT [PK_product] PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product_category]    Script Date: 26.11.2023 23:29:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product_category](
	[category_id] [int] IDENTITY(1,1) NOT NULL,
	[category_name] [varchar](30) NULL,
 CONSTRAINT [PK_product_category] PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 26.11.2023 23:29:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[login] [varchar](20) NOT NULL,
	[password] [varchar](max) NOT NULL,
	[last_online] [date] NULL,
	[is_stuff] [bit] NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[order] ON 

INSERT [dbo].[order] ([order_id], [user_id], [status], [date], [finall_price], [pharmacy_id]) VALUES (1, 3, 0, NULL, 120.0000, 1)
INSERT [dbo].[order] ([order_id], [user_id], [status], [date], [finall_price], [pharmacy_id]) VALUES (2, 3, 0, NULL, 500.0000, 2)
INSERT [dbo].[order] ([order_id], [user_id], [status], [date], [finall_price], [pharmacy_id]) VALUES (3, 3, 0, NULL, 1200.0000, 1)
SET IDENTITY_INSERT [dbo].[order] OFF
GO
SET IDENTITY_INSERT [dbo].[order_sctructure] ON 

INSERT [dbo].[order_sctructure] ([id], [order_id], [product_id], [count]) VALUES (2, 1, 1, 5)
SET IDENTITY_INSERT [dbo].[order_sctructure] OFF
GO
SET IDENTITY_INSERT [dbo].[pharmacy] ON 

INSERT [dbo].[pharmacy] ([pharmacy_id], [name], [address], [work_time], [is_available]) VALUES (1, N'Аптека', NULL, NULL, 1)
INSERT [dbo].[pharmacy] ([pharmacy_id], [name], [address], [work_time], [is_available]) VALUES (2, N'НеАптека', NULL, NULL, 1)
INSERT [dbo].[pharmacy] ([pharmacy_id], [name], [address], [work_time], [is_available]) VALUES (3, N'ПочтиАптека', NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[pharmacy] OFF
GO
SET IDENTITY_INSERT [dbo].[product] ON 

INSERT [dbo].[product] ([product_id], [name], [price], [description], [count], [image], [caterogy_id]) VALUES (1, N'Морфин', 10000.0000, NULL, 100, NULL, 1)
INSERT [dbo].[product] ([product_id], [name], [price], [description], [count], [image], [caterogy_id]) VALUES (3, N'Витамин C', 500.0000, NULL, 24, NULL, 1)
INSERT [dbo].[product] ([product_id], [name], [price], [description], [count], [image], [caterogy_id]) VALUES (4, N'Омез', 250.0000, NULL, 10, NULL, 1)
INSERT [dbo].[product] ([product_id], [name], [price], [description], [count], [image], [caterogy_id]) VALUES (5, N'Тонометр', 1500.0000, NULL, 42, NULL, 2)
INSERT [dbo].[product] ([product_id], [name], [price], [description], [count], [image], [caterogy_id]) VALUES (6, N'Пульсометр', 1000.0000, NULL, 5, NULL, 2)
SET IDENTITY_INSERT [dbo].[product] OFF
GO
SET IDENTITY_INSERT [dbo].[product_category] ON 

INSERT [dbo].[product_category] ([category_id], [category_name]) VALUES (1, N'Препараты')
INSERT [dbo].[product_category] ([category_id], [category_name]) VALUES (2, N'Устройства')
SET IDENTITY_INSERT [dbo].[product_category] OFF
GO
SET IDENTITY_INSERT [dbo].[user] ON 

INSERT [dbo].[user] ([user_id], [login], [password], [last_online], [is_stuff]) VALUES (3, N'petya', N'202cb962ac59075b964b07152d234b70', NULL, 0)
INSERT [dbo].[user] ([user_id], [login], [password], [last_online], [is_stuff]) VALUES (7, N'adm', N'sJxgD93Fc/EXRJs3I/I9ZA==', CAST(N'2023-11-26' AS Date), 1)
SET IDENTITY_INSERT [dbo].[user] OFF
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_order_pharmacy] FOREIGN KEY([pharmacy_id])
REFERENCES [dbo].[pharmacy] ([pharmacy_id])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_order_pharmacy]
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_order_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[user] ([user_id])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_order_user]
GO
ALTER TABLE [dbo].[order_sctructure]  WITH CHECK ADD  CONSTRAINT [FK_order_sctructure_order] FOREIGN KEY([order_id])
REFERENCES [dbo].[order] ([order_id])
GO
ALTER TABLE [dbo].[order_sctructure] CHECK CONSTRAINT [FK_order_sctructure_order]
GO
ALTER TABLE [dbo].[order_sctructure]  WITH CHECK ADD  CONSTRAINT [FK_order_sctructure_product] FOREIGN KEY([product_id])
REFERENCES [dbo].[product] ([product_id])
GO
ALTER TABLE [dbo].[order_sctructure] CHECK CONSTRAINT [FK_order_sctructure_product]
GO
ALTER TABLE [dbo].[product]  WITH CHECK ADD  CONSTRAINT [FK_product_product_category] FOREIGN KEY([caterogy_id])
REFERENCES [dbo].[product_category] ([category_id])
GO
ALTER TABLE [dbo].[product] CHECK CONSTRAINT [FK_product_product_category]
GO
USE [master]
GO
ALTER DATABASE [HealthHere] SET  READ_WRITE 
GO
