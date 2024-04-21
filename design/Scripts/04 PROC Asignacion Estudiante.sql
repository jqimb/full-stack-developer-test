CREATE OR ALTER PROCEDURE sp_asignacion_sesion_estudiante (@id_estudiante as int, @id_sesion as int)
AS
BEGIN

	BEGIN TRY
		SET NOCOUNT ON;
		BEGIN TRAN
		
		DECLARE @cupo INT = 0, @ocupado INT = 0
		DECLARE @start DATETIME
		
		SELECT @cupo = s.cupo, @ocupado = s.ocupado, @start = s.start_datetime
		FROM TBL_SESIONES s
		WHERE s.id = @id_sesion

		-- RESTRICCIONES / VALIDACIONES
		-- UN ALUMNO Y LA SESION DEBE EXISTIR EN EL SISTEMA PREVIAMENTE
		IF NOT EXISTS(SELECT 1 FROM TBL_ESTUDIANTES WHERE id = @id_estudiante)
		BEGIN
			SELECT 0 as result, 'No existe el estudiante.' as msg
		END
		ELSE IF @ocupado IS NULL 
		BEGIN
			SELECT 0 as result, 'No existe la sesión.' as msg
		END
		ELSE IF @cupo = @ocupado 
		BEGIN
			-- UNA SESIÓN NO DEBE PERMITIR INSCRIPCIONES DESPUÉS DE LLEGAR A SU CUPO LÍMITE
			SELECT 0 as result, 'No hay cupo disponible.' as msg
		END
		-- UN ALUMNO NO PUEDE INSCRIBIRSE A 2 O MÁS SESIONES QUE SUS HORARIOS SE ENTRELAZAN
		ELSE IF (
		SELECT  COUNT(1) 
		FROM TBL_ASIGNACIONES a 
		JOIN TBL_SESIONES s ON s.id = a.id_sesion
		WHERE a.id_estudiante = @id_estudiante 
		AND s.start_datetime = @start) > 0
		BEGIN
			SELECT 0 as result, 'El horario de esta sesión se entrelaza con una sesión ya asignada.' as msg
		END
		ELSE
		BEGIN
			-- SE HACE EL REGISTRO EN LA TABLA DE ASIGNACIONES
			INSERT INTO TBL_ASIGNACIONES (id_estudiante, id_sesion) VALUES (@id_estudiante, @id_sesion);
			
			-- SE DISMINUYE EL DISPONIBLE EN LA TABLA DE SESIONES
			UPDATE TBL_SESIONES SET ocupado = ocupado + 1 WHERE id = @id_sesion;
			
			SELECT 1 as result, 'Asignación guardada correctamente!' as msg
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