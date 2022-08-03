SELECT ot.IdOT ,iot.item, c.Cotizacion ,cl.Razon_Social ,ot.Buque,ot.BLBooking AS Booking ,ts.descripcion AS Servicio,tm.descripcion AS Modalidad,
CONCAT (corr.IdOrigen , ' ', corr.IdDestino, ' ', .corr.IdRetorno) as Ruta,
CONCAT (iot.RetiroFecha,' ',iot.RetiroHora) AS Retiro , CONCAT (iot.PosFecha,' ',iot.PosHora) AS Posic,iot.NroContenedor AS Contenedor,iot.NroGenerador AS Generador,
p.Razon_Social AS transportista, tt.Patente  AS tractor,tc.Patente AS chasis,tch.Apellido  AS chofer,iot.TieneAnticipo,iot.TieneFactura 
FROM ot 
INNER JOIN itemot iot ON ot.IdEmpresa=iot.IdEmpresa AND ot.IdOT =iot.IdOT
INNER JOIN cotizaciones c ON ot.IdEmpresa=c.IdEmpresa AND ot.IdCotizacion=c.IdCotizacion
INNER JOIN clientes cl ON cl.Id =c.IdCliente 
INNER JOIN tipo_servicios ts ON ot.TipoServicio =ts.id 
INNER JOIN tipo_modalidad tm ON ot.Tipo_Modalidad=tm.id AND ot.IdEmpresa=tm.IdEmpresa
INNER JOIN corredores corr ON corr.idCorredor =ot.Ruta AND corr.IdEmpresa =ot.IdEmpresa 
INNER JOIN proveedores p ON iot.IdTransportista=p.id 
INNER JOIN t_trans_tractor ttt ON p.id=ttt.idTransportista 
INNER JOIN t_tractores tt ON ttt.idTractor=tt.Id 
INNER JOIN t_trans_chasis ttc ON p.id=ttc.idTransportista
INNER JOIN t_chasis tc ON ttc.idChasis=tc.Id
INNER JOIN t_trans_chofer ttch ON p.id=ttch.idTransportista 
INNER JOIN t_choferes tch ON tch.IdChofer = ttch.idChofer 
 