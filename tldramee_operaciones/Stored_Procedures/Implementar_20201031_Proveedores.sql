CREATE TABLE `web_prov` (
	`Id` INT(11) NOT NULL AUTO_INCREMENT,
	`IdEmpresa` INT(11) NULL DEFAULT '0',
	`cod_Proveedor` INT(11) NULL DEFAULT '0',
	`nombre` VARCHAR(100) NULL COLLATE 'latin1_swedish_ci',
	`cuit` VARCHAR(100) NULL COLLATE 'latin1_swedish_ci',
	PRIMARY KEY (`Id`) USING BTREE,
	INDEX `IdEmpresa_cod_Proveedor` (`IdEmpresa`, `cod_Proveedor`) USING BTREE
)
COLLATE='latin1_swedish_ci'
ENGINE=InnoDB
;


CREATE TABLE `web_prov_detalle` (
	`Id` INT(11) NOT NULL AUTO_INCREMENT,
	`IdEmpresa` INT(11) NULL,
	`cod_Proveedor` INT(11) NULL,
	`fecha` DATE NOT NULL,
	`detalle` VARCHAR(50) NOT NULL DEFAULT '0' COLLATE 'latin1_swedish_ci',
	`rutaArchivo` VARCHAR(500) NOT NULL DEFAULT '0' COLLATE 'latin1_swedish_ci',
	PRIMARY KEY (`Id`) USING BTREE,
	INDEX `IdEmpresa_cod_proveedor` (`IdEmpresa`, `cod_proveedor`) USING BTREE
)
COLLATE='latin1_swedish_ci'
ENGINE=InnoDB
;

CREATE TABLE `web_prov_usuarios` (
	`ID` INT(11) NOT NULL AUTO_INCREMENT,
	`IdEmpresa` INT(11) NOT NULL COMMENT 'Viene por Defaul archivo config',
	`cod_Proveedor` INT(11) NOT NULL,
	`email` VARCHAR(50) NOT NULL COLLATE 'latin1_swedish_ci',
	`pass` VARCHAR(100) NOT NULL COLLATE 'latin1_swedish_ci',
	`nombre` VARCHAR(50) NOT NULL COLLATE 'latin1_swedish_ci',
	`activo` TINYINT(4) NULL COMMENT '0=Activo 1=Inactivo',
	`fechaAlta` DATETIME NULL,
	`fechaModif` DATETIME NULL,
	INDEX `ID` (`ID`) USING BTREE
)
COLLATE='latin1_swedish_ci'
ENGINE=InnoDB
AUTO_INCREMENT=15
;


CREATE PROCEDURE `SP_Web_Alta_Proveedores`(
	IN `intEmpresa` INT,
	IN `intCodigo` INT,
	IN `strRazonSocial` VARCHAR(100),
	IN `strCuit` VARCHAR(13)
)
BEGIN
	IF EXISTS(SELECT 1  FROM web_prov WHERE IdEmpresa=intEmpresa AND cod_Proveedor=intCodigo) THEN
		UPDATE web_prov SET 
		nombre=strRazonSocial
		WHERE IdEmpresa=intEmpresa AND cod_Proveedor=intCodigo;
	ELSE
		INSERT INTO web_prov (IdEmpresa,cod_Proveedor,nombre,cuit) VALUES (intEmpresa,intCodigo,strRazonSocial,strCuit);
	END IF;
END


CREATE PROCEDURE `SP_Web_Alta_Proveedores_Detalle`(
	IN `intEmpresa` INT,
	IN `intProveedor` INT,
	IN `datFecha` DATE,
	IN `strDetalle` VARCHAR(50),
	IN `strNombreArchivo` VARCHAR(50),
	IN `strRutaFTP` VARCHAR(500)
)
BEGIN
	IF EXISTS(SELECT 1 FROM web_prov_detalle WHERE IdEmpresa =intEmpresa AND cod_Proveedor=intProveedor AND nombreArchivo=strNombreArchivo) THEN
		UPDATE web_prov_detalle  SET detalle=strDetalle WHERE IdEmpresa =intEmpresa AND cod_Proveedor=intProveedor AND nombreArchivo=strNombreArchivo;
	ELSE
		INSERT INTO web_prov_detalle(IdEmpresa,cod_Proveedor,fecha,detalle,nombreArchivo,rutaArchivo)
		VALUES (intEmpresa,intProveedor,datFecha,strDetalle,strNombreArchivo,strRutaFTP);
	END IF;
	
END

/*
cambiar cant ejes de t_chasis por INT 
SP_Chasis_ABM
SP_Choferes_ABM
SP_Tractores_ABM
SP_OT_Item_Alta
SP_GET_ESTADOS_OTS_ALL
*/
