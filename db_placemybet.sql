CREATE DATABASE db_placemybet;

--
-- Base de datos: `db_placemybet`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `apuestas`
--

CREATE TABLE `apuestas` (
  `id` int(11) NOT NULL,
  `email_user` varchar(255) COLLATE latin1_spanish_ci NOT NULL,
  `id_mercado` int(11) NOT NULL,
  `tipo_apuesta` varchar(255) COLLATE latin1_spanish_ci NOT NULL,
  `cuota` float NOT NULL,
  `apuesta` float NOT NULL,
  `fecha` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

--
-- Volcado de datos para la tabla `apuestas`
--

INSERT INTO `apuestas` (`id`, `email_user`, `id_mercado`, `tipo_apuesta`, `cuota`, `apuesta`, `fecha`) VALUES
(1, 'manuel@gmail.com', 2, 'over', 1.9, 6.75, '2020-10-15 12:44:54');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cuentas`
--

CREATE TABLE `cuentas` (
  `id` int(11) NOT NULL,
  `email_user` varchar(255) COLLATE latin1_spanish_ci NOT NULL,
  `saldo` float NOT NULL,
  `nombre_banco` varchar(255) COLLATE latin1_spanish_ci NOT NULL,
  `tarjeta_creadito` varchar(255) COLLATE latin1_spanish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

--
-- Volcado de datos para la tabla `cuentas`
--

INSERT INTO `cuentas` (`id`, `email_user`, `saldo`, `nombre_banco`, `tarjeta_creadito`) VALUES
(1, 'manuel@gmail.com', 1432.44, 'La Caixa', '999922221111000');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `eventos`
--

CREATE TABLE `eventos` (
  `id` int(11) NOT NULL,
  `equipo_local` varchar(255) COLLATE latin1_spanish_ci NOT NULL,
  `equipo_visitante` varchar(255) COLLATE latin1_spanish_ci NOT NULL,
  `fecha` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

--
-- Volcado de datos para la tabla `eventos`
--

INSERT INTO `eventos` (`id`, `equipo_local`, `equipo_visitante`, `fecha`) VALUES
(1, 'Valencia CF', 'Espanyol FC', '2020-10-16 12:33:37');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `mercados`
--

CREATE TABLE `mercados` (
  `id` int(11) NOT NULL,
  `id_evento` int(11) NOT NULL,
  `over_under` float NOT NULL,
  `cuota_over` float NOT NULL,
  `cuota_under` float NOT NULL,
  `dinero_over` float NOT NULL,
  `dinero_under` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

--
-- Volcado de datos para la tabla `mercados`
--

INSERT INTO `mercados` (`id`, `id_evento`, `over_under`, `cuota_over`, `cuota_under`, `dinero_over`, `dinero_under`) VALUES
(1, 1, 1.5, 1.43, 2.85, 100, 50),
(2, 1, 2.5, 1.9, 1.9, 100, 100),
(3, 1, 3.5, 2.85, 1.43, 50, 100);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `email` varchar(255) COLLATE latin1_spanish_ci NOT NULL,
  `nombre` varchar(255) COLLATE latin1_spanish_ci NOT NULL,
  `apellidos` varchar(255) COLLATE latin1_spanish_ci NOT NULL,
  `edad` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`email`, `nombre`, `apellidos`, `edad`) VALUES
('manuel@gmail.com', 'Manuel', 'Gomez Gomez', 22),
('maria@gmail.com', 'Maria', 'Garcia Rodriguez', 31);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `apuestas`
--
ALTER TABLE `apuestas`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_mercado` (`id_mercado`),
  ADD KEY `fk_usuario_apuesta` (`email_user`);

--
-- Indices de la tabla `cuentas`
--
ALTER TABLE `cuentas`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_usuario` (`email_user`);

--
-- Indices de la tabla `eventos`
--
ALTER TABLE `eventos`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `mercados`
--
ALTER TABLE `mercados`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_evento` (`id_evento`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`email`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `apuestas`
--
ALTER TABLE `apuestas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `cuentas`
--
ALTER TABLE `cuentas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `eventos`
--
ALTER TABLE `eventos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `mercados`
--
ALTER TABLE `mercados`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `apuestas`
--
ALTER TABLE `apuestas`
  ADD CONSTRAINT `fk_mercado` FOREIGN KEY (`id_mercado`) REFERENCES `mercados` (`id`),
  ADD CONSTRAINT `fk_usuario_apuesta` FOREIGN KEY (`email_user`) REFERENCES `usuarios` (`email`);

--
-- Filtros para la tabla `cuentas`
--
ALTER TABLE `cuentas`
  ADD CONSTRAINT `fk_usuario` FOREIGN KEY (`email_user`) REFERENCES `usuarios` (`email`);

--
-- Filtros para la tabla `mercados`
--
ALTER TABLE `mercados`
  ADD CONSTRAINT `fk_evento` FOREIGN KEY (`id_evento`) REFERENCES `eventos` (`id`);
COMMIT;
 