/*
INSERT INTO itemot_conceptos(Empresa,ot,Item,Transportista,Tractor,Chasis,Chofer,Codigo_Concepto)
SELECT i.IdEmpresa, i.IdOT,i.Item,i.IdTransportista,i.IdTractor,i.IdChasis,i.IdChofer ,0 Codigo_Concepto  FROM itemot i where idot =916 AND item IN (3) ORDER BY idot ASC
*/


SELECT i.*  FROM itemot i where idot =641 AND item IN (1) 

SELECT * FROM itemot_conceptos  where ot =1112 AND item=3



SELECT * FROM .t_choferes

/*




UPDATE itemot SET IdTransportista=59 WHERE IdOT=528 AND item=2 AND IdTransportista=54

UPDATE itemot_conceptos SET Transportista =59 WHERE ot =528 AND item=2 AND Transportista =54

SELECT * FROM rel_OT_Item_Anticipos WHERE ot=554 AND item_ot=1 AND IdProveedor=15

UPDATE rel_OT_Item_Anticipos SET IdProveedor=59 WHERE ot=528 AND item_ot=2 AND IdProveedor=54
*/