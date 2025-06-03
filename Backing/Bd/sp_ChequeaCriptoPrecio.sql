/* Name: sp_ChequeaCriptoPrecio.SQL
   File: sp_ChequeaCriptoPrecio
   Date: Mayo-2025
   Actualization: 29/05/2025
   Author: Elias Silva
   System: Criptos
   Note: Chequear que no exista un precio duplicado
   Test: Al final del script
*/

USE Criptos
GO

IF EXISTS (SELECT name FROM sysobjects WHERE name = 'sp_ChequeaCriptoPrecio' AND type = 'P')
   DROP PROCEDURE sp_ChequeaCriptoPrecio
GO

CREATE PROCEDURE sp_ChequeaCriptoPrecio
	-- Parametros
	@p_Cripto INT=0,
    @p_Moneda INT=0,
    @p_Precio DECIMAL=0,
    @p_PrecioFecha VARCHAR(25),
    @o_outMsg INT=0 OUT
AS
BEGIN
	IF EXISTS(SELECT P.PrcId, C.CrmId, C.CrmNombre, C.CrmSimbolo, M.MonId, M.MonSimbolo, M.MonNombre, P.PrcPrecio, P.PrcPrecioFecha
        FROM  PrecioCripto AS P INNER JOIN
            Criptomoneda AS C ON P.CrmId = C.CrmId INNER JOIN
            Moneda AS M ON P.MonId = M.MonId 
            WHERE C.CrmId=@p_Cripto AND M.MonId= @p_Moneda AND P.PrcPrecio= @p_Precio AND P.PrcPrecioFecha = CAST(@p_PrecioFecha AS date))
        BEGIN
            SELECT @o_outMsg=1
            RETURN 0
        END
    RETURN 0        
END
GO
IF object_id('dbo.sp_ChequeaCriptoPrecio') IS NOT NULL
	PRINT '<<< Create procedure dbo.sp_ChequeaCriptoPrecio >>>'
ELSE
	PRINT '<<< The creation of the procedure failed dbo.sp_ChequeaCriptoPrecio >>>'
       
/* Test
DECLARE @p_Cripto INT
DECLARE @p_Moneda INT
DECLARE @p_Precio DECIMAL
DECLARE @p_PrecioFecha DATETIME
DECLARE @o_outMsg INT

SET @p_Cripto = 1
SET @p_Moneda = 1
SET @p_Precio = 1
--SET @p_PrecioFechaHora = CAST('2025-07-27 00:20:00.000' AS datetime2)
SET @p_PrecioFecha = CAST('2025-07-27' AS date)
SET @o_outMsg = 0

EXEC sp_ChequeaCriptoPrecio @p_Cripto, @p_Moneda, @p_Precio, @p_PrecioFecha, @o_outMsg OUT
SELECT @o_outMsg
*/
