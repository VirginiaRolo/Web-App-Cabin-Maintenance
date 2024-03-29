USE [HotelCabaniasObligatorioP3]
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
