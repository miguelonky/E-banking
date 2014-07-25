-- Creating Stored Procedures SP--

CREATE PROCEDURE sp_add_client 
(@fname varchar(45), @lname varchar(45), @cedula char(11), @email varchar(100), 
@phone char(10), @birth_date date, @role varchar(45), @information varchar(100) output) 
AS
BEGIN
	DECLARE @id int
	DECLARE @username VARCHAR(60)
	DECLARE @password VARCHAR(32)
	SET @password = 'E-banking01'
	IF EXISTS(SELECT id FROM clients WHERE cedula = @cedula) 
	BEGIN
		SET @information = 'La cedula ya se encuetra registrado';
	END
	ELSE IF exists(SELECT id FROM clients WHERE email = @email) 
	BEGIN
		SET @information = 'El email ya se encuentra registrado';
	END
	ELSE 
	BEGIN
		SET @password = CONVERT(VARCHAR(32), HASHBYTES('MD5', @password), 2)
		BEGIN TRANSACTION
			INSERT INTO clients VALUES (@fname, @lname, @cedula, LOWER(@email), @phone, @birth_date)
			SET @id = SCOPE_IDENTITY();
			
			INSERT INTO users VALUES (dbo.create_username(@id), @password, @role, @id)
		COMMIT TRANSACTION
		SET @information = 'Cliente registrado correctamente'
	END
END

CREATE PROCEDURE sp_delete_client (@id int, @information varchar(200) output)
AS
BEGIN
	
	IF EXISTS(SELECT id FROM clients WHERE id = @id)
	BEGIN
		BEGIN TRANSACTION
			BEGIN TRY
				DELETE FROM users WHERE userid = @id
				DELETE FROM clients WHERE id = @id
				COMMIT TRANSACTION
				SET @information = 'Cliente eliminado correctamente'
			END TRY
			BEGIN CATCH
				ROLLBACK
				SET @information = 'Ha ocurrido un error eliminando al cliente: ' + ERROR_MESSAGE()
			END CATCH
	END

	ELSE
	BEGIN
		SET @information = 'Cliente no encontrado'
	END
END

CREATE PROCEDURE sp_update_client (@id int, @fname varchar(45), @lname varchar(45), 
@cedula char(11), @email varchar(100), @phone char(10), @birth_date date, @username VARCHAR(60),
@password varchar(256), @role varchar(45), @information varchar(100) output)
AS
BEGIN
	
	IF EXISTS(SELECT id FROM clients WHERE id = @id)
	BEGIN
		IF ISNULL(@password, 'NULL') = 'NULL'
		BEGIN
			BEGIN TRANSACTION
				UPDATE clients SET fname = @fname, lname = @lname, cedula = @cedula, 
						email = LOWER(@email), phone = @phone, birth_date = @birth_date 
						WHERE id = @id
			
				UPDATE users SET username = @username, role = @role WHERE userid = @id
			COMMIT TRANSACTION
			SET @information = 'Cliente Actualizado Correctamente !!!'
		END 
	
		ELSE
		BEGIN
			SET @password = CONVERT(VARCHAR(32), HASHBYTES('MD5', @password), 2)
			BEGIN TRANSACTION
				UPDATE clients SET fname = @fname, lname = @lname, cedula = @cedula, 
						email = LOWER(@email), phone = @phone, birth_date = @birth_date 
						WHERE id = @id
			
				UPDATE users SET username = @username, password = @password, role = @role 
				WHERE userid = @id
			COMMIT TRANSACTION
			SET @information = 'Cliente Actualizado Correctamente !!!'
		END
	END

	ELSE 
	BEGIN
		SET @information = 'El cliente no existe'
	END
END

-- End Creating Stored Procedures --