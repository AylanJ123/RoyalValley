USE [master]
GO
/****** Object:  Database [RoyaltyValley-Aylan_Sebas]    Script Date: 4/26/2023 11:45:38 AM ******/
CREATE DATABASE [RoyaltyValley-Aylan_Sebas] CONTAINMENT = NONE
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RoyaltyValley-Aylan_Sebas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RoyaltyValley-Aylan_Sebas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RoyaltyValley-Aylan_Sebas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RoyaltyValley-Aylan_Sebas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RoyaltyValley-Aylan_Sebas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RoyaltyValley-Aylan_Sebas] SET ARITHABORT OFF 
GO
ALTER DATABASE [RoyaltyValley-Aylan_Sebas] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RoyaltyValley-Aylan_Sebas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RoyaltyValley-Aylan_Sebas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RoyaltyValley-Aylan_Sebas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RoyaltyValley-Aylan_Sebas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RoyaltyValley-Aylan_Sebas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RoyaltyValley-Aylan_Sebas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RoyaltyValley-Aylan_Sebas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RoyaltyValley-Aylan_Sebas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RoyaltyValley-Aylan_Sebas] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RoyaltyValley-Aylan_Sebas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RoyaltyValley-Aylan_Sebas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RoyaltyValley-Aylan_Sebas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RoyaltyValley-Aylan_Sebas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RoyaltyValley-Aylan_Sebas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RoyaltyValley-Aylan_Sebas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RoyaltyValley-Aylan_Sebas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RoyaltyValley-Aylan_Sebas] SET RECOVERY FULL 
GO
ALTER DATABASE [RoyaltyValley-Aylan_Sebas] SET  MULTI_USER 
GO
ALTER DATABASE [RoyaltyValley-Aylan_Sebas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RoyaltyValley-Aylan_Sebas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RoyaltyValley-Aylan_Sebas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RoyaltyValley-Aylan_Sebas] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RoyaltyValley-Aylan_Sebas] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RoyaltyValley-Aylan_Sebas] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'RoyaltyValley-Aylan_Sebas', N'ON'
GO
ALTER DATABASE [RoyaltyValley-Aylan_Sebas] SET QUERY_STORE = ON
GO
ALTER DATABASE [RoyaltyValley-Aylan_Sebas] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [RoyaltyValley-Aylan_Sebas]
GO
/****** Object:  Table [dbo].[Cobro]    Script Date: 4/26/2023 11:45:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cobro](
	[fecha] [date] NOT NULL,
	[IDPlanCobro] [int] NOT NULL,
	[IDResidencia] [int] NOT NULL,
	[total] [money] NOT NULL,
	[pagado] [bit] NOT NULL,
	[fechaPago] [datetime] NULL,
 CONSTRAINT [PK_Cobro_1] PRIMARY KEY CLUSTERED 
(
	[fecha] ASC,
	[IDPlanCobro] ASC,
	[IDResidencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Edificio]    Script Date: 4/26/2023 11:45:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Edificio](
	[ID] [int] IDENTITY(100,1) NOT NULL,
	[calle] [varchar](20) NOT NULL,
	[avenida] [varchar](20) NOT NULL,
	[descripcion] [varchar](200) NOT NULL,
	[fechaConst] [date] NULL,
	[estado] [tinyint] NOT NULL,
 CONSTRAINT [PK_Edificio] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EdificioPublico]    Script Date: 4/26/2023 11:45:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EdificioPublico](
	[edificio] [int] NOT NULL,
	[espacioPersonas] [smallint] NOT NULL,
	[espacioParqueo] [smallint] NOT NULL,
	[montoHoraReserva] [money] NOT NULL,
 CONSTRAINT [PK_EdificioPublico] PRIMARY KEY CLUSTERED 
(
	[edificio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Incidencia]    Script Date: 4/26/2023 11:45:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Incidencia](
	[ID] [int] IDENTITY(100,1) NOT NULL,
	[descripcion] [varchar](200) NOT NULL,
	[fecha] [date] NOT NULL,
	[estado] [tinyint] NOT NULL,
	[IDUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Incidencia] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Noticias]    Script Date: 4/26/2023 11:45:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Noticias](
	[nombre] [varchar](40) NOT NULL,
	[contenido] [varchar](max) NOT NULL,
	[fecha] [date] NOT NULL,
	[imagen] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_Noticias] PRIMARY KEY CLUSTERED 
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlanCobro]    Script Date: 4/26/2023 11:45:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlanCobro](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](40) NOT NULL,
	[descripcion] [varchar](200) NOT NULL,
	[automatico] [bit] NOT NULL,
 CONSTRAINT [PK_PlanCobro_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reserva]    Script Date: 4/26/2023 11:45:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reserva](
	[fecha] [datetime] NOT NULL,
	[IDEdificio] [int] NOT NULL,
	[motivo] [varchar](100) NOT NULL,
	[estado] [tinyint] NOT NULL,
	[IDUsuario] [int] NOT NULL,
	[horas] [tinyint] NOT NULL,
 CONSTRAINT [PK_Reserva] PRIMARY KEY CLUSTERED 
(
	[fecha] ASC,
	[IDEdificio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Residencia]    Script Date: 4/26/2023 11:45:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Residencia](
	[edificio] [int] NOT NULL,
	[montoMensual] [money] NOT NULL,
	[cantInquilinos] [tinyint] NOT NULL,
	[espacioGaraje] [tinyint] NOT NULL,
	[habitaciones] [tinyint] NOT NULL,
	[dueno] [int] NOT NULL,
 CONSTRAINT [PK_Residencia] PRIMARY KEY CLUSTERED 
(
	[edificio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rubro]    Script Date: 4/26/2023 11:45:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rubro](
	[ID] [int] IDENTITY(1000,1) NOT NULL,
	[monto] [money] NOT NULL,
	[porcentual] [bit] NOT NULL,
	[motivo] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Rubro] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RubroPlan]    Script Date: 4/26/2023 11:45:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RubroPlan](
	[IDRubro] [int] NOT NULL,
	[IDPlan] [int] NOT NULL,
 CONSTRAINT [PK_RubroPlan] PRIMARY KEY CLUSTERED 
(
	[IDRubro] ASC,
	[IDPlan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 4/26/2023 11:45:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[ID] [int] IDENTITY(1000,1) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[apellido1] [varchar](12) NOT NULL,
	[apellido2] [varchar](12) NOT NULL,
	[telefono] [varchar](12) NULL,
	[correo] [varchar](30) NULL,
	[contrasena] [varbinary](max) NOT NULL,
	[cedula] [varchar](12) NOT NULL,
	[tipo] [tinyint] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Cobro] ([fecha], [IDPlanCobro], [IDResidencia], [total], [pagado], [fechaPago]) VALUES (CAST(N'2022-10-01' AS Date), 1, 102, 17500.0000, 1, CAST(N'2022-10-05T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Cobro] ([fecha], [IDPlanCobro], [IDResidencia], [total], [pagado], [fechaPago]) VALUES (CAST(N'2022-11-01' AS Date), 1, 102, 17500.0000, 1, CAST(N'2022-11-05T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Cobro] ([fecha], [IDPlanCobro], [IDResidencia], [total], [pagado], [fechaPago]) VALUES (CAST(N'2022-11-01' AS Date), 1, 105, 18500.0000, 1, CAST(N'2022-11-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Cobro] ([fecha], [IDPlanCobro], [IDResidencia], [total], [pagado], [fechaPago]) VALUES (CAST(N'2022-12-01' AS Date), 1, 105, 18500.0000, 1, CAST(N'2022-12-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Cobro] ([fecha], [IDPlanCobro], [IDResidencia], [total], [pagado], [fechaPago]) VALUES (CAST(N'2022-12-01' AS Date), 4, 102, 23500.0000, 1, CAST(N'2022-12-05T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Cobro] ([fecha], [IDPlanCobro], [IDResidencia], [total], [pagado], [fechaPago]) VALUES (CAST(N'2023-01-01' AS Date), 1, 102, 17500.0000, 1, CAST(N'2023-02-05T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Cobro] ([fecha], [IDPlanCobro], [IDResidencia], [total], [pagado], [fechaPago]) VALUES (CAST(N'2023-01-01' AS Date), 1, 105, 18500.0000, 1, CAST(N'2023-01-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Cobro] ([fecha], [IDPlanCobro], [IDResidencia], [total], [pagado], [fechaPago]) VALUES (CAST(N'2023-01-01' AS Date), 2, 101, 25000.0000, 1, CAST(N'2023-01-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Cobro] ([fecha], [IDPlanCobro], [IDResidencia], [total], [pagado], [fechaPago]) VALUES (CAST(N'2023-02-01' AS Date), 1, 105, 18500.0000, 1, CAST(N'2023-02-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Cobro] ([fecha], [IDPlanCobro], [IDResidencia], [total], [pagado], [fechaPago]) VALUES (CAST(N'2023-02-01' AS Date), 2, 101, 25000.0000, 1, CAST(N'2023-02-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Cobro] ([fecha], [IDPlanCobro], [IDResidencia], [total], [pagado], [fechaPago]) VALUES (CAST(N'2023-02-01' AS Date), 5, 102, 21875.0000, 1, CAST(N'2023-02-05T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Cobro] ([fecha], [IDPlanCobro], [IDResidencia], [total], [pagado], [fechaPago]) VALUES (CAST(N'2023-03-01' AS Date), 1, 101, 17500.0000, 0, NULL)
GO
INSERT [dbo].[Cobro] ([fecha], [IDPlanCobro], [IDResidencia], [total], [pagado], [fechaPago]) VALUES (CAST(N'2023-03-01' AS Date), 1, 105, 18500.0000, 0, NULL)
GO
INSERT [dbo].[Cobro] ([fecha], [IDPlanCobro], [IDResidencia], [total], [pagado], [fechaPago]) VALUES (CAST(N'2023-03-01' AS Date), 2, 102, 25000.0000, 0, CAST(N'2023-03-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Cobro] ([fecha], [IDPlanCobro], [IDResidencia], [total], [pagado], [fechaPago]) VALUES (CAST(N'2023-04-01' AS Date), 1, 101, 25000.0000, 0, NULL)
GO
INSERT [dbo].[Cobro] ([fecha], [IDPlanCobro], [IDResidencia], [total], [pagado], [fechaPago]) VALUES (CAST(N'2023-04-01' AS Date), 2, 102, 20500.0000, 0, NULL)
GO
SET IDENTITY_INSERT [dbo].[Edificio] ON 
GO
INSERT [dbo].[Edificio] ([ID], [calle], [avenida], [descripcion], [fechaConst], [estado]) VALUES (101, N'1', N'1', N'Hogar de dos pisos de altura, con garaje. Color Beige.', CAST(N'2022-12-12' AS Date), 2)
GO
INSERT [dbo].[Edificio] ([ID], [calle], [avenida], [descripcion], [fechaConst], [estado]) VALUES (102, N'1', N'1', N'Casa de una sola planta. Sin garaje. Color verde techo de zinc.', CAST(N'2022-09-25' AS Date), 2)
GO
INSERT [dbo].[Edificio] ([ID], [calle], [avenida], [descripcion], [fechaConst], [estado]) VALUES (103, N'2', N'1', N'Obra gris residencia de dos plantas. Sin garaje. Se espera se termine la construccion en Marzo 2023.', CAST(N'2023-01-06' AS Date), 1)
GO
INSERT [dbo].[Edificio] ([ID], [calle], [avenida], [descripcion], [fechaConst], [estado]) VALUES (104, N'2', N'1', N'Lote baldío sin construir. Planes para convertir en residencia.', CAST(N'2022-08-01' AS Date), 0)
GO
INSERT [dbo].[Edificio] ([ID], [calle], [avenida], [descripcion], [fechaConst], [estado]) VALUES (105, N'3', N'1', N'Hogar de un piso con garaje, color azul con fachada frontal de rocas', CAST(N'2022-11-07' AS Date), 2)
GO
INSERT [dbo].[Edificio] ([ID], [calle], [avenida], [descripcion], [fechaConst], [estado]) VALUES (108, N'4', N'1', N'Salon de eventos con capacidad media y parqueo sin techo.', CAST(N'2022-10-09' AS Date), 2)
GO
INSERT [dbo].[Edificio] ([ID], [calle], [avenida], [descripcion], [fechaConst], [estado]) VALUES (109, N'4', N'1', N'Piscinas del residencial, una de niños y otra de adultos.', CAST(N'2022-11-01' AS Date), 2)
GO
INSERT [dbo].[Edificio] ([ID], [calle], [avenida], [descripcion], [fechaConst], [estado]) VALUES (110, N'4', N'2', N'Rancho bajo techo para picnic.', CAST(N'2022-08-05' AS Date), 2)
GO
SET IDENTITY_INSERT [dbo].[Edificio] OFF
GO
INSERT [dbo].[EdificioPublico] ([edificio], [espacioPersonas], [espacioParqueo], [montoHoraReserva]) VALUES (108, 80, 20, 5000.0000)
GO
INSERT [dbo].[EdificioPublico] ([edificio], [espacioPersonas], [espacioParqueo], [montoHoraReserva]) VALUES (109, 25, 5, 10000.0000)
GO
INSERT [dbo].[EdificioPublico] ([edificio], [espacioPersonas], [espacioParqueo], [montoHoraReserva]) VALUES (110, 18, 2, 2500.0000)
GO
SET IDENTITY_INSERT [dbo].[Incidencia] ON 
GO
INSERT [dbo].[Incidencia] ([ID], [descripcion], [fecha], [estado], [IDUsuario]) VALUES (100, N'El vecino de la casa 102 deja a su perro afuera y casi muerde a mi hijo, pedirle que lo mantenga encerrado o le ponga bozal', CAST(N'2023-03-15' AS Date), 0, 1001)
GO
INSERT [dbo].[Incidencia] ([ID], [descripcion], [fecha], [estado], [IDUsuario]) VALUES (101, N'Estoy teniendo problemas con el salario, el gobierno lo tiene retenido entonces no podre pagar a tiempo', CAST(N'2023-03-15' AS Date), 1, 1001)
GO
INSERT [dbo].[Incidencia] ([ID], [descripcion], [fecha], [estado], [IDUsuario]) VALUES (102, N'Los vecinos de la 105 tiene música Rock todo el día a muy alto volumen', CAST(N'2023-03-15' AS Date), 1, 1001)
GO
INSERT [dbo].[Incidencia] ([ID], [descripcion], [fecha], [estado], [IDUsuario]) VALUES (1101, N'Todos los días aparecen excrementos de perro al frente de mi casa, por favor hacer algo al respecto.', CAST(N'2023-04-26' AS Date), 0, 1003)
GO
SET IDENTITY_INSERT [dbo].[Incidencia] OFF
GO
INSERT [dbo].[Noticias] ([nombre], [contenido], [fecha], [imagen]) VALUES (N'Bienvenido!', N'Al sitio oficial de Royalty Valley!', CAST(N'2023-03-15' AS Date), 0x)
GO
INSERT [dbo].[Noticias] ([nombre], [contenido], [fecha], [imagen]) VALUES (N'Buffet', N'Buffet de bienvenida! Descuento del 25% a los residentes con menos de un mes con nosotros!
Solo para residentes.', CAST(N'2023-03-14' AS Date), 0x)
GO
INSERT [dbo].[Noticias] ([nombre], [contenido], [fecha], [imagen]) VALUES (N'Partido de futsala', N'Mañana a las 6pm en el gimnasio local! Todos los residentes invitados.
Se permiten 4 amigos por residencia. Avisar con antelación.', CAST(N'2023-03-09' AS Date), 0x)
GO
SET IDENTITY_INSERT [dbo].[PlanCobro] ON 
GO
INSERT [dbo].[PlanCobro] ([ID], [nombre], [descripcion], [automatico]) VALUES (1, N'Plan Básico', N'Cobros básicos a todas las residencias por el 100% de su valor', 1)
GO
INSERT [dbo].[PlanCobro] ([ID], [nombre], [descripcion], [automatico]) VALUES (2, N'Plan Avanzado', N'Cobros básicos con extra por limpiar el frente de la residencia cada 2 días', 0)
GO
INSERT [dbo].[PlanCobro] ([ID], [nombre], [descripcion], [automatico]) VALUES (3, N'Multa por basura', N'Cobro básico con extra fijo por botar basura personalmente', 0)
GO
INSERT [dbo].[PlanCobro] ([ID], [nombre], [descripcion], [automatico]) VALUES (4, N'Multa por descuido de basurero', N'Cobro básico con extra fijo por dejar la bolsa de basura al alcance de perros callejeros', 0)
GO
INSERT [dbo].[PlanCobro] ([ID], [nombre], [descripcion], [automatico]) VALUES (5, N'Plan Básico Atrasado', N'Cobros básicos con multa del 25% por atrasarse dos semanas en el pago', 0)
GO
INSERT [dbo].[PlanCobro] ([ID], [nombre], [descripcion], [automatico]) VALUES (6, N'Plan Avanzado Atrasado', N'Cobros básicos con multa del 25% por atrasarse dos semanas en el pago con extra por limpieza', 0)
GO
INSERT [dbo].[PlanCobro] ([ID], [nombre], [descripcion], [automatico]) VALUES (7, N'Plan básico multa por basura y atraso', N'Cobro básico según la residencia con multa por botar basura y atraso', 0)
GO
SET IDENTITY_INSERT [dbo].[PlanCobro] OFF
GO
INSERT [dbo].[Reserva] ([fecha], [IDEdificio], [motivo], [estado], [IDUsuario], [horas]) VALUES (CAST(N'2023-04-22T12:00:00.000' AS DateTime), 108, N'Baby shower', 1, 1001, 6)
GO
INSERT [dbo].[Reserva] ([fecha], [IDEdificio], [motivo], [estado], [IDUsuario], [horas]) VALUES (CAST(N'2023-04-25T11:00:00.000' AS DateTime), 110, N'Almuerzo compartido', 1, 1001, 2)
GO
INSERT [dbo].[Reserva] ([fecha], [IDEdificio], [motivo], [estado], [IDUsuario], [horas]) VALUES (CAST(N'2023-04-27T12:00:00.000' AS DateTime), 110, N'Picnic', 1, 1003, 2)
GO
INSERT [dbo].[Reserva] ([fecha], [IDEdificio], [motivo], [estado], [IDUsuario], [horas]) VALUES (CAST(N'2023-04-29T08:00:00.000' AS DateTime), 109, N'Cumpleaños en piscina', 2, 1001, 4)
GO
INSERT [dbo].[Residencia] ([edificio], [montoMensual], [cantInquilinos], [espacioGaraje], [habitaciones], [dueno]) VALUES (101, 25000.0000, 6, 2, 10, 1001)
GO
INSERT [dbo].[Residencia] ([edificio], [montoMensual], [cantInquilinos], [espacioGaraje], [habitaciones], [dueno]) VALUES (102, 17500.0000, 3, 0, 5, 1002)
GO
INSERT [dbo].[Residencia] ([edificio], [montoMensual], [cantInquilinos], [espacioGaraje], [habitaciones], [dueno]) VALUES (103, 0.0000, 0, 0, 6, 1003)
GO
INSERT [dbo].[Residencia] ([edificio], [montoMensual], [cantInquilinos], [espacioGaraje], [habitaciones], [dueno]) VALUES (105, 18500.0000, 4, 1, 7, 1004)
GO
SET IDENTITY_INSERT [dbo].[Rubro] ON 
GO
INSERT [dbo].[Rubro] ([ID], [monto], [porcentual], [motivo]) VALUES (1001, 1.0000, 1, N'Cobro por servicios comunes')
GO
INSERT [dbo].[Rubro] ([ID], [monto], [porcentual], [motivo]) VALUES (1002, 3000.0000, 0, N'Cobro limpieza extra de zona frontal')
GO
INSERT [dbo].[Rubro] ([ID], [monto], [porcentual], [motivo]) VALUES (1003, 4000.0000, 0, N'Multa por botar basura')
GO
INSERT [dbo].[Rubro] ([ID], [monto], [porcentual], [motivo]) VALUES (1004, 6000.0000, 0, N'Multa por no subir basura a la canasta')
GO
INSERT [dbo].[Rubro] ([ID], [monto], [porcentual], [motivo]) VALUES (1005, 1.2500, 1, N'Multa por pago atrasado')
GO
SET IDENTITY_INSERT [dbo].[Rubro] OFF
GO
INSERT [dbo].[RubroPlan] ([IDRubro], [IDPlan]) VALUES (1001, 1)
GO
INSERT [dbo].[RubroPlan] ([IDRubro], [IDPlan]) VALUES (1001, 2)
GO
INSERT [dbo].[RubroPlan] ([IDRubro], [IDPlan]) VALUES (1001, 3)
GO
INSERT [dbo].[RubroPlan] ([IDRubro], [IDPlan]) VALUES (1001, 4)
GO
INSERT [dbo].[RubroPlan] ([IDRubro], [IDPlan]) VALUES (1002, 2)
GO
INSERT [dbo].[RubroPlan] ([IDRubro], [IDPlan]) VALUES (1002, 6)
GO
INSERT [dbo].[RubroPlan] ([IDRubro], [IDPlan]) VALUES (1003, 3)
GO
INSERT [dbo].[RubroPlan] ([IDRubro], [IDPlan]) VALUES (1003, 7)
GO
INSERT [dbo].[RubroPlan] ([IDRubro], [IDPlan]) VALUES (1004, 4)
GO
INSERT [dbo].[RubroPlan] ([IDRubro], [IDPlan]) VALUES (1005, 5)
GO
INSERT [dbo].[RubroPlan] ([IDRubro], [IDPlan]) VALUES (1005, 6)
GO
INSERT [dbo].[RubroPlan] ([IDRubro], [IDPlan]) VALUES (1005, 7)
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 
GO
INSERT [dbo].[Usuario] ([ID], [nombre], [apellido1], [apellido2], [telefono], [correo], [contrasena], [cedula], [tipo]) VALUES (1001, N'Alejandro', N'Alvarez', N'Miranda', N'51052431', N'alalmiranda@gmail.com', 0xBBA417729125BB78C1CE2DB614D15DAF, N'108230365', 0)
GO
INSERT [dbo].[Usuario] ([ID], [nombre], [apellido1], [apellido2], [telefono], [correo], [contrasena], [cedula], [tipo]) VALUES (1002, N'Jorge', N'Castro', N'Gonzales', N'84750394', N'castrogon@gmail.com', 0xBBA417729125BB78C1CE2DB614D15DAF, N'200340534', 0)
GO
INSERT [dbo].[Usuario] ([ID], [nombre], [apellido1], [apellido2], [telefono], [correo], [contrasena], [cedula], [tipo]) VALUES (1003, N'Jessica', N'Herrera', N'Solano', NULL, N'jessyherrera@gmail.com', 0xBBA417729125BB78C1CE2DB614D15DAF, N'408530472', 0)
GO
INSERT [dbo].[Usuario] ([ID], [nombre], [apellido1], [apellido2], [telefono], [correo], [contrasena], [cedula], [tipo]) VALUES (1004, N'Josué', N'Cañas', N'Delgado', NULL, N'cañasflaco@gmail.com', 0xBBA417729125BB78C1CE2DB614D15DAF, N'303450687', 0)
GO
INSERT [dbo].[Usuario] ([ID], [nombre], [apellido1], [apellido2], [telefono], [correo], [contrasena], [cedula], [tipo]) VALUES (1010, N'Aylan Josué', N'Miranda', N'Blanco', N'60151105', N'aylanjosue@gmail.com', 0xBBA417729125BB78C1CE2DB614D15DAF, N'208410471', 1)
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Usuario__2A586E0BA9709953]    Script Date: 4/26/2023 11:45:38 AM ******/
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [UQ__Usuario__2A586E0BA9709953] UNIQUE NONCLUSTERED 
(
	[correo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cobro]  WITH CHECK ADD  CONSTRAINT [FK_Cobro_PlanCobro1] FOREIGN KEY([IDPlanCobro])
REFERENCES [dbo].[PlanCobro] ([ID])
GO
ALTER TABLE [dbo].[Cobro] CHECK CONSTRAINT [FK_Cobro_PlanCobro1]
GO
ALTER TABLE [dbo].[Cobro]  WITH CHECK ADD  CONSTRAINT [FK_Cobro_Residencia] FOREIGN KEY([IDResidencia])
REFERENCES [dbo].[Residencia] ([edificio])
GO
ALTER TABLE [dbo].[Cobro] CHECK CONSTRAINT [FK_Cobro_Residencia]
GO
ALTER TABLE [dbo].[EdificioPublico]  WITH CHECK ADD  CONSTRAINT [FK_EdificioPublico_Edificio] FOREIGN KEY([edificio])
REFERENCES [dbo].[Edificio] ([ID])
GO
ALTER TABLE [dbo].[EdificioPublico] CHECK CONSTRAINT [FK_EdificioPublico_Edificio]
GO
ALTER TABLE [dbo].[Incidencia]  WITH CHECK ADD  CONSTRAINT [FK_Incidencia_Usuario] FOREIGN KEY([IDUsuario])
REFERENCES [dbo].[Usuario] ([ID])
GO
ALTER TABLE [dbo].[Incidencia] CHECK CONSTRAINT [FK_Incidencia_Usuario]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_EdificioPublico] FOREIGN KEY([IDEdificio])
REFERENCES [dbo].[EdificioPublico] ([edificio])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_EdificioPublico]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Usuario] FOREIGN KEY([IDUsuario])
REFERENCES [dbo].[Usuario] ([ID])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Usuario]
GO
ALTER TABLE [dbo].[Residencia]  WITH CHECK ADD  CONSTRAINT [FK_Residencia_Edificio] FOREIGN KEY([edificio])
REFERENCES [dbo].[Edificio] ([ID])
GO
ALTER TABLE [dbo].[Residencia] CHECK CONSTRAINT [FK_Residencia_Edificio]
GO
ALTER TABLE [dbo].[Residencia]  WITH CHECK ADD  CONSTRAINT [FK_Residencia_Usuario] FOREIGN KEY([dueno])
REFERENCES [dbo].[Usuario] ([ID])
GO
ALTER TABLE [dbo].[Residencia] CHECK CONSTRAINT [FK_Residencia_Usuario]
GO
ALTER TABLE [dbo].[RubroPlan]  WITH CHECK ADD  CONSTRAINT [FK_RubroPlan_PlanCobro] FOREIGN KEY([IDPlan])
REFERENCES [dbo].[PlanCobro] ([ID])
GO
ALTER TABLE [dbo].[RubroPlan] CHECK CONSTRAINT [FK_RubroPlan_PlanCobro]
GO
ALTER TABLE [dbo].[RubroPlan]  WITH CHECK ADD  CONSTRAINT [FK_RubroPlan_Rubro] FOREIGN KEY([IDRubro])
REFERENCES [dbo].[Rubro] ([ID])
GO
ALTER TABLE [dbo].[RubroPlan] CHECK CONSTRAINT [FK_RubroPlan_Rubro]
GO
USE [master]
GO
ALTER DATABASE [RoyaltyValley-Aylan_Sebas] SET  READ_WRITE 
GO
