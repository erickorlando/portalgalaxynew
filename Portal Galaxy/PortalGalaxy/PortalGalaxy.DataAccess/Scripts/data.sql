SET IDENTITY_INSERT [dbo].[Alumno] ON 
GO
INSERT [dbo].[Alumno] ([Id], [NroDocumento], [NombreCompleto], [Correo], [Telefono], [Departamento], [Provincia], [Distrito], [FechaInscripcion], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaActualizacion], [UsuarioActualizacion]) VALUES (1, N'60046848', N'Erick Orlando', N'erickorlando@outlook.com', N'5409849', N'01', N'01', N'01', CAST(N'2024-07-31' AS Date), 1, CAST(N'2024-07-31T20:23:13.7593740' AS DateTime2), N'erick', NULL, NULL)
GO
INSERT [dbo].[Alumno] ([Id], [NroDocumento], [NombreCompleto], [Correo], [Telefono], [Departamento], [Provincia], [Distrito], [FechaInscripcion], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaActualizacion], [UsuarioActualizacion]) VALUES (2, N'012364856', N'Adam Mateo', N'orlando.erick@gmail.com', N'95742193', N'01', N'01', N'04', CAST(N'2024-08-05' AS Date), 1, CAST(N'2024-08-05T20:21:19.5386028' AS DateTime2), N'erick', NULL, NULL)
GO
INSERT [dbo].[Alumno] ([Id], [NroDocumento], [NombreCompleto], [Correo], [Telefono], [Departamento], [Provincia], [Distrito], [FechaInscripcion], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaActualizacion], [UsuarioActualizacion]) VALUES (3, N'80855041', N'Jose Pérez', N'orlandoerick@gmail.com', N'92180845', N'02', N'03', N'01', CAST(N'2024-08-21' AS Date), 1, CAST(N'2024-08-21T19:33:56.6251204' AS DateTime2), N'erick', NULL, NULL)
GO
INSERT [dbo].[Alumno] ([Id], [NroDocumento], [NombreCompleto], [Correo], [Telefono], [Departamento], [Provincia], [Distrito], [FechaInscripcion], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaActualizacion], [UsuarioActualizacion]) VALUES (4, N'46607898', N'Erick Velasco', N'evelasco@galaxy.edu.pe', N'5742193', N'01', N'01', N'01', CAST(N'2024-08-22' AS Date), 1, CAST(N'2024-08-22T14:57:15.7803284' AS DateTime2), N'erick', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Alumno] OFF
GO
SET IDENTITY_INSERT [dbo].[Instructor] ON 
GO
INSERT [dbo].[Instructor] ([Id], [Nombres], [NroDocumento], [CategoriaId], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaActualizacion], [UsuarioActualizacion]) VALUES (1, N'Pepe Macias', N'0848048', 1, 1, CAST(N'2024-08-05T00:00:00.0000000' AS DateTime2), N'admin', NULL, NULL)
GO
INSERT [dbo].[Instructor] ([Id], [Nombres], [NroDocumento], [CategoriaId], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaActualizacion], [UsuarioActualizacion]) VALUES (2, N'Juan Mattos', N'6594708', 1, 1, CAST(N'2024-08-05T00:00:00.0000000' AS DateTime2), N'admin', NULL, NULL)
GO
INSERT [dbo].[Instructor] ([Id], [Nombres], [NroDocumento], [CategoriaId], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaActualizacion], [UsuarioActualizacion]) VALUES (3, N'Bryan Aguilar', N'12324335443', 2, 1, CAST(N'2024-08-12T22:02:22.0628693' AS DateTime2), N'erick', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Instructor] OFF
GO
SET IDENTITY_INSERT [dbo].[Taller] ON 
GO
INSERT [dbo].[Taller] ([Id], [Nombre], [CategoriaId], [InstructorId], [FechaInicio], [HoraInicio], [Situacion], [PortadaUrl], [TemarioUrl], [Descripcion], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaActualizacion], [UsuarioActualizacion]) VALUES (1, N'Taller de ASP.NET', 1, 1, CAST(N'2024-09-01' AS Date), CAST(N'20:00:00' AS Time), 0, N'https://galaxytraining.blob.core.windows.net/portalgalaxy/CourseNET6.png', NULL, N'Curso para aprender a programar con .NET', 1, CAST(N'2024-05-05T00:00:00.0000000' AS DateTime2), N'admin', NULL, NULL)
GO
INSERT [dbo].[Taller] ([Id], [Nombre], [CategoriaId], [InstructorId], [FechaInicio], [HoraInicio], [Situacion], [PortadaUrl], [TemarioUrl], [Descripcion], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaActualizacion], [UsuarioActualizacion]) VALUES (2, N'Taller de Angular', 2, 2, CAST(N'2024-10-01' AS Date), CAST(N'19:00:00' AS Time), 0, N'https://galaxytraining.blob.core.windows.net/portalgalaxy/fullstack-angular16.jpg', NULL, N'Curso para aprender creacion de webs con Angular', 1, CAST(N'2024-05-06T00:00:00.0000000' AS DateTime2), N'admin', NULL, NULL)
GO
INSERT [dbo].[Taller] ([Id], [Nombre], [CategoriaId], [InstructorId], [FechaInicio], [HoraInicio], [Situacion], [PortadaUrl], [TemarioUrl], [Descripcion], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaActualizacion], [UsuarioActualizacion]) VALUES (3, N'Taller de Blazor', 1, 1, CAST(N'2024-09-15' AS Date), CAST(N'19:30:00' AS Time), 1, N'https://galaxytraining.blob.core.windows.net/portalgalaxy/csharpfrontend.jpg', NULL, N'Aprender blazor como un campeón', 1, CAST(N'2024-08-05T00:00:00.0000000' AS DateTime2), N'admin', NULL, NULL)
GO
INSERT [dbo].[Taller] ([Id], [Nombre], [CategoriaId], [InstructorId], [FechaInicio], [HoraInicio], [Situacion], [PortadaUrl], [TemarioUrl], [Descripcion], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaActualizacion], [UsuarioActualizacion]) VALUES (5, N'Cálculo de costos Cloud Azure vs on-premises', 4, 2, CAST(N'2024-10-01' AS Date), CAST(N'19:00:00' AS Time), 0, N'https://galaxytraining.blob.core.windows.net/portalgalaxy/cloudazure-vs-onpremises.jpg', NULL, N'CE70190F-FF86-48AC-AA13-B2E3096B638B', 1, CAST(N'2024-08-05T22:00:53.1200000' AS DateTime2), N'admin', NULL, NULL)
GO
INSERT [dbo].[Taller] ([Id], [Nombre], [CategoriaId], [InstructorId], [FechaInicio], [HoraInicio], [Situacion], [PortadaUrl], [TemarioUrl], [Descripcion], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaActualizacion], [UsuarioActualizacion]) VALUES (7, N'Paginación por Backend', 2, 3, CAST(N'2024-10-17' AS Date), CAST(N'17:00:00' AS Time), 0, N'https://galaxytraining.blob.core.windows.net/portalgalaxy/paginacionbackend.jpg', NULL, N'TALLER DE PAGINACION POR BACKEND EN TU LENGUAJE FAVORITO', 1, CAST(N'2024-08-12T22:03:09.4774997' AS DateTime2), N'erick', NULL, NULL)
GO
INSERT [dbo].[Taller] ([Id], [Nombre], [CategoriaId], [InstructorId], [FechaInicio], [HoraInicio], [Situacion], [PortadaUrl], [TemarioUrl], [Descripcion], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaActualizacion], [UsuarioActualizacion]) VALUES (9, N'Spring Security', 2, 2, CAST(N'2024-10-26' AS Date), CAST(N'20:20:11.0580000' AS Time), 0, N'https://galaxytraining.blob.core.windows.net/portalgalaxy/spring-security.jpg', N'https://galaxytraining.blob.core.windows.net/portalgalaxy/NET8WebDeveloper_AplicacionesWeb_Sesion01.pptx', N'Curso de arquitectura de Spring Security', 1, CAST(N'2024-09-02T20:21:15.5281211' AS DateTime2), N'PortalGalaxyPool', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Taller] OFF
GO
SET IDENTITY_INSERT [dbo].[Inscripcion] ON 
GO
INSERT [dbo].[Inscripcion] ([Id], [AlumnoId], [TallerId], [Situacion], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaActualizacion], [UsuarioActualizacion]) VALUES (1, 1, 1, 0, 1, CAST(N'2024-08-12T23:35:06.6747736' AS DateTime2), N'erick', NULL, NULL)
GO
INSERT [dbo].[Inscripcion] ([Id], [AlumnoId], [TallerId], [Situacion], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaActualizacion], [UsuarioActualizacion]) VALUES (2, 2, 1, 0, 1, CAST(N'2024-08-12T23:35:06.6767155' AS DateTime2), N'erick', NULL, NULL)
GO
INSERT [dbo].[Inscripcion] ([Id], [AlumnoId], [TallerId], [Situacion], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaActualizacion], [UsuarioActualizacion]) VALUES (3, 3, 1, 1, 1, CAST(N'2024-08-21T19:34:58.5840796' AS DateTime2), N'erick', NULL, NULL)
GO
INSERT [dbo].[Inscripcion] ([Id], [AlumnoId], [TallerId], [Situacion], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaActualizacion], [UsuarioActualizacion]) VALUES (4, 3, 2, 1, 1, CAST(N'2024-08-21T22:10:30.9774823' AS DateTime2), N'erick', NULL, NULL)
GO
INSERT [dbo].[Inscripcion] ([Id], [AlumnoId], [TallerId], [Situacion], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaActualizacion], [UsuarioActualizacion]) VALUES (5, 3, 7, 1, 1, CAST(N'2024-08-21T22:10:39.3357327' AS DateTime2), N'erick', NULL, NULL)
GO
INSERT [dbo].[Inscripcion] ([Id], [AlumnoId], [TallerId], [Situacion], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaActualizacion], [UsuarioActualizacion]) VALUES (7, 1, 2, 0, 1, CAST(N'2024-08-22T10:51:59.1314964' AS DateTime2), N'erick', NULL, NULL)
GO
INSERT [dbo].[Inscripcion] ([Id], [AlumnoId], [TallerId], [Situacion], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaActualizacion], [UsuarioActualizacion]) VALUES (8, 2, 2, 0, 1, CAST(N'2024-08-22T10:51:59.1349072' AS DateTime2), N'erick', NULL, NULL)
GO
INSERT [dbo].[Inscripcion] ([Id], [AlumnoId], [TallerId], [Situacion], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaActualizacion], [UsuarioActualizacion]) VALUES (9, 3, 2, 1, 1, CAST(N'2024-08-22T10:51:59.1359700' AS DateTime2), N'erick', NULL, NULL)
GO
INSERT [dbo].[Inscripcion] ([Id], [AlumnoId], [TallerId], [Situacion], [Estado], [FechaCreacion], [UsuarioCreacion], [FechaActualizacion], [UsuarioActualizacion]) VALUES (11, 3, 5, 0, 1, CAST(N'2024-08-26T20:40:06.5999249' AS DateTime2), N'erick', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Inscripcion] OFF
GO
