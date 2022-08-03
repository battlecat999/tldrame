SELECT * FROM cotizaciones

ALTER TABLE cotizaciones
ADD IdContenedor INT AFTER estado,
ADD diasValidez INT AFTER IdDuracion,
ADD ImporteEstadia DECIMAL (10,2) AFTER ImporteVenta,
ADD FechaVigenciaDesde DATE AFTER estado


UPDATE cotizaciones SET
IdDuracion=1,
IdContenedor=7,
diasValidez=7,
ImporteEstadia=0

/*UPDATE cotizaciones SET FechaVigenciaDesde=Fecha*/


/*
Exportar 
SP_Cotizaciones_Insert
SP_Cotizaciones_UPDATE
SP_Cotizacion_Traer
TABLA mail_asunto_cuerpo
SP_PRESUPUESTO_POR_CLIENTE
SP_Cotizaciones_Reporte
*/

CREATE TABLE `estado_cotizaciones` (
	`Codigo_Estado` INT(11) NOT NULL AUTO_INCREMENT,
	`IdEmpresa` INT(11) NOT NULL
	`Descripcion` VARCHAR(50) NOT NULL COLLATE 'latin1_general_cs',
	`Activo` INT(11) NOT NULL,
	PRIMARY KEY (`Id`) USING BTREE
)
COLLATE='latin1_general_cs'
ENGINE=InnoDB
;

INSERT INTO estado_cotizaciones (IdEmpresa,Descripcion,Activo) VALUES (1,'PENDIENTE',0);
INSERT INTO estado_cotizaciones (IdEmpresa,Descripcion,Activo) VALUES (1,'APROBADA',0);
INSERT INTO estado_cotizaciones (IdEmpresa,Descripcion,Activo) VALUES (1,'NO APROBADA',0);
INSERT INTO estado_cotizaciones (IdEmpresa,Descripcion,Activo) VALUES (1,'ANULADA',0);


UPDATE cotizaciones SET FechaVigenciaDesde='2020-10-01',FechaVencimiento='2020-10-21' WHERE estado=1;
UPDATE cotizaciones SET Estado=4 WHERE Estado=2;
UPDATE cotizaciones SET Estado=2 WHERE Estado=1;


CREATE PROCEDURE `SP_Cotizacion_Estados`(
	IN `pIdEmpresa` INT,
	IN `ID` INT
)
LANGUAGE SQL
NOT DETERMINISTIC
CONTAINS SQL
SQL SECURITY DEFINER
COMMENT ''
BEGIN
SELECT id,descripcion FROM estado_cotizaciones WHERE Activo=0 AND IdEmpresa=pIdEmpresa;
END
