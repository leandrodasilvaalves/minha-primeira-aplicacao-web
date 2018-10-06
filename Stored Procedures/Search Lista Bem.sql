-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$

CREATE DEFINER=`listabem`@`%` PROCEDURE `SearchListaBem`(buscar varchar(100), IncioPg int, TamanhoPg int)
BEGIN
				CALL QuebraString(buscar);
				SELECT 
					NomePrimario, NomeSecundario, 
					RamoAtividade, Endereco, Bairro, 
					Cidade, CEP, Estado, Telefone1, 
					Telefone2, Telefone3, Telefone4, 
					Email, Site, Prioridade, Ativo, 
					Banner1, Banner2, Banner3, 
					Banner4, ChaveComercial,
					SubDivisao1, SiteSubDivisao1,
					TelefoneSubDivisao1, AtividadesSubDivisao1,
					SubDivisao2, SiteSubDivisao2,
					TelefoneSubDivisao2, AtividadesSubDivisao2,
					SubDivisao3, SiteSubDivisao3,
					TelefoneSubDivisao3, AtividadesSubDivisao3,
					SubDivisao4, SiteSubDivisao4,
					TelefoneSubDivisao4, AtividadesSubDivisao4,
					SubDivisao5, SiteSubDivisao5,
					TelefoneSubDivisao5, AtividadesSubDivisao5,
					SubDivisao6, SiteSubDivisao6,
					TelefoneSubDivisao6, AtividadesSubDivisao6

				FROM Empresas 
				WHERE 
					(AutoComplete = buscar)

				UNION				
				SELECT 
					NomePrimario, NomeSecundario, 
					RamoAtividade, Endereco, Bairro, 
					Cidade, CEP, Estado, Telefone1, 
					Telefone2, Telefone3, Telefone4, 
					Email, Site, Prioridade, Ativo, 
					Banner1, Banner2, Banner3, 
					Banner4, ChaveComercial,
					SubDivisao1, SiteSubDivisao1,
					TelefoneSubDivisao1, AtividadesSubDivisao1,
					SubDivisao2, SiteSubDivisao2,
					TelefoneSubDivisao2, AtividadesSubDivisao2,
					SubDivisao3, SiteSubDivisao3,
					TelefoneSubDivisao3, AtividadesSubDivisao3,
					SubDivisao4, SiteSubDivisao4,
					TelefoneSubDivisao4, AtividadesSubDivisao4,
					SubDivisao5, SiteSubDivisao5,
					TelefoneSubDivisao5, AtividadesSubDivisao5,
					SubDivisao6, SiteSubDivisao6,
					TelefoneSubDivisao6, AtividadesSubDivisao6
				FROM Empresas AS E
				INNER JOIN tbl_Temp as t
				ON E.NomePrimario LIKE CONCAT('%',t.Palavra,'%')
				OR E.NomeSecundario LIKE CONCAT('%',t.Palavra,'%')
				
				
				UNION		
				SELECT 
					NomePrimario, NomeSecundario, 
					RamoAtividade, Endereco, Bairro, 
					Cidade, CEP, Estado, Telefone1, 
					Telefone2, Telefone3, Telefone4, 
					Email, Site, Prioridade, Ativo, 
					Banner1, Banner2, Banner3, 
					Banner4, ChaveComercial,
					SubDivisao1, SiteSubDivisao1,
					TelefoneSubDivisao1, AtividadesSubDivisao1,
					SubDivisao2, SiteSubDivisao2,
					TelefoneSubDivisao2, AtividadesSubDivisao2,
					SubDivisao3, SiteSubDivisao3,
					TelefoneSubDivisao3, AtividadesSubDivisao3,
					SubDivisao4, SiteSubDivisao4,
					TelefoneSubDivisao4, AtividadesSubDivisao4,
					SubDivisao5, SiteSubDivisao5,
					TelefoneSubDivisao5, AtividadesSubDivisao5,
					SubDivisao6, SiteSubDivisao6,
					TelefoneSubDivisao6, AtividadesSubDivisao6
				FROM Empresas
				WHERE 
					(NomePrimario LIKE( CONCAT(SUBSTRING(buscar,1,2),'%')))
				OR
					(NomeSecundario LIKE( CONCAT(SUBSTRING(buscar,1,2),'%')))
				LIMIT IncioPg, TamanhoPg;

				
				DROP TABLE IF EXISTS tbl_Temp;

END