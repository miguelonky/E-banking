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
GO

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
GO

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
GO

CREATE PROCEDURE sp_login (@username varchar(60), @password varchar(60), @exists bit output) 
AS 
BEGIN
	SET @password = CONVERT(VARCHAR(32), HASHBYTES('MD5', @password), 2)
	IF EXISTS(SELECT id FROM users WHERE username = @username AND password = @password)
	BEGIN
		SELECT @exists = id FROM users WHERE username = @username AND password = @password
	END
	ELSE
	BEGIN
		SET @exists = '0'
	END
	
END
GO

CREATE PROCEDURE sp_add_account(@id INT, @type VARCHAR(45), @balance decimal(13,2), @information VARCHAR(200) output) 
AS
BEGIN
	BEGIN TRAN
		DECLARE @account_number INT
		SELECT @account_number = id FROM last_account
		SET @account_number = @account_number + 1
		INSERT INTO accounts VALUES (@id, right(replicate('0',16) + @account_number,16), @type, @balance, @balance)
		UPDATE last_account SET id = @account_number
	COMMIT TRAN
END
GO

CREATE PROCEDURE sp_add_card (@id INT, @type VARCHAR(50), @credit_limit DECIMAL(13,2), @balance DECIMAL(13,2),
@status bit, @information VARCHAR(200) output)
AS
BEGIN
	BEGIN TRAN
		DECLARE @card_number INT
		SELECT @card_number = id FROM last_account
		SET @card_number = @card_number + 1
		INSERT INTO cards VALUES (@id, right(replicate('0', 16) + @card_number, 16), @type, @credit_limit, @balance, @balance,
								  DATEADD(mm, 1, getdate()), DATEADD(yy, 4, getdate()), @status)
		UPDATE last_account SET id = @card_number
		SET @information = 'Tarjeta registrada con exito'
	COMMIT TRAN							  
END
GO

CREATE PROCEDURE sp_add_loan (@id INT, @type VARCHAR(50), @amount DECIMAL (13,2), @quotes INT, @months INT, 
@rate DECIMAL(3,2), @begin_date DATE, @end_date DATE, @information VARCHAR(200) output)
AS
BEGIN
	BEGIN TRAN
		DECLARE @loan_number INT
		SELECT @loan_number = id FROM last_account
		SET @loan_number = @loan_number + 1
		INSERT INTO loans VALUES (@id, RIGHT(REPLICATE('0', 16) + @loan_number, 16), @type, @amount, @quotes,
								  @months, @rate, @begin_date, @end_date)
		SET @information = 'Prestamo realizado con exito'
		UPDATE last_account SET id = @loan_number
	COMMIT TRAN
END
GO

CREATE PROCEDURE sp_make_transaction (@type VARCHAR(50), @account_number VARCHAR(50), @account_number_destination VARCHAR(50), 
@amount DECIMAL(13,2), @date DATETIME, @status BIT, @information VARCHAR(200))
AS
BEGIN
	BEGIN TRAN
		DECLARE @transaction_number INT 
		SELECT @transaction_number = CAST(@transaction_number AS INT) FROM transactions
		SET @transaction_number = @transaction_number + 1 
		INSERT INTO transactions VALUES (RIGHT(REPLICATE('0', 25) + @transaction_number, 25), @type, @account_number, @account_number_destination,
										 @amount, @date, @status)
		SET @information = 'Transaccion realizada con exito'
	COMMIT TRAN
END
GO

CREATE PROCEDURE sp_add_beneficiary (@id INT, @name VARCHAR(150), @account VARCHAR(50), 
@email VARCHAR(100), @type VARCHAR(50), @information VARCHAR(200) output)
AS
BEGIN
	BEGIN TRAN
		IF EXISTS(SELECT id FROM beneficiary WHERE name = @name)
		BEGIN
			SET @information = 'Nombre de Beneficiario repetido'
		END
		ELSE IF EXISTS(SELECT id FROM beneficiary WHERE account = @account)
		BEGIN
			SET @information = 'La cuenta del beneficiario ya existe'
		END
		ELSE IF EXISTS(SELECT id FROM beneficiary WHERE email = @email)
		BEGIN
			SET @information = 'El email del beneficiario ya esta registrado'
		END
		ELSE 
		BEGIN
			INSERT INTO beneficiary VALUES (@id, @name, @account, @email, @type)
			SET @information = 'Beneficiario registrado con exito'
		END
	COMMIT TRAN
END
GO
-- End Creating Stored Procedures --

