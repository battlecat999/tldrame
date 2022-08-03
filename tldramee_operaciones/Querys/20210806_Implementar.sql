/*UPDATE de SP_Anticipos_Insert
SP_Transferencia_Para_Anticipos
SP_Condicion_de_Pago_Anticipos
SP_Get_Anticipos_OT
*/

SELECT * FROM rel_OT_Item_Anticipos

SELECT * FROM .condicion_pago



ALTER TABLE rel_OT_Item_Anticipos
ADD Fecha_Cheque DATETIME NULL,
ADD Nro_Cheque VARCHAR(15);

UPDATE condicion_pago SET activo_anticipos=1 WHERE Id<>0; /*4 CHEQUE PROPIO*/






