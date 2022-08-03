ALTER TABLE t_tractores ADD COLUMN codigo_color INT;
UPDATE t_tractores SET codigo_color=1;
ALTER TABLE t_chasis ADD COLUMN codigo_color INT;
UPDATE t_chasis SET codigo_color=1;

ALTER TABLE ot ADD COLUMN email_nominacion DATETIME NULL DEFAULT NULL;

/*SELECT * FROM eventos_avisos*/
UPDATE eventos_avisos SET activo=0 WHERE id=3;
DELETE  FROM mail_asoc_cliente_evento  WHERE idEvento=3;

ALTER TABLE t_tractores MODIFY Seguro INT;
ALTER TABLE t_chasis MODIFY Seguro INT;
/*EXPORTAR TABLA TIPO_COLORES*/
CREATE DEFINER=`marco`@`%` PROCEDURE `SP_GET_Tipo_Colores`()
LANGUAGE SQL
NOT DETERMINISTIC
CONTAINS SQL
SQL SECURITY DEFINER
COMMENT ''
BEGIN
SELECT id,descripcion FROM tipo_Colores order by descripcion;
END

CREATE PROCEDURE `SP_ItemOT_Tiene_Anticipo_Factura`(
	IN `intEmpresa` INT,
	IN `intOT` INT,
	IN `intItem` INT
)
LANGUAGE SQL
NOT DETERMINISTIC
CONTAINS SQL
SQL SECURITY DEFINER
COMMENT ''
BEGIN
SELECT IFNULL(TieneAnticipo,'NO') Anticipo ,IFNULL(TieneFactura,'NO') Factura FROM itemot i WHERE i.IdEmpresa=intEmpresa AND i.IdOT=intOT AND i.Item=intItem;
END

CREATE TABLE `cambio_nominaciones` (
	`ID` INT(11) NOT NULL AUTO_INCREMENT,
	`IdEmpresa` INT(11) NULL,
	`IdTransporte` INT(11) NULL,
	`IdTractor` INT(11) NULL,
	`IdChasis` INT(11) NULL,
	`IdChofer` INT(11) NULL,
	`IdOT` INT(11) NULL,
	`Item` INT(11) NULL,
	`nroOrden` INT(11) NULL COMMENT '0=Original; 1=Cambio',
	`FechaCambio` DATETIME NULL,
	`IdUsuario` INT(11) NULL,
	PRIMARY KEY (`ID`) USING BTREE
)
COLLATE='latin1_swedish_ci'
ENGINE=INNODB

CREATE DEFINER=`marco`@`%` PROCEDURE `SP_Cambio_Nominacion_Insert`(
	IN `intEmpresa` INT,
	IN `intTransportista` INT,
	IN `intTractor` INT,
	IN `intChasis` INT,
	IN `intChofer` INT,
	IN `intOT` INT,
	IN `intItem` INT,
	IN `intOrden` INT,
	IN `intUsuario` INT,
	IN `decCosto` DECIMAL(10,2)
)
LANGUAGE SQL
NOT DETERMINISTIC
CONTAINS SQL
SQL SECURITY DEFINER
COMMENT ''
BEGIN
	
	INSERT INTO cambio_nominaciones (IdEmpresa,IdTransporte,IdTractor,IdChasis,IdChofer,IdOT,Item,nroOrden,FechaCambio,IdUsuario)
	VALUES (intEmpresa,intTransportista,intTractor,intChasis,intChofer,intOT, intItem,intOrden,NOW(),intUsuario);
	
	IF intOrden=1 THEN /*con 1 grabo lo nuevo.*/
		UPDATE itemot SET IdTransportista=intTransportista,IdTractor=intTractor,IdChasis=intChasis,IdChofer=intChofer,Costo=decCosto
		WHERE IdEmpresa=intEmpresa AND IdOT=intOT AND Item=intItem;
		
		UPDATE itemot_conceptos SET Transportista=intTransportista,Tractor=intTractor,Chasis=intChasis,Chofer=intChofer
		WHERE Empresa=intEmpresa AND OT=intOT AND Item=intItem;
		
		UPDATE t_trans_tractor SET	ocupado=0 WHERE idEmpresa=intEmpresa and idTransportista= intTransportista AND idTractor=intTractor;
		UPDATE t_trans_chasis SET	ocupado=0 WHERE idEmpresa=intEmpresa and idTransportista= intTransportista AND idChasis=intChasis;
		UPDATE t_trans_chofer SET	ocupado=0 WHERE idEmpresa=intEmpresa and idTransportista= intTransportista AND idChofer=intChofer;
		
		UPDATE ot SET ot.email_nominacion=NULL WHERE IdEmpresa=intEmpresa AND IdOT=intOT;
	END IF;
	
END