USE [FerreteriaJyR]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 29/07/2018 21:33:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categoria](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](20) NULL,
	[Descripcion] [varchar](150) NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CotizacionDetalle]    Script Date: 29/07/2018 21:33:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CotizacionDetalle](
	[Cotizacion] [int] NOT NULL,
	[IdDetalle] [int] IDENTITY(1,1) NOT NULL,
	[Producto] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[PrecioUnitario] [money] NOT NULL,
	[Subtotal] [money] NOT NULL,
 CONSTRAINT [PK_CotizacionDetalle] PRIMARY KEY CLUSTERED 
(
	[IdDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CotizacionEncabezado]    Script Date: 29/07/2018 21:33:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CotizacionEncabezado](
	[IdCotizacion] [int] NOT NULL,
	[Usuario] [int] NOT NULL,
	[Fecha] [datetime] NULL,
 CONSTRAINT [PK_Cotizacion] PRIMARY KEY CLUSTERED 
(
	[IdCotizacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Producto]    Script Date: 29/07/2018 21:33:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Producto](
	[IdProducto] [int] NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Descripcion] [varchar](100) NULL,
	[Categoria] [int] NOT NULL,
	[Imagen] [image] NULL,
	[Precio] [money] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 29/07/2018 21:33:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rol](
	[IdRol] [int] NOT NULL,
	[Descripcion] [varchar](20) NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 29/07/2018 21:33:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[Nombre] [varchar](20) NULL,
	[Apellidos] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Contraseña] [varbinary](max) NULL,
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Rol] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[CotizacionDetalle]  WITH CHECK ADD  CONSTRAINT [FK_CotizacionDetalle_CotizacionEncabezado] FOREIGN KEY([Cotizacion])
REFERENCES [dbo].[CotizacionEncabezado] ([IdCotizacion])
GO
ALTER TABLE [dbo].[CotizacionDetalle] CHECK CONSTRAINT [FK_CotizacionDetalle_CotizacionEncabezado]
GO
ALTER TABLE [dbo].[CotizacionDetalle]  WITH CHECK ADD  CONSTRAINT [FK_CotizacionDetalle_Producto] FOREIGN KEY([Producto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
ALTER TABLE [dbo].[CotizacionDetalle] CHECK CONSTRAINT [FK_CotizacionDetalle_Producto]
GO
ALTER TABLE [dbo].[CotizacionEncabezado]  WITH CHECK ADD  CONSTRAINT [FK_Cotizacion_Usuario] FOREIGN KEY([Usuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[CotizacionEncabezado] CHECK CONSTRAINT [FK_Cotizacion_Usuario]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Categoria] FOREIGN KEY([Categoria])
REFERENCES [dbo].[Categoria] ([IdCategoria])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Categoria]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Rol] FOREIGN KEY([Rol])
REFERENCES [dbo].[Rol] ([IdRol])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Rol]
GO
/****** Object:  StoredProcedure [dbo].[SP_ActualizarCategoria]    Script Date: 29/07/2018 21:33:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ActualizarCategoria]
	@IdCategoria int,@Nombre varchar(20),@Descripcion varchar(150)
AS
BEGIN
	SET NOCOUNT ON;
	Update Categoria set Nombre = @Nombre,Descripcion = @Descripcion
	where IdCategoria = @IdCategoria
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ActualizarUsuario]    Script Date: 29/07/2018 21:33:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ActualizarUsuario]
	@IdUsuario int,@Nombre varchar(20),@Apellidos varchar(50),
	@Email varchar(50),@Rol int
AS
BEGIN
	SET NOCOUNT ON;
	Update Usuario set Nombre = @Nombre,Apellidos = @Apellidos,Email = @Email,Rol = @Rol
	where IdUsuario = @IdUsuario
END

GO
/****** Object:  StoredProcedure [dbo].[SP_EliminarCategoria]    Script Date: 29/07/2018 21:33:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[SP_EliminarCategoria]
	@IdCategoria int
AS
BEGIN
	SET NOCOUNT ON;
    Delete from Categoria
	where IdCategoria = @IdCategoria
END
GO
/****** Object:  StoredProcedure [dbo].[SP_EliminarUsuario]    Script Date: 29/07/2018 21:33:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_EliminarUsuario]
	@IdUsuario int
AS
BEGIN
	SET NOCOUNT ON;
    Delete from Usuario
	where IdUsuario = @IdUsuario
END
GO
/****** Object:  StoredProcedure [dbo].[SP_InsertarCategoria]    Script Date: 29/07/2018 21:33:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_InsertarCategoria]
		@Nombre varchar(20), @Descripción varchar(150) 
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Categoria] ([Nombre], [Descripcion])
	SELECT @Nombre, @Descripción;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_InsertarUsuario]    Script Date: 29/07/2018 21:33:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_InsertarUsuario]
	@Nombre varchar(20), @Apellidos varchar(50) ,@Email varchar(50) , @Contraseña varchar(MAX),@Rol int
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Usuario] ([Nombre], [Apellidos],[Email], [Contraseña], [Rol])
	SELECT @Nombre, @Apellidos, @Email,ENCRYPTBYPASSPHRASE('contraseñajyr',@Contraseña),@Rol ;
END

GO
/****** Object:  StoredProcedure [dbo].[SP_SeleccionarCategoriaPorId]    Script Date: 29/07/2018 21:33:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[SP_SeleccionarCategoriaPorId] 
	@IdCategoria int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * from Categoria
	where [IdCategoria] = @IdCategoria;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SeleccionarCategorias]    Script Date: 29/07/2018 21:33:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_SeleccionarCategorias] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * from Categoria
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SeleccionarUsuarioPorId]    Script Date: 29/07/2018 21:33:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_SeleccionarUsuarioPorId] 
	@Email varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Nombre,Apellidos,Email,Convert(varchar(50),DECRYPTBYPASSPHRASE('contraseñajyr',Contraseña)) AS Contraseña,Rol,IdUsuario
	from Usuario
	where [Email] = @Email;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SeleccionarUsuarios]    Script Date: 29/07/2018 21:33:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[SP_SeleccionarUsuarios] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Nombre,Apellidos,Email,Convert(varchar(50),DECRYPTBYPASSPHRASE('contraseñajyr',Contraseña)) AS Contraseña,Rol,IdUsuario
	from Usuario
END
GO
