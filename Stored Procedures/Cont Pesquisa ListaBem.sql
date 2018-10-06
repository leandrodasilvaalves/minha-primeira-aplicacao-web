-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$

CREATE DEFINER=`listabem`@`%` PROCEDURE `ContPesquisaListaBem`(buscar varchar(100))
BEGIN


	CALL QuebraString(buscar);
	SELECT DISTINCT COUNT(Usuario) AS TOTAL FROM (
		SELECT Usuario FROM Empresas WHERE 
					(AutoComplete = buscar) 
		UNION
		SELECT Usuario FROM Empresas AS E
		INNER JOIN tbl_Temp as t
				ON E.NomePrimario LIKE CONCAT('%',t.Palavra,'%')
				OR E.NomeSecundario LIKE CONCAT('%',t.Palavra,'%')
		UNION
		SELECT Usuario FROM Empresas
		WHERE 
					(NomePrimario LIKE( CONCAT(SUBSTRING(buscar,1,2),'%')))
				OR
					(NomeSecundario LIKE( CONCAT(SUBSTRING(buscar,1,2),'%')))
	) AS TB;
	
	

		DROP TABLE IF EXISTS tbl_Temp;
	
		
END