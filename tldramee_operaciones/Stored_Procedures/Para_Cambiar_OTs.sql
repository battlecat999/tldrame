/*SELECT * FROM proveedores WHERE IdEmpresa=2 order by razon_Social*/

SET @intTran_New=137;
SET @intTran_Old=101;

/*select  * from t_tractores*/

INSERT INTO t_trans_tractor (idEmpresa,idTransportista,idTractor,ocupado,ot,activo,fechaAlta,idUsuario)
SELECT idEmpresa,@intTran_New,idTractor,ocupado,ot,activo,NOW(),idUsuario FROM .t_trans_tractor tt WHERE tt.idTransportista=@intTran_Old AND tt.idEmpresa=2;

/*SELECT * FROM .t_trans_tractor tt WHERE tt.idEmpresa=2 AND tt.idTransportista=101;*/


/*SELECT * FROM t_tractores WHERE t_tractores.Patente='OKD126';*/


INSERT INTO t_trans_chasis (idEmpresa,idTransportista,idChasis,ocupado,ot,activo,fechaAlta,idUsuario)
SELECT idEmpresa,@intTran_New,idChasis,ocupado,ot,activo,NOW(),idUsuario FROM .t_trans_chasis tt WHERE tt.idTransportista=@intTran_Old AND tt.idEmpresa=2;

/*SELECT * FROM .t_trans_chasis tt WHERE tt.idEmpresa=2 AND tt.idTransportista=101;*/

/*select  * from t_chasis where patente='gsj769'*/



/*SELECT * FROM t_choferes ORDER BY t_choferes.Apellido asc*/
INSERT INTO t_trans_chofer (idEmpresa,idTransportista,idChofer,ocupado,ot,activo,idUsuario)
SELECT idEmpresa,@intTran_New,idChofer,ocupado,ot,activo,idUsuario FROM .t_trans_chofer tt WHERE tt.idTransportista=@intTran_Old AND tt.idEmpresa=2;

/*SELECT * FROM .t_trans_chofer tt WHERE tt.idEmpresa=2 AND tt.idTransportista=101;

SELECT *
FROM proveedores

*/

UPDATE itemot i SET i.IdTransportista=@intTran_New WHERE idot=145 AND item=1 AND i.IdEmpresa=2 AND i.IdTransportista=@intTran_Old;
/*UPDATE itemot i SET i.IdTransportista=@intTran_New WHERE idot=1781 AND item=2 AND i.IdTransportista=@intTran_Old;
UPDATE itemot i SET i.IdTransportista=@intTran_New WHERE idot=1786 AND item=5 AND i.IdTransportista=@intTran_Old;
UPDATE itemot i SET i.IdTransportista=@intTran_New WHERE idot=1744 AND item=2 AND i.IdTransportista=@intTran_Old;*/
/*UPDATE itemot i SET i.IdTransportista=77 WHERE idot=1126 AND item=1 AND i.IdTransportista=74;
UPDATE itemot i SET i.IdTransportista=77 WHERE idot=1124 AND item=5 AND i.IdTransportista=74;
UPDATE itemot i SET i.IdTransportista=77 WHERE idot=1122 AND item=1 AND i.IdTransportista=74;*/


UPDATE itemot_conceptos i SET i.Transportista=@intTran_New WHERE i.ot=145 AND i.Item=1 AND i.Transportista=@intTran_Old AND i.Empresa=2;
/*UPDATE/* itemot_conceptos i SET i.Transportista=@intTran_New WHERE i.ot=1781 AND item=2 AND i.Transportista=@intTran_Old;
UPDATE itemot_conceptos i SET i.Transportista=@intTran_New WHERE i.ot=1786 AND item=5 AND i.Transportista=@intTran_Old;*/
/*UPDATE itemot_conceptos i SET i.Transportista=@intTran_New WHERE i.ot=1744 AND item=2 AND i.Transportista=@intTran_Old;*/
/*UPDATE itemot_conceptos i SET i.Transportista=77 WHERE i.ot=1126 AND item=1 AND i.Transportista=74;
UPDATE itemot_conceptos i SET i.Transportista=77 WHERE i.ot=1124 AND item=5 AND i.Transportista=74;
UPDATE itemot_conceptos i SET i.Transportista=77 WHERE i.ot=1122 AND item=1 AND i.Transportista=74;*/


UPDATE rel_OT_Item_Anticipos SET IdProveedor=@intTran_New WHERE ot=145 AND Item_OT=1 AND IdProveedor=@intTran_Old AND Empresa=2;
/*UPDATE rel_OT_Item_Anticipos SET IdProveedor=@intTran_New WHERE ot=1781 AND Item_OT=2 AND IdProveedor=@intTran_Old;
UPDATE rel_OT_Item_Anticipos SET IdProveedor=@intTran_New WHERE ot=1786 AND Item_OT=5 AND IdProveedor=@intTran_Old;
UPDATE rel_OT_Item_Anticipos SET IdProveedor=@intTran_New WHERE ot=1744 AND Item_OT=2 AND IdProveedor=@intTran_Old;*/
/*
UPDATE rel_OT_Item_Anticipos SET IdProveedor=77 WHERE ot=1126 AND Item_OT=1 AND IdProveedor=74;
UPDATE rel_OT_Item_Anticipos SET IdProveedor=77 WHERE ot=1124 AND Item_OT=5 AND IdProveedor=74;
UPDATE rel_OT_Item_Anticipos SET IdProveedor=77 WHERE ot=1122 AND Item_OT=1 AND IdProveedor=74;*/
