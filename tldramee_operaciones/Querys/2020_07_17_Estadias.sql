SELECT a.IdOT,a.Item,b.Codigo_Concepto,c.Descripcion,b.Hora AS Fecha_Salida_Planta,a.PosFecha AS Fecha_Posic,
DATEDIFF(b.hora,a.PosFecha) AS Estadia_Dias
FROM itemot a 
INNER JOIN itemot_conceptos b ON a.IdEmpresa=b.Empresa AND a.IdOT =b.OT AND a.Item=b.Item
INNER JOIN conceptos_a_nominar c ON b.Codigo_Concepto=c.Id
WHERE a.Idot=424 AND c.cod_calcula_estadia=1

/*
SELECT * FROM conceptos_a_nominar
ALTER TABLE conceptos_a_nominar ADD COLUMN cod_calcula_estadia INT
UPDATE conceptos_a_nominar SET cod_calcula_estadia=0
UPDATE conceptos_a_nominar SET cod_calcula_estadia=1 WHERE Id=4
*/