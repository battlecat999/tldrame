CALL `SP_Genera_Recibo_Anticipos`('1', '1865', '1');


SELECT * FROM empresa_datos;

ALTER TABLE empresa_datos
ADD condicion_frente_iva VARCHAR (30),
ADD fecha_inicio_actividad DATETIME null,
ADD numero_iibb VARCHAR(15);

UPDATE empresa_datos SET
empresa_nombre='LOGISTICA MYM SAS',
empresa_direccion='Av. Corrientes 327, CABA, Bs Aires.',
empresa_cuit='30-71677503-4',
numero_iibb='30-716775034-4',
empresa_email='administracion@logisticamym.com.ar',
fecha_inicio_actividad='2019-03-01',
condicion_frente_iva='IVA Responsable Inscripto',
empresa_telefono=''
WHERE empresa_ID=1;



SELECT CONCAT(LPAD(Empresa,4,0),'-',LPAD(ot,4,0), LPAD(Item_OT,4,0)) numero_anticipo
FROM .rel_OT_Item_Anticipos
WHERE ot=1869



INSERT INTO eventos_avisos (descripcion,detalle, activo,idConcepto) VALUES ('E_RECIBOS','RECIBOS DE CHEQUES',1,0);
INSERT INTO eventos_avisos (descripcion,detalle, activo,idConcepto) VALUES ('E_ESTADIAS','ESTADIAS',1,0);


SELECT * FROM estadias;

SELECT iot.IdOT,iot.Item,ot.BLBooking AS Booking, 
	CONCAT (corr.IdOrigen , ' ', corr.IdDestino, ' ', .corr.IdRetorno) as Ruta,
	DATE_FORMAT(iot.RetiroFecha,"%d/%m/%Y") AS Retiro , 
	ifnull(iot.NroContenedor,0) NroContenedor,
	tt.Patente  AS tractor,
	tc.Patente AS chasis,
	tch.Apellido AS chofer,
	tch.NroDOC,
	tch.Celular,
	e.FechaInicio,
	e.CantDias,
	e.FechaFin,
	e.PrecioDiario,
	e.Observaciones 
	FROM ot INNER JOIN itemot iot ON ot.IdEmpresa=iot.IdEmpresa AND ot.IdOT =iot.IdOT 	
	INNER JOIN corredores corr ON corr.idCorredor =ot.Ruta AND corr.IdEmpresa =ot.IdEmpresa  
	INNER JOIN t_tractores tt ON iot.IdTractor=tt.Id 
	INNER JOIN t_chasis tc ON iot.idChasis=tc.Id
	INNER JOIN t_choferes tch ON iot.IdChofer = tch.IdChofer 
	INNER JOIN estadias e ON e.IdOT = iot.IdOT AND e.IdItem=iot.Item
	WHERE iot.IdEmpresa=1 AND iot.IdOT=1974 and iot.Item= 2;
