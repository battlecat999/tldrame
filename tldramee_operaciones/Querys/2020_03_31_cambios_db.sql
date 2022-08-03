ALTER TABLE rel_OT_Item_Anticipos ADD opAutoriza INT DEFAULT '0';
UPDATE rel_OT_Item_Anticipos SET opAutoriza=1;


DROP PROCEDURE IF EXISTS `SP_Get_Anticipos_OT`;
CREATE DEFINER=`marco`@`%` PROCEDURE `SP_Get_Anticipos_OT`(
	IN `intEmpresa` INT,
	IN `intOT` INT,
	IN `intItem_OT` INT,
	IN `intActualizacion_Web` TINYINT
)
LANGUAGE SQL
NOT DETERMINISTIC
CONTAINS SQL
SQL SECURITY DEFINER
COMMENT ''
BEGIN

	if (intActualizacion_Web = 0) Then

		Select Empresa, OT, Item_OT, Item_Anticipo, Fecha, Forma_Pago Codigo_Forma_Pago, ifnull(Importe, 0) Importe, ifnull(Litros, 0) Litros, ifnull(Observaciones, '') Observaciones,
		LPAD(OT, 11, '0') OT_Con_Mascara,
		ifnull(Precio_Litro, 0) Precio_Litro, opAutoriza 
		From rel_OT_Item_Anticipos 
		Where Empresa = intEmpresa
		And OT = intOT
		And Item_OT = intItem_OT
		Order By Item_Anticipo;
		
	else

		Select a.ID, a.Empresa, a.OT, a.Item_OT, a.Item_Anticipo, a.Fecha, a.Forma_Pago Codigo_Forma_Pago, ifnull(a.Importe, 0) Importe, ifnull(a.Litros, 0) Litros, 
		ifnull(a.Observaciones, '') Observaciones,
		LPAD(a.OT, 11, '0') OT_Con_Mascara, 
		c.IdTransportista Codigo_Proveedor,
		ifnull(a.Precio_Litro, 0) Precio_Litro,opAutoriza
		
		From rel_OT_Item_Anticipos a Inner Join ot b
		
		On a.Empresa = b.IdEmpresa
		And a.OT = b.IdOT
		
		Inner Join itemot c
		ON a.Empresa = c.IdEmpresa
		And a.OT = c.IdOT
		And a.Item_OT = c.Item
		
		Where Empresa = intEmpresa
		/*
		And OT = intOT
		And Item_OT = intItem_OT
		*/
		And ifnull(Actualizacion_Web, 0) = 0
		Order By Fecha;
	
	end if;

END


DROP PROCEDURE IF EXISTS `SP_Anticipos_Autorizacion`;
CREATE DEFINER=`marco`@`%` PROCEDURE `SP_Anticipos_Autorizacion`(
	IN `intEmpresa` INT
)
LANGUAGE SQL
NOT DETERMINISTIC
CONTAINS SQL
SQL SECURITY DEFINER
COMMENT ''
BEGIN
SELECT iot.IdOT ,iot.item ,cl.Razon_Social ,ot.BLBooking AS Booking ,
CONCAT (corr.IdOrigen , ' ', corr.IdDestino, ' ', .corr.IdRetorno) as Ruta,
p.Razon_Social AS transportista,tch.Apellido  AS chofer,r.Fecha Fecha_Pago,SUM(r.Importe) 'Total_Anticipo',r.opAutoriza 'Confirma'
FROM ot 
INNER JOIN itemot iot ON ot.IdEmpresa=iot.IdEmpresa AND ot.IdOT =iot.IdOT
INNER JOIN cotizaciones c ON ot.IdEmpresa=c.IdEmpresa AND ot.IdCotizacion=c.IdCotizacion
INNER JOIN clientes cl ON cl.Id =c.IdCliente 
INNER JOIN corredores corr ON corr.idCorredor =ot.Ruta AND corr.IdEmpresa =ot.IdEmpresa 
INNER JOIN proveedores p ON iot.IdTransportista=p.id 
INNER JOIN t_trans_tractor ttt ON p.id=ttt.idTransportista 
INNER JOIN t_tractores tt ON ttt.idTractor=tt.Id AND iot.IdTractor=tt.Id
INNER JOIN t_trans_chasis ttc ON p.id=ttc.idTransportista
INNER JOIN t_chasis tc ON ttc.idChasis=tc.Id AND iot.IdChasis=tc.Id 
INNER JOIN t_trans_chofer ttch ON p.id=ttch.idTransportista 
INNER JOIN t_choferes tch ON tch.IdChofer = ttch.idChofer  AND iot.IdChofer=tch.IdChofer 
inner JOIN rel_OT_Item_Anticipos r ON r.Empresa=iot.IdEmpresa AND r.OT=iot.IdOT AND r.Item_OT=iot.Item
WHERE ot.IdEmpresa=intEmpresa AND r.Actualizacion_Web IS NULL AND r.opAutoriza=0
GROUP BY ot.IdOT ,iot.item ,cl.Razon_Social ,ot.Buque,ot.BLBooking ,
CONCAT (corr.IdOrigen , ' ', corr.IdDestino, ' ', .corr.IdRetorno),
CONCAT (iot.PosFecha),iot.NroContenedor,
p.Razon_Social,tch.Apellido,r.Fecha
ORDER BY 1 desc,2 ;
END

DROP PROCEDURE IF EXISTS `SP_Transferencia_Para_Anticipos`;

CREATE DEFINER=`marco`@`%` PROCEDURE `SP_Transferencia_Para_Anticipos`(
	IN `intEmpresa` INT
)
LANGUAGE SQL
NOT DETERMINISTIC
CONTAINS SQL
SQL SECURITY DEFINER
COMMENT ''
BEGIN
	SELECT r.ID ,r.Empresa,r.OT,r.Item_OT,r.Item_Anticipo,r.Fecha,r.Forma_Pago,r.Importe,r.Litros,r.Precio_Litro,r.Observaciones,r.Contenedor,r.IdProveedor,
	CONCAT(LPAD(r.Empresa,4,'0'),'-',LPAD(r.OT,4,'0'),LPAD(r.Item_OT,4,'0')) Nro_AP
	FROM rel_OT_Item_Anticipos r
	WHERE r.Actualizacion_Web IS NULL AND r.Empresa =intEmpresa AND r.opAutoriza=1;
END

CREATE DEFINER=`marco`@`%` PROCEDURE `SP_Anticipos_Confirma`(
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
	UPDATE rel_OT_Item_Anticipos SET opAutoriza=1 WHERE Empresa=intEmpresa AND ot=intOT AND Item_OT=intItem;
END