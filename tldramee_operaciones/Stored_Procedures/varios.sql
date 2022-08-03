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
	WHERE iot.IdEmpresa=1 AND iot.IdOT=1974 and iot.Item= 2 LIMIT 1;
	
	
	
SELECT MD5('Thiago2021')