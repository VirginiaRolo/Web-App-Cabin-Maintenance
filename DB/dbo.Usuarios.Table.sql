USE [HotelCabaniasObligatorioP3]
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([IdUsuario], [Discriminator], [Email], [Contrasenia]) VALUES (1, N'Funcionario', N'lola@email.com', N'Lola1234')
INSERT [dbo].[Usuarios] ([IdUsuario], [Discriminator], [Email], [Contrasenia]) VALUES (2, N'Funcionario', N'lolo@email.com', N'Lolo1234')
INSERT [dbo].[Usuarios] ([IdUsuario], [Discriminator], [Email], [Contrasenia]) VALUES (3, N'Funcionario', N'lucas@email.com', N'Lucas1234')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
