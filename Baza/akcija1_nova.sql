-- MySQL dump 10.13  Distrib 5.6.43, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: akcija1
-- ------------------------------------------------------
-- Server version	5.6.43-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `akcija`
--

DROP TABLE IF EXISTS `akcija`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `akcija` (
  `id_poduzece` int(11) NOT NULL,
  `id_akcija` int(11) NOT NULL AUTO_INCREMENT,
  `id_oglas` int(11) NOT NULL,
  `naziv_akcija` varchar(60) NOT NULL,
  `datum_pocetka` date NOT NULL,
  `datum_zavrsetka` date NOT NULL,
  `opis` varchar(100) NOT NULL,
  PRIMARY KEY (`id_akcija`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `akcija`
--

LOCK TABLES `akcija` WRITE;
/*!40000 ALTER TABLE `akcija` DISABLE KEYS */;
INSERT INTO `akcija` VALUES (0,2,0,'Svježe voce','2019-03-01','2019-03-02','Svježe voce sniženo 30%. '),(6,8,0,'Svježe voce','2019-02-13','2019-02-11','Sniženo svježe voce.'),(0,9,0,'Svježe voce','2019-02-13','2019-02-11','Sniženo svježe voce.'),(6,10,0,'NOvo','2019-02-13','2019-02-11','sniženjeeee'),(0,11,0,'Ajd','2019-03-02','2019-03-03','sniženjeeee'),(28,12,0,'AJMOO','2019-02-13','2019-02-11','sniženjeeee'),(0,13,0,'Veliko sniženje','2019-03-01','2019-03-02','sniženjeeee');
/*!40000 ALTER TABLE `akcija` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `artikl`
--

DROP TABLE IF EXISTS `artikl`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `artikl` (
  `id_artikl` int(11) NOT NULL AUTO_INCREMENT,
  `naziv_artikl` varchar(45) COLLATE cp1250_croatian_ci NOT NULL,
  `cijena_artikl` double NOT NULL,
  PRIMARY KEY (`id_artikl`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=cp1250 COLLATE=cp1250_croatian_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `artikl`
--

LOCK TABLES `artikl` WRITE;
/*!40000 ALTER TABLE `artikl` DISABLE KEYS */;
INSERT INTO `artikl` VALUES (1,'Lopta',100),(2,'Novi',100),(3,'novii',100);
/*!40000 ALTER TABLE `artikl` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `kategorija`
--

DROP TABLE IF EXISTS `kategorija`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `kategorija` (
  `id_kategorija` int(11) NOT NULL AUTO_INCREMENT,
  `naziv_kategorije` varchar(50) NOT NULL,
  PRIMARY KEY (`id_kategorija`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kategorija`
--

LOCK TABLES `kategorija` WRITE;
/*!40000 ALTER TABLE `kategorija` DISABLE KEYS */;
INSERT INTO `kategorija` VALUES (1,'Sport'),(2,'Prehrana'),(3,'Tehnicka roba'),(4,'Odjeca'),(6,'sport'),(7,'Sport1'),(12,'Školski pribor');
/*!40000 ALTER TABLE `kategorija` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `korisnik`
--

DROP TABLE IF EXISTS `korisnik`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `korisnik` (
  `id_poduzece` int(11) NOT NULL,
  `id_korisnik` int(11) NOT NULL AUTO_INCREMENT,
  `ime` varchar(60) NOT NULL,
  `prezime` varchar(60) NOT NULL,
  `email` varchar(45) NOT NULL,
  `lozinka` varchar(20) NOT NULL,
  PRIMARY KEY (`id_korisnik`),
  UNIQUE KEY `id_korisnik_UNIQUE` (`id_korisnik`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `korisnik`
--

LOCK TABLES `korisnik` WRITE;
/*!40000 ALTER TABLE `korisnik` DISABLE KEYS */;
INSERT INTO `korisnik` VALUES (0,1,'Silvio ','Putak','silvio.putak@gmail.com','12345');
/*!40000 ALTER TABLE `korisnik` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `oglas`
--

DROP TABLE IF EXISTS `oglas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `oglas` (
  `id_oglas` int(11) NOT NULL AUTO_INCREMENT,
  `id_akcija` int(11) NOT NULL,
  `osnovna_cijena` double(10,2) DEFAULT NULL,
  `mjerna_jedinica` varchar(15) DEFAULT NULL,
  `postotak_popusta` double(10,2) DEFAULT NULL,
  `akcijska_cijena` double(10,2) DEFAULT NULL,
  `kratki_opis` varchar(100) DEFAULT NULL,
  `dugi_opis` varchar(300) DEFAULT NULL,
  `slika_proizvoda` varchar(255) DEFAULT NULL,
  `id_poduzece` int(11) DEFAULT NULL,
  `id_kategorija` int(11) DEFAULT NULL,
  `id_artikl` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_oglas`),
  KEY `id_kategorija` (`id_kategorija`),
  KEY `id_artikl` (`id_artikl`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `oglas`
--

LOCK TABLES `oglas` WRITE;
/*!40000 ALTER TABLE `oglas` DISABLE KEYS */;
INSERT INTO `oglas` VALUES (21,2,100.00,'komad',50.00,50.00,' yyxy','sa','lopta.png',0,1,1),(22,2,100.00,'komad',50.00,50.00,'sdsad','sadad','neimenovano.png',0,1,1);
/*!40000 ALTER TABLE `oglas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `poduzece`
--

DROP TABLE IF EXISTS `poduzece`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `poduzece` (
  `id_poduzece` int(14) NOT NULL,
  `naziv_poduzece` varchar(100) DEFAULT NULL,
  `adresa` varchar(100) DEFAULT NULL,
  `grad` varchar(50) DEFAULT NULL,
  `telefon` varchar(12) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `web_adresa` varchar(100) CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  PRIMARY KEY (`id_poduzece`),
  UNIQUE KEY `id_poduzece_UNIQUE` (`id_poduzece`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `poduzece`
--

LOCK TABLES `poduzece` WRITE;
/*!40000 ALTER TABLE `poduzece` DISABLE KEYS */;
INSERT INTO `poduzece` VALUES (0,'Marker','jelkovecka 9','varazdin','0919449354','matej@gmail.com','www.marker.com'),(1,'PopUp','jelkovecka 4','varazdin','0919449354','marker.vt@gmail.com','www.marker.com'),(2,'Marker','Jalkovečka 3','varazdin','555522222','marker.vt@gmail.com','www.marker.com'),(3,'Oprugarna Dvorski','Petkovec 37a','Vz.Toplice','42671023','oprugarna.dvorski@gmail.com','www.opruge.com'),(4,'Megaldo','Petkovec 68a','Varaždinske Toplice','42671097','magaldo.opruge@gmail.com','www.megaldo.com'),(5,'Marker','jelkovecka','varazdin','454522222','marker.vt@gmail.com','www.marker.com'),(6,'Butik','Varazdinska 3','Varazdin','111111111','butik.vz@gmail.com','www.butik.com'),(8,'Marker','Zagrebacka 2','varazdin','22222','marker.vt@gmail.com','www.marker.com'),(9,'Megaldo','Petkovec 68','Varaždinske Toplice','42671097','magaldo.oprugeee@gmail.com','www.megaldo.com'),(10,'Novo','jelkovecka','varazdin','22222','marker.vt@gmail.com','www.marker.com');
/*!40000 ALTER TABLE `poduzece` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-06-02 17:23:38
