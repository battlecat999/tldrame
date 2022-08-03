SELECT DISTINCT IdOT, Item,Razon_Social FROM (
SELECT cn.IdOT,cn.Item,cn.IdTransporte,p.Razon_Social,
case when cn.nroOrden=0 THEN 'ORIGINAL' ELSE 'CAMBIO' END AS ESTADO
FROM cambio_nominaciones cn INNER JOIN proveedores p ON cn.IdTransporte=p.id AND cn.IdEmpresa=p.IdEmpresa
INNER JOIN (
SELECT COUNT(*) as cambios,cn.IdOT,cn.Item,cn.IdTransporte,cn.IdEmpresa
FROM cambio_nominaciones cn INNER JOIN proveedores p ON cn.IdTransporte=p.id AND cn.IdEmpresa=p.IdEmpresa
GROUP BY cn.IdOT,cn.Item,cn.IdTransporte,cn.IdEmpresa
HAVING COUNT(*)>1) x ON cn.IdEmpresa=x.IdEmpresa AND cn.IdOT=x.IdOT AND cn.Item=x.Item AND cn.IdTransporte<>x.IdTransporte) S
ORDER BY IdOT DESC,Item ASC


SELECT DISTINCT cn.IdOT,cn.Item,cn.IdTransporte,p.Razon_Social,FechaCambio,
case when cn.nroOrden=0 THEN 'ORIGINAL' ELSE 'CAMBIO' END AS ESTADO,cn.Confirmado
FROM cambio_nominaciones cn INNER JOIN proveedores p ON cn.IdTransporte=p.id AND cn.IdEmpresa=p.IdEmpresa
WHERE cn.Confirmado=0 AND cn.IdEmpresa=intEmpresa
ORDER BY IdOT DESC,Item ASC,FechaCambio ASC,nroOrden ASC

/*SELECT * from cambio_nominaciones cn WHERE cn.IdOT=1205 AND cn.Item=1*/

/*
"ID"	"IdEmpresa"	"IdTransporte"	"IdTractor"	"IdChasis"	"IdChofer"	"IdOT"	"Item"	"nroOrden"	"FechaCambio"	"IdUsuario"
"607"		"1"				"1"			"1"			"1"			"237"		"1205"	"1"	"0"	"2021-03-02 11:56:58"	"4"
"608"	"1"	"1"	"5"	"8"	"256"	"1205"	"1"	"1"	"2021-03-02 11:56:58"	"4"
"609"	"1"	"1"	"5"	"8"	"256"	"1205"	"1"	"0"	"2021-03-02 11:57:31"	"4"
"610"	"1"	"2"	"10"	"5"	"265"	"1205"	"1"	"1"	"2021-03-02 11:57:31"	"4"
"611"	"1"	"2"	"10"	"5"	"265"	"1205"	"1"	"0"	"2021-03-02 11:58:32"	"4"
"612"	"1"	"1"	"1"	"1"	"237"	"1205"	"1"	"1"	"2021-03-02 11:58:32"	"4"

*/

UPDATE cambio_nominaciones SET Confirmado=0;