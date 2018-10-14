-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1:3306
-- Tiempo de generación: 13-10-2018 a las 18:49:23
-- Versión del servidor: 5.7.19
-- Versión de PHP: 5.6.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `base`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `producto`
--

DROP TABLE IF EXISTS `producto`;
CREATE TABLE IF NOT EXISTS `producto` (
  `ID Producto` int(15) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(30) NOT NULL,
  `Tipo` int(2) NOT NULL,
  `Modelo` int(2) NOT NULL,
  `No. Control` int(15) NOT NULL,
  `Descripcion` text NOT NULL,
  `Precio` int(8) NOT NULL,
  PRIMARY KEY (`ID Producto`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `servicio`
--

DROP TABLE IF EXISTS `servicio`;
CREATE TABLE IF NOT EXISTS `servicio` (
  `ID Clase` int(15) NOT NULL AUTO_INCREMENT,
  `Nombre del Impartidor` varchar(50) NOT NULL,
  `Materia` int(2) NOT NULL,
  `Costo x hora` int(5) NOT NULL,
  `Horarios` text NOT NULL,
  `Ubicacion` varchar(50) NOT NULL,
  `No. Control` int(15) NOT NULL,
  `Descripcion` text NOT NULL,
  PRIMARY KEY (`ID Clase`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario`
--

DROP TABLE IF EXISTS `usuario`;
CREATE TABLE IF NOT EXISTS `usuario` (
  `Nombre` varchar(30) NOT NULL,
  `Apellido_Paterno` varchar(30) NOT NULL,
  `Apellido_Materno` varchar(30) NOT NULL,
  `Especialidad` int(1) NOT NULL,
  `Semestre` int(1) NOT NULL,
  `No_Control` int(15) NOT NULL,
  `Edad` int(2) NOT NULL,
  `Nombre_usuarios` varchar(30) NOT NULL,
  `Contraseña` varchar(40) NOT NULL,
  `Correo` varchar(50) NOT NULL,
  PRIMARY KEY (`No_Control`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `usuario`
--

INSERT INTO `usuario` (`Nombre`, `Apellido_Paterno`, `Apellido_Materno`, `Especialidad`, `Semestre`, `No_Control`, `Edad`, `Nombre_usuarios`, `Contraseña`, `Correo`) VALUES
('Elian', 'Cruz', 'Esquivel', 1, 5, 1, 17, 'aa', '1234', 'aa@gmail.com'),
('Elian Javier', 'Cruz', 'Esquivel', 0, 4, 4, 2, 'Usuario1', '1234', 'Usuario1@gmail.com'),
('Roger', 'Waters', 'Waters', 1, 5, 163020, 17, 'usuario_prueba', 'prueba', 'pruebausuario@gmail.com');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
