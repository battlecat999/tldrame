select atc.IdTransportista,t.RazonSocial ,c.idCorredor , c.IdOrigen,c.IdDestino,c.IdRetorno,atc.Costo,atc.FechaAlta, IF(atc.Activo=1,'SI','NO') as Habilitado
from asoc_transportistas_corredores atc inner join transportistas t ON atc.IdTransportista=t.Id
inner join corredores c on atc.IdCorredor =c.idCorredor
where t.Estado=1 and c.Activo=1 and atc.NroOrden=0