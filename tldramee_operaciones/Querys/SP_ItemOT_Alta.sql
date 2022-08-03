CREATE PROCEDURE `SP_OTItem_Alta`(
	IN `pIdEmpresa` INT,
	IN `pIdOT` INT,
	IN `pItem` INT,
	IN `pViajeConjunto` INT,
	IN `pRetiroFecha` DATETIME,
	IN `pRetiroHora` VARCHAR(5),
	IN `pPosFecha` DATETIME,
	IN `pPosHora` VARCHAR(5),
	IN `pCantidad` INT,
	IN `pIdContenedor` INT,
	IN `pNroContenedor` VARCHAR(100),
	IN `pPesoContenedor` DECIMAL(10,2),
	IN `pIdGenerador` INT,
	IN `pNroGenerador` VARCHAR(100),
	IN `pPesoGenerador` INT,	
	IN `pNroPrecinto` VARCHAR(100),
	IN `pPesotn` DECIMAL(10,2),
	IN `pEstado` VARCHAR(10)
)
LANGUAGE SQL
NOT DETERMINISTIC
CONTAINS SQL
SQL SECURITY DEFINER
COMMENT ''
BEGIN


INSERT INTO itemot(IdEmpresa,IdOT,Item,viajeConjunto, RetiroFecha,RetiroHora,PosFecha,PosHora,Cantidad,IdContenedor,NroContenedor,PesoContenedor,IdGenerador,NroGenerador,PesoGenerador,NroPrecinto,pesotn,Estado)
VALUES (pIdEmpresa,pIdOT,pItem,pViajeConjunto,pRetiroFecha,pRetiroHora,pPosFecha,pPosHora,pCantidad,pIdContenedor,pNroContenedor,pPesoContenedor,pIdGenerador,pNroGenerador,pPesoGenerador,pNroPrecinto,pPesotn,pEstado);

SELECT @nextOT;
END