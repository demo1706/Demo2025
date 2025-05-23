USE [master]
GO
/****** Object:  Database [Partners]    Script Date: 23.04.2025 0:03:31 ******/
CREATE DATABASE [Partners]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Partners', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Partners.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Partners_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Partners_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Partners] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Partners].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Partners] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Partners] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Partners] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Partners] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Partners] SET ARITHABORT OFF 
GO
ALTER DATABASE [Partners] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Partners] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Partners] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Partners] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Partners] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Partners] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Partners] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Partners] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Partners] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Partners] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Partners] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Partners] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Partners] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Partners] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Partners] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Partners] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Partners] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Partners] SET RECOVERY FULL 
GO
ALTER DATABASE [Partners] SET  MULTI_USER 
GO
ALTER DATABASE [Partners] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Partners] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Partners] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Partners] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Partners] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Partners] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Partners', N'ON'
GO
ALTER DATABASE [Partners] SET QUERY_STORE = ON
GO
ALTER DATABASE [Partners] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Partners]
GO
/****** Object:  Table [dbo].[PartnerProducts]    Script Date: 23.04.2025 0:03:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartnerProducts](
	[Id] [int] NOT NULL,
	[IdPartner] [int] NOT NULL,
	[Article] [varchar](15) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Date] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Partners]    Script Date: 23.04.2025 0:03:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Partners](
	[Id] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[IdType] [int] NOT NULL,
	[Phone] [varchar](20) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Address] [varchar](100) NOT NULL,
	[Director] [varchar](100) NOT NULL,
	[Rating] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PartnerType]    Script Date: 23.04.2025 0:03:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartnerType](
	[Id] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 23.04.2025 0:03:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Article] [varchar](15) NOT NULL,
	[IdType] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[MinPrice] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Article] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductTypes]    Script Date: 23.04.2025 0:03:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductTypes](
	[Id] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Coefficient] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypesMaterial]    Script Date: 23.04.2025 0:03:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypesMaterial](
	[Id] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Percentage] [decimal](18, 0) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[PartnerProducts] ([Id], [IdPartner], [Article], [Quantity], [Date]) VALUES (1, 1, N'8758385', 15500, CAST(N'2023-03-23' AS Date))
INSERT [dbo].[PartnerProducts] ([Id], [IdPartner], [Article], [Quantity], [Date]) VALUES (2, 1, N'7750282', 12350, CAST(N'2023-12-18' AS Date))
INSERT [dbo].[PartnerProducts] ([Id], [IdPartner], [Article], [Quantity], [Date]) VALUES (3, 1, N'7028748', 37400, CAST(N'2024-06-07' AS Date))
INSERT [dbo].[PartnerProducts] ([Id], [IdPartner], [Article], [Quantity], [Date]) VALUES (4, 2, N'8858958', 35000, CAST(N'2022-12-02' AS Date))
INSERT [dbo].[PartnerProducts] ([Id], [IdPartner], [Article], [Quantity], [Date]) VALUES (5, 2, N'5012543', 1250, CAST(N'2023-05-17' AS Date))
INSERT [dbo].[PartnerProducts] ([Id], [IdPartner], [Article], [Quantity], [Date]) VALUES (6, 2, N'7750282', 1000, CAST(N'2024-06-07' AS Date))
INSERT [dbo].[PartnerProducts] ([Id], [IdPartner], [Article], [Quantity], [Date]) VALUES (7, 2, N'8758385', 7550, CAST(N'2024-07-01' AS Date))
INSERT [dbo].[PartnerProducts] ([Id], [IdPartner], [Article], [Quantity], [Date]) VALUES (8, 3, N'8758385', 7250, CAST(N'2023-01-22' AS Date))
INSERT [dbo].[PartnerProducts] ([Id], [IdPartner], [Article], [Quantity], [Date]) VALUES (9, 3, N'8858958', 2500, CAST(N'2024-07-05' AS Date))
INSERT [dbo].[PartnerProducts] ([Id], [IdPartner], [Article], [Quantity], [Date]) VALUES (10, 4, N'7028748', 59050, CAST(N'2023-03-20' AS Date))
INSERT [dbo].[PartnerProducts] ([Id], [IdPartner], [Article], [Quantity], [Date]) VALUES (11, 4, N'7750282', 37200, CAST(N'2024-03-12' AS Date))
INSERT [dbo].[PartnerProducts] ([Id], [IdPartner], [Article], [Quantity], [Date]) VALUES (12, 4, N'5012543', 4500, CAST(N'2024-05-14' AS Date))
INSERT [dbo].[PartnerProducts] ([Id], [IdPartner], [Article], [Quantity], [Date]) VALUES (13, 5, N'7750282', 50000, CAST(N'2023-09-19' AS Date))
INSERT [dbo].[PartnerProducts] ([Id], [IdPartner], [Article], [Quantity], [Date]) VALUES (14, 5, N'7028748', 670000, CAST(N'2023-11-10' AS Date))
INSERT [dbo].[PartnerProducts] ([Id], [IdPartner], [Article], [Quantity], [Date]) VALUES (15, 5, N'8758385', 35000, CAST(N'2024-04-15' AS Date))
INSERT [dbo].[PartnerProducts] ([Id], [IdPartner], [Article], [Quantity], [Date]) VALUES (16, 5, N'8858958', 25000, CAST(N'2024-06-12' AS Date))
GO
INSERT [dbo].[Partners] ([Id], [Name], [IdType], [Phone], [Email], [Address], [Director], [Rating]) VALUES (1, N'База Строитель', 1, N'493 123 45 67', N'aleksandraivanova@ml.ru', N'652050, Кемеровская область, город Юрга, ул. Лесная, 15', N'Иванова Александра Ивановна', 7)
INSERT [dbo].[Partners] ([Id], [Name], [IdType], [Phone], [Email], [Address], [Director], [Rating]) VALUES (2, N'Паркет 29', 2, N'987 123 56 78', N'vppetrov@vl.ru', N'164500, Архангельская область, город Северодвинск, ул. Строителей, 18', N'Петров Василий Петрович', 7)
INSERT [dbo].[Partners] ([Id], [Name], [IdType], [Phone], [Email], [Address], [Director], [Rating]) VALUES (3, N'Стройсервис', 3, N'812 223 32 00', N'ansolovev@st.ru', N'188910, Ленинградская область, город Приморск, ул. Парковая, 21', N'Соловьев Андрей Николаевич', 7)
INSERT [dbo].[Partners] ([Id], [Name], [IdType], [Phone], [Email], [Address], [Director], [Rating]) VALUES (4, N'Ремонт и отделка', 4, N'444 222 33 11', N'ekaterina.vorobeva@ml.ru', N'143960, Московская область, город Реутов, ул. Свободы, 51', N'Воробьева Екатерина Валерьевна', 5)
INSERT [dbo].[Partners] ([Id], [Name], [IdType], [Phone], [Email], [Address], [Director], [Rating]) VALUES (5, N'МонтажПро', 1, N'912 888 33 33', N'stepanov@stepan.ru', N'309500, Белгородская область, город Старый Оскол, ул. Рабочая, 122', N'Степанов Степан Сергеевич', 10)
GO
INSERT [dbo].[PartnerType] ([Id], [Name]) VALUES (1, N'ЗАО')
INSERT [dbo].[PartnerType] ([Id], [Name]) VALUES (2, N'ООО')
INSERT [dbo].[PartnerType] ([Id], [Name]) VALUES (3, N'ПАО')
INSERT [dbo].[PartnerType] ([Id], [Name]) VALUES (4, N'ОАО')
GO
INSERT [dbo].[Products] ([Article], [IdType], [Name], [MinPrice]) VALUES (N'5012543', 4, N'Пробковое напольное клеевое покрытие 32 класс 4 мм', CAST(5450.59 AS Decimal(18, 2)))
INSERT [dbo].[Products] ([Article], [IdType], [Name], [MinPrice]) VALUES (N'7028748', 1, N'Ламинат Дуб серый 32 класс 8 мм с фаской', CAST(3890.41 AS Decimal(18, 2)))
INSERT [dbo].[Products] ([Article], [IdType], [Name], [MinPrice]) VALUES (N'7750282', 1, N'Ламинат Дуб дымчато-белый 33 класс 12 мм', CAST(1799.33 AS Decimal(18, 2)))
INSERT [dbo].[Products] ([Article], [IdType], [Name], [MinPrice]) VALUES (N'8758385', 3, N'Паркетная доска Ясень темный однополосная 14 мм', CAST(4456.90 AS Decimal(18, 2)))
INSERT [dbo].[Products] ([Article], [IdType], [Name], [MinPrice]) VALUES (N'8858958', 3, N'Инженерная доска Дуб Французская елка однополосная 12 мм', CAST(7330.99 AS Decimal(18, 2)))
GO
INSERT [dbo].[ProductTypes] ([Id], [Name], [Coefficient]) VALUES (1, N'Ламинат', CAST(2.35 AS Decimal(18, 2)))
INSERT [dbo].[ProductTypes] ([Id], [Name], [Coefficient]) VALUES (2, N'Массивная доска', CAST(5.15 AS Decimal(18, 2)))
INSERT [dbo].[ProductTypes] ([Id], [Name], [Coefficient]) VALUES (3, N'Паркетная доска', CAST(4.34 AS Decimal(18, 2)))
INSERT [dbo].[ProductTypes] ([Id], [Name], [Coefficient]) VALUES (4, N'Пробковое покрытие', CAST(1.50 AS Decimal(18, 2)))
GO
INSERT [dbo].[TypesMaterial] ([Id], [Name], [Percentage]) VALUES (1, N'Тип материала 1', CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[TypesMaterial] ([Id], [Name], [Percentage]) VALUES (2, N'Тип материала 2', CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[TypesMaterial] ([Id], [Name], [Percentage]) VALUES (3, N'Тип материала 3', CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[TypesMaterial] ([Id], [Name], [Percentage]) VALUES (4, N'Тип материала 4', CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[TypesMaterial] ([Id], [Name], [Percentage]) VALUES (5, N'Тип материала 5', CAST(0 AS Decimal(18, 0)))
GO
ALTER TABLE [dbo].[PartnerProducts]  WITH CHECK ADD FOREIGN KEY([Article])
REFERENCES [dbo].[Products] ([Article])
GO
ALTER TABLE [dbo].[PartnerProducts]  WITH CHECK ADD FOREIGN KEY([IdPartner])
REFERENCES [dbo].[Partners] ([Id])
GO
ALTER TABLE [dbo].[Partners]  WITH CHECK ADD FOREIGN KEY([IdType])
REFERENCES [dbo].[PartnerType] ([Id])
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD FOREIGN KEY([IdType])
REFERENCES [dbo].[ProductTypes] ([Id])
GO
USE [master]
GO
ALTER DATABASE [Partners] SET  READ_WRITE 
GO
