-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 26 Mar 2023, 22:04
-- Wersja serwera: 10.4.22-MariaDB
-- Wersja PHP: 8.1.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `biblio_app`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `authors`
--

CREATE TABLE `authors` (
  `id_author` int(11) NOT NULL,
  `name` varchar(20) CHARACTER SET utf8 COLLATE utf8_polish_ci NOT NULL,
  `last_name` varchar(20) CHARACTER SET utf8 COLLATE utf8_polish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `authors`
--

INSERT INTO `authors` (`id_author`, `name`, `last_name`) VALUES
(1, 'Robert C.', 'Martin'),
(2, 'Andrzej', 'Sapkowski'),
(3, 'Stephen', 'King'),
(4, 'Remigiusz', 'Mróz'),
(5, 'J.K.', 'Rowling'),
(6, 'J.R.R.', 'Tolkien'),
(7, 'Nicholas', 'Sparks'),
(8, 'Dan', 'Brown'),
(9, 'Arthur Conan', 'Doyle'),
(10, 'Tomasz', 'Strzelczyk'),
(11, 'Dan', 'Jones'),
(12, 'Lee', 'Child'),
(13, 'Mike', 'Tyson'),
(14, 'Jhumpa', 'Lahiri');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `books`
--

CREATE TABLE `books` (
  `id_book` int(11) NOT NULL,
  `title` varchar(50) NOT NULL,
  `image` varchar(50) NOT NULL,
  `publication_date` varchar(10) NOT NULL,
  `isbn` varchar(13) NOT NULL,
  `publication_house` varchar(50) NOT NULL,
  `author_id` int(11) NOT NULL,
  `genre_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `books`
--

INSERT INTO `books` (`id_book`, `title`, `image`, `publication_date`, `isbn`, `publication_house`, `author_id`, `genre_id`) VALUES
(1, 'Czysty kod. Podręcznik dobrego programisty', '\\images\\czystykod.jpg', '01.08.2008', '9780132350884', 'Helion', 1, 5),
(2, 'Wiedźmin - Miecz przeznaczenia', '\\images\\mieczprzeznaczenia.png', '25.09.2014', '9788496173729', 'SuperNowa', 2, 2),
(3, 'Kabalista', '\\images\\kabalista.jpg', '08.02.2023', '9788382805222', 'Filia', 4, 4),
(4, 'Fairy Tale', '\\images\\fairytale.jpg', '10.12.2009', '9788401027710', 'Hodder And Stoughton', 3, 3),
(5, 'Behawiorysta', '\\images\\behawiorysta.jpg', '10.10.2016', '9788379348615', 'Filia', 4, 4),
(6, 'Harry Potter - Kamień filozoficzny', '\\images\\harrykamien.jpg', '26.06.1997', '9780439362139', 'Znak', 5, 2),
(7, 'Harry Potter - Komnata tajemnic', '\\images\\harrykomnata.jpg', '13.09.2000', '9780439064873', 'Znak', 5, 2),
(8, 'Harry Potter - Więzień Azkabanu', '\\images\\harrywiezien.jpg', '31.01.2001', '9788380082151', 'Znak', 5, 2),
(9, 'Harry Potter - Czara ognia', '\\images\\harryczara.jpg', '29.09.2001', '9788380082380', 'Znak', 5, 2),
(10, 'Harry Potter - Zakon feniksa', '\\images\\harryzakon.jpg', '31.01.2004', '9788382651836', 'Znak', 5, 2),
(11, 'Harry Potter - Książe półkrwi', '\\images\\harryksiaze.jpg', '28.01.2006', '9788380082427', 'Znak', 5, 2),
(12, 'Harry Potter - Insygnia śmierci', '\\images\\harryinsygnia.jpg', '21.07.2007', '9788380082458', 'Znak', 5, 2),
(13, 'Władca Pierścieni - Bractwo pierścienia', '\\images\\wladcatom1.jpg', '01.01.1954', '9788381168151', 'Zysk i S-ka', 6, 2),
(14, 'Władca Pierścieni - Dwie wieże', '\\images\\wladcatom2.jpg', '30.10.2017', '9788382022254', 'Zysk i S-ka', 6, 2),
(15, 'Władca Pierścieni - Powrót króla', '\\images\\wladcatom3.jpg', '15.11.2017', '9788382024906', 'Zysk i S-ka', 6, 2),
(16, 'Pamiętnik', '\\images\\pamietnik.jpg', '01.10.1996', '9788371572081', 'Da Capo', 7, 11),
(17, 'Jesienna miłość', '\\images\\jesiennam.jpg', '01.10.1999', '9788381255929', 'Albatros', 7, 11),
(18, 'Dla ciebie wszystko', '\\images\\dlaciebie.jpg', '14.09.2010', '9788378855200', 'Albatros', 7, 11),
(19, 'Kod Leonarda da Vinci', '\\images\\leo.jpg', '18.03.2003', '9788366512474', 'Sonia Draga', 8, 7),
(20, 'Anioły i demony', '\\images\\aniolki.jpg', '18.05.2000', '9788366512429', 'Sonia Draga', 8, 4),
(21, 'Inferno', '\\images\\inferno.jpg', '14.05.2013', '9788379991518', 'Sonia Draga', 8, 4),
(22, 'Przygody Sherlocka Holmesa', '\\images\\holmesa.jpg', '14.10.1892', '9788374371391', 'Algo', 9, 7),
(23, 'Pies Baskerville’ów', '\\images\\pies.jpg', '25.03.1902', '9788375441369', 'Algo', 9, 8),
(24, 'Oddasz fartucha', '\\images\\fartuch.jpg', '24.11.2021', '9788324079933', 'Znak horyzont', 10, 14),
(25, 'The Plantagenets', '\\images\\theking.jpg', '10.05.2012', '9780007213948', 'Gardners', 11, 13),
(26, 'Essex Dogs', '\\images\\dogs.jpg', '15.09.2022', '9780593653784', 'Head Of Zeus', 11, 9),
(27, 'The Templars', '\\images\\templars.jpg', '07.09.2017', '9780143108962', 'Head Of Zeus', 11, 9),
(28, 'Powers and Thrones', '\\images\\powers.jpg', '02.09.2021', '9781789543544', 'Head Of Zeus', 11, 9),
(29, 'Poziom śmierci', '\\images\\poziom.jpg', '17.03.1997', '9788382158168', 'Albatros', 12, 6),
(30, 'Wróg bez twarzy', '\\images\\twarz.jpg', '15.04.1999', '9788367338523', 'Albatros', 12, 6),
(31, 'Mike Tyson. Moja prawda', '\\images\\mike.jpg', '19.11.2014', '9788379242818', 'SQN', 13, 13),
(32, 'Imiennik', '\\images\\imie.jpg', '19.09.2003', '‎8374695870', 'Prószyński i S-ka', 14, 8),
(33, 'Tłumacz chorób', '\\images\\tlumacz.jpg', '13.12.1999', '‎8324001921', 'Albatros', 14, 8);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `genres`
--

CREATE TABLE `genres` (
  `id_genres` int(11) NOT NULL,
  `name_genre` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `genres`
--

INSERT INTO `genres` (`id_genres`, `name_genre`) VALUES
(1, 'None'),
(2, 'Fantasy'),
(3, 'Thriller'),
(4, 'Crime'),
(5, 'Education'),
(6, 'Action'),
(7, 'Detective'),
(8, 'Novel'),
(9, 'Historical'),
(10, 'Horror'),
(11, 'Romance'),
(12, 'Short Stories'),
(13, 'Biographie'),
(14, 'Cooking');

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `authors`
--
ALTER TABLE `authors`
  ADD PRIMARY KEY (`id_author`);

--
-- Indeksy dla tabeli `books`
--
ALTER TABLE `books`
  ADD PRIMARY KEY (`id_book`),
  ADD KEY `author_id` (`author_id`),
  ADD KEY `genre_id` (`genre_id`);

--
-- Indeksy dla tabeli `genres`
--
ALTER TABLE `genres`
  ADD PRIMARY KEY (`id_genres`);

--
-- AUTO_INCREMENT dla zrzuconych tabel
--

--
-- AUTO_INCREMENT dla tabeli `authors`
--
ALTER TABLE `authors`
  MODIFY `id_author` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT dla tabeli `books`
--
ALTER TABLE `books`
  MODIFY `id_book` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=35;

--
-- AUTO_INCREMENT dla tabeli `genres`
--
ALTER TABLE `genres`
  MODIFY `id_genres` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- Ograniczenia dla zrzutów tabel
--

--
-- Ograniczenia dla tabeli `books`
--
ALTER TABLE `books`
  ADD CONSTRAINT `books_ibfk_1` FOREIGN KEY (`author_id`) REFERENCES `authors` (`id_author`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `books_ibfk_2` FOREIGN KEY (`genre_id`) REFERENCES `genres` (`id_genres`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
