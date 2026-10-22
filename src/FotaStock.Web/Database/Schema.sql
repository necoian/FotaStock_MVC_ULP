-- MySQL dump 10.13  Distrib 8.0.46, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: db_fotastock
-- ------------------------------------------------------
-- Server version	8.0.46

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `archivoimagen`
--

DROP TABLE IF EXISTS `archivoimagen`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `archivoimagen` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ImagenId` int NOT NULL,
  `TipoArchivo` varchar(20) NOT NULL,
  `RutaAlmacenamiento` varchar(500) NOT NULL,
  `TieneMarcaAgua` tinyint(1) NOT NULL,
  `Moneda` char(3) NOT NULL,
  `HashIntegridad` varchar(128) NOT NULL,
  `FechaCarga` datetime NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_ArchivoImagen_ImagenId` (`ImagenId`),
  CONSTRAINT `FK_ArchivoImagen_Imagen` FOREIGN KEY (`ImagenId`) REFERENCES `imagen` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `categoria`
--

DROP TABLE IF EXISTS `categoria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categoria` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(100) NOT NULL,
  `Descripcion` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Nombre` (`Nombre`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `compra`
--

DROP TABLE IF EXISTS `compra`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `compra` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UsuarioId` int NOT NULL,
  `Fecha` datetime DEFAULT NULL,
  `Estado` varchar(30) NOT NULL,
  `Total` decimal(10,2) NOT NULL,
  `Moneda` char(3) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Compra_UsuarioId` (`UsuarioId`),
  CONSTRAINT `FK_Compra_Usuario` FOREIGN KEY (`UsuarioId`) REFERENCES `usuario` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `detallecompra`
--

DROP TABLE IF EXISTS `detallecompra`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `detallecompra` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `CompraId` int NOT NULL,
  `OfertaLicenciaId` int NOT NULL,
  `PrecioUnitario` decimal(10,2) NOT NULL,
  `CondicionesSnapshot` text NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_DetalleCompra_CompraId` (`CompraId`),
  KEY `IX_DetalleCompra_OfertaLicencia3Id` (`OfertaLicenciaId`),
  CONSTRAINT `FK_DetalleCompra_Compra` FOREIGN KEY (`CompraId`) REFERENCES `compra` (`Id`),
  CONSTRAINT `FK_DetalleCompra_OfertaLicencia` FOREIGN KEY (`OfertaLicenciaId`) REFERENCES `ofertalicencia` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `imagen`
--

DROP TABLE IF EXISTS `imagen`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `imagen` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UsuarioId` int NOT NULL,
  `CategoriaId` int NOT NULL,
  `Titulo` varchar(150) NOT NULL,
  `Descripcion` varchar(1000) DEFAULT NULL,
  `Ubicacion` varchar(150) DEFAULT NULL,
  `Estado` varchar(30) NOT NULL,
  `FechaPublicacion` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Imagen_UsuarioId` (`UsuarioId`),
  KEY `IX_Imagen_CategoriaId` (`CategoriaId`),
  CONSTRAINT `FK_Imagen_Categoria` FOREIGN KEY (`CategoriaId`) REFERENCES `categoria` (`Id`),
  CONSTRAINT `FK_Imagen_Usuario` FOREIGN KEY (`UsuarioId`) REFERENCES `usuario` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `licencia`
--

DROP TABLE IF EXISTS `licencia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `licencia` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `DetalleCompraId` int NOT NULL,
  `Codigo` varchar(100) NOT NULL,
  `FechaEmision` datetime NOT NULL,
  `Estado` varchar(30) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `DetalleCompraId` (`DetalleCompraId`),
  UNIQUE KEY `Codigo` (`Codigo`),
  KEY `IX_DetalleCompra_CompraId` (`DetalleCompraId`),
  CONSTRAINT `FK_Licencia_DetalleCompra` FOREIGN KEY (`DetalleCompraId`) REFERENCES `detallecompra` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ofertalicencia`
--

DROP TABLE IF EXISTS `ofertalicencia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ofertalicencia` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ImagenId` int NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  `Condiciones` text NOT NULL,
  `Precio` decimal(10,2) NOT NULL,
  `Moneda` char(3) NOT NULL,
  `Estado` varchar(30) NOT NULL,
  `FechaVigenciaDesde` datetime NOT NULL,
  `FechaVigenciaHasta` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_OfertaLicencia_ImagenId` (`ImagenId`),
  CONSTRAINT `FK_OfertaLicencia_Imagen` FOREIGN KEY (`ImagenId`) REFERENCES `imagen` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `pago`
--

DROP TABLE IF EXISTS `pago`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pago` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `CompraId` int NOT NULL,
  `Monto` decimal(10,2) NOT NULL,
  `FechaIntento` datetime NOT NULL,
  `FechaRespuesta` datetime DEFAULT NULL,
  `Estado` varchar(30) NOT NULL,
  `Metodo` varchar(30) NOT NULL,
  `Referencia` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Referencia` (`Referencia`),
  KEY `IX_Pago_CompraId` (`CompraId`),
  CONSTRAINT `FK_Pago_Compra` FOREIGN KEY (`CompraId`) REFERENCES `compra` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuario` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(100) NOT NULL,
  `Email` varchar(150) NOT NULL,
  `PasswordHash` varchar(255) NOT NULL,
  `Rol` varchar(30) NOT NULL,
  `AvatarRuta` varchar(30) DEFAULT NULL,
  `FechaAlta` datetime NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Email` (`Email`) /*!80000 INVISIBLE */
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-10-22  1:20:31
