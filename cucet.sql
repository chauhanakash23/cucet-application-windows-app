-- MySQL dump 10.11
--
-- Host: localhost    Database: cucet
-- ------------------------------------------------------
-- Server version	5.0.67-community-nt

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
-- Table structure for table `appno`
--

DROP TABLE IF EXISTS `appno`;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
CREATE TABLE `appno` (
  `no` int(20) NOT NULL,
  PRIMARY KEY  (`no`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
SET character_set_client = @saved_cs_client;

--
-- Dumping data for table `appno`
--

LOCK TABLES `appno` WRITE;
/*!40000 ALTER TABLE `appno` DISABLE KEYS */;
INSERT INTO `appno` VALUES (1),(2),(3),(4),(5),(6),(7),(8),(9),(10),(11),(12),(13);
/*!40000 ALTER TABLE `appno` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `candidate`
--

DROP TABLE IF EXISTS `candidate`;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
CREATE TABLE `candidate` (
  `appno` int(20) NOT NULL default '0',
  `fn` varchar(45) default NULL,
  `ln` varchar(45) default NULL,
  `dob` varchar(45) default NULL,
  `phone` varchar(45) default NULL,
  `category` varchar(45) default NULL,
  `gender` varchar(45) default NULL,
  `nat` varchar(45) default NULL,
  `mail` varchar(45) default NULL,
  `relegion` varchar(45) default NULL,
  `address` varchar(45) default NULL,
  `program` varchar(45) default NULL,
  `photo` longblob,
  `sign` longblob,
  PRIMARY KEY  (`appno`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
SET character_set_client = @saved_cs_client;

--
-- Dumping data for table `candidate`
--

LOCK TABLES `candidate` WRITE;
/*!40000 ALTER TABLE `candidate` DISABLE KEYS */;
/*!40000 ALTER TABLE `candidate` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `courses`
--

DROP TABLE IF EXISTS `courses`;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
CREATE TABLE `courses` (
  `program` varchar(200) NOT NULL,
  `course` varchar(200) default NULL,
  PRIMARY KEY  (`program`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
SET character_set_client = @saved_cs_client;

--
-- Dumping data for table `courses`
--

LOCK TABLES `courses` WRITE;
/*!40000 ALTER TABLE `courses` DISABLE KEYS */;
INSERT INTO `courses` VALUES ('Integrated Masters','Artificial Intelligence'),('Masters','Artificial Intelligence');
/*!40000 ALTER TABLE `courses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `departments`
--

DROP TABLE IF EXISTS `departments`;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
CREATE TABLE `departments` (
  `school` varchar(200) NOT NULL,
  `department` varchar(200) default NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
SET character_set_client = @saved_cs_client;

--
-- Dumping data for table `departments`
--

LOCK TABLES `departments` WRITE;
/*!40000 ALTER TABLE `departments` DISABLE KEYS */;
INSERT INTO `departments` VALUES ('School of Mathematics Statistics and Computational Sciences','Computer Science'),('School of Mathematics Statistics and Computational Sciences','Statistics'),('School of Mathematics Statistics and Computational Sciences','Mathematics'),('School of Physical Sciences','Physics'),('School of Architecture','Architecture'),('School of chemical sciences and pharmacy','Chemistry'),('School of chemical sciences and pharmacy','Pharmacy'),('School of commerce and management ','Management'),('School of commerce and management ','Commerce'),('School of Engineering and technology','Computer Science and engineering'),('School of Earth Sciences','Environmental Science'),('School of Earth Sciences','Atmospheric Science'),('School of Life Sciences','Biotechnology'),('School of Life Sciences','Biochemistry'),('School of Life Sciences','Microbiology'),('School of Humanities and Languages','English'),('School of Humanities and Languages','Hindi'),('School of Social Sciences','Economics'),('School of Social Sciences','Culture and Media Studies'),('School of Social Sciences','Public Policy Law and Governance'),('School of Social Sciences','Social Work'),('School of Education','Education');
/*!40000 ALTER TABLE `departments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `programs`
--

DROP TABLE IF EXISTS `programs`;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
CREATE TABLE `programs` (
  `program` varchar(200) NOT NULL,
  `department` varchar(200) default NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
SET character_set_client = @saved_cs_client;

--
-- Dumping data for table `programs`
--

LOCK TABLES `programs` WRITE;
/*!40000 ALTER TABLE `programs` DISABLE KEYS */;
INSERT INTO `programs` VALUES ('Integrated Masters','Computer Science'),('Masters','Computer Science'),('Masters','Statistics'),('Integrated Masters','Mathematics'),('Masters','Mathematics'),('Masters','Physics'),('Integrated Masters','Physics'),('Masters','Chemistry'),('Integrated Masters','Chemistry'),('Masters','English'),('Masters','Hindi'),('Masters','Culture and Media Studies'),('Masters','Economics'),('Integrated Masters','Economics');
/*!40000 ALTER TABLE `programs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reg_courses`
--

DROP TABLE IF EXISTS `reg_courses`;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
CREATE TABLE `reg_courses` (
  `reg_id` int(11) NOT NULL auto_increment,
  `name` varchar(200) default NULL,
  `course` varchar(200) default NULL,
  `semester` varchar(200) default NULL,
  `department` varchar(200) default NULL,
  `program` varchar(200) default NULL,
  PRIMARY KEY  (`reg_id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;
SET character_set_client = @saved_cs_client;

--
-- Dumping data for table `reg_courses`
--

LOCK TABLES `reg_courses` WRITE;
/*!40000 ALTER TABLE `reg_courses` DISABLE KEYS */;
INSERT INTO `reg_courses` VALUES (1,'GreatName GreatSurname','Artificial Intelligence','','Computer Science','Masters'),(2,'GreatName GreatSurname','Artificial Intelligence','','Computer Science','Masters'),(3,'GreatName GreatSurname','Artificial Intelligence','','Computer Science','Masters'),(4,'GreatName GreatSurname','Artificial Intelligence','','Computer Science','Masters'),(5,'GreatName GreatSurname','Artificial Intelligence','1','Computer Science','Masters'),(6,'GreatName GreatSurname','Artificial Intelligence','5','Computer Science','Masters'),(7,'GreatName GreatSurname','Artificial Intelligence','4','Computer Science','Masters');
/*!40000 ALTER TABLE `reg_courses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `schools`
--

DROP TABLE IF EXISTS `schools`;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
CREATE TABLE `schools` (
  `school` varchar(200) NOT NULL,
  PRIMARY KEY  (`school`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
SET character_set_client = @saved_cs_client;

--
-- Dumping data for table `schools`
--

LOCK TABLES `schools` WRITE;
/*!40000 ALTER TABLE `schools` DISABLE KEYS */;
INSERT INTO `schools` VALUES ('School of Architecture'),('School of chemical science and pharmacy'),('School of commerce and management'),('School of Earth sciences'),('School of Education'),('School of Engineering and technology'),('School of Humanities and Languages'),('School of Life sciences'),('School of Mathematics Statistics and Computational Sciences'),('School of Physical Sciences'),('School of Social Sciences');
/*!40000 ALTER TABLE `schools` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-04-22  7:11:29
