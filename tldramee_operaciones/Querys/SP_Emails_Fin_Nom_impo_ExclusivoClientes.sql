CREATE DEFINER=`tldrameee1896_operaciones`@`%` PROCEDURE `SP_Emails_Fin_Nom_impo_Vessel`(
	IN `intEmpresa` INT,
	IN `intOt` INT,
	IN `strBooking` VARCHAR(50),
	IN `intItemOt` INT,
	IN `intOpcion` INT
)
LANGUAGE SQL
NOT DETERMINISTIC
CONTAINS SQL
SQL SECURITY DEFINER
COMMENT ''
BEGIN
SELECT tch.Apellido 'APELLIDO Y NOMBRE',tch.NroDOC 'DNI',tt.Patente Tractor,tc.Patente 'SEMI',iot.NroContenedor 'CONTENEDOR',ot.BLBooking AS 'BL'/*tch.Telefono*/,c.Peso 'PESO',iot.PosHora AS 'HORA', 0 AS 'OC'
 
-- /*CONCAT(iot.NroPrecintoEmpty, ' || ',iot.NroPrecinto) 'Precito de L&iacute;nea Vac&iacute;o // P. Full',*/
-- /*iot.NroPrecintoEmpty ' Precinto Vac&iacute;o ',/*2022-05-09*/
-- /*iot.NroPrecinto 'Precinto Full', 
-- iot.NroContenedor Contenedor,
-- c.descripcion 'Tipo Contr',
-- c.Peso 'Tara del Contr',
-- tch.Apellido Chofer, 
-- tch.NroDOC 'CUIT/CUIL',
-- tt.Patente Tractor,
-- tm.descripcion Marca,
-- -- /*CONCAT(tmm.descripcion,' || ',tt.Anio ) 'Modelo || A&ntilde;o',*/
-- tmm.descripcion 'Modelo',
-- tt.Anio 'A&ntilde;o',
-- col.descripcion Color,
-- tc.Patente Chasis,
-- CONCAT(es_tt.descripcion, ' || ',tt.NroPoliza) 'Cia Seg. Tractor/Poliza',
-- CONCAT(es_tc.descripcion, ' || ',tc.NroPoliza) 'Cia Seg. Chasis/Poliza',
-- CONCAT(tch.Seguro , ' || ',tch.NroPoliza) 'Art./Seg. de Vida',
-- DATE_FORMAT(tch.FecVenLic,"%d/%m/%Y") 'Venc. CNRT',
-- tch.Telefono,
-- tt.GPS_Link Satelital ,
-- tt.GPS_Us Usuario,
-- tt.GPS_Ps 'Contrase&ntilde;a'
 FROM ot 
INNER JOIN itemot iot ON ot.IdEmpresa=iot.IdEmpresa AND ot.IdOT =iot.IdOT
INNER JOIN corredores corr ON corr.idCorredor =ot.Ruta AND corr.IdEmpresa =ot.IdEmpresa 
INNER JOIN proveedores p ON iot.IdTransportista=p.id AND iot.IdEmpresa AND p.IdEmpresa
INNER JOIN t_trans_tractor ttt ON p.id=ttt.idTransportista AND p.IdEmpresa=ttt.idEmpresa
INNER JOIN t_tractores tt ON ttt.idTractor=tt.Id AND iot.IdTractor=tt.Id AND ttt.idEmpresa=iot.IdEmpresa
INNER JOIN t_trans_chasis ttc ON p.id=ttc.idTransportista
INNER JOIN t_chasis tc ON ttc.idChasis=tc.Id AND iot.IdChasis=tc.Id AND iot.IdEmpresa=ttc.idEmpresa
INNER JOIN t_trans_chofer ttch ON p.id=ttch.idTransportista 
INNER JOIN t_choferes tch ON tch.IdChofer = ttch.idChofer  AND iot.IdChofer=tch.IdChofer AND iot.IdEmpresa=ttch.idEmpresa
INNER JOIN contenedores c ON c.Id=iot.IdContenedor 
LEFT JOIN tipo_marcas tm ON tm.id=tt.Marca
LEFT JOIN tipo_marcas_modelos tmm ON tmm.id =tm.id AND tmm.idModelo =tt.Modelo
LEFT JOIN empresas_seguros es_tt ON es_tt.id  =tt.Seguro
LEFT JOIN empresas_seguros es_tc ON es_tc.id=tc.Seguro
LEFT JOIN tipo_Colores col ON col.id=tt.codigo_color AND col.id =tc.codigo_color 
WHERE ot.IdEmpresa=intEmpresa AND ot.IdOT=intOT AND (intItemOT IS NULL OR iot.Item=intItemOT) AND
 ot.BLBooking=strBooking
-- 
AND
	CASE
		WHEN intOpcion=0 THEN 1=1
		WHEN intOpcion=1 THEN ot.IdOT NOT IN (SELECT o.IdOT FROM ot o INNER JOIN itemot i ON o.IdEmpresa=i.IdEmpresa AND o.IdOT = i.IdOT WHERE (i.IdTransportista IS NULL OR i.IdTransportista=0) AND o.BLBooking =strBooking AND o.IdOT=intOT AND (i.Estado IS NULL OR i.Estado=0))
		WHEN intOpcion=2 THEN ot.IdOT NOT IN (SELECT o.IdOT FROM ot o INNER JOIN itemot i ON o.IdEmpresa=i.IdEmpresa AND o.IdOT = i.IdOT WHERE (i.IdTransportista>0) AND o.BLBooking =strBooking AND o.IdOT=intOT AND (i.Estado=0))
	END
ORDER BY iot.NroContenedor DESC;
 /*AND ot.email_nominacion IS NULL AND 
ot.IdOT NOT IN (SELECT o.IdOT FROM ot o INNER JOIN itemot i ON o.IdEmpresa=i.IdEmpresa AND o.IdOT = i.IdOT WHERE (i.NroContenedor IS NULL OR i.NroContenedor='') AND o.BLBooking =strBooking AND o.IdOT=intOT);*/
IF intOpcion=0 THEN
	UPDATE ot SET ot.email_nominacion=NOW() WHERE ot.IdEmpresa=intEmpresa AND ot.IdOT=intOT;
END IF;

END