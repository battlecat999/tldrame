BEGIN
SELECT iot.IdOT 'OT' ,iot.item 'Items' ,cl.Razon_Social 'Cliente' ,ot.Buque,ot.BLBooking AS Booking ,ts.descripcion AS Servicio,tm.descripcion AS Modalidad,
CONCAT (corr.IdOrigen , ' ', corr.IdDestino, ' ', .corr.IdRetorno) as Ruta,
DATE_FORMAT(CONCAT (iot.RetiroFecha),'%d/%m/%y') AS Retiro , CONCAT(date_format(iot.PosFecha,'%d/%m/%y') , ' ',iot.PosHora) AS Posic,iot.NroContenedor AS Contenedor,
p.Razon_Social AS Transportista, tt.Patente  AS tractor,tc.Patente AS Chasis,tch.Apellido  AS Chofer,eo.Descripcion ,if(iot.TieneAnticipo IS null,'NO','SI') 'Anticipo',
if(iot.TieneFactura IS null,'NO','SI') 'Factura',cc.Descripcion 'Ultima Pos', if(iot.Costo IS NULL,0,iot.Costo) 'Compra',ttt.idTractor 'codTractor',tc.Id'CodChasis', tch.IdChofer 'codChofer',iot.PosHora 'HoraPosic', corr.idCorredor 'idCorredor'
FROM ot
INNER JOIN itemot iot ON ot.IdEmpresa=iot.IdEmpresa AND ot.IdOT =iot.IdOT
INNER JOIN cotizaciones c ON ot.IdEmpresa=c.IdEmpresa AND ot.IdCotizacion=c.IdCotizacion
INNER JOIN clientes cl ON cl.Id =c.IdCliente AND c.IdEmpresa = cl.IdEmpresa
INNER JOIN tipo_servicios ts ON ot.TipoServicio =ts.id 
INNER JOIN tipo_modalidad tm ON ot.Tipo_Modalidad=tm.id AND ot.IdEmpresa=tm.IdEmpresa
INNER JOIN corredores corr ON corr.idCorredor =ot.Ruta AND corr.IdEmpresa =ot.IdEmpresa 
INNER JOIN tipo_marcas tms ON tm.IdEmpresa = ot.IdEmpresa
LEFT JOIN estados_ots eo ON eo.Id=iot.Estado
LEFT JOIN proveedores p ON iot.IdTransportista=p.id  AND p.IdEmpresa=iot.IdEmpresa
LEFT JOIN t_trans_tractor ttt ON p.id=ttt.idTransportista AND p.IdEmpresa=ttt.idEmpresa AND ttt.idTractor=iot.IdTractor 
LEFT JOIN t_tractores tt ON ttt.idTractor=tt.Id 
LEFT JOIN t_trans_chasis ttc ON p.id=ttc.idTransportista AND p.IdEmpresa=ttc.idEmpresa AND iot.IdChasis=ttc.idChasis 
LEFT JOIN t_chasis tc ON ttc.idChasis=tc.Id 
LEFT JOIN t_trans_chofer ttch ON p.id=ttch.idTransportista AND p.IdEmpresa=ttch.idEmpresa AND iot.IdChofer=ttch.IdChofer
LEFT JOIN t_choferes tch ON tch.IdChofer = ttch.idChofer
LEFT Join (Select Fecha, Codigo_Concepto, b.Descripcion, a.Empresa, a.OT, a.Item
		From itemot_conceptos a INNER JOIN conceptos_a_nominar b
		ON a.Empresa = b.IdEmpresa 
		And a.Codigo_Concepto = b.Id
		WHERE Empresa = intEmpresa AND a.Ultimo=1
		ORDER BY b.Orden DESC) cc ON cc.OT=iot.IdOT AND cc.Item=iot.Item AND iot.IdEmpresa=cc.Empresa
WHERE ot.IdEmpresa=intEmpresa AND
(intOT IS NULL OR ot.IdOT=intOT) AND
(intCliente IS NULL OR  cl.Id=intCliente) AND
(intTransportista IS NULL OR p.id=intTransportista) AND
(iot.PosFecha BETWEEN datFechaDesde AND datFechaHasta) AND
(strNroCont IS NULL OR iot.NroContenedor = strNroCont) AND
(strBooking IS NULL OR ot.BLBooking=strBooking) AND
(strPatente IS NULL OR tt.Patente LIKE CONCAT('%',strPatente,'%'))
ORDER BY 1 DESC, 2 asc;
END