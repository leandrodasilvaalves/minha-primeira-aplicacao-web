-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$

CREATE DEFINER=`listabem`@`%` PROCEDURE `QuebraString`(buscar varchar(100))
BEGIN
DECLARE inicio INT DEFAULT 0;
DECLARE Len_Frase INT DEFAULT 0;
DECLARE palavra VARCHAR(25) DEFAULT NULL;


	CREATE TEMPORARY TABLE IF NOT EXISTS tbl_Temp( 
		id INT UNSIGNED NOT NULL AUTO_INCREMENT,    
		Palavra VARCHAR(25) NOT NULL,
		PRIMARY KEY (id));	

	SET Len_Frase = LENGTH(buscar)+1;	

	WHILE inicio <= Len_Frase DO
		IF ( SUBSTRING(buscar, inicio, 1)<>" ") THEN
			SET palavra = CONCAT(palavra, SUBSTRING(buscar, inicio, 1));
		END IF;	
		IF ( SUBSTRING(buscar, inicio, 1)=" ") THEN
			IF (NOT ISNULL(palavra)) THEN
				IF (NOT palavra = "") THEN
					IF (LENGTH(palavra)>=3) THEN
						INSERT INTO tbl_Temp (Palavra) VALUE (palavra);
					END IF;
				END IF;
			END IF;
			SET palavra="";
		END IF;	
		SET inicio= inicio +1;
	END WHILE;
		
				
	

END