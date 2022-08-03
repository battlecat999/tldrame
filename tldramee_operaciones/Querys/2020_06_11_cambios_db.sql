ALTER TABLE itemot
ADD COLUMN reqAnticipo INT NULL;

ALTER TABLE ot ADD COLUMN Cod_Referencia VARCHAR (50);
UPDATE ot SET Cod_Referencia=''


SELECT estado,itemot.* FROM itemot WHERE idot=259


UPDATE itemot SET reqAnticipo =0
UPDATE itemot SET reqAnticipo =1 WHERE (estado IS NULL OR estado=0) AND TieneAnticipo IS NULL
UPDATE itemot SET reqAnticipo =0 WHERE  estado>0
/*
CREATE TABLE `rel_OT_Email_Nominacion` (
	`IdOT` INT(11) NOT NULL,
	`FechaEmail` DATETIME NULL,
	PRIMARY KEY (`IdOT`) USING BTREE
)
COLLATE='latin1_swedish_ci'
ENGINE=InnoDB
;
*/
UPDATE t_trans_tractor SET	ocupado=0;
UPDATE t_trans_chasis SET	ocupado=0;
UPDATE t_trans_chofer SET	ocupado=0;