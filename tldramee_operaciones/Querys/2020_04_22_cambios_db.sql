ALTER TABLE `itemot` CHANGE COLUMN `CostoCorredor` `CostoInicial` DECIMAL(15,2) NULL AFTER `Observaciones`;
ALTER TABLE `itemot` ADD  `VentaInicial` DECIMAL (15,2) NULL AFTER `CostoInicial`;
ALTER TABLE `itemot`	CHANGE COLUMN `Observaciones` `Observaciones` VARCHAR(500) NULL DEFAULT NULL COLLATE 'utf8_spanish2_ci' AFTER `Venta`;
ALTER TABLE `itemot` ADD  `idUsuarioFF` INT NULL AFTER `VentaInicial`;


CREATE DEFINER=`marco`@`%` PROCEDURE `SP_OT_Item_Falso_Flete`(
	IN `intEmpresa` INT,
	IN `intNumero_OT` INT,
	IN `intNumero_Item` INT,
	IN `intUsuario` INT,
	IN `strMotivo` VARCHAR(50),
	IN `decCostoFF` DECIMAL (15,2),
	IN `decVentaFF` DECIMAL (15,2)
)
LANGUAGE SQL
NOT DETERMINISTIC
CONTAINS SQL
SQL SECURITY DEFINER
COMMENT ''
BEGIN
/*
	Delete from itemot 
	
	Where IDEmpresa = intEmpresa
	AND IdOT = intNumero_OT;
*/

UPDATE itemot SET CostoInicial=Costo,VentaInicial=Venta WHERE IdEmpresa=intEmpresa AND IdOT=intNumero_OT AND item=intNumero_Item;
UPDATE itemot SET Costo=decCostoFF,Venta=decVentaFF,Observaciones=strMotivo,idUsuarioFF=intUsuario, Estado=2 WHERE IdEmpresa=intEmpresa AND IdOT=intNumero_OT AND item=intNumero_Item;

END;

/*Ejecutar*/
Insert into mail_asoc_admin_evento(idEmpresa,idEvento,idUsuario,Email)
SELECT empresa_ID,5,idUser,userEmail FROM users where idUser NOT IN (1,4)


/*
Exportar
SP_Emails_Sin_Conceptos
SP_Emails_Con_Conceptos
SP_OT_Item_Falso_Flete
SP_Transferencia_Para_Remitos
SP_Email_Admin_Evento

mail_asunto_cuerpo


*/