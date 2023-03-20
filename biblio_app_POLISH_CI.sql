-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 20 Mar 2023, 17:20
-- Wersja serwera: 10.4.6-MariaDB
-- Wersja PHP: 7.3.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
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
(5, 'Rafał', 'Bartoń'),
(6, 'Denis', 'Czech');

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
(20, 'Behawiorysta', '\\images\\behawiorysta.jpg', '10.10.2016', '9788379348615', 'Filia', 4, 4),
(21, 'Jak zniszczyć ludzkość', '\\images\\Przechwytywanie.PNG', '13.10.2020', '3490283849239', 'Denis Czech INC', 6, 5);

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
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT dla tabeli `authors`
--
ALTER TABLE `authors`
  MODIFY `id_author` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT dla tabeli `books`
--
ALTER TABLE `books`
  MODIFY `id_book` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

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
