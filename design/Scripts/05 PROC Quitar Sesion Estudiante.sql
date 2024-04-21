CREATE OR ALTER PROCEDURE sp_eliminar_sesion_estudiante (@id_asignacion as int)
AS
BEGIN

	BEGIN TRY
		SET NOCOUNT ON;
		BEGIN TRAN
		
		DECLARE @id_sesion INT  
		
		SELECT @id_sesion = a.id_sesion
		FROM TBL_ASIGNACIONES a
		WHERE a.id = @id_asignacion 

		IF @id_sesion IS NULL 
		BEGIN
			SELECT 0 as result, 'La asignacion indicada no existe.' as msg
		END
		ELSE 
		BEGIN
		
			-- SE HACE EL REGISTRO EN LA TABLA DE ASIGNACIONES
			DELETE FROM TBL_ASIGNACIONES WHERE id = @id_asignacion;
			
			-- SE AUMENTA EL DISPONIBLE EN LA TABLA DE SESIONES
			UPDATE TBL_SESIONES SET ocupado = ocupado - 1 WHERE id = @id_sesion;
			
			SELECT 1 as result, 'Se ha quitado la asignación correctamente!' as msg;

		END;
		COMMIT;
		
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
		BEGIN
			ROLLBACK;
		END;
		
		SELECT 0 result, ERROR_MESSAGE() as msg
	END CATCH;

END;