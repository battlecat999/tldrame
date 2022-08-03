SELECT c.Cotizacion,c.diasValidez,c.FechaVencimiento,
c.IdCliente,cl.Razon_Social,
ts.descripcion 'TipoServicio',
tm.descripcion 'TipoModalidad',
v.Descripcion 'Vendedor',
CONCAT (ruta.IdOrigen, ' || ', ruta.IdDestino,' || ',  ruta.IdRetorno) 'Ruta',
m.Mercaderia 'Mercaderia',
ct.descripcion 'Contenedor',
dv.descripcion 'dias_operacion',
c.ImporteEstadia 'Estadia',
c.ImporteVenta 'Taria'
FROM cotizaciones c 
INNER JOIN clientes cl ON c.IdCliente=cl.Id
INNER JOIN tipo_servicios ts ON c.TipoServicio=ts.id
INNER JOIN tipo_modalidad tm ON c.TipoModalidad=tm.id AND c.IdEmpresa=tm.IdEmpresa
INNER JOIN vendedores v ON c.IdVendedor=v.IdVendedor
INNER JOIN corredores ruta ON ruta.IdEmpresa=c.IdEmpresa AND ruta.idCorredor=c.IdCorredor 
INNER JOIN mercaderias m ON m.idMercaderia=c.idMercaderia
INNER JOIN contenedores ct ON ct.Id=c.idContenedor
INNER JOIN duracionviajes dv ON dv.id=c.IdDuracion
WHERE c.IdEmpresa=1 AND c.Fecha BETWEEN '2020-03-01' AND '2020-04-30'
ORDER BY c.Cotizacion DESC