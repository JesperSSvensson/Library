-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Värd: 127.0.0.1
-- Tid vid skapande: 10 jan 2023 kl 19:53
-- Serverversion: 10.4.25-MariaDB
-- PHP-version: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Databas: `librarydb`
--

-- --------------------------------------------------------

--
-- Tabellstruktur `admin`
--

CREATE TABLE `admin` (
  `ID` int(11) NOT NULL,
  `admin_user_name` varchar(32) NOT NULL,
  `password` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumpning av Data i tabell `admin`
--

INSERT INTO `admin` (`ID`, `admin_user_name`, `password`) VALUES
(1, 'ChristerAdmin', 12345);

-- --------------------------------------------------------

--
-- Tabellstruktur `author`
--

CREATE TABLE `author` (
  `ID` int(11) NOT NULL,
  `first_name` varchar(32) NOT NULL,
  `last_name` varchar(32) NOT NULL,
  `date_of_birth` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumpning av Data i tabell `author`
--

INSERT INTO `author` (`ID`, `first_name`, `last_name`, `date_of_birth`) VALUES
(12, 'J.R.R', 'Tolkien', '1949-01-17'),
(13, 'Karin', 'Boye', '1945-01-15'),
(14, 'Jan', 'Guillou', '1949-01-17'),
(15, 'Fredrik', 'Backman', '1985-01-15'),
(16, 'JK', 'Rowling', '1971-04-12'),
(17, 'George R.R', 'Martin', '1947-09-12');

-- --------------------------------------------------------

--
-- Tabellstruktur `book`
--

CREATE TABLE `book` (
  `ID` int(11) NOT NULL,
  `title` varchar(128) NOT NULL,
  `published` varchar(32) NOT NULL,
  `price` int(32) NOT NULL,
  `category` varchar(32) NOT NULL,
  `stock` int(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumpning av Data i tabell `book`
--

INSERT INTO `book` (`ID`, `title`, `published`, `price`, `category`, `stock`) VALUES
(19, 'En man som heter Ove', '2015', 99, 'Drama', 0),
(20, 'Sagan om ringen', '1945', 109, 'Fantasy', 2),
(21, 'Sagan om dom två tornen', '1965', 79, 'Fantasy', 5),
(22, 'Blå Stjärnan', '2009', 39, 'Drama', 4),
(23, 'Bilbo en hobbits äventyr', '1937', 79, 'Fantasy', 5),
(24, 'The Silmarillion', '1977', 109, 'fantasy', 2),
(25, 'Beowulf', '2014', 39, 'Fantasy', 8),
(26, 'Harry Potter och de vises sten', '1997', 79, 'Fantasy', 6),
(27, 'Harry Potter och hemligheternas ', '2000', 89, 'Fantasy', 4),
(28, 'Harry Potter och Fången från Azk', '2002', 109, 'Fantasy', 8),
(29, 'Harry Potter och Den flammande b', '2004', 99, 'Fantasy', 5),
(30, 'Harry Potter och Fenixorden', '2006', 89, 'Fantasy', 2),
(31, 'Harry Potter och Halvblodsprinse', '2008', 99, 'Fantasy', 4),
(32, 'Harry Potter och Dödsrelikerna', '2009', 59, 'Fantasy', 4),
(33, 'Harry Potter och Det fördömda ba', '2011', 149, 'Fantasy', 7),
(34, 'Kampen om järntronen', '1996', 199, 'Fantasy', 2),
(35, 'Kungarnas krig', '2001', 149, 'Fantasy', 5),
(36, 'Svärdets makt', '2009', 49, 'Fantasy', 1),
(37, 'Björnstad', '2016', 59, 'Drama', 2),
(38, 'Folk med ångest ', '2019', 39, 'Drama', 1),
(39, 'Vi mot er', '2017', 99, 'Action', 0);

-- --------------------------------------------------------

--
-- Tabellstruktur `book_to_author`
--

CREATE TABLE `book_to_author` (
  `book_id` int(11) NOT NULL,
  `author_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumpning av Data i tabell `book_to_author`
--

INSERT INTO `book_to_author` (`book_id`, `author_id`) VALUES
(22, 14),
(19, 15),
(20, 12),
(21, 12),
(29, 12),
(33, 12),
(24, 12),
(25, 12),
(22, 15),
(38, 15),
(39, 15),
(23, 12),
(26, 16),
(27, 16),
(28, 16),
(30, 16),
(31, 16),
(32, 16),
(34, 17),
(35, 17),
(36, 17),
(37, 15);

-- --------------------------------------------------------

--
-- Tabellstruktur `borrowed_book`
--

CREATE TABLE `borrowed_book` (
  `ID` int(11) NOT NULL,
  `date_of_loan` datetime NOT NULL,
  `book_id` int(11) NOT NULL,
  `customer_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumpning av Data i tabell `borrowed_book`
--

INSERT INTO `borrowed_book` (`ID`, `date_of_loan`, `book_id`, `customer_id`) VALUES
(32, '2023-01-02 21:59:30', 39, 6),
(33, '2023-01-02 22:39:49', 36, 7),
(35, '2023-01-02 22:57:10', 39, 5),
(36, '2023-01-02 22:57:16', 37, 5),
(37, '2023-01-02 23:49:34', 37, 5),
(38, '2023-01-02 23:57:58', 29, 5),
(39, '2023-01-03 14:51:34', 38, 5),
(40, '2023-01-03 14:52:27', 36, 5),
(42, '2023-01-03 15:43:38', 25, 5);

-- --------------------------------------------------------

--
-- Tabellstruktur `customer`
--

CREATE TABLE `customer` (
  `ID` int(11) NOT NULL,
  `name` varchar(32) NOT NULL,
  `date_of_birth` date NOT NULL,
  `user_name` varchar(32) NOT NULL,
  `password` int(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumpning av Data i tabell `customer`
--

INSERT INTO `customer` (`ID`, `name`, `date_of_birth`, `user_name`, `password`) VALUES
(5, 'Jesper Svensson', '1990-09-08', 'jesperjesper', 12345),
(6, 'Jonas Svensson', '1985-01-15', 'jondiah', 12345),
(7, 'Lisa Magnusson', '1907-05-19', 'LisaM', 12345),
(8, 'Lucia Wiren', '1990-09-08', 'LuciaW', 12345),
(9, 'Åsa Svensson', '1965-09-18', 'ÅsaBlåsa', 12345);

--
-- Index för dumpade tabeller
--

--
-- Index för tabell `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`ID`);

--
-- Index för tabell `author`
--
ALTER TABLE `author`
  ADD PRIMARY KEY (`ID`);

--
-- Index för tabell `book`
--
ALTER TABLE `book`
  ADD PRIMARY KEY (`ID`);

--
-- Index för tabell `book_to_author`
--
ALTER TABLE `book_to_author`
  ADD KEY `author_id` (`author_id`),
  ADD KEY `book_id` (`book_id`);

--
-- Index för tabell `borrowed_book`
--
ALTER TABLE `borrowed_book`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `book_id` (`book_id`),
  ADD KEY `customer_id` (`customer_id`);

--
-- Index för tabell `customer`
--
ALTER TABLE `customer`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT för dumpade tabeller
--

--
-- AUTO_INCREMENT för tabell `admin`
--
ALTER TABLE `admin`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT för tabell `author`
--
ALTER TABLE `author`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT för tabell `book`
--
ALTER TABLE `book`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=40;

--
-- AUTO_INCREMENT för tabell `borrowed_book`
--
ALTER TABLE `borrowed_book`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=44;

--
-- AUTO_INCREMENT för tabell `customer`
--
ALTER TABLE `customer`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- Restriktioner för dumpade tabeller
--

--
-- Restriktioner för tabell `book_to_author`
--
ALTER TABLE `book_to_author`
  ADD CONSTRAINT `book_to_author_ibfk_1` FOREIGN KEY (`book_id`) REFERENCES `book` (`ID`),
  ADD CONSTRAINT `book_to_author_ibfk_2` FOREIGN KEY (`author_id`) REFERENCES `author` (`ID`);

--
-- Restriktioner för tabell `borrowed_book`
--
ALTER TABLE `borrowed_book`
  ADD CONSTRAINT `borrowed_book_ibfk_2` FOREIGN KEY (`customer_id`) REFERENCES `customer` (`ID`),
  ADD CONSTRAINT `borrowed_book_ibfk_3` FOREIGN KEY (`book_id`) REFERENCES `book` (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
