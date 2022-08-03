
SELECT * FROM condicion_pago

ALTER TABLE condicion_pago ADD COLUMN activo_anticipos INT 

INSERT INTO condicion_pago (Id,Abreviatura,Descripcion) VALUES (11,'DEPOSITO','DEPOS.');
INSERT INTO condicion_pago (Id,Abreviatura,Descripcion) VALUES (12,'REMISION','REM.');
INSERT INTO condicion_pago (Id,Abreviatura,Descripcion) VALUES (13,'OTROS','OTROS.');

UPDATE condicion_pago SET activo_anticipos=1 WHERE id IN (1,9,10,11,12,13);
UPDATE condicion_pago SET activo_anticipos=0 WHERE id NOT IN (1,9,10,11,12,13);

