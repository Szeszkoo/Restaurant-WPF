-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1:3306
-- Létrehozás ideje: 2019. Sze 03. 10:28
-- Kiszolgáló verziója: 5.7.23
-- PHP verzió: 7.2.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `szakdoga_db`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `food_list`
--

DROP TABLE IF EXISTS `food_list`;
CREATE TABLE IF NOT EXISTS `food_list` (
  `Food_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) COLLATE utf8_hungarian_ci NOT NULL,
  `Price` int(11) NOT NULL,
  `Category` varchar(45) COLLATE utf8_hungarian_ci NOT NULL,
  `In_Stock` int(11) NOT NULL,
  PRIMARY KEY (`Food_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `food_list`
--

INSERT INTO `food_list` (`Food_ID`, `Name`, `Price`, `Category`, `In_Stock`) VALUES
(1, 'Fruit soup', 400, 'Soup', 55),
(2, 'Meat soup', 600, 'Soup', 14),
(3, 'Bean soup', 550, 'Soup', 10),
(4, 'Rice', 150, 'SideDish', 33),
(5, 'Fries', 200, 'SideDish', 43),
(6, 'Steak', 2000, 'MainDish', 22),
(7, 'Meat Stew', 1300, 'MainDish', 10),
(8, 'Gyros', 900, 'MainDish', 10),
(9, 'Coca-Cola', 350, 'Drink', 30),
(10, 'Fanta', 350, 'Drink', 25),
(11, 'Eggsoup', 400, 'Soup', 10),
(12, 'Hamburger', 700, 'MainDish', 35);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `orders`
--

DROP TABLE IF EXISTS `orders`;
CREATE TABLE IF NOT EXISTS `orders` (
  `Order_no` int(11) NOT NULL AUTO_INCREMENT,
  `Table_no` int(11) NOT NULL,
  `State` varchar(45) COLLATE utf8_hungarian_ci NOT NULL,
  `Waiter` int(11) NOT NULL,
  `Time` datetime NOT NULL,
  `Cancel_Reason` varchar(250) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `Customer` varchar(45) COLLATE utf8_hungarian_ci DEFAULT NULL,
  PRIMARY KEY (`Order_no`),
  KEY `FK_Worker_ID` (`Waiter`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `orders`
--

INSERT INTO `orders` (`Order_no`, `Table_no`, `State`, `Waiter`, `Time`, `Cancel_Reason`, `Customer`) VALUES
(15, 2, 'Completed', 0, '2018-10-21 19:05:00', '', 'Uti László'),
(16, 3, 'Completed', 0, '2018-10-21 19:05:00', '', 'Turi István'),
(17, 3, 'Completed', 1, '2018-11-30 20:05:00', NULL, 'Wadu Hekk'),
(18, 3, 'Completed', 1, '2018-12-01 21:05:00', '', 'Balázs Róbert'),
(19, 10, 'Canceled', 2, '2018-12-05 05:30:00', 'Elégedetlenség.', 'Kuti Lajos'),
(20, 12, 'Completed', 1, '2018-12-05 05:30:00', NULL, 'Task Pál'),
(21, 4, 'Completed', 0, '2018-12-05 05:30:00', NULL, 'Hudak Petra'),
(22, 5, 'Completed', 1, '2018-12-01 21:05:00', NULL, 'Ferenc Józsefné'),
(23, 1, 'Completed', 2, '2018-11-30 20:05:00', NULL, 'Busa Réka'),
(24, 3, 'Completed', 2, '2019-02-27 20:20:16', NULL, 'Kuka József'),
(25, 3, 'Canceled', 0, '2019-03-13 13:25:08', 'Meggondolta magát.', 'Raktáros Lajos'),
(26, 4, 'Canceled', 2, '2019-03-13 13:28:24', 'Eltűnt.', 'Pados Géza'),
(27, 4, 'Completed', 0, '2019-03-19 13:42:17', NULL, 'Kokó Judit'),
(28, 9, 'Completed', 0, '2019-04-08 13:13:39', NULL, 'Juti Béla'),
(29, 12, 'In Progress', 1, '2019-04-13 20:10:24', NULL, NULL);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `order_details`
--

DROP TABLE IF EXISTS `order_details`;
CREATE TABLE IF NOT EXISTS `order_details` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Order_no` int(11) NOT NULL,
  `Food` int(11) NOT NULL,
  `Count` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `FK_Order_no` (`Order_no`),
  KEY `FK_Food` (`Food`)
) ENGINE=InnoDB AUTO_INCREMENT=247 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `order_details`
--

INSERT INTO `order_details` (`ID`, `Order_no`, `Food`, `Count`) VALUES
(5, 18, 5, 2),
(6, 18, 4, 4),
(30, 20, 2, 2),
(32, 20, 3, 5),
(33, 19, 3, 1),
(34, 19, 2, 2),
(35, 19, 5, 3),
(113, 24, 4, 5),
(122, 21, 4, 3),
(123, 21, 6, 7),
(126, 23, 2, 4),
(127, 23, 3, 2),
(128, 23, 7, 5),
(147, 17, 3, 2),
(203, 15, 9, 10),
(204, 16, 4, 1),
(205, 16, 5, 3),
(206, 16, 6, 3),
(209, 26, 3, 2),
(210, 26, 2, 2),
(217, 25, 6, 1),
(218, 25, 3, 3),
(226, 22, 3, 1),
(230, 27, 9, 5),
(233, 28, 3, 1),
(244, 29, 6, 10),
(245, 29, 5, 12),
(246, 29, 3, 3);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `workers`
--

DROP TABLE IF EXISTS `workers`;
CREATE TABLE IF NOT EXISTS `workers` (
  `Worker_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Username` varchar(45) COLLATE utf8_hungarian_ci NOT NULL,
  `Password` varchar(45) COLLATE utf8_hungarian_ci NOT NULL,
  `Registration_Date` datetime DEFAULT NULL,
  `Salary` int(11) NOT NULL,
  `Title` varchar(45) COLLATE utf8_hungarian_ci NOT NULL,
  `Realname` varchar(45) COLLATE utf8_hungarian_ci NOT NULL,
  PRIMARY KEY (`Worker_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `workers`
--

INSERT INTO `workers` (`Worker_ID`, `Username`, `Password`, `Registration_Date`, `Salary`, `Title`, `Realname`) VALUES
(0, 'eri11', 'eri11', '2019-03-11 18:29:43', 120000, 'Waiter', 'Zoltán Erika'),
(1, 'gabi11', 'bai11', '2019-03-11 18:30:10', 500000, 'Manager', 'Oláh Gábor*'),
(2, 'pisti11', 'pisti11', '2019-03-11 18:29:16', 150000, 'Waiter', 'Kiss István'),
(3, 'asd', 'asd', '2019-06-13 00:05:54', 0, 'asd', 'asd');

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `FK_Worker_ID` FOREIGN KEY (`Waiter`) REFERENCES `workers` (`Worker_ID`);

--
-- Megkötések a táblához `order_details`
--
ALTER TABLE `order_details`
  ADD CONSTRAINT `FK_Food` FOREIGN KEY (`Food`) REFERENCES `food_list` (`Food_ID`),
  ADD CONSTRAINT `FK_Order_no` FOREIGN KEY (`Order_no`) REFERENCES `orders` (`Order_no`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
