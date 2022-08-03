/*
SP_Alta_OT
SP_GET_OT_All
SP_Carga_ItemsOT
SP_OT_Item_Alta
SP_OT_Item_Es_Moro
SP_Transportistas_Insert
SP_Transportistas_Update
SP_Transportistas_Get_Id
SP_Get_Anticipos_OT
SP_Anticipos_Insert
SP_Transferencia_Para_Anticipos
*/

ALTER TABLE proveedores ADD COLUMN  opMoro INT NULL AFTER Site;

UPDATE proveedores SET opMoro=0;

/**/

ALTER TABLE ot ADD COLUMN opMoro INT NULL AFTER Cod_Referencia;
UPDATE ot SET opMoro=0;
/**/
ALTER TABLE itemot ADD COLUMN opMoro INT NULL AFTER reqAnticipo;
UPDATE itemot SET opMoro=0;
/**/
ALTER TABLE rel_OT_Item_Anticipos ADD COLUMN opMoro INT NULL AFTER opAutoriza;
UPDATE rel_OT_Item_Anticipos SET opMoro=0;

ALTER TABLE cambio_nominaciones ADD COLUMN Confirmado INT NULL AFTER IdUsuario;
UPDATE cambio_nominaciones SET Confirmado=0;
