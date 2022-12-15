CREATE TABLE `envioEmailExclusivos` (
	`id` INT(11) NOT NULL,
	`idRazonSocial` INT(11) NULL DEFAULT NULL,
	`SP` VARCHAR(50) NULL DEFAULT NULL COLLATE 'latin1_swedish_ci'
)
COLLATE='latin1_swedish_ci'
ENGINE=InnoDB
;
