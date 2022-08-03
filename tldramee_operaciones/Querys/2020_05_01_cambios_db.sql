/*
ALTER TABLE cotizaciongastos RENAME gastos_ots;
ALTER TABLE gastos_ots DROP COLUMN IdCotizacion;
ALTER TABLE gastos_ots DROP COLUMN IdGastos;
ALTER TABLE gastos_ots DROP COLUMN DescripcionGasto;
ALTER TABLE gastos_ots DROP COLUMN Costo;
ALTER TABLE gastos_ots DROP PRIMARY KEY ;

SELECT * FROM gastos_ots



ALTER TABLE gastos_ots
ADD COLUMN Codigo_Gasto INT NOT NULL auto_increment AFTER IdEmpresa,
ADD COLUMN Descripcion VARCHAR(100) AFTER Codigo_Gasto,
ADD COLUMN Gasto_Costo DECIMAL(18,2) AFTER Descripcion,
ADD COLUMN Fecha_Asignacion DATETIME NOT NULL AFTER Gasto_Costo,
ADD PRIMARY KEY(Codigo_Gasto)

CREATE TABLE `itemot_gastos` (
	`IdEmpresa` INT(11) NOT NULL,
	`IdOT` INT(11) NOT NULL,
	`Item_OT` INT(11) NOT NULL,
	`Codigo_Gasto` INT(11) NOT NULL,
	`Costo` INT(11) NOT NULL,
	`FechaAlta` DATETIME NULL,
	`UsuarioAlta` VARCHAR(100) NULL COLLATE 'utf8_spanish2_ci',
	`FechaBaja` DATETIME NULL,
	PRIMARY KEY (`IdEmpresa`, `IdOT`, `Item_OT`, `Codigo_Gasto`) USING BTREE
)
COLLATE='utf8_spanish2_ci'
ENGINE=InnoDB
ROW_FORMAT=COMPACT
;



*/
CREATE PROCEDURE `SP_Item_Gastos_Alta_Baja`(
	IN `intEsAlta` INT,
	IN `intEmpresa` INT,
	IN `intOT` INT,
	IN `intItem_OT` INT,
	IN `intCodigo_Gasto` INT,
	IN `decCosto` DECIMAL(18,2),
	IN `datFechaAlta` DATE,
	IN `intUsuarioAlta` INT,
	IN `datFechaAnulacion` DATE
)
LANGUAGE SQL
NOT DETERMINISTIC
CONTAINS SQL
SQL SECURITY DEFINER
COMMENT ''
BEGIN

IF intEsAlta=0 THEN/*0= Alta*/
	INSERT INTO itemot_gastos (IdEmpresa, IdOT, Item_OT, Codigo_Gasto,Costo,FechaAlta,UsuarioAlta)
	VALUES (intEmpresa,intOT, intItem_OT, intCodigo_Gasto, decCosto, datFechaAlta,intUsuarioAlta);
ELSE /*1=Baja o Actualizacion*/
	UPDATE itemot_gastos SET Costo=decCosto, Fecha_Anulacion=datFecha_Anulacion WHERE IdEmpresa=intEmpresa and IdOT=intOT and Item_OT=intItem_OT;
END IF;
END

