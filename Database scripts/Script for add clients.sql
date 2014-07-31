-- Adding Clients to DATABASE --

DECLARE @value INT
DECLARE @fname varchar (45)
DECLARE @lname varchar (45)
DECLARE @email varchar (45)
DECLARE @cedula char (11)
DECLARE @phone char (10)
DECLARE @dinero1 decimal(13,2)
DECLARE @dinero2 decimal(13,2)
declare @date1 date
declare @date2 date
declare @num int
declare @n varchar (200)

SET @value = 1
BEGIN TRAN
	WHILE @value < 200
	BEGIN
		SET @fname = 'Erick' + CAST(@value as VARCHAR(3))
		SET @lname = 'Jimenez' + CAST(@value as VARCHAR(3))
		SET @cedula = '40224705' + CAST(@value as VARCHAR(3))
		SET @email = 'ramses_eldiro01@hotmail.es'  + CAST(@value as VARCHAR(3))
		set @phone = '8294100' + CAST(@value as VARCHAR(3))
		set @date1 = DATEADD(dd, @value, getdate())
		EXEC sp_add_client @fname, @lname, @cedula, @email, @phone, @date1, 'User', @n
		set @dinero1 = '500' + CAST(@value as VARCHAR(3)) + '.00'
		EXEC sp_add_account '1', 'Corriente', '15.00', @n
		EXEC sp_add_card @value, 'Credito', '50000.00', @dinero1, 1, @n
		set @date1 = DATEADD(month, @value, getdate())
		set @date2 = getdate()
		EXEC sp_add_loan @value, 'Hipotecario', '200000.00', @value, '36', @value, 
		@date2, @date1, @n
		SET @fname = 'Leonal'  + CAST(@value as VARCHAR(3))
		set @email = 'hoy@hotmail.com'  + CAST(@value as VARCHAR(3))
		select @lname = account_number from accounts where id = @value
		EXEC sp_add_beneficiary @value, @fname, @lname, @email, 'Amigo xD', @n
		SET @value = @value + 1 
	END
COMMIT TRAN

-- END adding clients to DATABASE --
