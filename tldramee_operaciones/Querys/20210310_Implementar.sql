SELECT * FROM t_tractores;

ALTER TABLE t_tractores ADD black_list INT AFTER codigo_color;
UPDATE t_tractores SET black_list=0;


SELECT * FROM t_chasis;

ALTER TABLE t_chasis ADD black_list INT AFTER codigo_color;
UPDATE t_chasis SET black_list=0;

SELECT * FROM t_choferes;

ALTER TABLE t_choferes ADD black_list INT AFTER celular;
UPDATE t_choferes SET black_list=0;

CREATE PROCEDURE `SP_ValidarDNI`(
	IN `strDNI` VARCHAR(50)
)
LANGUAGE SQL
NOT DETERMINISTIC
CONTAINS SQL
SQL SECURITY DEFINER
COMMENT ''
BEGIN
	SELECT 1 FROM t_choferes WHERE nroDoc=strDNI;
END

CREATE TABLE `blackList` (
	`ID` INT(11) NOT NULL AUTO_INCREMENT,
	`Numero` VARCHAR(50) NOT NULL COLLATE 'latin1_swedish_ci',
	PRIMARY KEY (`ID`) USING BTREE,
	UNIQUE INDEX `Numero` (`Numero`) USING BTREE
)
COLLATE='latin1_swedish_ci'
ENGINE=InnoDB
;


CREATE DEFINER=`marco`@`%` PROCEDURE `SP_Black_List_Valida`(
	IN `strPatente` VARCHAR(50),
	IN `intGrabar` INT
)
LANGUAGE SQL
NOT DETERMINISTIC
CONTAINS SQL
SQL SECURITY DEFINER
COMMENT ''
BEGIN
	IF NOT EXISTS(SELECT 1 FROM blackList b  WHERE b.Numero=strPatente) AND intGrabar=1 THEN
		INSERT INTO blackList (Numero) VALUES (strPatente);
	END IF;
	SELECT b.id,b.Numero FROM blackList b  WHERE b.Numero=strPatente;
END

/*
SP_Black_List_Valida
SP_Get_Chofer_Transportista
*/