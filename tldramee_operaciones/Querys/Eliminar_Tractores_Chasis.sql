SELECT * FROM itemot i WHERE i.IdTractor IN (
SELECT Id FROM .t_tractores a WHERE a.Patente='djt174')


SELECT * FROM t_trans_tractor WHERE idTractor=72
/*

DELETE  FROM t_trans_tractor WHERE t_trans_tractor.idTractor IN (SELECT Id FROM t_tractores WHERE t_tractores.Patente='IGA234')
DELETE  FROM t_tractores WHERE t_tractores.Patente='IGA234'

*/

SELECT * FROM itemot i WHERE i.IdChasis IN (
SELECT Id FROM .t_chasis b WHERE b.Patente='ACY635')

SELECT * FROM .t_trans_chasis  WHERE t_trans_chasis.idChasis IN (SELECT Id FROM .t_chasis b WHERE b.Id=218)

SELECT * FROM t_trans_chasis WHERE idChasis=82

/*
DELETE  FROM t_trans_chasis WHERE t_trans_chasis.idChasis IN (SELECT Id FROM t_chasis WHERE t_chasis.Patente='OYW181')
DELETE  FROM t_chasis WHERE t_chasis.Patente='OYW181'

*/

SELECT * from t_choferes

SELECT * FROM proveedores WHERE proveedores.Id IN (5,47)
SELECT  * FROM t_trans_tractor WHERE t_trans_tractor.IdTractor IN (SELECT Id FROM .t_tractores a WHERE a.Id=169)
SELECT  * FROM t_trans_tractor WHERE t_trans_tractor.IdTransportista =0 IN (SELECT Id FROM .t_tractores a WHERE a.Id=56)

SELECT  * FROM t_trans_chofer WHERE t_trans_chofer.IdChofer =115

SELECT * FROM t_tractores WHERE id=169

SELECT * FROM itemot WHERE idchofer IN (55,121)


UPDATE t_chasis SET activo=1 WHERE activo=0;
UPDATE t_tractores SET activo=1 WHERE activo=0;
SELECT * FROM .t_chasis b WHERE b.Patente='ACY635'
