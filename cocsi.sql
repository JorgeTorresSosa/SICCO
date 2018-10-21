-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 21-10-2018 a las 03:36:21
-- Versión del servidor: 5.6.17
-- Versión de PHP: 5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de datos: `cocsi`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `producto`
--

CREATE TABLE IF NOT EXISTS `producto` (
  `ID_Producto` int(15) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(30) NOT NULL,
  `Tipo` int(2) NOT NULL,
  `Modelo` int(2) NOT NULL,
  `No_Control` int(15) NOT NULL,
  `Descripcion` text NOT NULL,
  `Precio` int(8) NOT NULL,
  `imagen` blob NOT NULL,
  PRIMARY KEY (`ID_Producto`),
  KEY `No_Control` (`No_Control`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `servicio`
--

CREATE TABLE IF NOT EXISTS `servicio` (
  `ID_Clase` int(15) NOT NULL AUTO_INCREMENT,
  `Nombre_del_Impartidor` varchar(50) NOT NULL,
  `Materia` int(2) NOT NULL,
  `Costo_x_hora` int(5) NOT NULL,
  `Horarios` text NOT NULL,
  `Ubicacion` varchar(50) NOT NULL,
  `No_Control` int(15) NOT NULL,
  `Descripcion` text NOT NULL,
  `imagen` blob NOT NULL,
  PRIMARY KEY (`ID_Clase`),
  KEY `No_Control` (`No_Control`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario`
--

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

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `producto`
--
ALTER TABLE `producto`
  ADD CONSTRAINT `producto_ibfk_1` FOREIGN KEY (`No_Control`) REFERENCES `usuario` (`No_Control`);

--
-- Filtros para la tabla `servicio`
--
ALTER TABLE `servicio`
  ADD CONSTRAINT `servicio_ibfk_1` FOREIGN KEY (`No_Control`) REFERENCES `usuario` (`No_Control`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
