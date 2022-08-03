INSERT INTO empresa_datos (empresa_ID,empresa_nombre,empresa_direccion,empresa_telefono,empresa_email,empresa_cuit,condicion_frente_iva,fecha_inicio_actividad,numero_iibb)
VALUES (2,'LOGISTICA MYF SA','Av. Roque Sáenz Peña 885 Piso 6 Of "P"','22883481','administracion@logisticamyf.ar','30-71726802-0','IVA Responsable Inscripto','2022-01-01','30-71726802-0');

ALTER TABLE empresa_datos ADD COLUMN Activo INT;

UPDATE empresa_datos SET Activo=0 WHERE empresa_ID=1;
UPDATE empresa_datos SET Activo=1 WHERE empresa_ID=2;


/*YA IMPLEMENTADO*/

/*
SP_GET_OT_POR_ITEM
SP_cambio_contenedores_precintos_add
*/
/*
CREATE TABLE `cambios_contenedores_precintos` (
	`ID` INT(11) NOT NULL AUTO_INCREMENT,
	`IdEmpresa` INT(11) NOT NULL,
	`IdOT` INT(11) NOT NULL,
	`Item` INT(11) NOT NULL,
	`IdUsuario` INT(11) NOT NULL,
	`sContenedor_Nuevo` VARCHAR(12) NULL DEFAULT NULL COLLATE 'utf8_general_ci',
	`sPrecinto_Nuevo` VARCHAR(12) NULL DEFAULT NULL COLLATE 'utf8_general_ci',
	`sBooking` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8_general_ci',
	`sObservacion` VARCHAR(100) NULL DEFAULT NULL COLLATE 'utf8_general_ci',
	PRIMARY KEY (`ID`) USING BTREE,
	INDEX `IdEmpresa_IdOT_ItemOT` (`IdEmpresa`, `IdOT`, `Item`) USING BTREE
)
COLLATE='utf8_general_ci'
ENGINE=InnoDB
;*/

SELECT * FROM permisos_AsocUsuarios p WHERE p.IdUsuario=10;
/*


/*Administrador*/
INSERT INTO permisos_AsocUsuarios (IdMenu, IdFormulario, IdBoton,IdUsuario,Estado,IdEmpresa)
SELECT IdMenu, IdFormulario, IdBoton,10,Estado,2 FROM permisos_AsocUsuarios p WHERE p.IdUsuario=1;
/*Carla*/
INSERT INTO permisos_AsocUsuarios (IdMenu, IdFormulario, IdBoton,IdUsuario,Estado,IdEmpresa)
SELECT IdMenu, IdFormulario, IdBoton,13,Estado,2 FROM permisos_AsocUsuarios p WHERE p.IdUsuario=4;
/*Felipe*/
INSERT INTO permisos_AsocUsuarios (IdMenu, IdFormulario, IdBoton,IdUsuario,Estado,IdEmpresa)
SELECT IdMenu, IdFormulario, IdBoton,9,Estado,2 FROM permisos_AsocUsuarios p WHERE p.IdUsuario=8;
/*Fernanda*/
INSERT INTO permisos_AsocUsuarios (IdMenu, IdFormulario, IdBoton,IdUsuario,Estado,IdEmpresa)
SELECT IdMenu, IdFormulario, IdBoton,14,Estado,2 FROM permisos_AsocUsuarios p WHERE p.IdUsuario=5;
/*Iciar*/
INSERT INTO permisos_AsocUsuarios (IdMenu, IdFormulario, IdBoton,IdUsuario,Estado,IdEmpresa)
SELECT IdMenu, IdFormulario, IdBoton,15,Estado,2 FROM permisos_AsocUsuarios p WHERE p.IdUsuario=6;
/*Maxi*/
INSERT INTO permisos_AsocUsuarios (IdMenu, IdFormulario, IdBoton,IdUsuario,Estado,IdEmpresa)
SELECT IdMenu, IdFormulario, IdBoton,12,Estado,2 FROM permisos_AsocUsuarios p WHERE p.IdUsuario=3;
/*Thiago*/
INSERT INTO permisos_AsocUsuarios (IdMenu, IdFormulario, IdBoton,IdUsuario,Estado,IdEmpresa)
SELECT IdMenu, IdFormulario, IdBoton,11,Estado,2 FROM permisos_AsocUsuarios p WHERE p.IdUsuario=2;

/*CAMBIAR KEY permisos_AsocMenuFormulario Y permisos_AsocUsuarios */
INSERT INTO permisos_AsocMenuFormulario (IdFormulario,IdMenu,NombreFormulario,IdEmpresa,DescripcionFormulario,Estado,Orden)
SELECT IdFormulario,IdMenu,NombreFormulario,2,DescripcionFormulario,Estado,Orden  FROM permisos_AsocMenuFormulario;


/*Modificar clientes, PK IdEmpresa y Id, quitar CUIT*/

INSERT INTO clientes (IdEmpresa,Id,Razon_Social,Domicilio,Localidad,Provincia,Pais, Codigo_Postal,telefonos,Email,site,Registro_Fiscal,condicion_pago,Inicio_Actividades,Condicion_IVA,Descuento,Estado)
SELECT 2,Id,Razon_Social,Domicilio,Localidad,Provincia,Pais, Codigo_Postal,telefonos,Email,site,Registro_Fiscal,condicion_pago,Inicio_Actividades,Condicion_IVA,Descuento,Estado FROM clientes;



/*Tabla Contactos*/
/*IdEmpresa y IdContacto como PK, quiar el autoincremental.
SP_Contactos_Insert

*/
INSERT INTO contactos (IdEmpresa,IdContacto,IdOrigen,RazonSocial,Pais,Provincia,Localidad,Direccion,CodPost,Tel1,Tel2,Fax,Email,Estado,EsDe,FechaInicioActividad)
SELECT 2,IdContacto,IdOrigen,RazonSocial,Pais,Provincia,Localidad,Direccion,CodPost,Tel1,Tel2,Fax,Email,Estado,EsDe,FechaInicioActividad FROM contactos;

/*EXPORTAR TABLA TIPO_MODALIDAD*/

/*corredores*/

ALTER TABLE corredores ADD COLUMN equivalente INT;

INSERT INTO corredores( idEmpresa,IdOrigen,IdDestino,IdRetorno,OneWay,RoundTrip,TTA_Transporte,TTA_Cliente,IndTipo,Costo,Fecha, Activo,IdUsuario,equivalente)
SELECT 2,IdOrigen,IdDestino,IdRetorno,OneWay,RoundTrip,TTA_Transporte,TTA_Cliente,IndTipo,Costo,Fecha, Activo,IdUsuario,idCorredor AS equivalente FROM corredores;


SELECT * FROM asoc_clientes_corredores

INSERT INTO asoc_clientes_corredores(IdEmpresa,IdCliente,IdCorredor,NroOrden,Costo,FechaAlta,Activo,IdUsuario)
SELECT 2,IdCliente,c.IdCorredor,NroOrden,acc.Costo,'2022-01-01',acc.Activo,10
FROM asoc_clientes_corredores acc INNER JOIN corredores c WHERE acc.IdCorredor=c.equivalente;


INSERT INTO detalle_corredores (IdEmpresa,es_odr,idNombre,idPais,idProvincia,idLocalidad,direccion)
SELECT 2,es_odr,idNombre,idPais,idProvincia,idLocalidad,direccion FROM detalle_corredores;

/*exportar todo estado_cotizaciones*/
/*EXPORTAR TABLA COTIZACIONES*/
/*
Tabla Proveedores, cambiar las claves
SP_Transportistas_Insert

*/
INSERT INTO proveedores(IdEmpresa,id,Razon_Social,Domicilio,Localidad,Codigo_Postal,Provincia, Telefonos, Registro_Fiscal,
Condicion_IVA, Estado, EMail, Pais, Site, opMoro,Novedad )
SELECT 2,id,Razon_Social,Domicilio,Localidad,Codigo_Postal,Provincia, Telefonos, Registro_Fiscal,
Condicion_IVA, Estado, EMail, Pais, Site, opMoro,Novedad 
FROM proveedores WHERE idEmpresa=1;


INSERT INTO conceptos_a_nominar(IdEmpresa,Id,Descripcion,Activo,Orden,Color, EsOW,liberaCamion,finaliza_OT)
SELECT 2,Id,Descripcion,Activo,Orden,Color, EsOW,liberaCamion,finaliza_OT FROM conceptos_a_nominar WHERE idEmpresa=1;


INSERT INTO mail_asoc_cliente_evento (idEmpresa, idEvento,idCliente,idContacto,Estado)
SELECT 2, idEvento,idCliente,idContacto,Estado FROM mail_asoc_cliente_evento

INSERT INTO mail_asunto_cuerpo(idEmpresa, idEvento,idAsunto,idDestino,sAsunto,sCuerpo)
SELECT 2, idEvento,idAsunto,idDestino,sAsunto,sCuerpo FROM mail_asunto_cuerpo


INSERT INTO asoc_transportistas_corredores (IdEmpresa,IdTransportista,idCorredor,NroOrden,Costo,FechaAlta,Activo,IdUsuario)
SELECT 2,atc.IdTransportista,c.idCorredor,atc.NroOrden,atc.Costo,'2022-01-01',atc.Activo,10 
FROM asoc_transportistas_corredores atc INNER JOIN corredores c ON atc.IdCorredor=c.equivalente

INSERT INTO t_trans_tractor (idEmpresa,idTransportista,idTractor,ocupado,ot,activo,fechaAlta,idUsuario)
SELECT 2,idTransportista,idTractor,ocupado,0,activo,'2022-01-01',10 FROM t_trans_tractor;

INSERT INTO t_trans_chasis (idEmpresa,idTransportista,idChasis,ocupado,ot,activo,fechaAlta,idUsuario)
SELECT 2,idTransportista,idChasis,ocupado,0,activo,'2022-01-01',10 FROM t_trans_chasis;

INSERT INTO t_trans_chofer (idEmpresa,idTransportista,IdChofer,ocupado,ot,activo,fechaAlta,idUsuario)
SELECT 2,idTransportista,idChofer,ocupado,0,activo,'2022-01-01',10 FROM t_trans_chofer;

