
SET IDENTITY_INSERT [TipoProveedor] ON;
INSERT INTO [TipoProveedor] (TipoProveedorID,Nombre)
VALUES
  (1,'Generico'),
  (2,'Generico 2'),
  (3,'Generico 3');
SET IDENTITY_INSERT [TipoProveedor] OFF;

SET IDENTITY_INSERT [TipoPersona] ON;
INSERT INTO [TipoPersona] (TipoPersonaID, Nombre)
VALUES
(1, 'Normal'),
(2, 'Juridica'),
(3, 'Generico');

SET IDENTITY_INSERT [TipoPersona] OFF;

SET IDENTITY_INSERT [Empresa] ON;
INSERT INTO [Empresa] (EmpresaID,Correo,Password)
VALUES
  (1,'malesuada.vel.convallis@protonmail.net','6ACBF962-2AF4-E373-9915-A68EAC3DB6D3'),
  (2,'nec.orci@aol.org','DE8002AE-C10F-328D-61C4-83B277448046'),
  (3,'quis@icloud.com','B13157CE-E9E3-1A31-02C9-B4AB68CBBA22'),
  (4,'eros.nec.tellus@google.edu','1B506408-B244-B755-E11A-DA559C9B01A9'),
  (5,'sodales.nisi@google.ca','868B71B1-DDCE-12F8-B992-5D2E481165F0'),
  (6,'vitae@outlook.com','6BAC987C-652B-A5EF-D335-8748A43B56AD'),
  (7,'vestibulum@yahoo.ca','8B142482-76BA-E63F-6D43-D24D8CD91DD0'),
  (8,'tempor.erat@outlook.ca','6270B1AC-3629-6B85-2383-E3C9EB01C373'),
  (9,'aliquam@google.edu','12DD4E99-4215-A853-B88B-E5741CED35A3'),
  (10,'imperdiet.ullamcorper@hotmail.edu','F86698D2-F942-5F02-45D6-5A38D71786E3');
SET IDENTITY_INSERT [Empresa] OFF;


SET IDENTITY_INSERT [Estado] ON;
INSERT INTO [Estado] (EstadoID,Nombre) 
VALUES
  (1, 'Amazonas'),
  (2, 'Anzoátegui'),
  (3, 'Apure'),
  (4, 'Aragua'),
  (5, 'Barinas'),
  (6, 'Bolívar'),
  (7, 'Carabobo'),
  (8, 'Cojedes'),
  (9, 'Delta Amacuro'),
  (10, 'Falcón'),
  (11, 'Guárico'),
  (12, 'Lara'),
  (13, 'Mérida'),
  (14, 'Miranda'),
  (15, 'Monagas'),
  (16, 'Nueva Esparta'),
  (17, 'Portuguesa'),
  (18, 'Sucre'),
  (19, 'Táchira'),
  (20, 'Trujillo'),
  (21, 'La Guaira'),
  (22, 'Yaracuy'),
  (23, 'Zulia'),
  (24, 'Distrito Capital');
SET IDENTITY_INSERT [Estado] OFF;

SET IDENTITY_INSERT [Provincia] ON;
INSERT INTO [Provincia] (ProvinciaID, EstadoID, Nombre) 
VALUES
  (1, 1, 'Alto Orinoco'),
  (2, 1, 'Atabapo'),
  (3, 1, 'Atures'),
  (4, 1, 'Autana'),
  (5, 1, 'Manapiare'),
  (6, 1, 'Maroa'),
  (7, 1, 'Río Negro'),
  (8, 2, 'Anaco'),
  (9, 2, 'Aragua'),
  (10, 2, 'Manuel Ezequiel Bruzual'),
  (11, 2, 'Diego Bautista Urbaneja'),
  (12, 2, 'Fernando Peñalver'),
  (13, 2, 'Francisco Del Carmen Carvajal'),
  (14, 2, 'General Sir Arthur McGregor'),
  (15, 2, 'Guanta'),
  (16, 2, 'Independencia'),
  (17, 2, 'José Gregorio Monagas'),
  (18, 2, 'Juan Antonio Sotillo'),
  (19, 2, 'Juan Manuel Cajigal'),
  (20, 2, 'Libertad'),
  (21, 2, 'Francisco de Miranda'),
  (22, 2, 'Pedro María Freites'),
  (23, 2, 'Píritu'),
  (24, 2, 'San José de Guanipa'),
  (25, 2, 'San Juan de Capistrano'),
  (26, 2, 'Santa Ana'),
  (27, 2, 'Simón Bolívar'),
  (28, 2, 'Simón Rodríguez'),
  (29, 3, 'Achaguas'),
  (30, 3, 'Biruaca'),
  (31, 3, 'Muñóz'),
  (32, 3, 'Páez'),
  (33, 3, 'Pedro Camejo'),
  (34, 3, 'Rómulo Gallegos'),
  (35, 3, 'San Fernando'),
  (36, 4, 'Atanasio Girardot'),
  (37, 4, 'Bolívar'),
  (38, 4, 'Camatagua'),
  (39, 4, 'Francisco Linares Alcántara'),
  (40, 4, 'José Ángel Lamas'),
  (41, 4, 'José Félix Ribas'),
  (42, 4, 'José Rafael Revenga'),
  (43, 4, 'Libertador'),
  (44, 4, 'Mario Briceño Iragorry'),
  (45, 4, 'Ocumare de la Costa de Oro'),
  (46, 4, 'San Casimiro'),
  (47, 4, 'San Sebastián'),
  (48, 4, 'Santiago Mariño'),
  (49, 4, 'Santos Michelena'),
  (50, 4, 'Sucre'),
  (51, 4, 'Tovar'),
  (52, 4, 'Urdaneta'),
  (53, 4, 'Zamora'),
  (54, 5, 'Alberto Arvelo Torrealba'),
  (55, 5, 'Andrés Eloy Blanco'),
  (56, 5, 'Antonio José de Sucre'),
  (57, 5, 'Arismendi'),
  (58, 5, 'Barinas'),
  (59, 5, 'Bolívar'),
  (60, 5, 'Cruz Paredes'),
  (61, 5, 'Ezequiel Zamora'),
  (62, 5, 'Obispos'),
  (63, 5, 'Pedraza'),
  (64, 5, 'Rojas'),
  (65, 5, 'Sosa'),
  (66, 6, 'Caroní'),
  (67, 6, 'Cedeño'),
  (68, 6, 'El Callao'),
  (69, 6, 'Gran Sabana'),
  (70, 6, 'Heres'),
  (71, 6, 'Piar'),
  (72, 6, 'Angostura (Raúl Leoni)'),
  (73, 6, 'Roscio'),
  (74, 6, 'Sifontes'),
  (75, 6, 'Sucre'),
  (76, 6, 'Padre Pedro Chien'),
  (77, 7, 'Bejuma'),
  (78, 7, 'Carlos Arvelo'),
  (79, 7, 'Diego Ibarra'),
  (80, 7, 'Guacara'),
  (81, 7, 'Juan José Mora'),
  (82, 7, 'Libertador'),
  (83, 7, 'Los Guayos'),
  (84, 7, 'Miranda'),
  (85, 7, 'Montalbán'),
  (86, 7, 'Naguanagua'),
  (87, 7, 'Puerto Cabello'),
  (88, 7, 'San Diego'),
  (89, 7, 'San Joaquín'),
  (90, 7, 'Valencia'),
  (91, 8, 'Anzoátegui'),
  (92, 8, 'Tinaquillo'),
  (93, 8, 'Girardot'),
  (94, 8, 'Lima Blanco'),
  (95, 8, 'Pao de San Juan Bautista'),
  (96, 8, 'Ricaurte'),
  (97, 8, 'Rómulo Gallegos'),
  (98, 8, 'San Carlos'),
  (99, 8, 'Tinaco'),
  (100, 9, 'Antonio Díaz'),
  (101, 9, 'Casacoima'),
  (102, 9, 'Pedernales'),
  (103, 9, 'Tucupita'),
  (104, 10, 'Acosta'),
  (105, 10, 'Bolívar'),
  (106, 10, 'Buchivacoa'),
  (107, 10, 'Cacique Manaure'),
  (108, 10, 'Carirubana'),
  (109, 10, 'Colina'),
  (110, 10, 'Dabajuro'),
  (111, 10, 'Democracia'),
  (112, 10, 'Falcón'),
  (113, 10, 'Federación'),
  (114, 10, 'Jacura'),
  (115, 10, 'José Laurencio Silva'),
  (116, 10, 'Los Taques'),
  (117, 10, 'Mauroa'),
  (118, 10, 'Miranda'),
  (119, 10, 'Monseñor Iturriza'),
  (120, 10, 'Palmasola'),
  (121, 10, 'Petit'),
  (122, 10, 'Píritu'),
  (123, 10, 'San Francisco'),
  (124, 10, 'Sucre'),
  (125, 10, 'Tocópero'),
  (126, 10, 'Unión'),
  (127, 10, 'Urumaco'),
  (128, 10, 'Zamora'),
  (129, 11, 'Camaguán'),
  (130, 11, 'Chaguaramas'),
  (131, 11, 'El Socorro'),
  (132, 11, 'José Félix Ribas'),
  (133, 11, 'José Tadeo Monagas'),
  (134, 11, 'Juan Germán Roscio'),
  (135, 11, 'Julián Mellado'),
  (136, 11, 'Las Mercedes'),
  (137, 11, 'Leonardo Infante'),
  (138, 11, 'Pedro Zaraza'),
  (139, 11, 'Ortíz'),
  (140, 11, 'San Gerónimo de Guayabal'),
  (141, 11, 'San José de Guaribe'),
  (142, 11, 'Santa María de Ipire'),
  (143, 11, 'Sebastián Francisco de Miranda'),
  (144, 12, 'Andrés Eloy Blanco'),
  (145, 12, 'Crespo'),
  (146, 12, 'Iribarren'),
  (147, 12, 'Jiménez'),
  (148, 12, 'Morán'),
  (149, 12, 'Palavecino'),
  (150, 12, 'Simón Planas'),
  (151, 12, 'Torres'),
  (152, 12, 'Urdaneta'),
  (179, 13, 'Alberto Adriani'),
  (180, 13, 'Andrés Bello'),
  (181, 13, 'Antonio Pinto Salinas'),
  (182, 13, 'Aricagua'),
  (183, 13, 'Arzobispo Chacón'),
  (184, 13, 'Campo Elías'),
  (185, 13, 'Caracciolo Parra Olmedo'),
  (186, 13, 'Cardenal Quintero'),
  (187, 13, 'Guaraque'),
  (188, 13, 'Julio César Salas'),
  (189, 13, 'Justo Briceño'),
  (190, 13, 'Libertador'),
  (191, 13, 'Miranda'),
  (192, 13, 'Obispo Ramos de Lora'),
  (193, 13, 'Padre Noguera'),
  (194, 13, 'Pueblo Llano'),
  (195, 13, 'Rangel'),
  (196, 13, 'Rivas Dávila'),
  (197, 13, 'Santos Marquina'),
  (198, 13, 'Sucre'),
  (199, 13, 'Tovar'),
  (200, 13, 'Tulio Febres Cordero'),
  (201, 13, 'Zea'),
  (223, 14, 'Acevedo'),
  (224, 14, 'Andrés Bello'),
  (225, 14, 'Baruta'),
  (226, 14, 'Brión'),
  (227, 14, 'Buroz'),
  (228, 14, 'Carrizal'),
  (229, 14, 'Chacao'),
  (230, 14, 'Cristóbal Rojas'),
  (231, 14, 'El Hatillo'),
  (232, 14, 'Guaicaipuro'),
  (233, 14, 'Independencia'),
  (234, 14, 'Lander'),
  (235, 14, 'Los Salias'),
  (236, 14, 'Páez'),
  (237, 14, 'Paz Castillo'),
  (238, 14, 'Pedro Gual'),
  (239, 14, 'Plaza'),
  (240, 14, 'Simón Bolívar'),
  (241, 14, 'Sucre'),
  (242, 14, 'Urdaneta'),
  (243, 14, 'Zamora'),
  (258, 15, 'Acosta'),
  (259, 15, 'Aguasay'),
  (260, 15, 'Bolívar'),
  (261, 15, 'Caripe'),
  (262, 15, 'Cedeño'),
  (263, 15, 'Ezequiel Zamora'),
  (264, 15, 'Libertador'),
  (265, 15, 'Maturín'),
  (266, 15, 'Piar'),
  (267, 15, 'Punceres'),
  (268, 15, 'Santa Bárbara'),
  (269, 15, 'Sotillo'),
  (270, 15, 'Uracoa'),
  (271, 16, 'Antolín del Campo'),
  (272, 16, 'Arismendi'),
  (273, 16, 'García'),
  (274, 16, 'Gómez'),
  (275, 16, 'Maneiro'),
  (276, 16, 'Marcano'),
  (277, 16, 'Mariño'),
  (278, 16, 'Península de Macanao'),
  (279, 16, 'Tubores'),
  (280, 16, 'Villalba'),
  (281, 16, 'Díaz'),
  (282, 17, 'Agua Blanca'),
  (283, 17, 'Araure'),
  (284, 17, 'Esteller'),
  (285, 17, 'Guanare'),
  (286, 17, 'Guanarito'),
  (287, 17, 'Monseñor José Vicente de Unda'),
  (288, 17, 'Ospino'),
  (289, 17, 'Páez'),
  (290, 17, 'Papelón'),
  (291, 17, 'San Genaro de Boconoíto'),
  (292, 17, 'San Rafael de Onoto'),
  (293, 17, 'Santa Rosalía'),
  (294, 17, 'Sucre'),
  (295, 17, 'Turén'),
  (296, 18, 'Andrés Eloy Blanco'),
  (297, 18, 'Andrés Mata'),
  (298, 18, 'Arismendi'),
  (299, 18, 'Benítez'),
  (300, 18, 'Bermúdez'),
  (301, 18, 'Bolívar'),
  (302, 18, 'Cajigal'),
  (303, 18, 'Cruz Salmerón Acosta'),
  (304, 18, 'Libertador'),
  (305, 18, 'Mariño'),
  (306, 18, 'Mejía'),
  (307, 18, 'Montes'),
  (308, 18, 'Ribero'),
  (309, 18, 'Sucre'),
  (310, 18, 'Valdéz'),
  (341, 19, 'Andrés Bello'),
  (342, 19, 'Antonio Rómulo Costa'),
  (343, 19, 'Ayacucho'),
  (344, 19, 'Bolívar'),
  (345, 19, 'Cárdenas'),
  (346, 19, 'Córdoba'),
  (347, 19, 'Fernández Feo'),
  (348, 19, 'Francisco de Miranda'),
  (349, 19, 'García de Hevia'),
  (350, 19, 'Guásimos'),
  (351, 19, 'Independencia'),
  (352, 19, 'Jáuregui'),
  (353, 19, 'José María Vargas'),
  (354, 19, 'Junín'),
  (355, 19, 'Libertad'),
  (356, 19, 'Libertador'),
  (357, 19, 'Lobatera'),
  (358, 19, 'Michelena'),
  (359, 19, 'Panamericano'),
  (360, 19, 'Pedro María Ureña'),
  (361, 19, 'Rafael Urdaneta'),
  (362, 19, 'Samuel Darío Maldonado'),
  (363, 19, 'San Cristóbal'),
  (364, 19, 'Seboruco'),
  (365, 19, 'Simón Rodríguez'),
  (366, 19, 'Sucre'),
  (367, 19, 'Torbes'),
  (368, 19, 'Uribante'),
  (369, 19, 'San Judas Tadeo'),
  (370, 20, 'Andrés Bello'),
  (371, 20, 'Boconó'),
  (372, 20, 'Bolívar'),
  (373, 20, 'Candelaria'),
  (374, 20, 'Carache'),
  (375, 20, 'Escuque'),
  (376, 20, 'José Felipe Márquez Cañizalez'),
  (377, 20, 'Juan Vicente Campos Elías'),
  (378, 20, 'La Ceiba'),
  (379, 20, 'Miranda'),
  (380, 20, 'Monte Carmelo'),
  (381, 20, 'Motatán'),
  (382, 20, 'Pampán'),
  (383, 20, 'Pampanito'),
  (384, 20, 'Rafael Rangel'),
  (385, 20, 'San Rafael de Carvajal'),
  (386, 20, 'Sucre'),
  (387, 20, 'Trujillo'),
  (388, 20, 'Urdaneta'),
  (389, 20, 'Valera'),
  (390, 21, 'Vargas'),
  (391, 22, 'Arístides Bastidas'),
  (392, 22, 'Bolívar'),
  (407, 22, 'Bruzual'),
  (408, 22, 'Cocorote'),
  (409, 22, 'Independencia'),
  (410, 22, 'José Antonio Páez'),
  (411, 22, 'La Trinidad'),
  (412, 22, 'Manuel Monge'),
  (413, 22, 'Nirgua'),
  (414, 22, 'Peña'),
  (415, 22, 'San Felipe'),
  (416, 22, 'Sucre'),
  (417, 22, 'Urachiche'),
  (418, 22, 'José Joaquín Veroes'),
  (441, 23, 'Almirante Padilla'),
  (442, 23, 'Baralt'),
  (443, 23, 'Cabimas'),
  (444, 23, 'Catatumbo'),
  (445, 23, 'Colón'),
  (446, 23, 'Francisco Javier Pulgar'),
  (447, 23, 'Páez'),
  (448, 23, 'Jesús Enrique Losada'),
  (449, 23, 'Jesús María Semprún'),
  (450, 23, 'La Cañada de Urdaneta'),
  (451, 23, 'Lagunillas'),
  (452, 23, 'Machiques de Perijá'),
  (453, 23, 'Mara'),
  (454, 23, 'Maracaibo'),
  (455, 23, 'Miranda'),
  (456, 23, 'Rosario de Perijá'),
  (457, 23, 'San Francisco'),
  (458, 23, 'Santa Rita'),
  (459, 23, 'Simón Bolívar'),
  (460, 23, 'Sucre'),
  (461, 23, 'Valmore Rodríguez'),
  (462, 24, 'Libertador');
SET IDENTITY_INSERT [Provincia] OFF;

SET IDENTITY_INSERT [Proveedor] ON;
INSERT INTO [Proveedor] (ProveedorID,EmpresaID,RazonSocial,Codigo,Contacto,TipoProveedorID,Direccion,Telefono,Correo,Plazo,RUC,ProvinciaID,EstadoID,TipoPersonaID,PaginaWeb)
VALUES
  (1,3,'Felis Donec Tempor Company',8882,'Vance, Gregory K.',1,'2099 Convallis Rd.','+58 181-7442763','ligula@protonmail.org','08-29-22','40.996.900',3,2,2,'https://pinterest.com/fr'),
  (2,6,'Lectus A Incorporated',2774,'Delgado, Aidan J.',3,'363-5304 Senectus Ave','+58 477-3134234','ante.bibendum@outlook.org','06-01-23','34.856.445',3,3,3,'http://pinterest.com/group/9'),
  (3,7,'Tempus Corp.',5227,'James, Susan K.',1,'P.O. Box 124, 633 Odio. St.','+58 894-2812814','et.euismod@google.com','10-28-22','37.479.455',2,1,3,'https://cnn.com/user/110'),
  (4,5,'Magna Lorem LLC',7688,'Dudley, Callum C.',2,'Ap #670-423 Nulla Street','+58 440-8485912','arcu.eu@outlook.org','04-17-22','39.757.927',2,2,2,'https://yahoo.com/fr'),
  (5,5,'Auctor LLC',9478,'Rios, Forrest G.',3,'Ap #709-4535 Maecenas Rd.','+58 848-4621232','adipiscing.fringilla@google.com','10-29-23','471.231',1,2,3,'https://ebay.com/group/9'),
  (6,8,'Duis Cursus Industries',3179,'Wheeler, Tatum J.',2,'883-5117 Massa. Av.','+58 652-2352884','nunc.commodo@google.com','03-18-22','43.815.532',1,1,2,'http://netflix.com/user/110'),
  (7,5,'In Cursus Et Industries',9764,'Collier, Yuri Q.',2,'266-6455 Vitae St.','+58 978-8374457','aliquet.sem@outlook.com','05-09-23','49.196.600',2,1,2,'http://instagram.com/fr'),
  (8,8,'Vivamus Corporation',3050,'Dillon, Cameron V.',2,'917-6900 Donec St.','+58 737-7553463','nulla.interdum.curabitur@hotmail.com','06-07-23','16.301.406',1,1,2,'http://netflix.com/sub'),
  (9,9,'Non Cursus Institute',6796,'Rush, Phelan U.',2,'817-9884 Et Av.','+58 083-9362717','magnis@hotmail.org','06-21-23','30.548.582',1,1,2,'https://yahoo.com/group/9'),
  (10,5,'Nullam Ut Associates',5984,'Kent, Sawyer K.',1,'Ap #192-4595 Aliquam Avenue','+58 582-4405520','aliquam.enim@hotmail.org','05-08-22','27.294.108',2,2,2,'https://youtube.com/en-us');
SET IDENTITY_INSERT [Proveedor] OFF;

SET IDENTITY_INSERT [CondicionPago] ON;
INSERT INTO CondicionPago (CondicionPagoID,Nombre)
VALUES
  (1,'Contado'),
  (2,'Credito'),
  (3,'Generico');
SET IDENTITY_INSERT [CondicionPago] OFF;



SET IDENTITY_INSERT [Bodega] ON;

INSERT INTO Bodega (BodegaID,Direccion,EstadoID,ProvinciaID,EmpresaID)
VALUES
  (1,'Almacen A',1,7,2),
  (2,'Almacen B',1,6,3),
  (3,'Bodega A',1,4,4),
  (4,'Bodega B',1,3,5),
  (5,'Proveduria',1,1,6);
SET IDENTITY_INSERT [Bodega] OFF;

SET IDENTITY_INSERT [OrdenCompra] ON;
INSERT INTO [OrdenCompra] (OrdenCompraID,ProveedorID,BodegaID,Referencia,CondicionPagoID,Observacion,Fecha,SubTotal,Descuento,Impuestos,Total)
VALUES
  (1,6,1,'Portia',2,'laoreet ipsum. Curabitur consequat, lectus','08-05-2022',631,18,982,3),
  (2,5,2,'William',3,'luctus et ultrices posuere cubilia','04-01-2023',756,13,958,2),
  (3,4,3,'Maisie',1,'sollicitudin adipiscing ligula. Aenean gravida','11-22-2023',718,3,977,5),
  (4,6,4,'Janna',1,'sodales. Mauris blandit enim consequat','02-07-2024',381,18,799,0),
  (5,2,5,'Brenda',1,'urna, nec luctus felis purus','04-16-2022',168,17,516,6),
  (6,6,1,'Miranda',2,'ligula consectetuer rhoncus. Nullam velit','02-05-2023',272,10,556,2),
  (7,4,3,'Miranda',2,'ligula consectetuer rhoncus. Nullam velit','02-05-2023',272,10,556,2),
  (8,3,2,'Miranda',2,'ligula consectetuer rhoncus. Nullam velit','02-05-2023',272,10,556,2),
  (9,9,1,'Miranda',2,'ligula consectetuer rhoncus. Nullam velit','02-05-2023',272,10,556,2),
  (10,7,4,'Miranda',2,'ligula consectetuer rhoncus. Nullam velit','02-05-2023',272,10,556,2);
SET IDENTITY_INSERT [OrdenCompra] OFF;


SET IDENTITY_INSERT [Motivo] ON;
INSERT INTO Motivo (MotivoID,Nombre)
VALUES
  (1,'Solicitud'),
  (2,'Suministro'),
  (3,'Reposicion'),
  (4,'Compra'),
  (5,'Emergencia'),
  (6,'Donacion');
SET IDENTITY_INSERT [Motivo] OFF;

SET IDENTITY_INSERT [Tipo] ON;
INSERT INTO Tipo (TipoID,Nombre)
VALUES
  (1,'Papeleria'),
  (2,'Alimento'),
  (3,'Insumo'),
  (4,'Medicamento'),
  (5,'Limpieza'),
  (6,'Pintura'),
  (7,'Consumible'),
  (8,'Insumos');
SET IDENTITY_INSERT [Tipo] OFF;

SET IDENTITY_INSERT [TipoIngreso] ON;
INSERT INTO TipoIngreso (TipoIngresoID,Nombre)
VALUES
  (1,'Nacional'),
  (2,'Internacional');
SET IDENTITY_INSERT [TipoIngreso] OFF;

  
SET IDENTITY_INSERT [Requisicion] ON;

INSERT INTO Requisicion (RequisicionID,CodigoRequisicion, Fecha, Comentario)
VALUES
  (1,1, CONVERT(DATETIME,'01/02/2023'),'lacus pede sagittis augue, eu'),
  (2,2, CONVERT(DATETIME,'01/02/2023'),'eu nibh vulputate'),
  (3,3, CONVERT(DATETIME,'01/02/2023'),'egestas lacinia. Sed congue, elit'),
  (4,4, CONVERT(DATETIME,'01/02/2023'),'quis diam.'),
  (5,5, CONVERT(DATETIME,'01/02/2023'),'nisi dictum augue malesuada malesuada. Integer id'),
  (6,6, CONVERT(DATETIME,'01/02/2023'),'Nunc ut erat. Sed nunc est, mollis non,'),
  (7,7, CONVERT(DATETIME,'01/02/2023'),'ac, fermentum'),
  (8,8, CONVERT(DATETIME,'01/02/2023'),'Cras'),
  (9,9, CONVERT(DATETIME,'01/02/2023'),'orci luctus et'),
  (10,10, CONVERT(DATETIME,'01/02/2023'),'arcu eu odio tristique pharetra. Quisque ac');
SET IDENTITY_INSERT [Requisicion] OFF;


SET IDENTITY_INSERT [Color] ON;

INSERT INTO [Color] (ColorID,Nombre)
VALUES
	(1, 'violeta'),
	(2,'amarillo'),
	(3,'azul'),
	(4,'naranja'),
	(5,'verde'),
	(6, 'rojo'),
	(7, 'marron'),
	(8,'negro'),
	(9,'blanco'),
	(10, 'rosado');
SET IDENTITY_INSERT [Color] OFF;

SET IDENTITY_INSERT [Departamento] ON;

INSERT INTO [Departamento] (DepartamentoID,Nombre)
VALUES
	(1, 'Pediatria'),
	(2,'Cirugia'),
	(3,'Maternidad'),
	(4,'Mantenimiento'),
	(5,'IT'),
	(6,'Administracion'),
	(7,'Contabilidad'),
	(8,'RRHH'),
	(9,'Servicios Generales'),
	(10,'Seguridad');
SET IDENTITY_INSERT [Departamento] OFF;


SET IDENTITY_INSERT [Salida] ON;

INSERT INTO [Salida] (SalidaID,Codigo,Fecha,Comentario,MotivoID,BodegaID)
VALUES
  (1,1, CONVERT(DATETIME,'01/02/2023'),'Lorem ipsum dolor sit amet, consectetuer adipiscing',1,1),
  (2,2, CONVERT(DATETIME,'01/02/2023'),'Lorem ipsum dolor sit amet, consectetuer',2,2),
  (3,3, CONVERT(DATETIME,'01/02/2023'),'Lorem ipsum dolor sit amet, consectetuer adipiscing',3,3),
  (4,4, CONVERT(DATETIME,'01/02/2023'),'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Curabitur',4,4),
  (5,5, CONVERT(DATETIME,'01/02/2023'),'Lorem',5,5),
  (6,6, CONVERT(DATETIME,'01/02/2023'),'Lorem ipsum dolor sit amet,',6,1),
  (7,7, CONVERT(DATETIME,'01/02/2023'),'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Curabitur sed',1,2),
  (8,8, CONVERT(DATETIME,'01/02/2023'),'Lorem ipsum dolor sit amet, consectetuer',2,3),
  (9,9, CONVERT(DATETIME,'01/02/2023'),'Lorem ipsum dolor sit amet, consectetuer',3,4),
  (10,10, CONVERT(DATETIME,'01/02/2023'),'Lorem ipsum dolor sit',4,5);

SET IDENTITY_INSERT [Salida] OFF;



SET IDENTITY_INSERT [Usuario] ON;

INSERT INTO [Usuario] (UsuarioID,Correo,Password,EmpresaID)
VALUES
  (1,'sed.eu.nibh@protonmail.couk','945F6302-FF93-3017-589C-06688B7C1B03',9),
  (2,'leo.in@hotmail.net','45FCABAD-AB23-9BD2-637D-7A8DAC9A4B85',7),
  (3,'odio@aol.org','8C2321D3-176A-862A-3078-440DC328D935',4),
  (4,'euismod.mauris.eu@protonmail.org','552AB036-A45D-FF45-140E-381DA16D4460',6),
  (5,'sed.pede@hotmail.couk','3A77D407-B97D-CDF7-FB37-63E4428A0C6C',1),
  (6,'elit.pretium@google.net','3AEC858E-2E7A-70A4-A777-F2D838F5A95A',7),
  (7,'ipsum.donec@google.ca','E3222B7E-4115-AAFC-6506-6966AD2E2BA1',6),
  (8,'enim.suspendisse@google.net','3CDED3A9-642D-237D-5E1D-A7C1F7FAB1F1',6),
  (9,'nec@hotmail.ca','43BEEE3A-B8BB-C14E-5CCD-9386153F1E5B',8),
  (10,'fames@outlook.couk','5EAEC579-51CA-FA9C-B1F5-597565C2C78B',3);
SET IDENTITY_INSERT [Usuario] OFF;

SET IDENTITY_INSERT [Linea] ON;


INSERT INTO [Linea] (LineaID,Nombre)
VALUES
	(1,'Generico'),
	(2,'Generico 2'),
	(3,'Generico 3'),
	(4,'Generico 4');
SET IDENTITY_INSERT [Linea] OFF;

SET IDENTITY_INSERT [Grupo] ON;
INSERT INTO [Grupo] (GrupoID,Nombre)
VALUES
	(1,'Generico'),
	(2,'Generico 2'),
	(3,'Generico 3'),
	(4,'Generico 4');
SET IDENTITY_INSERT [Grupo] OFF;


SET IDENTITY_INSERT [Ingreso] ON;

INSERT INTO [Ingreso] (IngresoID,OrdenCompraID,CodigoIngreso,ProveedorID,MotivoID,BodegaID,TipoIngresoID,Fecha,Descuento,Impuestos,Total)
VALUES
  (1,1,3930,7,5,2,2,CONVERT(DATETIME,'04-04-23'),17,16,2734),
  (2,2,8294,7,2,3,2,CONVERT(DATETIME,'01-17-23'),6,13,8490),
  (3,3,2605,10,5,2,2,CONVERT(DATETIME,'02-04-23'),16,10,7241),
  (4,4,7978,5,6,4,1,CONVERT(DATETIME,'01-05-24'),10,12,8000),
  (5,5,2280,2,1,4,1,CONVERT(DATETIME,'06-30-22'),1,17,7287),
  (6,6,2867,6,4,4,2,CONVERT(DATETIME,'03-27-22'),10,8,6935),
  (7,7,3149,3,1,2,1,CONVERT(DATETIME,'04-24-22'),8,3,3203),
  (8,8,4215,5,3,1,1,CONVERT(DATETIME,'07-07-22'),5,12,5458),
  (9,9,1458,2,5,3,2,CONVERT(DATETIME,'05-06-23'),14,9,7347),
  (10,10,6199,6,5,3,1,CONVERT(DATETIME,'07-31-22'),1,8,2448);
SET IDENTITY_INSERT [Ingreso] OFF;

SET IDENTITY_INSERT [Marca] ON;

INSERT INTO [Marca] (MarcaID,Nombre)
VALUES
	(1,'Abbott'),
	(2,'Medtronic'),
	(3,'Terumo'),
	(4,'Paper Mate'),
	(5,'Faber Castell'),
	(6,'HP'),
	(7,'Norma'),
	(8,'Samsung'),
	(9,'Polar'),
	(10,'Primor');
SET IDENTITY_INSERT [Marca] OFF;

SET IDENTITY_INSERT [LineaSalida] ON;
INSERT INTO [LineaSalida] (LineaSalidaID,Cantidad,CostoSalida,SalidaID,ProductoID)
VALUES
  (1,98,3223,1,1),
  (2,54,7732,2,2),
  (3,0,5455,3,3),
  (4,67,2287,4,4),
  (5,63,5508,5,5),
  (6,85,2704,6,6),
  (7,32,7124,7,7),
  (8,2,5880,8,8),
  (9,89,3768,9,9),
  (10,12,562,10,10);
SET IDENTITY_INSERT [LineaSalida] OFF;

SET IDENTITY_INSERT [Medida] ON;

INSERT INTO [Medida] (MedidaID,Dimension)
VALUES
  (1,'Metro'),
  (2,'Centimetro'),
  (3,'Milimetro'),
  (4,'Kilo'),
  (5,'Gramo'),
  (6,'Miligramo'),
  (7,'Litro'),
  (8,'Mililitro');

SET IDENTITY_INSERT [Medida] OFF;

SET IDENTITY_INSERT [Producto] ON;
INSERT INTO [Producto] (ProductoID,Nombre,Codigo,LineaID,TipoID,Unidad,Caja,GrupoID,Activo,Iva,Perecible,Comentario,FechaCaducidad,Precio, MarcaID, MedidaID)
VALUES
  (1,'Vendas',2197,3,6,55,38,3,'0','1','0','libero lacus, varius et, euismod','09-22-23',190, 1, 2),
  (2,'Gasas',9486,3,3,56,12,3,'0','0','0','tempor diam dictum sapien.','09-02-23',343, 2, 3),
  (3,'Alcohol',6820,4,5,40,38,4,'1','0','0','vitae dolor. Donec fringilla. Donec feugiat metus sit amet','02-10-23',805, 3, 4),
  (4,'Inyectadora',7817,1,3,18,20,2,'0','1','1','mauris. Suspendisse aliquet molestie tellus. Aenean egestas hendrerit','12-29-22',754, 4, 5),
  (5,'Guantes',6503,3,2,65,43,3,'1','0','0','dolor dapibus gravida. Aliquam tincidunt,','04-23-22',933, 5, 6),
  (6,'Par Muletas',1779,1,3,23,76,2,'1','0','1','Nulla eget metus eu erat','04-13-23',182, 6, 7),
  (7,'Acetaminofen',8340,3,3,24,3,2,'1','0','0','non, dapibus rutrum, justo. Praesent luctus. Curabitur','12-17-23',555, 7, 8),
  (8,'Yeso',8108,3,6,3,84,2,'1','0','0','a purus.','07-12-22',98, 8, 1),
  (9,'Ibuprofeno',3776,4,2,29,22,4,'1','1','0','lorem ipsum sodales purus, in molestie tortor nibh sit amet','01-03-23',901, 9, 2),
  (10,'Pack Paletas',4004,2,5,77,42,2,'0','1','1','id, erat. Etiam vestibulum massa rutrum magna. Cras','05-15-22',410, 10, 3);
SET IDENTITY_INSERT [Producto] OFF;

SET IDENTITY_INSERT [ColorProducto] ON;
INSERT INTO [ColorProducto] (ColorProductoID, ColorID, ProductoID)
VALUES
  (1,1,1),
  (2,2,2),
  (3,3,3),
  (4,4,4),
  (5,5,5),
  (6,6,6),
  (7,7,7),
  (8,8,8),
  (9,9,9),
  (10,10,10);
SET IDENTITY_INSERT [ColorProducto] OFF;

SET IDENTITY_INSERT [Existencia] ON;

INSERT INTO [Existencia] (ExistenciaID,ProductoID,BodegaID,Stock)
VALUES
  (1,3,3,3),
  (2,6,2,6),
  (3,1,1,7),
  (4,7,3,2),
  (5,1,3,3),
  (6,4,4,4),
  (7,5,2,5),
  (8,9,1,1),
  (9,2,2,4),
  (10,3,4,8);
SET IDENTITY_INSERT [Existencia] OFF;

SET IDENTITY_INSERT [LineaCompra] ON;

INSERT INTO [LineaCompra] (LineaCompraID,OrdenCompraID,ProductoID,DepartamentoID,Cantidad,Caja,Precio,Descuento,Total)
VALUES
  (1,5,2,9,83,3,247,71,942),
  (2,6,8,3,50,10,65,65,716),
  (3,4,7,5,15,71,719,38,452),
  (4,3,5,4,46,14,330,41,732),
  (5,2,4,10,98,28,754,45,55),
  (6,6,2,10,29,46,805,21,43),
  (7,2,3,3,21,79,767,40,113),
  (8,1,7,9,81,87,715,78,50),
  (9,2,2,2,49,44,257,43,447),
  (10,5,7,8,79,82,16,83,556);
SET IDENTITY_INSERT [LineaCompra] OFF;

SET IDENTITY_INSERT [IngresoDetalle] ON;
INSERT INTO [IngresoDetalle] (IngresoDetalleID,ProductoID,IngresoID,PrecioBruto,Fecha,Caja,Cantidad)
VALUES
  (1,5,9,83,CONVERT(DATE,'06/02/2023'),247,71),
  (2,5,3,50,CONVERT(DATE,'06/02/2023'),65,65),
  (3,3,5,15,CONVERT(DATE,'06/02/2023'),719,38),
  (4,5,4,46,CONVERT(DATE,'06/02/2023'),330,41),
  (5,6,10,98,CONVERT(DATE,'06/02/2023'),754,45),
  (6,2,10,29,CONVERT(DATE,'06/02/2023'),805,21),
  (7,3,3,21,CONVERT(DATE,'06/02/2023'),767,40),
  (8,9,9,81,CONVERT(DATE,'06/02/2023'),715,78),
  (9,2,2,49,CONVERT(DATE,'06/02/2023'),257,43),
  (10,5,8,79,CONVERT(DATE,'06/02/2023'),16,83);
SET IDENTITY_INSERT [IngresoDetalle] OFF;

